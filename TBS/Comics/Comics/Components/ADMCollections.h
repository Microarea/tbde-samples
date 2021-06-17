
#pragma once

//NOW INCLUDED IN COMMON PCH: #include <tbges\extdoc.h>

#include <Comics\Dbl\TCollections.h>

#include "beginh.dex"

/////////////////////////////////////////////////////////////////////////////
//							ADMCollectionsObj
/////////////////////////////////////////////////////////////////////////////
//
class TB_EXPORT ADMCollectionsObj : public ADMObj
{     
	DECLARE_ADMCLASS(ADMCollectionsObj)
		
public:
	virtual	ADMObj*			GetADM			()			= 0;
	virtual	TCollections*	GetCollections	()	const	= 0;
};

#include "endh.dex"