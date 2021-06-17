
#include "stdafx.h"             

// Library declarations
//NOW INCLUDED IN COMMON PCH: #include <tboledb\sqltable.h>
//NOW INCLUDED IN COMMON PCH: #include <TbGes\extdoc.h>

//Local declarations
#include "TCollections.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


static TCHAR szP1[]	= _T("P1");
static TCHAR szP2[]	= _T("P2");

/////////////////////////////////////////////////////////////////////////////
//	SqlRecord					### TCollections ###	
/////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE(TCollections, SqlRecord) 

//-----------------------------------------------------------------------------
TCollections::TCollections(BOOL bCallInit)
	:
	SqlRecord	(GetStaticName()),
	f_Disabled	(FALSE)
{
	f_Collection.SetUpperCase();

	BindRecord();	
	if (bCallInit) Init();
}

//-----------------------------------------------------------------------------
void TCollections::BindRecord()
{
	BEGIN_BIND_DATA	();
		BIND_DATA	(_NS_FLD("Collection"),		f_Collection);
		BIND_DATA	(_NS_FLD("Description"),	f_Description);
		BIND_DATA	(_NS_FLD("Notes"),			f_Notes);
		BIND_DATA	(_NS_FLD("Disabled"),		f_Disabled);
		BIND_TB_GUID();
	END_BIND_DATA();    
}

//-----------------------------------------------------------------------------
LPCTSTR TCollections::GetStaticName() { return _NS_TBL("CO_Collections"); }

/////////////////////////////////////////////////////////////////////////////
//	Hotlink						### HKLCollections ###			
/////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE (HKLCollections, HotKeyLink)

//------------------------------------------------------------------------------
HKLCollections::HKLCollections() 
	: 
	HotKeyLink			(RUNTIME_CLASS(TCollections), _NS_DOC("Comics.Documents.Collections")),
	m_SelectionDisable	(ACTIVE)
{
}
	
//------------------------------------------------------------------------------
void HKLCollections::DefineDisable()
{ 
	switch(m_SelectionDisable)
	{
		case ACTIVE:
		case DISABLE: 
			m_pTable->AddFilterColumn	(GetRecord()->f_Disabled);
			m_pTable->AddParam			(szP2, GetRecord()->f_Disabled);
			break;  
	}               
}

//------------------------------------------------------------------------------
void HKLCollections::OnDefineQuery (SelectionType nQuerySelection)
{
	m_pTable->SelectAll();
	
	switch (nQuerySelection)
	{
		case DIRECT_ACCESS:
			m_pTable->AddFilterColumn	(GetRecord()->f_Collection);
			m_pTable->AddParam			(szP1, GetRecord()->f_Collection);
			break;
			
		case COMBO_ACCESS:
		case UPPER_BUTTON:
			m_pTable->AddSortColumn		(GetRecord()->f_Collection);
			m_pTable->AddFilterLike		(GetRecord()->f_Collection);
			m_pTable->AddParam			(szP1, GetRecord()->f_Collection);
			DefineDisable();
			break;

		case LOWER_BUTTON:
			m_pTable->AddSortColumn		(GetRecord()->f_Description);
			m_pTable->AddFilterLike		(GetRecord()->f_Description);
			m_pTable->AddParam			(szP1, GetRecord()->f_Description);
			DefineDisable();
			break;
	}	
}

//------------------------------------------------------------------------------
void HKLCollections::PrepareDisable()
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
void HKLCollections::OnPrepareQuery (DataObj* pDataObj, SelectionType nQuerySelection)
{
	ASSERT(pDataObj->IsKindOf(RUNTIME_CLASS(DataStr)));
	
	switch (nQuerySelection)
	{
		case DIRECT_ACCESS:
			m_pTable->SetParamValue(szP1, *pDataObj);
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
BOOL HKLCollections::IsValid()
{
	if (!HotKeyLink::IsValid())
		return FALSE;
		
	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
//						classe TRCollections
/////////////////////////////////////////////////////////////////////////////

IMPLEMENT_DYNAMIC(TRCollections, TableReader)

//------------------------------------------------------------------------------
TRCollections::TRCollections(CAbstractFormDoc* pDocument/*NULL*/)
	:
	TableReader(RUNTIME_CLASS(TCollections), pDocument)
{
}

//------------------------------------------------------------------------------
void TRCollections::OnDefineQuery()
{
	m_pTable->SelectAll();

	m_pTable->AddFilterColumn(GetRecord()->f_Collection);
	m_pTable->AddParam(szP1, GetRecord()->f_Collection);
}

//------------------------------------------------------------------------------
void TRCollections::OnPrepareQuery()
{
	m_pTable->SetParamValue(szP1, m_Collection);
}

//------------------------------------------------------------------------------
BOOL TRCollections::IsEmptyQuery()
{
	return m_Collection.IsEmpty();
}

//------------------------------------------------------------------------------
TableReader::FindResult TRCollections::FindRecord(const DataStr& aBoxNo)
{
	m_Collection = aBoxNo;

	return TableReader::FindRecord();
}
