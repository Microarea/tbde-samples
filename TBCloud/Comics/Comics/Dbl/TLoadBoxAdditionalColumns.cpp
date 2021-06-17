
#include "stdafx.h"  

// Database declarations
#include <Comics\Dbl\TLoadBoxAdditionalColumns.h>  

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


//////////////////////////////////////////////////////////////////////////////
//             		TLoadBoxAdditionalColumns Implementation
//////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------
IMPLEMENT_DYNCREATE(TLoadBoxAdditionalColumns, SqlAddOnFieldsColumn) 
//---------------------------------------------------------------------------
TLoadBoxAdditionalColumns::TLoadBoxAdditionalColumns()
{
}

//--------------------------------------------------------------------------
void TLoadBoxAdditionalColumns::InitAddOnFields()
{
}

//-----------------------------------------------------------------
int TLoadBoxAdditionalColumns::BindAddOnFields(int nStartPos /*=0*/)
{
	BEGIN_BIND_ADDON_FIELDS(nStartPos);
		BIND_ADDON_DATA (_NS_FLD("ComicsLoadBox"), f_LoadBox);
	END_BIND_ADDON_FIELDS();
}