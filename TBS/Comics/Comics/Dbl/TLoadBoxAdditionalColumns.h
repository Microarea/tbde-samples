#pragma once

#include <Inventory\Dbl\TInventoryReasons.h>

#include "beginh.dex"

/////////////////////////////////////////////////////////////////////////////
//	SqlRecord					### TLoadBoxAdditionalColumns.h ###	
/////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////

class TB_EXPORT TLoadBoxAdditionalColumns: public SqlAddOnFieldsColumn
{
	DECLARE_DYNCREATE(TLoadBoxAdditionalColumns)

public:
	DataBool f_LoadBox;

public:
	TLoadBoxAdditionalColumns();

public:   
	virtual void InitAddOnFields();
	virtual int	 BindAddOnFields(int nStartPos =0);

};
#include "endh.dex"