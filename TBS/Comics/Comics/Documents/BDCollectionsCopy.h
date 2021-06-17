
#pragma once

// Library declarations
//NOW INCLUDED IN COMMON PCH: #include <tbges\extdoc.h>
//NOW INCLUDED IN COMMON PCH: #include <tbgeneric\dataobj.h>
//NOW INCLUDED IN COMMON PCH: #include <tbgenlib\messages.h>

#include <Comics\Components\ADMCollectionsCopy.h>
#include "UICollectionsCopy.hjson"

#include "beginh.dex"

class HKLCollections;
class TRCollections;

//=============================================================================
class TB_EXPORT BDCollectionsCopy : public CTBActivityDocument, public ADMCollectionsCopyObj
{
	DECLARE_DYNCREATE(BDCollectionsCopy)

public:
	BDCollectionsCopy();

	virtual	ADMObj*	GetADM		    () { return this; }

public:
	virtual	BOOL	InitDocument	();
	virtual void	DeleteContents	();   

protected:
	virtual void OnBatchExecute			();
	virtual BOOL OnAttachData 			();
	virtual void DisableControlsForBatch();

private:
	BOOL Execute			();
	BOOL CreateNewCollection		();
	void UpdateStateProc			(CString strMsg, BOOL bClear = TRUE);


protected:	
	//{{AFX_MSG(BDCollectionsCopy)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

public:
	DataStr					m_NewCollection;
	DataStr					m_OldCollection;
	DataBool				m_bSetNewDisabled;
 	BOOL					m_bExecuting;
	TRCollections			m_TRCollections;
};

#include "endh.dex"
