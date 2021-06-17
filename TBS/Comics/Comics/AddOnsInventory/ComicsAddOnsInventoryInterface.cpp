//=============================================================================
// Module name  : ComicsAddOnsInventoryInterface.cpp
//=============================================================================

#include "stdafx.h" 
#include "CDLoadBoxInventoryEntries.h"
#include "UILoadBoxInventoryEntries.hjson"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define _AddOn_Interface_Of comicsaddonsinventory

/////////////////////////////////////////////////////////////////////////////
//					Add-On Interface Definition
/////////////////////////////////////////////////////////////////////////////
//

//-----------------------------------------------------------------------------
BEGIN_ADDON_INTERFACE()

	//-----------------------------------------------------------------------------
	BEGIN_TABLES()
		BEGIN_REGISTER_TABLES	()
		END_REGISTER_TABLES		()
	END_TABLES()

	//-----------------------------------------------------------------------------
	BEGIN_FUNCTIONS()
	END_FUNCTIONS()

	//-----------------------------------------------------------------------------
	BEGIN_HOTLINK()
	END_HOTLINK ()

	//-----------------------------------------------------------------------------
	BEGIN_TEMPLATE()
	REGISTER_SLAVE_JSON_TEMPLATE(IDD_LOAD_BOX)
	END_TEMPLATE()

	//-----------------------------------------------------------------------------
	BEGIN_CLIENT_DOC()
	WHEN_SERVER_DOC(DInventoryEntries)
	ATTACH_CLIENT_DOC(CDLoadBoxInventoryEntries, _NS_CD("CDLoadBoxInventoryEntries"))
	END_SERVER_DOC()

	END_CLIENT_DOC()

END_ADDON_INTERFACE()

#undef _AddOn_Interface_Of