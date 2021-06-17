//=============================================================================
// module name  : DCollections.h
//=============================================================================
#pragma once

//dbl
#include <Comics\Dbl\TCollections.h>

//components
#include <Comics\Components\ADMCollections.h>

#include "beginh.dex"

class DBTCollections;
class DCollections;

//////////////////////////////////////////////////////////////////////////////
//             DBTCollections class declaration
//////////////////////////////////////////////////////////////////////////////
//
//============================================================================
class TB_EXPORT DBTCollections : public DBTMaster
{ 
	DECLARE_DYNAMIC(DBTCollections)

public:
	DBTCollections(CRuntimeClass*, CAbstractFormDoc*);

public:
	TCollections*	GetCollections			() const { return (TCollections*)GetRecord(); }
	DCollections*	GetDocument				() const { return (DCollections*)m_pDocument; }

protected:
 	virtual	void	OnDefineQuery			();
	virtual	void	OnPrepareQuery			();
	virtual	void	OnPrepareBrowser 		(SqlTable*);
	virtual	void	OnPrepareFindQuery 		(SqlTable*);

protected:
	virtual	BOOL	OnCheckPrimaryKey		();
	virtual	void	OnPreparePrimaryKey		();
	virtual	void	OnEnableControlsForFind	();
	virtual void	OnDisableControlsForEdit();
};

///////////////////////////////////////////////////////////////////////////////
//							DCollections
///////////////////////////////////////////////////////////////////////////////
//
class TB_EXPORT DCollections : public CAbstractFormDoc, public ADMCollectionsObj
{ 
	DECLARE_DYNCREATE(DCollections)

	virtual	ADMObj*	GetADM () 	{ return this; }

public: 
	DCollections(); 
	~DCollections();

public:
	DBTCollections*	m_pDBTCollections;

public:
    virtual DBTCollections*	GetDBTMaster	()	const { return m_pDBTCollections; }
    virtual TCollections*	GetCollections	()	const { return m_pDBTCollections->GetCollections(); }

public:	
	BOOL	CollectionsStillInUse		(const DataStr& sCollections);

public:	
	virtual BOOL	OnAttachData		();
	virtual BOOL	OnInitAuxData		();
	virtual BOOL	OnPrepareAuxData	();
	virtual BOOL	OnOkTransaction		();
	virtual BOOL	OnOkDelete			();
	
protected:	
	//{{AFX_MSG(DCollections)
	afx_msg void	OnDisabledChanged	();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#include "endh.dex"
