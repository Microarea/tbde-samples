
#pragma once

//NOW INCLUDED IN COMMON PCH: #include <tbges\extdoc.h>

#include <Comics\Dbl\TCollections.h>

#include "beginh.dex"

/////////////////////////////////////////////////////////////////////////////
//							ADMCollectionsCopyObj
/////////////////////////////////////////////////////////////////////////////
//
class TB_EXPORT ADMCollectionsCopyObj : public ADMObj
{     
	DECLARE_ADMCLASS(ADMCollectionsCopyObj)
		
public:
	virtual	ADMObj*			GetADM			()			= 0;
};

#include "endh.dex"