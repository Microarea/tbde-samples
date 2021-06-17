//=============================================================================
// module name  : DCollections.cpp
//=============================================================================

#include "stdafx.h" 
//Dbl
//#include <comics\Dbl\TBoxes.h>

//Locals
#include "DCollections.h"
#include "UICollections.hjson"



#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__; 
#endif

static TCHAR szP1	[]	= _T("P1");
static TCHAR szP2	[]	= _T("P2");
static TCHAR szP3	[]	= _T("P3");

//////////////////////////////////////////////////////////////////////////////
//             class DBTCollections implementation
//////////////////////////////////////////////////////////////////////////////
//
//============================================================================
IMPLEMENT_DYNAMIC(DBTCollections, DBTMaster)

//-----------------------------------------------------------------------------	
DBTCollections::DBTCollections
	(
		CRuntimeClass*		pClass, 
		CAbstractFormDoc*	pDocument
	)
	:
	DBTMaster (pClass, pDocument, _NS_DBT("DBTCollections"))
{
}

//-----------------------------------------------------------------------------
void DBTCollections::OnDefineQuery ()
{ 
	TCollections* pRecord = GetCollections();
	
	m_pTable->SelectAll();

	m_pTable->AddFilterColumn(pRecord->f_Collection);
	
	m_pTable->AddParam(szP1, pRecord->f_Collection);
}

//-----------------------------------------------------------------------------
void DBTCollections::OnPrepareQuery ()
{
	TCollections* pRecord = GetCollections();
	
	m_pTable->SetParamValue(szP1, pRecord->f_Collection);
}

//-----------------------------------------------------------------------------	
BOOL DBTCollections::OnCheckPrimaryKey()
{   
	TCollections* pRecord = GetCollections();

	if (pRecord->f_Collection.IsEmpty())
	{
		SetError(_TB("It is not possible to save with Empty Collection!"));
		return FALSE;
	}

    return TRUE;
}

//-----------------------------------------------------------------------------	
void DBTCollections::OnPreparePrimaryKey ()
{ 
}

//-----------------------------------------------------------------------------
void DBTCollections::OnPrepareBrowser (SqlTable* pTable)
{
	TCollections* pRecord = (TCollections*)pTable->GetRecord();
	
	pTable->SelectAll();

	pTable->AddSortColumn(pRecord->f_Collection);
}

//-----------------------------------------------------------------------------
void DBTCollections::OnPrepareFindQuery (SqlTable* pTable)
{
	TCollections* pRecord = (TCollections*)pTable->GetRecord();

	pTable->SelectAll();

	pTable->AddSortColumn(pRecord->f_Collection);
}

//-----------------------------------------------------------------------------
void DBTCollections::OnEnableControlsForFind ()
{
	TCollections* pRecord = GetCollections();

	pRecord->f_Collection.	SetFindable();
	pRecord->f_Description.	SetFindable();
}

//-----------------------------------------------------------------------------
void DBTCollections::OnDisableControlsForEdit()
{
	GetDocument()->GetCollections()->f_Collection.SetReadOnly();
}

///////////////////////////////////////////////////////////////////////////////
//							DCollections
///////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE(DCollections, CAbstractFormDoc)

//-----------------------------------------------------------------------------
BEGIN_MESSAGE_MAP(DCollections, CAbstractFormDoc)
	//ON_EN_VALUE_CHANGED	(IDC_COLLECTIONS_DISABLED,	OnDisabledChanged)
END_MESSAGE_MAP() 

//------------------------------------------------------------------------------ 
DCollections::DCollections()
	:
	m_pDBTCollections(NULL)
{
}

//------------------------------------------------------------------------------ 
DCollections::~DCollections()
{
}

//-----------------------------------------------------------------------------
BOOL DCollections::OnAttachData()
{              
	SetFormTitle (_TB("Collezioni"));

	m_pDBTCollections = new DBTCollections(RUNTIME_CLASS(TCollections), this); 

	return Attach(m_pDBTCollections);
}

//-----------------------------------------------------------------------------
BOOL DCollections::OnInitAuxData()
{   
	return TRUE;
}

//-----------------------------------------------------------------------------
BOOL DCollections::OnPrepareAuxData()
{
	return TRUE;
}

//-----------------------------------------------------------------------------
BOOL DCollections::OnOkTransaction()
{
	return CAbstractFormDoc::OnOkTransaction();
}

//-------------------------------------------------------------------------------
void DCollections::OnDisabledChanged()
{
	if (GetCollections()->f_Disabled && CollectionsStillInUse(GetCollections()->f_Collection))
		SetError(cwsprintf(_TB("The Collection cannot be disabled because it is still in use in Boxes.")));

	UpdateDataView();
}


//-----------------------------------------------------------------------------
BOOL DCollections::OnOkDelete()
{
	if (CollectionsStillInUse(GetCollections()->f_Collection))
	{
		SetError(cwsprintf(_TB("The Collection cannot be disabled because it is still in use in Boxes.")));
		m_pMessages->Show();
		return FALSE;
	}

	return CAbstractFormDoc::OnOkDelete();
}

//-----------------------------------------------------------------------------
BOOL DCollections::CollectionsStillInUse(const DataStr& sCollections)
{
	BOOL bCollectionsStillInUse = FALSE;
//
//	TBoxCollections aRec;
//	SqlTable aTbl(&aRec, GetReadOnlySqlSession());
//	TRY
//	{
//		aTbl.Open();
//		
//		aTbl.SelectAll		();
//
//		aTbl.AddParam		(szP3,	aRec.f_Collection);
//		aTbl.AddFilterColumn(aRec.f_Collection);
//		aTbl.SetParamValue	(szP3,	sCollections);
//
//		aTbl.Query();
//
//		bCollectionsStillInUse = !aTbl.IsEmpty() && !aRec.f_IsClosed == FALSE;
//}
//	CATCH(SqlException, e)	
//	{
//		GetMessages()->Add(e->m_strError);
//		GetMessages()->Show(TRUE);
//	}
//	END_CATCH	
//
//	aTbl.Close();

	return bCollectionsStillInUse;
}

