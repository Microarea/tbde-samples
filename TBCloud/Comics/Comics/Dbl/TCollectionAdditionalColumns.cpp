
#include "stdafx.h"  

// Database declarations
#include <Comics\Dbl\TCollectionAdditionalColumns.h>  

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


//////////////////////////////////////////////////////////////////////////////
//             		TCollectionAdditionalColumns Implementation
//////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------
IMPLEMENT_DYNCREATE(TCollectionAdditionalColumns, SqlAddOnFieldsColumn) 
//---------------------------------------------------------------------------
TCollectionAdditionalColumns::TCollectionAdditionalColumns()
{
	f_Collection.SetUpperCase();
}

//--------------------------------------------------------------------------
void TCollectionAdditionalColumns::InitAddOnFields()
{
}

//-----------------------------------------------------------------
int TCollectionAdditionalColumns::BindAddOnFields(int nStartPos /*=0*/)
{
	BEGIN_BIND_ADDON_FIELDS(nStartPos);
		BIND_ADDON_DATA(_NS_FLD("Collection"), f_Collection);
	END_BIND_ADDON_FIELDS();
}