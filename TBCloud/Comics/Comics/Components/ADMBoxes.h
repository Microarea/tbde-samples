
#pragma once

//NOW INCLUDED IN COMMON PCH: #include <tbges\extdoc.h>

#include <Comics\Dbl\TBoxes.h>

#include "beginh.dex"

/////////////////////////////////////////////////////////////////////////////
//							ADMBoxesObj
/////////////////////////////////////////////////////////////////////////////
//
class TB_EXPORT ADMBoxesObj : public ADMObj
{     
	DECLARE_ADMCLASS(ADMBoxesObj)
		
public:
	virtual	ADMObj*	GetADM		()			= 0;
	virtual	TBoxes*	GetBoxes	()	const	= 0;
};

#include "endh.dex"