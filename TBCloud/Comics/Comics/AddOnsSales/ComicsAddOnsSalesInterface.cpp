//=============================================================================
// Module name  : ComicsAddOnsSalesInterface.cpp
//=============================================================================

#include "stdafx.h" 
#include "CDComicsReceipt.h"
#include "UIComicsReceipt.hjson"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define _AddOn_Interface_Of comicsaddonssales

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
	REGISTER_SLAVE_JSON_TEMPLATE(IDD_BOXSELECTION)
	REGISTER_SLAVE_JSON_TEMPLATE(IDD_RECEIPT_COLL)
	END_TEMPLATE()

	//-----------------------------------------------------------------------------
	BEGIN_CLIENT_DOC()
	WHEN_SERVER_DOC(DReceipt)
	ATTACH_CLIENT_DOC(CDComicsReceipt, _NS_CD("CDComicsReceipt"))
	END_SERVER_DOC()

	END_CLIENT_DOC()



END_ADDON_INTERFACE()

#undef _AddOn_Interface_Of