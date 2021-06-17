//=============================================================================
// Module name  : ComicsDocumentsInterface.cpp
//=============================================================================

#include "stdafx.h" 
#include "DCollections.h"
#include "UICollections.hjson"
#include "DBoxes.h"
#include "UIBoxes.hjson"
#include "BDCollectionsCopy.h"
#include "UICollectionsCopy.hjson"
#include "BDBoxesCopy.h"
#include "UIBoxesCopy.hjson"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define _AddOn_Interface_Of comicsdocuments

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
	BEGIN_DOCUMENT(_NS_DOC("Collections"), TPL_NO_PROTECTION)
	REGISTER_MASTER_JSON_TEMPLATE(szDefaultViewMode, DCollections, IDD_COLLECTIONS)
	REGISTER_BKGROUND_TEMPLATE(szBackgroundViewMode, DCollections)
	END_DOCUMENT()

	BEGIN_DOCUMENT(_NS_DOC("Boxes"), TPL_NO_PROTECTION)
	REGISTER_MASTER_JSON_TEMPLATE(szDefaultViewMode, DBoxes, IDD_BOXES)
	REGISTER_BKGROUND_TEMPLATE(szBackgroundViewMode, DBoxes)
	END_DOCUMENT()

	BEGIN_DOCUMENT(_NS_DOC("CollectionsCopy"), TPL_NO_PROTECTION)
	REGISTER_MASTER_JSON_TEMPLATE(szDefaultViewMode, BDCollectionsCopy, IDD_COLLECTIONS_COPY)
	REGISTER_BKGROUND_TEMPLATE(szBackgroundViewMode, BDCollectionsCopy)
	END_DOCUMENT()


	//BEGIN_DOCUMENT(_NS_DOC("BoxesCopy"), TPL_NO_PROTECTION)
	//REGISTER_MASTER_JSON_TEMPLATE(szDefaultViewMode, BDBoxesCopy, IDD_BOXESCOPY)
	//REGISTER_BKGROUND_TEMPLATE(szBackgroundViewMode, BDBoxesCopy)
	//END_DOCUMENT()

	END_TEMPLATE()

	//-----------------------------------------------------------------------------
	BEGIN_CLIENT_DOC()
	END_CLIENT_DOC()

END_ADDON_INTERFACE()

#undef _AddOn_Interface_Of