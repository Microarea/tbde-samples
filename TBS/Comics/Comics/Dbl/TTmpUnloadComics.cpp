
#include "stdafx.h"             

// Locals
#include "TTmpUnloadComics.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

static TCHAR szP1[]	= _T("P1");
static TCHAR szP2[]	= _T("P2");
static TCHAR szP3[]	= _T("P3");

/////////////////////////////////////////////////////////////////////////////
//				class TTmpUnloadComics Implementation
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
IMPLEMENT_DYNCREATE(TTmpUnloadComics, SqlRecord) 

//-----------------------------------------------------------------------------
TTmpUnloadComics::TTmpUnloadComics(BOOL bCallInit)
	:
	SqlRecord(GetStaticName())
{
	BindRecord();
	if (bCallInit) Init();
}

//-----------------------------------------------------------------------------
void TTmpUnloadComics::BindRecord()
{
	BEGIN_BIND_DATA	();
		BIND_DATA	(_NS_FLD("SaleDocId"),		f_Document_Id);
		BIND_DATA	(_NS_FLD("Line"),			f_Line);
		BIND_DATA	(_NS_FLD("BoxNo"),			f_BoxNo);
		BIND_DATA	(_NS_FLD("SubId"),			f_SubId);
		BIND_DATA	(_NS_FLD("LastName"),		f_LastName);
		BIND_DATA	(_NS_FLD("Name"),			f_Name);
		BIND_DATA	(_NS_FLD("Item"),			f_Item);
		BIND_DATA	(_NS_FLD("Collection"),		f_Collection);
		BIND_DATA	(_NS_FLD("ReceiptDate"),	f_ReceiptDate);
	END_BIND_DATA();							
}

//-----------------------------------------------------------------------------
LPCTSTR TTmpUnloadComics::GetStaticName() { return _NS_TBL("CO_TmpUnloadComics"); }

/////////////////////////////////////////////////////////////////////////////
//					class TUTmpUnloadComics Implementation
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
IMPLEMENT_DYNAMIC (TUTmpUnloadComics, TableUpdater)

//------------------------------------------------------------------------------
TUTmpUnloadComics::TUTmpUnloadComics
	(
		CAbstractFormDoc* 	pDocument,	// = NULL
		CMessages* 			pMessages	// = NULL
	)													
	: 
	TableUpdater(RUNTIME_CLASS(TTmpUnloadComics), pDocument, pMessages)
{
}

//------------------------------------------------------------------------------
void TUTmpUnloadComics::OnDefineQuery ()
{
	m_pTable->SelectAll			();
	m_pTable->AddFilterColumn	(GetRecord()->f_Document_Id);
	m_pTable->AddFilterColumn	(GetRecord()->f_BoxNo);
	m_pTable->AddFilterColumn	(GetRecord()->f_Item);
	m_pTable->AddParam			(szP1,	GetRecord()->f_Document_Id);
	m_pTable->AddParam			(szP3,	GetRecord()->f_BoxNo);
	m_pTable->AddParam			(szP2,	GetRecord()->f_Item);
}
	
//------------------------------------------------------------------------------
void TUTmpUnloadComics::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1,	m_Document_Id);
	m_pTable->SetParamValue(szP3,	m_BoxNo);
	m_pTable->SetParamValue(szP2,	m_Item);
}

//------------------------------------------------------------------------------
BOOL TUTmpUnloadComics::IsEmptyQuery()
{
	return m_Document_Id.IsEmpty() || m_Item.IsEmpty() || m_BoxNo.IsEmpty();
}

//------------------------------------------------------------------------------
TableUpdater::FindResult TUTmpUnloadComics::FindRecord
	(
		const DataLng& aDocument_Id,
		const DataStr& aBoxNo,
		const DataStr& aItem, 
			  BOOL	   bLock
	)
{
	m_Document_Id	= aDocument_Id;	
	m_BoxNo			= aBoxNo;
	m_Item			= aItem;

	return TableUpdater::FindRecord(bLock);
}                                          

/////////////////////////////////////////////////////////////////////////////
//						classe TRTmpUnloadComics
/////////////////////////////////////////////////////////////////////////////

IMPLEMENT_DYNAMIC (TRTmpUnloadComics, TableReader)

//------------------------------------------------------------------------------
TRTmpUnloadComics::TRTmpUnloadComics(CAbstractFormDoc* pDocument/*NULL*/)													
	: 
	TableReader(RUNTIME_CLASS(TTmpUnloadComics), pDocument)
{
}

//------------------------------------------------------------------------------
void TRTmpUnloadComics::OnDefineQuery ()
{   
	m_pTable->SelectAll();
     
	m_pTable->AddFilterColumn(GetRecord()->f_Item); 
	m_pTable->AddFilterColumn(GetRecord()->f_BoxNo);  

	m_pTable->AddParam		 (szP1,	GetRecord()->f_Item); 
	m_pTable->AddParam		 (szP2,	GetRecord()->f_BoxNo); 	
}
	
//------------------------------------------------------------------------------
void TRTmpUnloadComics::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1,	m_Item); 
	m_pTable->SetParamValue(szP2,	m_BoxNo); 
} 

//------------------------------------------------------------------------------
BOOL TRTmpUnloadComics::IsEmptyQuery()
{
	return m_Item.IsEmpty() || m_BoxNo.IsEmpty();
}

//------------------------------------------------------------------------------
TableReader::FindResult TRTmpUnloadComics::FindRecord(const DataStr& aItem, const DataStr& aBoxNo)
{ 
	m_Item  = aItem;
	m_BoxNo = aBoxNo;

	return TableReader::FindRecord();
}

/////////////////////////////////////////////////////////////////////////////
//						classe TRTmpUnloadComicsByDocIdSubId
/////////////////////////////////////////////////////////////////////////////

IMPLEMENT_DYNAMIC (TRTmpUnloadComicsByDocIdSubId, TableReader)

//------------------------------------------------------------------------------
TRTmpUnloadComicsByDocIdSubId::TRTmpUnloadComicsByDocIdSubId(CAbstractFormDoc* pDocument/*NULL*/)													
	: 
	TableReader(RUNTIME_CLASS(TTmpUnloadComics), pDocument)
{
}

//------------------------------------------------------------------------------
void TRTmpUnloadComicsByDocIdSubId::OnDefineQuery ()
{   
	m_pTable->SelectAll();
     
	m_pTable->AddFilterColumn(GetRecord()->f_Document_Id); 
	m_pTable->AddFilterColumn(GetRecord()->f_SubId);  

	m_pTable->AddParam		 (szP1,	GetRecord()->f_Document_Id); 
	m_pTable->AddParam		 (szP2,	GetRecord()->f_SubId); 	
}
	
//------------------------------------------------------------------------------
void TRTmpUnloadComicsByDocIdSubId::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1,	m_Document_Id); 
	m_pTable->SetParamValue(szP2,	m_SubId); 
} 

//------------------------------------------------------------------------------
BOOL TRTmpUnloadComicsByDocIdSubId::IsEmptyQuery()
{
	return m_Document_Id.IsEmpty() || m_SubId.IsEmpty();
}

//------------------------------------------------------------------------------
TableReader::FindResult TRTmpUnloadComicsByDocIdSubId::FindRecord(const DataLng& aDocument_Id, const DataLng& aSubId)
{ 
	m_Document_Id	= aDocument_Id;
	m_SubId			= aSubId;

	return TableReader::FindRecord();
}

/////////////////////////////////////////////////////////////////////////////
//	RowsetUpdater				### RUTmpUnloadComics ###					
/////////////////////////////////////////////////////////////////////////////
//
//------------------------------------------------------------------------------
IMPLEMENT_DYNAMIC (RUTmpUnloadComics , RowsetUpdater)

//------------------------------------------------------------------------------
RUTmpUnloadComics::RUTmpUnloadComics
	(
		CAbstractFormDoc* 	pDocument,	// = NULL
		CMessages* 			pMessages	// = NULL
	)													
	: 
	RowsetUpdater(RUNTIME_CLASS(TTmpUnloadComics), pDocument, pMessages)
{
}

//------------------------------------------------------------------------------
void RUTmpUnloadComics::OnDefineQuery ()
{
	m_pTable->SelectAll			();

	m_pTable->AddFilterColumn	(GetRecord()->f_Document_Id);
	m_pTable->AddFilterColumn	(GetRecord()->f_SubId);

	m_pTable->AddParam			(szP1,	GetRecord()->f_Document_Id);
	m_pTable->AddParam			(szP2,	GetRecord()->f_SubId);
}
	
//------------------------------------------------------------------------------
void RUTmpUnloadComics::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1,	m_Document_Id);
	m_pTable->SetParamValue(szP2,	m_SubId);
}

//------------------------------------------------------------------------------
BOOL RUTmpUnloadComics::IsEmptyQuery()
{
	return	m_Document_Id.IsEmpty() || m_SubId.IsEmpty();
}

//------------------------------------------------------------------------------
RowsetUpdater::FindResult RUTmpUnloadComics::FindRecord(const DataLng& aDocument_Id, const DataLng& aSubId, BOOL bLock)
{
	m_Document_Id	= aDocument_Id;	
	m_SubId			= aSubId;

	return RowsetUpdater::FindRecord(bLock);
}
