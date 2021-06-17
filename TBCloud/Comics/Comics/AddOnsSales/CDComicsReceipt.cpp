
#include "stdafx.h"

//ERP
#include <Items\Dbl\TItem.h>
#include <Sales\Documents\UISaleDoc.hjson>
//Comics
#include <Comics\ComicsLen.h>

//Dbl
#include <Comics\Dbl\TBoxes.h>
#include <Comics\Dbl\TTmpUnloadComics.h>
#include <Comics\Dbl\TCollectionAdditionalColumns.h>

//Local
#include "CDComicsReceipt.h"
#include "UIComicsReceipt.hjson"

#ifdef _DEBUG
#undef THIS_FILE
static char  THIS_FILE[] = __FILE__;
#endif

static TCHAR szP1	[]	= _T("P1");
static TCHAR szP2	[]	= _T("P2");

/////////////////////////////////////////////////////////////////////////////
//					class DBTComicsToBeDelivered Implementation
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
IMPLEMENT_DYNAMIC(DBTComicsToBeDelivered, DBTSlaveBuffered)

//-----------------------------------------------------------------------------	
DBTComicsToBeDelivered::DBTComicsToBeDelivered
	(
		CRuntimeClass*		pClass, 
		CAbstractFormDoc*	pDocument
	)
	:
	DBTSlaveBuffered (pClass, pDocument, _NS_DBT("DBTComicsToBeDelivered"), ALLOW_EMPTY_BODY, FALSE)
{
}

//-----------------------------------------------------------------------------
DataObj* DBTComicsToBeDelivered::OnCheckPrimaryKey(int /*nRow*/, SqlRecord*)
{ 
	return NULL; 
}

//-----------------------------------------------------------------------------
void DBTComicsToBeDelivered::OnPreparePrimaryKey(int nRow, SqlRecord* pSqlRec)
{   
}

//-----------------------------------------------------------------------------
void DBTComicsToBeDelivered::OnDefineQuery()
{
	m_pTable->SelectAll	();
}

//-----------------------------------------------------------------------------
void DBTComicsToBeDelivered::OnPrepareQuery()
{   
}

//////////////////////////////////////////////////////////////////////////////
//             			CDComicsReceipt
//////////////////////////////////////////////////////////////////////////////
//
IMPLEMENT_DYNCREATE(CDComicsReceipt, CClientDoc)
	
//-----------------------------------------------------------------------------
CDComicsReceipt::CDComicsReceipt()
	:
	CClientDoc					(),
	m_pDBTVirtualComicsToBeDelivered	(NULL),
	m_pTRItems							(NULL),
	m_pTRBoxes							(NULL),
	m_pTRBoxesLastName					(NULL),
	m_pTRTmpUnloadComics				(NULL),
	m_pRUTmpUnloadComics				(NULL),
	m_pTUTmpUnloadComics				(NULL),
	m_pTUBoxEntries						(NULL),
	m_pTUBoxCollections					(NULL),
	m_pRRBoxesLastName					(NULL),
	m_pRRBoxEntries						(NULL),
	m_pTRTmpUnloadComicsByDocIdSubId	(NULL)
	
{
	SetMsgRoutingMode(CD_MSG_AFTER);
}

//-----------------------------------------------------------------------------
CDComicsReceipt::~CDComicsReceipt()
{
	SAFE_DELETE(m_pDBTVirtualComicsToBeDelivered);
	SAFE_DELETE(m_pRUTmpUnloadComics);
	SAFE_DELETE(m_pTUTmpUnloadComics);
	SAFE_DELETE (m_pTRItems);
	SAFE_DELETE(m_pTRBoxes);
	SAFE_DELETE(m_pTRBoxesLastName);
	SAFE_DELETE(m_pRRBoxesLastName);
	SAFE_DELETE(m_pTRTmpUnloadComics);
	SAFE_DELETE(m_pTUBoxEntries);
	SAFE_DELETE(m_pTUBoxCollections);
	SAFE_DELETE(m_pRRBoxEntries);
	SAFE_DELETE(m_pTRTmpUnloadComicsByDocIdSubId);
}

//-----------------------------------------------------------------------------
BEGIN_MESSAGE_MAP(CDComicsReceipt, CClientDoc)
	//{{AFX_MSG_MAP(CDComicsReceipt)
	ON_UPDATE_COMMAND_UI	(ID_RECLASS_BTN_RESEARCH_COMICS_TO_BE_DELIVERED,	OnEnableResearchComics)
	ON_BN_CLICKED			(ID_RECLASS_BTN_RESEARCH_COMICS_TO_BE_DELIVERED,	OnOpenFilterSlaveView)
	ON_BN_CLICKED			(IDC_BOXSELECTION_OK,								OnResearchComics)
	ON_BN_CLICKED			(IDC_BOXSELECTION_UNDO,								OnUndoResearchComics)
	ON_BN_CLICKED			(IDC_RECEIPT_COLL_OK,								OnLoadComics)
	ON_BN_CLICKED			(IDC_RECEIPT_COLL_UNDO,								OnUndoLoadComics)
		
	ON_EN_VALUE_CHANGED		(IDC_DOC_LINE_QTY,								OnQtyBEChanged)
	ON_EN_VALUE_CHANGED		(IDC_DOC_LINE_QTY,								OnQtyRWChanged)
	ON_COMMAND				(ID_EXTDOC_ESCAPE,									OnEscape)


	//ON_COMMAND(IDC_RECEIPT_FILTER_END, OnEnd)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//-----------------------------------------------------------------------------
BOOL CDComicsReceipt::OnAttachData()
{ 
	m_pDBTVirtualComicsToBeDelivered = new DBTComicsToBeDelivered (RUNTIME_CLASS(TEnhBoxesSelection), GetDocument()); 

	m_pRUTmpUnloadComics = new RUTmpUnloadComics(GetDocument());
	m_pRUTmpUnloadComics->SetAutocommit();

	m_pTUTmpUnloadComics = new TUTmpUnloadComics(GetDocument());
	m_pTUTmpUnloadComics->SetAutocommit();

	m_pTUBoxEntries = new TUBoxEntries(GetDocument());

	m_pTUBoxCollections = new TUBoxCollections(GetDocument());

	m_pTRItems = new TRItems(GetDocument());

	m_pTRBoxes = new TRBoxes(GetDocument());

	m_pTRBoxesLastName = new TRBoxesLastName(GetDocument());

	m_pRRBoxesLastName = new RRBoxesLastName(GetDocument());

	m_pTRTmpUnloadComics = new TRTmpUnloadComics(GetDocument());

	m_pRRBoxEntries = new RRBoxEntries(GetDocument());

	m_pTRTmpUnloadComicsByDocIdSubId = new TRTmpUnloadComicsByDocIdSubId(GetDocument());
	
	DECLARE_VAR_JSON(nFilterBoxNo);

	return TRUE;
}   

//-----------------------------------------------------------------------------
BOOL CDComicsReceipt::OnInitAuxData()
{
	DeleteTmpRecords();
	return TRUE;
}

//-----------------------------------------------------------------------------
BOOL CDComicsReceipt::OnOkTransaction()
{
	return TRUE;
}

//-----------------------------------------------------------------------------
BOOL CDComicsReceipt::OnExtraNewTransaction()
{
	BOOL bOK = TRUE;

	if (!m_pServerDocument->m_pTbContext->StartTransaction())
	{
		m_pServerDocument->Message(_TB("Impossible to start transaction."));
		return FALSE;
	}
	
	bOK = UpdateBoxes();

	if (!bOK)
		m_pServerDocument->m_pTbContext->Rollback();
	else
	{
		m_pServerDocument->m_pTbContext->Commit();
		DeleteTmpRecords();
	}
	
	if (GetDocument()->GetDiagnostic()->MessageFound())
	{
		if(!GetDocument()->GetDiagnostic()->Show(TRUE))
			return FALSE;
	}

	GetDocument()->UpdateDataView();

	return TRUE;
}

//-----------------------------------------------------------------------------
void CDComicsReceipt::Customize()
{
}

//-----------------------------------------------------------------------------
DataStr CDComicsReceipt::ExtrapolateCollection(DataStr aItem)
{
	TRItems							aTRItems(GetServerDoc());
	TCollectionAdditionalColumns*	pCollectionAdditionalColumns;

	aTRItems.FindRecord(aItem);
	pCollectionAdditionalColumns = (TCollectionAdditionalColumns*)  aTRItems.GetRecord()->GetAddOnFields(RUNTIME_CLASS(TCollectionAdditionalColumns));

	DataStr sCollection;
	sCollection	 = pCollectionAdditionalColumns->f_Collection;
	
	return sCollection;
}

//-----------------------------------------------------------------------------
void CDComicsReceipt::OpenBoxesFilterView()
{   
	//GetDocument()->CreateSlaveView (RUNTIME_CLASS(CFilterComicsToBeDeliveredSlaveView), _TB("Richiesta Filtri per Ricercatore Casella"));
	CreateSlaveView(IDD_BOXSELECTION, NULL, 1);
}

//-----------------------------------------------------------------------------
void CDComicsReceipt::OpenComicsToBeDeliveredView()
{   
	//GetDocument()->CreateSlaveView (RUNTIME_CLASS(CComicsToBeDeliveredSlaveView), _TB("Ricercatore Fumetti da Consegnare"));
	//CreateSlaveView(IDD_BOX_SELECTION_RECEIPT, NULL, 1);
	
}

//-----------------------------------------------------------------------------
void CDComicsReceipt::OnOpenFilterSlaveView()
{
	OpenBoxesFilterView();
}

//-----------------------------------------------------------------------------------
void CDComicsReceipt::OnEnableResearchComics(CCmdUI* pCmdUI)
{
	BOOL bEnabled = FALSE;

	bEnabled =	GetServerDoc()->GetFormMode() == CAbstractFormDoc::NEW;	/*&& 
				!GetServerDoc()->m_pCopyDoc;*/

	pCmdUI->Enable(bEnabled);
}

//-----------------------------------------------------------------------------
void CDComicsReceipt::OnResearchComics()
{
	CSlaveFormView* pView = (CSlaveFormView*)GetServerDoc()->ViewAlreadyPresent(IDD_BOXSELECTION);
	if (pView)
		pView->GetParentFrame()->PostMessage(WM_CLOSE);

	CreateSlaveView(IDD_RECEIPT_COLL, NULL, 1);

}

//-----------------------------------------------------------------------------	
void CDComicsReceipt::OnUndoResearchComics()
{
	CSlaveFormView* pView = (CSlaveFormView*)GetServerDoc()->ViewAlreadyPresent(IDD_BOXSELECTION);
	if (pView)
		pView->GetParentFrame()->PostMessage(WM_CLOSE);
}

//-----------------------------------------------------------------------------	
void CDComicsReceipt::OnLoadComics()
{
	SaveTmpRecordsAndLoadReceiptLines();
	m_nFilterBoxNo.Clear();

	CSlaveFormView* pView = (CSlaveFormView*)GetServerDoc()->ViewAlreadyPresent(IDD_RECEIPT_COLL);
	if (pView)
		pView->GetParentFrame()->PostMessage(WM_CLOSE);

	GetServerDoc()->UpdateDataView();
}

//-----------------------------------------------------------------------------	
void CDComicsReceipt::OnUndoLoadComics()
{
	CSlaveFormView* pView = (CSlaveFormView*)GetServerDoc()->ViewAlreadyPresent(IDD_RECEIPT_COLL);
	if (pView)
		pView->GetParentFrame()->PostMessage(WM_CLOSE);
}

//-----------------------------------------------------------------------------
void CDComicsReceipt::SaveTmpRecordsAndLoadReceiptLines()
{
	TSaleDocDetail* pLineDBT;

	for (int i = 0; i <= m_pDBTVirtualComicsToBeDelivered->GetUpperBound(); i++)
	{
		if (m_pTUTmpUnloadComics->FindRecord	(
													GetServerDoc()->m_pDBTHeader->GetHeader()->f_Document_Id,
													m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->f_BoxNo,
													m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->l_Item,
													TRUE
												)
												== TableUpdater::NOT_FOUND && m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->l_IsSelected
			
		   )
		{
			m_pTUTmpUnloadComics->GetRecord()->f_Document_Id	= GetServerDoc()->m_pDBTHeader->GetHeader()->f_Document_Id;
			m_pTUTmpUnloadComics->GetRecord()->f_BoxNo			= m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->f_BoxNo;
			m_pTUTmpUnloadComics->GetRecord()->f_LastName		= m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->f_LastName;
			m_pTUTmpUnloadComics->GetRecord()->f_Name			= m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->f_Name;
			m_pTUTmpUnloadComics->GetRecord()->f_Item			= m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->l_Item;
			m_pTUTmpUnloadComics->GetRecord()->f_Collection		= m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->l_Collection;
			m_pTUTmpUnloadComics->GetRecord()->f_ReceiptDate	= m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->l_LoadingDate;

			pLineDBT = (TSaleDocDetail*)GetServerDoc()->m_pDBTDetail->AddRecord();

			pLineDBT->f_Item		= m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->l_Item;
			pLineDBT->f_Quantity	= 1;

			m_pTRItems->FindRecord(pLineDBT->f_Item);
			GetDocument()->DoItemChanged(pLineDBT,  NULL, TRUE);

			if	(
					m_pTRBoxes->FindRecord(m_pDBTVirtualComicsToBeDelivered->GetComicsToBeDelivered(i)->f_BoxNo) == TableUpdater::FOUND && 
					m_pTRBoxes->GetRecord()->f_Discount != 0
				)
				pLineDBT->f_DiscountFormula = (m_pTRBoxes->GetRecord()->f_Discount).Str();
			
			// Avendo fatto AddRecord TB ha aggiunto il riferimento alla Line e al SubId della riga del Dettaglio della Ricevuta Fiscal.
			// Inserisco quindi tali indormazioni nella tabella temporanea per avere i riferimenti completi.
			m_pTUTmpUnloadComics->GetRecord()->f_Line	= pLineDBT->f_Line;
			m_pTUTmpUnloadComics->GetRecord()->f_SubId	= pLineDBT->f_SubId;

			m_pTUTmpUnloadComics->UpdateRecord();

			GetDocument()->CalculateLine(pLineDBT, TRUE, TRUE);
			GetDocument()->UpdateCalculations();
			GetDocument()->UpdateDataView();
		}
	}
}

//-----------------------------------------------------------------------------
void CDComicsReceipt::OnEscape()
{ 
	DeleteTmpRecords();
}

//-----------------------------------------------------------------------------
void CDComicsReceipt::OnBeforeCloseDocument()
{
	DeleteTmpRecords();
}

//-----------------------------------------------------------------------------
BOOL CDComicsReceipt::DeleteTmpRecords()
{
	BOOL bOK = TRUE;

	SqlTable aTbl(&m_TTmpUnloadComics, GetServerDoc()->GetUpdatableSqlSession());
   
	TRY
	{  
		aTbl.Open(TRUE);
		aTbl.SelectAll();
		bOK = aTbl.NativeDelete();
		aTbl.Close();
	}
	CATCH(SqlException, e)
	{           
		TraceError(cwsprintf(_T("CDComicsReceipt::DeleteTmpTable failed : %s\n"), (LPCTSTR)aTbl.m_strSQL));
		aTbl.Close();
		return FALSE;
	}
	END_CATCH

	return bOK;
}

//-----------------------------------------------------------------------------
BOOL CDComicsReceipt::OnBeforeDeleteRow(DBTSlaveBuffered* pDBT, int nRow)
{
	DataLng documet_Id	= GetServerDoc()->m_pDBTHeader->GetHeader()->f_Document_Id;
	DataLng currSubId	= GetServerDoc()->m_pDBTDetail->GetDetail(nRow)->f_SubId;

	if (pDBT->IsKindOf(RUNTIME_CLASS(DBTSaleDocDetail)) && IsItemCollectionEntered())
	{
		if (m_pRUTmpUnloadComics->FindRecord(documet_Id, currSubId, TRUE) == TableUpdater::FOUND)
		{
			while(!m_pRUTmpUnloadComics->IsEOF())
			{
				m_pRUTmpUnloadComics->DeleteRecord();

				m_pRUTmpUnloadComics->MoveNext();
			}
		}
	}
	return TRUE;
}

//-----------------------------------------------------------------------------
BOOL CDComicsReceipt::IsItemCollectionEntered()
{
	BOOL bIsItemCollectionEntered = FALSE;
	DataStr sCollection;

	TRItems							aTRItems(GetServerDoc());
	TCollectionAdditionalColumns*	pCollectionAdditionalColumns;

	DataStr item = GetServerDoc()->m_pDBTDetail->GetCurrent()->f_Item;

	aTRItems.FindRecord(item);
	pCollectionAdditionalColumns = (TCollectionAdditionalColumns*)  aTRItems.GetRecord()->GetAddOnFields(RUNTIME_CLASS(TCollectionAdditionalColumns));

	if (!pCollectionAdditionalColumns->f_Collection.IsEmpty())
	{
		bIsItemCollectionEntered = TRUE;
		sCollection			 = pCollectionAdditionalColumns->f_Collection;
	}
	
	return bIsItemCollectionEntered;
}

//-----------------------------------------------------------------------------
BOOL CDComicsReceipt::UpdateBoxes()
{	
	BOOL bOK = TRUE;

	TTmpUnloadComics aRec;
	SqlTable  aTbl(&aRec, GetDocument()->GetReadOnlySqlSession());

	aTbl.Open			();
	aTbl.SelectAll		();

	CString	sComics;

	TRY
	{
		aTbl.Query();
		
		while (!aTbl.IsEOF())
		{
			if (m_pTUBoxEntries->FindRecord(aRec.f_BoxNo, aRec.f_Item, TRUE) == TableUpdater::FOUND)
				bOK = m_pTUBoxEntries->DeleteRecord();
				
			bOK &= m_pTUBoxEntries->UpdateRecord();
			
			if (m_pTUBoxCollections->FindRecord(aRec.f_BoxNo, aRec.f_Collection, TRUE) == TableUpdater::FOUND)
			{
				if (
						m_pTUBoxCollections->GetRecord()->f_LastIssuedNumber.IsEmpty()							|| 
						m_pTUBoxCollections->GetRecord()->f_LastIssuedNumber < ExtrapolateComicsNo(aRec.f_Item)
					)
				{
					m_pTUBoxCollections->GetRecord()->f_LastIssuedNumber = ExtrapolateComicsNo(aRec.f_Item);
					m_pTUBoxCollections->GetRecord()->f_LastIssuedDate	 = aRec.f_ReceiptDate;
				}
			}
			bOK  &= m_pTUBoxCollections->UpdateRecord();

			if (!bOK)
			{
				aTbl.Close();
				return FALSE;
			}
			aTbl.MoveNext();
		}

		if (aTbl.IsOpen())	
			aTbl.Close();
	}
	CATCH(SqlException, e)	
	{
		TRACE(cwsprintf(_T("CDComicsReceipt::UpdateBoxes SqlException.\n%s"),e->m_strError));
		if (aTbl.IsOpen())	aTbl.Close();
		return FALSE;
	}
	END_CATCH

	return bOK;	    	
}

//-----------------------------------------------------------------------------
DataStr CDComicsReceipt::ExtrapolateComicsNo(DataStr aItem)
{
	CString sItem = aItem;
	DataStr sComicsNo;

	sComicsNo = sItem.Right(LEN_COMICS_NO);

	return sComicsNo;
}

//-----------------------------------------------------------------------------
void CDComicsReceipt::OnQtyBEChanged()
{
	// solo in stato di NEW ?
	if (IsItemCollectionEntered() && GetServerDoc()->GetFormMode() == CAbstractFormDoc::NEW)
		ChangeQty();
}

//-----------------------------------------------------------------------------
void CDComicsReceipt::OnQtyRWChanged()
{
	// solo in stato di NEW ?  
	if (IsItemCollectionEntered() && GetServerDoc()->GetFormMode() == CAbstractFormDoc::NEW)
		ChangeQty();
}

//-----------------------------------------------------------------------------
BOOL CDComicsReceipt::ChangeQty()
{
	if (
			m_pTRTmpUnloadComicsByDocIdSubId->FindRecord(
															GetServerDoc()->m_pDBTDetail->GetCurrent()->f_Document_Id,
															GetServerDoc()->m_pDBTDetail->GetCurrent()->f_SubId
														) == TableReader::FOUND 
		)
	{
		GetDocument()->GetDiagnostic()->Add(_TB("Warning! It is not recommended to make this change as it could compromise the mailboxes archive."));

		if (GetDocument()->GetDiagnostic()->MessageFound())
		{
			if(!GetDocument()->GetDiagnostic()->Show(TRUE))
				return FALSE;
		}
	}

	return TRUE;
}

//-----------------------------------------------------------------------------
BOOL CDComicsReceipt::CheckFilterBoxNo()
{
	BOOL bOK = TRUE;

	if (m_pTRBoxes->FindRecord(m_nFilterBoxNo) == TableReader::NOT_FOUND || m_pTRBoxes->FindRecord(m_nFilterBoxNo) == TableReader::NONE)
	{
		GetDocument()->GetDiagnostic()->Add(_TB("Warning! It is not recommended to make this change as it could compromise the mailboxes archive."));
		bOK = FALSE;
	}

	if (GetDocument()->GetDiagnostic()->MessageFound())
	{
		if(!GetDocument()->GetDiagnostic()->Show(TRUE))
			return FALSE;
	}
	return bOK;
}
