//=============================================================================
// module name  : DBoxes.cpp
//=============================================================================

#include "stdafx.h" 

//ERP
#include <Items\Dbl\TItem.h>

//Dbl
#include <Comics\Dbl\TCollections.h>

//Components


//Locals
#include "DBoxes.h"
#include "UIBoxes.hjson"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__; 
#endif

static TCHAR szP1	[]	= _T("P1");
static TCHAR szP2	[]	= _T("P2");
static TCHAR szP3	[]	= _T("P3");

//////////////////////////////////////////////////////////////////////////////
//             class DBTBoxes implementation
//////////////////////////////////////////////////////////////////////////////
//
//============================================================================
IMPLEMENT_DYNAMIC(DBTBoxes, DBTMaster)

//-----------------------------------------------------------------------------	
DBTBoxes::DBTBoxes
	(
		CRuntimeClass*		pClass, 
		CAbstractFormDoc*	pDocument
	)
	:
	DBTMaster (pClass, pDocument, _NS_DBT("DBTBoxes"))
{
}

//-----------------------------------------------------------------------------
void DBTBoxes::OnDefineQuery ()
{ 
	TBoxes* pRecord = GetBoxes();
	
	m_pTable->SelectAll();

	m_pTable->AddFilterColumn(pRecord->f_BoxNo);
	
	m_pTable->AddParam(szP1, pRecord->f_BoxNo);
}

//-----------------------------------------------------------------------------
void DBTBoxes::OnPrepareQuery ()
{
	TBoxes* pRecord = GetBoxes();
	
	m_pTable->SetParamValue(szP1, pRecord->f_BoxNo);
}

//-----------------------------------------------------------------------------	
BOOL DBTBoxes::OnCheckPrimaryKey()
{  
    return TRUE;
}

//-----------------------------------------------------------------------------	
void DBTBoxes::OnPreparePrimaryKey ()
{ 
}

//-----------------------------------------------------------------------------
void DBTBoxes::OnPrepareBrowser (SqlTable* pTable)
{
	TBoxes* pRecord = (TBoxes*)pTable->GetRecord();
	
	pTable->SelectAll();

	pTable->AddSortColumn(pRecord->f_BoxNo);
}

//-----------------------------------------------------------------------------
void DBTBoxes::OnPrepareFindQuery (SqlTable* pTable)
{
	TBoxes* pRecord = (TBoxes*)pTable->GetRecord();

	pTable->SelectAll();

	pTable->AddSortColumn(pRecord->f_BoxNo);
}

//-----------------------------------------------------------------------------
void DBTBoxes::OnEnableControlsForFind ()
{
	TBoxes* pRecord = GetBoxes();

	pRecord->f_BoxNo.	SetFindable();
	pRecord->f_LastName.SetFindable();
	pRecord->f_Name.	SetFindable();
}

//-----------------------------------------------------------------------------
void DBTBoxes::OnDisableControlsForEdit()
{
	GetDocument()->GetBoxes()->f_BoxNo.SetReadOnly();

	GetDocument()->ManageReadOnly();
	GetDocument()->ManageBodyEditReadOnly();
}

//-----------------------------------------------------------------------------
void DBTBoxes::OnDisableControlsForAddNew()
{
}

/////////////////////////////////////////////////////////////////////////////
//					class DBTBoxCollections Implementation
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
IMPLEMENT_DYNAMIC(DBTBoxCollections, DBTSlaveBuffered)

//-----------------------------------------------------------------------------	
DBTBoxCollections::DBTBoxCollections
	(
		CRuntimeClass*		pClass, 
		CAbstractFormDoc*	pDocument
	)
	:
	DBTSlaveBuffered (pClass, pDocument, _NS_DBT("DBTBoxCollections"), ALLOW_EMPTY_BODY, CHECK_DUPLICATE_KEY)
{
}

//-----------------------------------------------------------------------------
void DBTBoxCollections::OnDefineQuery ()
{
	TBoxCollections* pRecord = GetBoxCollections();
	
	m_pTable->SelectAll();

	m_pTable->AddFilterColumn(pRecord->f_BoxNo);
	
	m_pTable->AddParam(szP2, pRecord->f_BoxNo);
}

//-----------------------------------------------------------------------------
void DBTBoxCollections::OnPrepareQuery()
{
	TBoxes* pMasterRecord = GetMasterRecord();

	m_pTable->SetParamValue(szP2, pMasterRecord->f_BoxNo);
}

//-----------------------------------------------------------------------------	
DataObj* DBTBoxCollections::OnCheckPrimaryKey(int /*nRow*/, SqlRecord* pRecord)
{   
	ASSERT (pRecord && pRecord->IsKindOf(RUNTIME_CLASS(TBoxCollections)));

    return NULL;
}

//-----------------------------------------------------------------------------	
void DBTBoxCollections::OnPreparePrimaryKey (int nRow, SqlRecord* pRecord)
{ 
	ASSERT (pRecord && pRecord->IsKindOf(RUNTIME_CLASS(TBoxCollections)));

	TBoxes*				pMasterRecord = GetMasterRecord();
	TBoxCollections*	pRec		  = (TBoxCollections*) pRecord;

	pRec->f_BoxNo = pMasterRecord->f_BoxNo;
}

//-----------------------------------------------------------------------------	
CString DBTBoxCollections::GetDuplicateKeyMsg(SqlRecord* pRecord)
{
	return cwsprintf(_TB("Non sono ammessi valori duplicati!"));
}

//-----------------------------------------------------------------------------	
DataObj* DBTBoxCollections::GetDuplicateKeyPos(SqlRecord* pRecord)
{   
	ASSERT (pRecord && pRecord->IsKindOf(RUNTIME_CLASS(TBoxCollections)));

	return 	&((TBoxCollections*)pRecord)->f_Collection;
}


/////////////////////////////////////////////////////////////////////////////
//					class DBTBoxEntries Implementation
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
IMPLEMENT_DYNAMIC(DBTBoxEntries, DBTSlaveBuffered)

//-----------------------------------------------------------------------------	
DBTBoxEntries::DBTBoxEntries
	(
		CRuntimeClass*		pClass, 
		CAbstractFormDoc*	pDocument
	)
	:
	DBTSlaveBuffered (pClass, pDocument, _NS_DBT("DBTBoxEntries"), ALLOW_EMPTY_BODY, CHECK_DUPLICATE_KEY)
{
}

//-----------------------------------------------------------------------------
void DBTBoxEntries::OnDefineQuery ()
{
	TBoxEntries* pRecord = GetBoxEntries();
	
	m_pTable->SelectAll();

	m_pTable->AddFilterColumn(pRecord->f_BoxNo);
	
	m_pTable->AddParam(szP3, pRecord->f_BoxNo);
}

//-----------------------------------------------------------------------------
void DBTBoxEntries::OnPrepareQuery()
{
	TBoxes* pMasterRecord = GetMasterRecord();

	m_pTable->SetParamValue(szP3, pMasterRecord->f_BoxNo);
}

//-----------------------------------------------------------------------------	
DataObj* DBTBoxEntries::OnCheckPrimaryKey(int /*nRow*/, SqlRecord* pRecord)
{   
	ASSERT (pRecord && pRecord->IsKindOf(RUNTIME_CLASS(TBoxEntries)));

    return NULL;
}

//-----------------------------------------------------------------------------	
void DBTBoxEntries::OnPreparePrimaryKey (int nRow, SqlRecord* pRecord)
{ 
	ASSERT (pRecord && pRecord->IsKindOf(RUNTIME_CLASS(TBoxEntries)));

	TBoxes*			pMasterRecord = GetMasterRecord();
	TBoxEntries*	pRec		  = (TBoxEntries*) pRecord;

	pRec->f_BoxNo = pMasterRecord->f_BoxNo;
}

//-----------------------------------------------------------------------------	
CString DBTBoxEntries::GetDuplicateKeyMsg(SqlRecord* pRecord)
{
	return cwsprintf(_TB("Non sono ammessi valori duplicati!"));
}

//-----------------------------------------------------------------------------	
DataObj* DBTBoxEntries::GetDuplicateKeyPos(SqlRecord* pRecord)
{   
	ASSERT (pRecord && pRecord->IsKindOf(RUNTIME_CLASS(TBoxEntries)));

	return 	&((TBoxEntries*)pRecord)->f_Item;
}

//-----------------------------------------------------------------------------	
void DBTBoxEntries::OnPrepareAuxColumns(SqlRecord* pSqlRec)
{
	DBoxes* pDoc = GetDocument();
	TBoxEntries* pDetail = (TBoxEntries*) pSqlRec; 

	if (!pDoc->IsKindOf(RUNTIME_CLASS(DBoxes)))
		return;
	
}

///////////////////////////////////////////////////////////////////////////////
//							DBoxes
///////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE(DBoxes, CAbstractFormDoc)

//-----------------------------------------------------------------------------
BEGIN_MESSAGE_MAP(DBoxes, CAbstractFormDoc)
	ON_EN_VALUE_CHANGED		(IDC_BOXES_CLOSED,						OnIsClosedChanged)
	ON_EN_VALUE_CHANGED		(IDC_BOX_COLLECTIONS_CLOSED,			OnIsColsedBoxCollectionChanged)
END_MESSAGE_MAP() 

//------------------------------------------------------------------------------ 
DBoxes::DBoxes()
	:
	m_pDBTBoxes					(NULL),
	m_pDBTBoxCollections		(NULL),
	m_pDBTBoxEntries			(NULL)
{
	m_ImageBox = _T("Image.Comics.Comics.Images.Green.png");
}

//------------------------------------------------------------------------------ 
DBoxes::~DBoxes()
{
}

//-----------------------------------------------------------------------------
BOOL DBoxes::OnAttachData()
{              
	SetFormTitle (_TB("Boxes"));

	m_pDBTBoxes					= new DBTBoxes(RUNTIME_CLASS(TBoxes), this); 

	m_pDBTBoxCollections = new DBTBoxCollections(RUNTIME_CLASS(TBoxCollections), this); 
	m_pDBTBoxes->Attach(m_pDBTBoxCollections);

	m_pDBTBoxEntries = new DBTBoxEntries(RUNTIME_CLASS(TBoxEntries), this); 
	m_pDBTBoxes->Attach(m_pDBTBoxEntries);

	DECLARE_VAR_JSON(ImageBox);

	return Attach(m_pDBTBoxes);
}

//-----------------------------------------------------------------------------
BOOL DBoxes::OnInitDocument()
{
	return TRUE;
}

//-----------------------------------------------------------------------------
BOOL DBoxes::OnInitAuxData()
{   
	if (GetFormMode() == CBaseDocument::NEW)
	{
		GetBoxes()->f_CreationDate = AfxGetApplicationDate();
	}

	return TRUE;
}

//-----------------------------------------------------------------------------
BOOL DBoxes::OnPrepareAuxData()
{
	if (!IsInUnattendedMode())
		m_ImageBox = GetImageBoxName();


	return TRUE;
}

//-----------------------------------------------------------------------------
BOOL DBoxes::OnOkTransaction()
{
	BOOL bOK = TRUE;

	m_ImageBox = GetImageBoxName();

	if (GetBoxes()->f_Name.IsEmpty())
	{
		bOK = FALSE;
		m_pMessages->Add(cwsprintf(_TB("The name can not be empty!")));
		m_pMessages->Show(TRUE);
	}

	UpdateDataView();
	
	return bOK && CAbstractFormDoc::OnOkTransaction();
}

//-----------------------------------------------------------------------------
BOOL DBoxes::OnOkDelete()
{
	return CAbstractFormDoc::OnOkDelete();
}

//-----------------------------------------------------------------------------
void DBoxes::ManageReadOnly()
{
	GetBoxes()->f_CreationDate.	SetReadOnly(GetBoxes()->f_IsClosed);
	GetBoxes()->f_ClosingDate.	SetReadOnly(GetBoxes()->f_IsClosed);
	GetBoxes()->f_Discount.		SetReadOnly(GetBoxes()->f_IsClosed);
	GetBoxes()->f_LastName.		SetReadOnly(GetBoxes()->f_IsClosed);
	GetBoxes()->f_Mail.			SetReadOnly(GetBoxes()->f_IsClosed);
	//GetBoxes()->f_Name.			SetReadOnly(GetBoxes()->f_IsClosed);
	GetBoxes()->f_Telephone1.	SetReadOnly(GetBoxes()->f_IsClosed);
	GetBoxes()->f_Telephone2.	SetReadOnly(GetBoxes()->f_IsClosed);

	UpdateDataView();
}

//-----------------------------------------------------------------------------
void DBoxes::ManageBodyEditReadOnly()
{
	for (int i = 0; i <= m_pDBTBoxCollections->GetUpperBound(); i++)
	{
		GetBoxCollections(i)->f_Collection.			SetReadOnly(GetBoxCollections(i)->f_IsClosed);
		GetBoxCollections(i)->f_CreationDate.		SetReadOnly(GetBoxCollections(i)->f_IsClosed);
		GetBoxCollections(i)->f_FromNumber.			SetReadOnly(GetBoxCollections(i)->f_IsClosed);
		GetBoxCollections(i)->f_LastReceiptNumber.	SetReadOnly(GetBoxCollections(i)->f_IsClosed);
		GetBoxCollections(i)->f_LastIssuedNumber.	SetReadOnly(GetBoxCollections(i)->f_IsClosed);
		GetBoxCollections(i)->f_LastReceiptDate.	SetReadOnly(GetBoxCollections(i)->f_IsClosed);
		GetBoxCollections(i)->f_LastIssuedDate.		SetReadOnly(GetBoxCollections(i)->f_IsClosed);
		GetBoxCollections(i)->f_ClosingDate.		SetReadOnly(GetBoxCollections(i)->f_IsClosed);
	}

	UpdateDataView();
}

//-----------------------------------------------------------------------------
void DBoxes::OnIsClosedChanged()
{
	if (GetBoxes()->f_IsClosed)
		GetBoxes()->f_ClosingDate = AfxGetApplicationDate();
	else
		GetBoxes()->f_ClosingDate.Clear();

	ManageReadOnly();

	m_ImageBox = GetImageBoxName();

	UpdateDataView();
}

//-----------------------------------------------------------------------------
void DBoxes::OnIsColsedBoxCollectionChanged()
{
	DoIsColsedBoxCollectionChanged();
	UpdateDataView();
}

//-----------------------------------------------------------------------------
void DBoxes::DoIsColsedBoxCollectionChanged()
{
	if (GetCurrentBoxCollections()->f_IsClosed)
		GetCurrentBoxCollections()->f_ClosingDate = AfxGetApplicationDate();
	else
		GetCurrentBoxCollections()->f_ClosingDate.Clear();

	ManageBodyEditReadOnly();
}

//-----------------------------------------------------------------------------
DataStr DBoxes::GetImageBoxName()
{
	DataInt nEntries = m_pDBTBoxEntries->GetSize();
	TBoxes* pRec	 = (TBoxes*)m_pDBTBoxes->GetBoxes();

	if (GetBoxes()->f_IsClosed)
	{
		pRec->l_BmpStatusBox = _TB("Box Closed");
		return DataStr(_T("Image.Comics.Comics.Images.Red.png"));
	}
	else if (!GetBoxes()->f_IsClosed && nEntries == 0)
	{
		pRec->l_BmpStatusBox = _TB("Box Empty");
		return DataStr(_T("Image.Comics.Comics.Images.Green.png"));
	}
	else
	{
		pRec->l_BmpStatusBox = _TB("Comics to delivery");
		return DataStr(_T("Image.Comics.Comics.Images.Yellow.png"));
	}
}

//-----------------------------------------------------------------------------
void DBoxes::OnParsedControlCreated(CParsedCtrl* pCtrl)
{
	if (pCtrl)
	{
		UINT nIDC = pCtrl->GetCtrlID();
		if (nIDC == IDC_BOXES_BOXNO)
		{
			
		}
	}
}