
#include "stdafx.h"             

//ERP
#include <Items\ItemsLen.h>
#include <Items\Dbl\ItemsInfo.h>

//Comics
#include <Comics\ComicsLen.h>

//Local
#include "TBoxes.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

static TCHAR szP1[]	= _T("P1");
static TCHAR szP2[]	= _T("P2");
static TCHAR szP3[]	= _T("P3");

/////////////////////////////////////////////////////////////////////////////
//	SqlRecord					### TBoxes ###	
/////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE(TBoxes, SqlRecord) 

//-----------------------------------------------------------------------------
TBoxes::TBoxes(BOOL bCallInit)
	:
	SqlRecord	(GetStaticName()),
	f_IsClosed	(FALSE)
{
	BindRecord();	
	if (bCallInit) Init();
}

//-----------------------------------------------------------------------------
void TBoxes::BindRecord()
{
	BEGIN_BIND_DATA	();
		BIND_DATA	(_NS_FLD("BoxNo"),				f_BoxNo);
		BIND_DATA	(_NS_FLD("CreationDate"),		f_CreationDate);
		BIND_DATA	(_NS_FLD("ClosingDate"),		f_ClosingDate);
		BIND_DATA	(_NS_FLD("IsClosed"),			f_IsClosed);
		BIND_DATA	(_NS_FLD("LastName"),			f_LastName);
		BIND_DATA	(_NS_FLD("Name"),				f_Name);
		BIND_DATA	(_NS_FLD("Telephone1"),			f_Telephone1);
		BIND_DATA	(_NS_FLD("Telephone2"),			f_Telephone2);
		BIND_DATA	(_NS_FLD("Mail"),				f_Mail);
		BIND_DATA	(_NS_FLD("Discount"),			f_Discount);
		BIND_DATA	(_NS_FLD("Notes"),				f_Notes);

		LOCAL_STR	(_NS_LFLD("l_BmpStatusBox"),	l_BmpStatusBox,	LEN_COLLECTION_DESCRI);
		BIND_TB_GUID();		
	END_BIND_DATA();    	
}							



//-----------------------------------------------------------------------------
LPCTSTR TBoxes::GetStaticName() { return _NS_TBL("CO_Boxes"); }

/////////////////////////////////////////////////////////////////////////////
//	SqlRecord					### TBoxCollections ###	
/////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE(TBoxCollections, SqlRecord) 

//-----------------------------------------------------------------------------
TBoxCollections::TBoxCollections(BOOL bCallInit)
	:
	SqlRecord	(GetStaticName()),
	f_IsClosed	(FALSE)
{
	f_Collection.SetUpperCase();

	BindRecord();	
	if (bCallInit) Init();
}

//-----------------------------------------------------------------------------
void TBoxCollections::BindRecord()
{
	BEGIN_BIND_DATA	();
		BIND_DATA	(_NS_FLD("BoxNo"),					f_BoxNo);
		BIND_DATA	(_NS_FLD("Collection"),				f_Collection);
		BIND_DATA	(_NS_FLD("CreationDate"),			f_CreationDate);
		BIND_DATA	(_NS_FLD("FromNumber"),				f_FromNumber);
		BIND_DATA	(_NS_FLD("LastReceiptNumber"),		f_LastReceiptNumber);
		BIND_DATA	(_NS_FLD("LastIssuedNumber"),		f_LastIssuedNumber);
		BIND_DATA	(_NS_FLD("LastReceiptDate"),		f_LastReceiptDate);
		BIND_DATA	(_NS_FLD("LastIssuedDate"),			f_LastIssuedDate);
		BIND_DATA	(_NS_FLD("ClosingDate"),			f_ClosingDate);
		BIND_DATA	(_NS_FLD("IsClosed"),				f_IsClosed);
		BIND_DATA	(_NS_FLD("Notes"),					f_Notes);

		LOCAL_STR	(_NS_LFLD("CollectionDescri"),		l_CollectionDescri,	LEN_COLLECTION_DESCRI);
	END_BIND_DATA();    
}

//-----------------------------------------------------------------------------
LPCTSTR TBoxCollections::GetStaticName() { return _NS_TBL("CO_CollectionsBox"); }

/////////////////////////////////////////////////////////////////////////////
//	SqlRecord					### TBoxEntries ###	
/////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE(TBoxEntries, SqlRecord) 

//-----------------------------------------------------------------------------
TBoxEntries::TBoxEntries(BOOL bCallInit)
	:
	SqlRecord	(GetStaticName())
{
	f_Item.SetUpperCase();

	BindRecord();	
	if (bCallInit) Init();
}

//-----------------------------------------------------------------------------
void TBoxEntries::BindRecord()
{
	BEGIN_BIND_DATA	();
		BIND_DATA	(_NS_FLD("BoxNo"),		f_BoxNo);
		BIND_DATA	(_NS_FLD("Item"),		f_Item);
		BIND_DATA	(_NS_FLD("ReceiptDate"),		f_ReceiptDate);

		LOCAL_STR	(_NS_LFLD("ItemDescri"),	l_ItemDescri,	LEN_DESCRI_ITEM);
	END_BIND_DATA();    
}

//-----------------------------------------------------------------------------
LPCTSTR TBoxEntries::GetStaticName() { return _NS_TBL("CO_ReceiptsBox"); }

/////////////////////////////////////////////////////////////////////////////
//			class  TEnhBoxesSelection implementation
/////////////////////////////////////////////////////////////////////////////
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE(TEnhBoxesSelection, TBoxes)

//-----------------------------------------------------------------------------
TEnhBoxesSelection::TEnhBoxesSelection(BOOL bCallInit  /* = TRUE */)
	:
	TBoxes(FALSE), 
	l_IsSelected(FALSE)
{
	BindRecord();	
	if (bCallInit) Init(); 
}

//-----------------------------------------------------------------------------
void TEnhBoxesSelection::BindRecord()
{
	BEGIN_BIND_DATA	();
		LOCAL_DATA	(_NS_LFLD("IsSelected"),				l_IsSelected);
		LOCAL_STR	(_NS_LFLD("CollectionNotes"),			l_CollectionNotes,			LEN_COLLECTION_NOTES);
		LOCAL_DATA	(_NS_LFLD("CollectionCreationDate"),	l_CollectionCreationDate);

		LOCAL_DATA	(_NS_LFLD("LoadingDate"),				l_LoadingDate);
		LOCAL_STR	(_NS_LFLD("Collection"),				l_Collection,				LEN_COLLECTION);
		LOCAL_STR	(_NS_LFLD("Item"),						l_Item,						AfxGetItemsInfo()->GetMaxLenCodItem());
	END_BIND_DATA();
}

/////////////////////////////////////////////////////////////////////////////
//						classe TRBoxes
/////////////////////////////////////////////////////////////////////////////

IMPLEMENT_DYNAMIC (TRBoxes, TableReader)

//------------------------------------------------------------------------------
TRBoxes::TRBoxes(CAbstractFormDoc* pDocument/*NULL*/)													
	: 
	TableReader(RUNTIME_CLASS(TBoxes), pDocument)
{
}

//------------------------------------------------------------------------------
void TRBoxes::OnDefineQuery ()
{   
	m_pTable->SelectAll();
    
	m_pTable->AddFilterColumn(GetRecord()->f_BoxNo);  
	m_pTable->AddParam		 (szP1,	GetRecord()->f_BoxNo); 
}
	
//------------------------------------------------------------------------------
void TRBoxes::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1,	m_BoxNo); 
} 

//------------------------------------------------------------------------------
BOOL TRBoxes::IsEmptyQuery()
{
	return m_BoxNo.IsEmpty();
}

//------------------------------------------------------------------------------
TableReader::FindResult TRBoxes::FindRecord(const DataStr& aBoxNo)
{ 
	m_BoxNo = aBoxNo;

	return TableReader::FindRecord();
}

/////////////////////////////////////////////////////////////////////////////
//						classe TRBoxesLastName
/////////////////////////////////////////////////////////////////////////////

IMPLEMENT_DYNAMIC (TRBoxesLastName, TableReader)

//------------------------------------------------------------------------------
TRBoxesLastName::TRBoxesLastName(CAbstractFormDoc* pDocument/*NULL*/)													
	: 
	TableReader(RUNTIME_CLASS(TBoxes), pDocument)
{
}

//------------------------------------------------------------------------------
void TRBoxesLastName::OnDefineQuery ()
{   
	m_pTable->SelectAll();
    
	m_pTable->AddFilterColumn(GetRecord()->f_BoxNo);  
	m_pTable->AddFilterColumn(GetRecord()->f_LastName);  
	m_pTable->AddParam		 (szP1,	GetRecord()->f_BoxNo); 
	m_pTable->AddParam		 (szP2,	GetRecord()->f_LastName); 
}
	
//------------------------------------------------------------------------------
void TRBoxesLastName::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1, m_BoxNo); 
	m_pTable->SetParamValue(szP2, m_LastName); 
} 

//------------------------------------------------------------------------------
BOOL TRBoxesLastName::IsEmptyQuery()
{
	return m_BoxNo.IsEmpty() || m_LastName.IsEmpty();
}

//------------------------------------------------------------------------------
TableReader::FindResult TRBoxesLastName::FindRecord(const DataStr& aBoxNo, const DataStr& aLastName)
{ 
	m_BoxNo		= aBoxNo;
	m_LastName	= aLastName;

	return TableReader::FindRecord();
}

/////////////////////////////////////////////////////////////////////////////
//						classe TRBoxEntries
/////////////////////////////////////////////////////////////////////////////

IMPLEMENT_DYNAMIC (TRBoxEntries, TableReader)

//------------------------------------------------------------------------------
TRBoxEntries::TRBoxEntries(CAbstractFormDoc* pDocument/*NULL*/)													
	: 
	TableReader(RUNTIME_CLASS(TBoxEntries), pDocument)
{
}

//------------------------------------------------------------------------------
void TRBoxEntries::OnDefineQuery ()
{   
	m_pTable->SelectAll();
    
	m_pTable->AddFilterColumn(GetRecord()->f_BoxNo);  
	m_pTable->AddFilterColumn(GetRecord()->f_Item);  
	m_pTable->AddParam		 (szP1,	GetRecord()->f_BoxNo);
	m_pTable->AddParam		 (szP2,	GetRecord()->f_Item);
}
	
//------------------------------------------------------------------------------
void TRBoxEntries::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1,	m_BoxNo); 
	m_pTable->SetParamValue(szP2,	m_Item); 
} 

//------------------------------------------------------------------------------
BOOL TRBoxEntries::IsEmptyQuery()
{
	return m_BoxNo.IsEmpty() || m_Item.IsEmpty();
}

//------------------------------------------------------------------------------
TableReader::FindResult TRBoxEntries::FindRecord(const DataStr& aBoxNo, const DataStr& aItem)
{ 
	m_BoxNo = aBoxNo;
	m_Item  = aItem;

	return TableReader::FindRecord();
}

/////////////////////////////////////////////////////////////////////////////
//					class TUBoxCollections Implementation
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
IMPLEMENT_DYNAMIC (TUBoxCollections, TableUpdater)

//------------------------------------------------------------------------------
TUBoxCollections::TUBoxCollections
	(
		CAbstractFormDoc* 	pDocument,	// = NULL
		CMessages* 			pMessages	// = NULL
	)													
	: 
	TableUpdater(RUNTIME_CLASS(TBoxCollections), pDocument, pMessages)
{
}

//------------------------------------------------------------------------------
void TUBoxCollections::OnDefineQuery ()
{
	m_pTable->SelectAll			();
	m_pTable->AddFilterColumn	(GetRecord()->f_BoxNo);
	m_pTable->AddFilterColumn	(GetRecord()->f_Collection);
	m_pTable->AddParam			(szP2,	GetRecord()->f_BoxNo);
	m_pTable->AddParam			(szP3,	GetRecord()->f_Collection);
}
	
//------------------------------------------------------------------------------
void TUBoxCollections::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP2,	m_BoxNo);
	m_pTable->SetParamValue(szP3,	m_Collection);
}

//------------------------------------------------------------------------------
BOOL TUBoxCollections::IsEmptyQuery()
{
	return m_BoxNo.IsEmpty() || m_Collection.IsEmpty();
}

//------------------------------------------------------------------------------
TableUpdater::FindResult TUBoxCollections::FindRecord
	(
		const DataStr& aBoxNo,
		const DataStr& aCollection,
			  BOOL	   bLock
	)
{
	m_BoxNo		 = aBoxNo;
	m_Collection = aCollection;

	return TableUpdater::FindRecord(bLock);
} 

/////////////////////////////////////////////////////////////////////////////
//					class TUBoxEntries Implementation
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
IMPLEMENT_DYNAMIC (TUBoxEntries, TableUpdater)

//------------------------------------------------------------------------------
TUBoxEntries::TUBoxEntries
	(
		CAbstractFormDoc* 	pDocument,	// = NULL
		CMessages* 			pMessages	// = NULL
	)													
	: 
	TableUpdater(RUNTIME_CLASS(TBoxEntries), pDocument, pMessages)
{
}

//------------------------------------------------------------------------------
void TUBoxEntries::OnDefineQuery ()
{
	m_pTable->SelectAll			();
	m_pTable->AddFilterColumn	(GetRecord()->f_BoxNo);
	m_pTable->AddFilterColumn	(GetRecord()->f_Item);
	m_pTable->AddParam			(szP2,	GetRecord()->f_BoxNo);
	m_pTable->AddParam			(szP3,	GetRecord()->f_Item);
}
	
//------------------------------------------------------------------------------
void TUBoxEntries::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP2,	m_BoxNo);
	m_pTable->SetParamValue(szP3,	m_Item);
}

//------------------------------------------------------------------------------
BOOL TUBoxEntries::IsEmptyQuery()
{
	return m_BoxNo.IsEmpty() || m_Item.IsEmpty();
}

//------------------------------------------------------------------------------
TableUpdater::FindResult TUBoxEntries::FindRecord
	(
		const DataStr& aBoxNo,
		const DataStr& aItem,
			  BOOL	   bLock
	)
{
	m_BoxNo	= aBoxNo;
	m_Item	= aItem;

	return TableUpdater::FindRecord(bLock);
} 

/////////////////////////////////////////////////////////////////////////////
//	RowsetReader		RRBoxesLastName
/////////////////////////////////////////////////////////////////////////////
//
//------------------------------------------------------------------------------
IMPLEMENT_DYNAMIC (RRBoxesLastName , RowsetReader)

//------------------------------------------------------------------------------
RRBoxesLastName::RRBoxesLastName
	(
		CAbstractFormDoc* 	pDocument	// = NULL
	)													
	: 
	RowsetReader(RUNTIME_CLASS(TBoxes), pDocument)
{
}

//------------------------------------------------------------------------------
void RRBoxesLastName::OnDefineQuery ()
{
	m_pTable->SelectAll			();

	m_pTable->AddFilterColumn	(GetRecord()->f_LastName);
	m_pTable->AddParam			(szP1,	GetRecord()->f_LastName);
}
	
//------------------------------------------------------------------------------
void RRBoxesLastName::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1, m_LastName);
}

//------------------------------------------------------------------------------
BOOL RRBoxesLastName::IsEmptyQuery()
{
	return	m_LastName.IsEmpty();
}

//------------------------------------------------------------------------------
RowsetReader::FindResult RRBoxesLastName::FindRecord
(
	const DataStr& aLastName
)
{
	m_LastName = aLastName;	
	return RowsetReader::FindRecord();
}

/////////////////////////////////////////////////////////////////////////////
//	RowsetReader		RRBoxEntries
/////////////////////////////////////////////////////////////////////////////
//
//------------------------------------------------------------------------------
IMPLEMENT_DYNAMIC (RRBoxEntries , RowsetReader)

//------------------------------------------------------------------------------
RRBoxEntries::RRBoxEntries
	(
		CAbstractFormDoc* 	pDocument	// = NULL
	)													
	: 
	RowsetReader(RUNTIME_CLASS(TBoxEntries), pDocument)
{
}

//------------------------------------------------------------------------------
void RRBoxEntries::OnDefineQuery ()
{
	m_pTable->SelectAll			();

	m_pTable->AddFilterColumn	(GetRecord()->f_BoxNo);
	m_pTable->AddParam			(szP1,	GetRecord()->f_BoxNo);
}
	
//------------------------------------------------------------------------------
void RRBoxEntries::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1, m_BoxNo);
}

//------------------------------------------------------------------------------
BOOL RRBoxEntries::IsEmptyQuery()
{
	return	m_BoxNo.IsEmpty();
}

//------------------------------------------------------------------------------
RowsetReader::FindResult RRBoxEntries::FindRecord
(
	const DataStr& aBoxNo
)
{
	m_BoxNo = aBoxNo;	
	return RowsetReader::FindRecord();
}

/////////////////////////////////////////////////////////////////////////////
//	Hotlink						### HKLBoxes ###			
/////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE (HKLBoxes, HotKeyLink)

//------------------------------------------------------------------------------
HKLBoxes::HKLBoxes() 
	: 
	HotKeyLink			(RUNTIME_CLASS(TBoxes), _NS_DOC("Comics.Documents.Boxes")),
	m_SelectionDisable	(ACTIVE)
{
}
	
//------------------------------------------------------------------------------
void HKLBoxes::DefineDisable()
{ 
	switch(m_SelectionDisable)
	{
		case ACTIVE:
		case DISABLE: 
			m_pTable->AddFilterColumn	(GetRecord()->f_IsClosed);
			m_pTable->AddParam			(szP2, GetRecord()->f_IsClosed);
			break;  
	}               
}

//------------------------------------------------------------------------------
void HKLBoxes::OnDefineQuery (SelectionType nQuerySelection)
{
	m_pTable->SelectAll();
	
	switch (nQuerySelection)
	{
		case DIRECT_ACCESS:
			m_pTable->AddFilterLike	(GetRecord()->f_BoxNo);
			m_pTable->AddParam		(szP1, GetRecord()->f_BoxNo);
			break;
			
		case COMBO_ACCESS:
		case UPPER_BUTTON:
			m_pTable->AddSortColumn	(GetRecord()->f_BoxNo);
			m_pTable->AddFilterLike	(GetRecord()->f_BoxNo);
			m_pTable->AddParam		(szP1, GetRecord()->f_BoxNo);
			DefineDisable();
			break;

		case LOWER_BUTTON:
			m_pTable->AddSortColumn	(GetRecord()->f_LastName);
			m_pTable->AddFilterLike	(GetRecord()->f_LastName);
			m_pTable->AddParam		(szP1, GetRecord()->f_LastName);
			DefineDisable();
			break;
	}	
}

//------------------------------------------------------------------------------
void HKLBoxes::PrepareDisable()
{
	DataBool bDisable;
	switch(m_SelectionDisable) 
	{
		case ACTIVE: 
			bDisable = FALSE;
			m_pTable->SetParamValue(szP2, bDisable);
			break;

		case DISABLE: 
			bDisable = TRUE;
			m_pTable->SetParamValue(szP2, bDisable);
            break;
	}               
}

//------------------------------------------------------------------------------
void HKLBoxes::OnPrepareQuery (DataObj* pDataObj, SelectionType nQuerySelection)
{
	ASSERT(pDataObj->IsKindOf(RUNTIME_CLASS(DataStr)));
	
	switch (nQuerySelection)
	{
		case DIRECT_ACCESS:
			m_pTable->SetParamLike(szP1, *pDataObj);
			break;

		case COMBO_ACCESS:
		case UPPER_BUTTON:
			m_pTable->SetParamLike(szP1, *pDataObj);
			PrepareDisable();
   			break;
   			
		case LOWER_BUTTON:
   			m_pTable->SetParamLike(szP1, *pDataObj);
			PrepareDisable();
   			break;
	}
}

//------------------------------------------------------------------------------
BOOL HKLBoxes::IsValid()
{
	if (!HotKeyLink::IsValid())
		return FALSE;
    
    return TRUE;
}

//------------------------------------------------------------------------------
BOOL HKLBoxes::Customize(const DataObjArray& params)
{
	ASSERT(params.GetSize() == 1);
	ASSERT(params[0]->IsKindOf(RUNTIME_CLASS(DataInt)));

	DataInt Filter;
	Filter.Assign(*params[0]);

	if (Filter == 0)
		SetSelDisable(ACTIVE);
	else if (Filter == 1)
		SetSelDisable(DISABLE);
	else 
		SetSelDisable(BOTH);

	return TRUE;
}


