#pragma once

#include <Items\Dbl\TItem.h>

#include "beginh.dex"

/////////////////////////////////////////////////////////////////////////////
//	SqlRecord					### TCollectionAdditionalColumns.h ###	
/////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////

class TB_EXPORT TCollectionAdditionalColumns: public SqlAddOnFieldsColumn
{
	DECLARE_DYNCREATE(TCollectionAdditionalColumns)

public:
	DataStr f_Collection;

public:
	TCollectionAdditionalColumns();

public:   
	virtual void InitAddOnFields();
	virtual int	 BindAddOnFields(int nStartPos =0);

};
#include "endh.dex"