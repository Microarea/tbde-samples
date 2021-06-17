
#include "stdafx.h"

//ERP
#include <Inventory\Dbl\TInventoryReasons.h>
#include <Inventory\Documents\UIInventoryEntries.hjson>
#include <Items\Dbl\TItem.h>

//Comics
#include <Comics\ComicsLen.h>
//#include <Comics\ComicsErrors.h>

//Dbl
#include <Comics\Dbl\TLoadBoxAdditionalColumns.h>
#include <Comics\Dbl\TCollectionAdditionalColumns.h>
#include <Comics\Dbl\TTmpLoadComics.h>

//Local
#include "CDLoadBoxInventoryEntries.h"
#include "UILoadBoxInventoryEntries.hjson"

#ifdef _DEBUG
#undef THIS_FILE
static char  THIS_FILE[] = __FILE__;
#endif

static TCHAR szP1	[]	= _T("P1");
static TCHAR szP2	[]	= _T("P2");

/////////////////////////////////////////////////////////////////////////////
//					class DBTBoxesSelection Implementation
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
IMPLEMENT_DYNAMIC(DBTBoxesSelection, DBTSlaveBuffered)

//-----------------------------------------------------------------------------	
DBTBoxesSelection::DBTBoxesSelection
	(
		CRuntimeClass*		pClass, 
		CAbstractFormDoc*	pDocument
	)
	:
	DBTSlaveBuffered (pClass, pDocument, _NS_DBT("DBTBoxesSelection"), ALLOW_EMPTY_BODY, FALSE)
{
}

//-----------------------------------------------------------------------------
DataObj* DBTBoxesSelection::OnCheckPrimaryKey(int /*nRow*/, SqlRecord*)
{ 
	return NULL; 
}

//-----------------------------------------------------------------------------
void DBTBoxesSelection::OnPreparePrimaryKey(int nRow, SqlRecord* pSqlRec)
{   
}

//-----------------------------------------------------------------------------
void DBTBoxesSelection::OnDefineQuery()
{
	m_pTable->SelectAll	();
}

//-----------------------------------------------------------------------------
void DBTBoxesSelection::OnPrepareQuery()
{   
}

//////////////////////////////////////////////////////////////////////////////
//             			CDLoadBoxInventoryEntries
//////////////////////////////////////////////////////////////////////////////
//
IMPLEMENT_DYNCREATE(CDLoadBoxInventoryEntries, CClientDoc)
//-----------------------------------------------------------------------------
BEGIN_MESSAGE_MAP(CDLoadBoxInventoryEntries, CClientDoc)
	//{{AFX_MSG_MAP(CDLoadBoxInventoryEntries)
	ON_EN_VALUE_CHANGED(IDC_DETAIL_ENTRY_ITEM,		OnItemChanged)
	ON_EN_VALUE_CHANGED(IDC_DETAIL_ENTRY_QUANTITY,	OnQtyChanged)
	ON_EN_VALUE_CHANGED(IDC_BOX_SELECTION_QUANTITY, OnSelectionViewQtyChanged)
	ON_COMMAND(ID_EXTDOC_ESCAPE, OnEscape)
	ON_COMMAND(IDC_LOAD_BOX_UNDO, OnCancel)
	ON_COMMAND(IDC_LOAD_BOX_OK, OnOk)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//-----------------------------------------------------------------------------
CDLoadBoxInventoryEntries::CDLoadBoxInventoryEntries()
	:
	CClientDoc					(),

	m_pTUBoxEntries				(NULL),
	m_pTUBoxCollections			(NULL),
	m_pRUTmpLoadComics			(NULL),
	m_pTUTmpLoadComics			(NULL)
{
	SetMsgRoutingMode(CD_MSG_AFTER);
}

//-----------------------------------------------------------------------------
CDLoadBoxInventoryEntries::~CDLoadBoxInventoryEntries()
{
	SAFE_DELETE(m_pTUBoxEntries);
	SAFE_DELETE(m_pTUBoxCollections);
	SAFE_DELETE(m_pTUTmpLoadComics);
	SAFE_DELETE(m_pRUTmpLoadComics);
}

//-----------------------------------------------------------------------------
BOOL CDLoadBoxInventoryEntries::OnAttachData()
{              
	m_pDBTBoxesSelection = new DBTBoxesSelection(RUNTIME_CLASS(TEnhBoxesSelection), GetServerDoc());

	m_pTUBoxEntries		= new TUBoxEntries(GetServerDoc());
	m_pTUBoxEntries->SetAutocommit();

	m_pTUBoxCollections	= new TUBoxCollections(GetServerDoc());
	m_pTUBoxCollections->SetAutocommit();

	m_pTUTmpLoadComics = new TUTmpLoadComics(GetServerDoc());
	m_pTUTmpLoadComics->SetAutocommit();

	m_pRUTmpLoadComics = new RUTmpLoadComics(GetServerDoc());
	m_pRUTmpLoadComics->SetAutocommit();

	DECLARE_VAR_JSON(Item);
	DECLARE_VAR_JSON(LoadQuantity);
	DECLARE_VAR_JSON(UoM);

	return TRUE;
}  

//-----------------------------------------------------------------------------
BOOL CDLoadBoxInventoryEntries::OnInitAuxData()
{
	DeleteTmpRecords();
	return TRUE;
}

//-----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::OnBeforeCloseDocument()
{
	DeleteTmpRecords();
}

//-----------------------------------------------------------------------------
BOOL CDLoadBoxInventoryEntries::OnBeforeDeleteRow(DBTSlaveBuffered* pDBT, int nRow)
{
	DataLng entryId = GetServerDoc()->m_pDBTHeader->GetHeader()->f_EntryId;
	DataLng currSubId = GetServerDoc()->m_pDBTDetail->GetDetail(nRow)->f_SubId;

	if (pDBT->IsKindOf(RUNTIME_CLASS(DBTInventoryEntriesDetail)) && IsItemCollectionEntered())
	{
		if (m_pRUTmpLoadComics->FindRecord(entryId, currSubId, TRUE) == TableUpdater::FOUND)
		{
			while (!m_pRUTmpLoadComics->IsEOF())
			{
				m_pRUTmpLoadComics->DeleteRecord();
				m_pRUTmpLoadComics->MoveNext();
			}
		}
	}

	return TRUE;
}

//-----------------------------------------------------------------------------
BOOL CDLoadBoxInventoryEntries::OnOkTransaction()
{
	BOOL bOK = TRUE;

	UpdateBoxes();

	if (GetServerDoc()->GetDiagnostic()->MessageFound())
	{
		bOK = FALSE;
		if(!GetServerDoc()->GetDiagnostic()->Show(TRUE))
			return FALSE;
	}

	return bOK;
}

//-----------------------------------------------------------------------------
BOOL CDLoadBoxInventoryEntries::IsInvRsnLoadBoxChecked()
{
	TLoadBoxAdditionalColumns* pLoadBoxAdditionalColumns = (TLoadBoxAdditionalColumns*)GetServerDoc()->GetInventoryReasons()->GetAddOnFields(RUNTIME_CLASS(TLoadBoxAdditionalColumns));

	return pLoadBoxAdditionalColumns->f_LoadBox;
}

//-----------------------------------------------------------------------------	
void CDLoadBoxInventoryEntries::OnOk()
{
	if (!CheckSlaveQty())
		return;

	SaveTmpRecords();

	GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_Quantity = m_LoadQuantity;
	GetServerDoc()->UpdateDataView();

	CSlaveFormView* pView = (CSlaveFormView*)GetServerDoc()->ViewAlreadyPresent(IDD_LOAD_BOX);
	if (pView)
		pView->GetParentFrame()->PostMessage(WM_CLOSE);
}

//-----------------------------------------------------------------------------	
void CDLoadBoxInventoryEntries::OnCancel()
{
	GetServerDoc()->GetDiagnostic()->Add(_TB("Attention! The information contained in this window will be deleted. Do you want to continue?"));

	if (GetServerDoc()->GetDiagnostic()->MessageFound())
	{
		if (!GetServerDoc()->GetDiagnostic()->Show(TRUE))
			return ;
	}

	CSlaveFormView* pView = (CSlaveFormView*)GetServerDoc()->ViewAlreadyPresent(IDD_LOAD_BOX);
	if (pView)
		pView->GetParentFrame()->PostMessage(WM_CLOSE);
}


//-----------------------------------------------------------------------------
BOOL CDLoadBoxInventoryEntries::IsItemCollectionEntered()
{
	BOOL bIsItemCollectionEntered = FALSE;

	TRItems							aTRItems(GetServerDoc());
	TCollectionAdditionalColumns* pCollectionAdditionalColumns;

	DataStr item = GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_Item;

	aTRItems.FindRecord(item);
	pCollectionAdditionalColumns = (TCollectionAdditionalColumns*)aTRItems.GetRecord()->GetAddOnFields(RUNTIME_CLASS(TCollectionAdditionalColumns));

	if (!pCollectionAdditionalColumns->f_Collection.IsEmpty())
	{
		bIsItemCollectionEntered = TRUE;
		m_Collection = pCollectionAdditionalColumns->f_Collection;
	}

	return bIsItemCollectionEntered;
}

//-----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::ExtrapolateComicsInfo()
{
	CString sComics;

	sComics = GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_Item;

	m_ComicsNo = sComics.Right(LEN_COMICS_NO);
}

//-----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::OpenBoxesSelectionView()
{
	if (GetServerDoc()->GetFormMode() != CAbstractFormDoc::NEW)
		return;

	if (IsInvRsnLoadBoxChecked() && IsItemCollectionEntered())
	{
		ExtrapolateComicsInfo();

		m_Item = GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_Item;
		m_LoadQuantity = GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_Quantity;
		m_UoM = GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_UoM;

		FillGridBoxes();

		CreateSlaveView(IDD_LOAD_BOX, NULL, 1);

	}
}
//-----------------------------------------------------------------------------
BOOL CDLoadBoxInventoryEntries::FillGridBoxes()
{
	DataInt quantity = 1;

	// Loop di rimpimento
	TRBoxes			aTRBoxes(GetServerDoc());
	TRTmpLoadComics aTRTmpLoadComics(GetServerDoc());

	TBoxCollections aRec;
	SqlTable  aTbl(&aRec, GetServerDoc()->GetReadOnlySqlSession());

	aTbl.Open();
	aTbl.SelectAll();
	aTbl.AddParam(szP1, aRec.f_Collection);
	aTbl.AddFilterColumn(aRec.f_Collection);
	aTbl.SetParamValue(szP1, m_Collection);

	TRY
	{
		aTbl.Query();

	// Pulizia e riempimento Body
	m_pDBTBoxesSelection->RemoveAll();
	TEnhBoxesSelection* pLineDBT = NULL;

	// Controllo se la riga corrente nell'InvEntry possiede già record corrispondenti nella nella tabella temporanea.
	// Se ci sono, i record vengono cancellati dalla temporanea (e poi successivamenti ricaricati).
	if (m_pRUTmpLoadComics->FindRecord(
														GetServerDoc()->m_pDBTHeader->GetHeader()->f_EntryId,
														GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_SubId,
														TRUE) == TableUpdater::FOUND
												   )
	{
		while (!m_pRUTmpLoadComics->IsEOF())
		{
			aTRBoxes.FindRecord(aRec.f_BoxNo);

			if (!aTRBoxes.GetRecord()->f_IsClosed)
			{
				pLineDBT = (TEnhBoxesSelection*)m_pDBTBoxesSelection->AddRecord();

				pLineDBT->l_IsSelected = TRUE;
				pLineDBT->f_BoxNo = m_pRUTmpLoadComics->GetRecord()->f_BoxNo;
				pLineDBT->f_Name = aTRBoxes.GetRecord()->f_Name;
				pLineDBT->f_LastName = aTRBoxes.GetRecord()->f_LastName;
				pLineDBT->l_CollectionNotes = aRec.f_Notes;
				pLineDBT->l_CollectionCreationDate = aRec.f_CreationDate;

				m_pRUTmpLoadComics->DeleteRecord();

				quantity++;
			}

			m_pRUTmpLoadComics->MoveNext();
		}
	}

	while (!aTbl.IsEOF())
	{
		// Carico SOLO le caselle che: 
		// 0) non sono chiuse 
		// 1) hanno la collezione prenotata, 
		// 2) collezione non chiusa
		// 3) m_ComicsNo (= Nr. Fumetto) > LastReceiptNumber (se LastReceiptNumber è vuoto il controllo avviene con FromNumber). 
		// 4) Inoltre il Fumetto NON deve ancora essere stato caricato nella tabella temporanea 
		// (ossia la "coppia" Fumetto + BoxNo non deve ancora essere presente nella tabella temporanea) 5) nè nella griglia 

		aTRBoxes.FindRecord(aRec.f_BoxNo);

		if (
				aTRBoxes.GetRecord()->f_IsClosed ||
				aRec.f_IsClosed ||
				(!aRec.f_LastReceiptNumber.IsEmpty() && m_ComicsNo <= aRec.f_LastReceiptNumber) ||
				(aRec.f_LastReceiptNumber.IsEmpty() && m_ComicsNo < aRec.f_FromNumber) ||
				aTRTmpLoadComics.FindRecord(GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_Item, aRec.f_BoxNo) == TableUpdater::FOUND ||
				BoxAlreadyEntered(aRec.f_BoxNo)
			)
		{
			aTbl.MoveNext();
			continue;
		}

		aTRBoxes.FindRecord(aRec.f_BoxNo);

		pLineDBT = (TEnhBoxesSelection*)m_pDBTBoxesSelection->AddRecord();

		if (quantity <= m_LoadQuantity)
		{
			pLineDBT->l_IsSelected = TRUE;
			quantity++;
		}

		pLineDBT->f_BoxNo = aTRBoxes.GetRecord()->f_BoxNo;
		pLineDBT->f_Name = aTRBoxes.GetRecord()->f_Name;
		pLineDBT->f_LastName = aTRBoxes.GetRecord()->f_LastName;
		pLineDBT->l_CollectionNotes = aRec.f_Notes;
		pLineDBT->l_CollectionCreationDate = aRec.f_CreationDate;

		aTbl.MoveNext();
	}
	if (aTbl.IsOpen())	aTbl.Close();
	}
		CATCH(SqlException, e)
	{
		TRACE(cwsprintf(_T("CBoxesSelectionSlaveView::FillGridBoxes SqlException.\n%s"), e->m_strError));
		if (aTbl.IsOpen())	aTbl.Close();
		return FALSE;
	}
	END_CATCH

		GetServerDoc()->UpdateDataView();
	return TRUE;
}
	

//-----------------------------------------------------------------------------
BOOL CDLoadBoxInventoryEntries::BoxAlreadyEntered(DataStr aBox)
{

	for (int i = 0; i <= m_pDBTBoxesSelection->GetUpperBound(); i++)
	{
		if (aBox == m_pDBTBoxesSelection->GetBoxesSelection(i)->f_BoxNo)
			return TRUE;
	}
	return FALSE;
}

//-----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::OnItemChanged()
{
	OpenBoxesSelectionView();
}

//-----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::OnQtyChanged()
{
	OpenBoxesSelectionView();
}

//-----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::OnSelectionViewQtyChanged()
{
	SelectComics();
}

//-----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::SaveTmpRecords()
{
	for (int i = 0; i <= m_pDBTBoxesSelection->GetUpperBound(); i++)
	{
		if (
			m_pTUTmpLoadComics->FindRecord(
				GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_EntryId,
				GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_SubId,
				m_pDBTBoxesSelection->GetBoxesSelection(i)->f_BoxNo,
				TRUE
			)
			== TableUpdater::NOT_FOUND && m_pDBTBoxesSelection->GetBoxesSelection(i)->l_IsSelected

			)
		{
			m_pTUTmpLoadComics->GetRecord()->f_BoxNo = m_pDBTBoxesSelection->GetBoxesSelection(i)->f_BoxNo;
			m_pTUTmpLoadComics->GetRecord()->f_EntryId = GetServerDoc()->m_pDBTHeader->GetHeader()->f_EntryId;
			m_pTUTmpLoadComics->GetRecord()->f_SubId = GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_SubId;
			m_pTUTmpLoadComics->GetRecord()->f_Item = GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->f_Item;
			m_pTUTmpLoadComics->GetRecord()->f_Description = GetServerDoc()->m_pDBTDetail->GetRecordCurrent()->l_ItemDescri;
			m_pTUTmpLoadComics->GetRecord()->f_Collection = m_Collection;													
			m_pTUTmpLoadComics->GetRecord()->f_InvEntryDate = GetServerDoc()->m_pDBTHeader->GetHeader()->f_PostingDate;

			m_pTUTmpLoadComics->UpdateRecord();
		}
	}
}

//-----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::CheckSelection()
{
	DataInt selectedBox = 0;

	for (int i = 0; i <= m_pDBTBoxesSelection->GetUpperBound(); i++)
	{
		if (m_pDBTBoxesSelection->GetBoxesSelection(i)->l_IsSelected)
			selectedBox++;
	}

	if (m_LoadQuantity != selectedBox)
	{
		CString msg = _TB("The quantity does not match the number of checked boxes.");
		AfxMessageBox(msg, MB_OK | MB_ICONSTOP);
		return;
	}
}

//----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::SelectComics()
{
	if (m_LoadQuantity > HowManySelectedBox())
	{
		DataDbl stillToBeSelected = m_LoadQuantity - HowManySelectedBox();

		for (int i = 0; i <= m_pDBTBoxesSelection->GetUpperBound(); i++)
		{
			if (!m_pDBTBoxesSelection->GetBoxesSelection(i)->l_IsSelected && stillToBeSelected > 0)
			{
				m_pDBTBoxesSelection->GetBoxesSelection(i)->l_IsSelected = TRUE;
				stillToBeSelected = stillToBeSelected - 1;
			}
		}
	}

	GetServerDoc()->UpdateDataView();
}

//-----------------------------------------------------------------------------
DataInt CDLoadBoxInventoryEntries::HowManySelectedBox()
{
	DataInt selectedBox = 0;

	for (int i = 0; i <= m_pDBTBoxesSelection->GetUpperBound(); i++)
	{
		if (m_pDBTBoxesSelection->GetBoxesSelection(i)->l_IsSelected)
			selectedBox++;
	}

	return selectedBox;
}

//-----------------------------------------------------------------------------
BOOL CDLoadBoxInventoryEntries::UpdateBoxes()
{
	TTmpLoadComics aRec;
	SqlTable  aTbl(&aRec, GetServerDoc()->GetReadOnlySqlSession());

	aTbl.Open();
	aTbl.SelectAll();

	CString	sComics;

	TRY
	{
		aTbl.Query();

		while (!aTbl.IsEOF())
		{
			if (m_pTUBoxEntries->FindRecord(aRec.f_BoxNo, aRec.f_Item, TRUE) == TableUpdater::NOT_FOUND)
			{
				m_pTUBoxEntries->GetRecord()->f_BoxNo = aRec.f_BoxNo;
				m_pTUBoxEntries->GetRecord()->f_Item = aRec.f_Item;
				m_pTUBoxEntries->GetRecord()->l_ItemDescri = aRec.f_Description;
				m_pTUBoxEntries->GetRecord()->f_ReceiptDate = aRec.f_InvEntryDate;
			}
			m_pTUBoxEntries->UpdateRecord();

			if (m_pTUBoxCollections->FindRecord(aRec.f_BoxNo, aRec.f_Collection, TRUE) == TableUpdater::FOUND)
			{
				sComics = aRec.f_Item;

				m_pTUBoxCollections->GetRecord()->f_LastReceiptNumber = sComics.Right(LEN_COMICS_NO);
				m_pTUBoxCollections->GetRecord()->f_LastReceiptDate = aRec.f_InvEntryDate;
			}
			m_pTUBoxCollections->UpdateRecord();

			aTbl.MoveNext();
		}

		if (aTbl.IsOpen())
			aTbl.Close();
	}
		CATCH(SqlException, e)
	{
		TRACE(cwsprintf(_T("CDLoadBoxInventoryEntries::UpdateBoxes SqlException.\n%s"), e->m_strError));
		if (aTbl.IsOpen())	aTbl.Close();
		return FALSE;
	}
	END_CATCH

		GetServerDoc()->UpdateDataView();
	return TRUE;
}

//-----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::DeleteTmpRecords()
{
	SqlTable aTbl(&m_TTmpLoadComics, GetServerDoc()->GetUpdatableSqlSession());

	TRY
	{
		aTbl.Open(TRUE);
		aTbl.SelectAll();
		aTbl.NativeDelete();
		aTbl.Close();
	}
		CATCH(SqlException, e)
	{
		TraceError(cwsprintf(_T("CDLoadBoxInventoryEntries::DeleteTmpTable failed : %s\n"), (LPCTSTR)aTbl.m_strSQL));
		aTbl.Close();
	}
	END_CATCH
}

//-----------------------------------------------------------------------------
BOOL CDLoadBoxInventoryEntries::CheckSlaveQty()
{
	DataInt selected = 0;

	BOOL bOK = TRUE;

	for (int i = 0; i <= m_pDBTBoxesSelection->GetUpperBound(); i++)
	{
		if (m_pDBTBoxesSelection->GetBoxesSelection(i)->l_IsSelected)
			selected++;
	}

	if (m_LoadQuantity < selected)
	{
		GetServerDoc()->GetDiagnostic()->Add(_TB("Attention! The number of comics to move is less than the available boxes."));
		bOK = FALSE;
	}

	if (GetServerDoc()->GetDiagnostic()->MessageFound())
	{
		if (!GetServerDoc()->GetDiagnostic()->Show(TRUE))
			return FALSE;
	}
	return bOK;
}

//-----------------------------------------------------------------------------
void CDLoadBoxInventoryEntries::OnEscape()
{
	DeleteTmpRecords();
}






