
#include "stdafx.h"             

// Locals
#include "TTmpLoadComics.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

static TCHAR szP1[]	= _T("P1");
static TCHAR szP2[]	= _T("P2");
static TCHAR szP3[]	= _T("P3");

/////////////////////////////////////////////////////////////////////////////
//				class TTmpLoadComics Implementation
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
IMPLEMENT_DYNCREATE(TTmpLoadComics, SqlRecord) 

//-----------------------------------------------------------------------------
TTmpLoadComics::TTmpLoadComics(BOOL bCallInit)
	:
	SqlRecord(GetStaticName())
{
	BindRecord();
	if (bCallInit) Init();
}

//-----------------------------------------------------------------------------
void TTmpLoadComics::BindRecord()
{
	BEGIN_BIND_DATA	();
		BIND_DATA	(_NS_FLD("EntryId"),		f_EntryId);
		BIND_DATA	(_NS_FLD("SubId"),			f_SubId);
		BIND_DATA	(_NS_FLD("BoxNo"),			f_BoxNo);
		BIND_DATA	(_NS_FLD("Item"),			f_Item);
		BIND_DATA	(_NS_FLD("Description"),	f_Description);
		BIND_DATA	(_NS_FLD("Collection"),		f_Collection);
		BIND_DATA	(_NS_FLD("InvEntryDate"),	f_InvEntryDate);
	END_BIND_DATA();
}

//-----------------------------------------------------------------------------
LPCTSTR TTmpLoadComics::GetStaticName() { return _NS_TBL("CO_TmpLoadComics"); }

/////////////////////////////////////////////////////////////////////////////
//					class TUTmpLoadComics Implementation
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
IMPLEMENT_DYNAMIC (TUTmpLoadComics, TableUpdater)

//------------------------------------------------------------------------------
TUTmpLoadComics::TUTmpLoadComics
	(
		CAbstractFormDoc* 	pDocument,	// = NULL
		CMessages* 			pMessages	// = NULL
	)													
	: 
	TableUpdater(RUNTIME_CLASS(TTmpLoadComics), pDocument, pMessages)
{
}

//------------------------------------------------------------------------------
void TUTmpLoadComics::OnDefineQuery ()
{
	m_pTable->SelectAll			();
	m_pTable->AddFilterColumn	(GetRecord()->f_EntryId);
	m_pTable->AddFilterColumn	(GetRecord()->f_SubId);
	m_pTable->AddFilterColumn	(GetRecord()->f_BoxNo);
	m_pTable->AddParam			(szP1,	GetRecord()->f_EntryId);
	m_pTable->AddParam			(szP2,	GetRecord()->f_SubId);
	m_pTable->AddParam			(szP3,	GetRecord()->f_BoxNo);
}
	
//------------------------------------------------------------------------------
void TUTmpLoadComics::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1,	m_EntryId);
	m_pTable->SetParamValue(szP2,	m_SubId);
	m_pTable->SetParamValue(szP3,	m_BoxNo);
}

//------------------------------------------------------------------------------
BOOL TUTmpLoadComics::IsEmptyQuery()
{
	return m_EntryId.IsEmpty() || m_SubId.IsEmpty() || m_BoxNo.IsEmpty();
}

//------------------------------------------------------------------------------
TableUpdater::FindResult TUTmpLoadComics::FindRecord
	(
		const DataLng& aEntryId,
		const DataLng& aSubId, 
		const DataStr& aBoxNo,
			  BOOL	   bLock
	)
{
	m_EntryId = aEntryId;	
	m_SubId	  = aSubId;
	m_BoxNo	  = aBoxNo;

	return TableUpdater::FindRecord(bLock);
}                                          

/////////////////////////////////////////////////////////////////////////////
//						classe TRTmpLoadComics
/////////////////////////////////////////////////////////////////////////////

IMPLEMENT_DYNAMIC (TRTmpLoadComics, TableReader)

//------------------------------------------------------------------------------
TRTmpLoadComics::TRTmpLoadComics(CAbstractFormDoc* pDocument/*NULL*/)													
	: 
	TableReader(RUNTIME_CLASS(TTmpLoadComics), pDocument)
{
}

//------------------------------------------------------------------------------
void TRTmpLoadComics::OnDefineQuery ()
{   
	m_pTable->SelectAll();
     
	m_pTable->AddFilterColumn(GetRecord()->f_Item); 
	m_pTable->AddFilterColumn(GetRecord()->f_BoxNo);  

	m_pTable->AddParam		 (szP1,	GetRecord()->f_Item); 
	m_pTable->AddParam		 (szP2,	GetRecord()->f_BoxNo); 	
}
	
//------------------------------------------------------------------------------
void TRTmpLoadComics::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1,	m_Item); 
	m_pTable->SetParamValue(szP2,	m_BoxNo); 
} 

//------------------------------------------------------------------------------
BOOL TRTmpLoadComics::IsEmptyQuery()
{
	return m_Item.IsEmpty() || m_BoxNo.IsEmpty();
}

//------------------------------------------------------------------------------
TableReader::FindResult TRTmpLoadComics::FindRecord(const DataStr& aItem, const DataStr& aBoxNo)
{ 
	m_Item  = aItem;
	m_BoxNo = aBoxNo;

	return TableReader::FindRecord();
}

/////////////////////////////////////////////////////////////////////////////
//	RowsetUpdater				### RUTmpLoadComics ###					
/////////////////////////////////////////////////////////////////////////////
//
//------------------------------------------------------------------------------
IMPLEMENT_DYNAMIC (RUTmpLoadComics , RowsetUpdater)

//------------------------------------------------------------------------------
RUTmpLoadComics::RUTmpLoadComics
	(
		CAbstractFormDoc* 	pDocument,	// = NULL
		CMessages* 			pMessages	// = NULL
	)													
	: 
	RowsetUpdater(RUNTIME_CLASS(TTmpLoadComics), pDocument, pMessages)
{
}

//------------------------------------------------------------------------------
void RUTmpLoadComics::OnDefineQuery ()
{
	m_pTable->SelectAll			();

	m_pTable->AddFilterColumn	(GetRecord()->f_EntryId);
	m_pTable->AddFilterColumn	(GetRecord()->f_SubId);

	m_pTable->AddParam			(szP1,	GetRecord()->f_EntryId);
	m_pTable->AddParam			(szP2,	GetRecord()->f_SubId);
}
	
//------------------------------------------------------------------------------
void RUTmpLoadComics::OnPrepareQuery ()
{
	m_pTable->SetParamValue(szP1,	m_EntryId);
	m_pTable->SetParamValue(szP2,	m_SubId);
}

//------------------------------------------------------------------------------
BOOL RUTmpLoadComics::IsEmptyQuery()
{
	return	m_EntryId.IsEmpty() || m_SubId.IsEmpty();
}

//------------------------------------------------------------------------------
RowsetUpdater::FindResult RUTmpLoadComics::FindRecord(const DataLng& aEntryId, const DataLng& aSubId, BOOL bLock)
{
	m_EntryId = aEntryId;	
	m_SubId	  = aSubId;
	return RowsetUpdater::FindRecord(bLock);
}
