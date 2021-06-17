//=============================================================================
// Module name  : ComicsDblInterface.cpp
//=============================================================================

#include "stdafx.h" 
#include "TCollections.h"
#include "TBoxes.h"
#include "TTmpLoadComics.h"
#include "TTmpUnloadComics.h"
#include "TLoadBoxAdditionalColumns.h"
#include "TCollectionAdditionalColumns.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define _AddOn_Interface_Of comicsdbl

/////////////////////////////////////////////////////////////////////////////
//					Add-On Interface Definition
/////////////////////////////////////////////////////////////////////////////
//

//-----------------------------------------------------------------------------
BEGIN_ADDON_INTERFACE()
	DATABASE_RELEASE(2)

	//-----------------------------------------------------------------------------
	BEGIN_TABLES()
		BEGIN_REGISTER_TABLES	()
			REGISTER_TABLE		(TCollections)
			REGISTER_TABLE		(TBoxes)
			REGISTER_TABLE		(TBoxCollections)
			REGISTER_TABLE		(TBoxEntries)
			REGISTER_TABLE		(TTmpLoadComics)
			REGISTER_TABLE		(TTmpUnloadComics)
		END_REGISTER_TABLES		()
	END_TABLES()

	//-----------------------------------------------------------------------------
	BEGIN_ADDON_NEW_COLUMNS()

	WHEN_TABLE(TInventoryReasons)
	ADDON_COLUMNS_CLASS(TLoadBoxAdditionalColumns)
	END_TABLE

	WHEN_TABLE(TItem)
	ADDON_COLUMNS_CLASS(TCollectionAdditionalColumns)
	END_TABLE

	END_ADDON_NEW_COLUMNS()

	//-----------------------------------------------------------------------------
	BEGIN_FUNCTIONS()
	END_FUNCTIONS()

	//-----------------------------------------------------------------------------
	BEGIN_HOTLINK()
	DECLARE_HOTLINK(HKLBoxes, _NS_HKL("Boxes"))
	DECLARE_HOTLINK(HKLCollections, _NS_HKL("Collections"))
	END_HOTLINK ()

	//-----------------------------------------------------------------------------
	BEGIN_TEMPLATE()
	END_TEMPLATE()

	//-----------------------------------------------------------------------------
	BEGIN_CLIENT_DOC()
	END_CLIENT_DOC()

END_ADDON_INTERFACE()

#undef _AddOn_Interface_Of