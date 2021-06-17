//=============================================================================
// module name  : DBoxes.h
//=============================================================================
#pragma once

#include <TbGeneric\dibitmap.h>

//dbl
#include <Comics\Dbl\TBoxes.h>

//components
#include <Comics\Components\ADMBoxes.h>

#include "beginh.dex"

class DBTBoxes;
class DBoxes;

//////////////////////////////////////////////////////////////////////////////
//             DBTBoxes class declaration
//////////////////////////////////////////////////////////////////////////////
//
//============================================================================
class TB_EXPORT DBTBoxes : public DBTMaster
{ 
	DECLARE_DYNAMIC(DBTBoxes)

public:
	DBTBoxes(CRuntimeClass*, CAbstractFormDoc*);

public:
	TBoxes*	GetBoxes	() const { return (TBoxes*)GetRecord(); }
	DBoxes*	GetDocument	() const { return (DBoxes*)m_pDocument; }

protected:
 	virtual	void	OnDefineQuery				();
	virtual	void	OnPrepareQuery				();
	virtual	void	OnPrepareBrowser 			(SqlTable*);
	virtual	void	OnPrepareFindQuery 			(SqlTable*);

protected:
	virtual	BOOL	OnCheckPrimaryKey			();
	virtual	void	OnPreparePrimaryKey			();
	virtual	void	OnEnableControlsForFind		();
	virtual void	OnDisableControlsForAddNew	();
	virtual void	OnDisableControlsForEdit	();
};

/////////////////////////////////////////////////////////////////////////////
//					class DBTBoxCollections definition
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
class TB_EXPORT DBTBoxCollections : public DBTSlaveBuffered
{ 
	DECLARE_DYNAMIC (DBTBoxCollections)

public:
	DBTBoxCollections (CRuntimeClass* pClass, CAbstractFormDoc* pDocument);

public:
	TBoxes*				GetMasterRecord			()			const { return (TBoxes*) m_pDBTMaster->GetRecord(); }
	DBoxes*				GetDocument				()			const { return (DBoxes*) m_pDocument; }
	TBoxCollections*	GetBoxCollections		()			const { return (TBoxCollections*) GetRecord(); }
	TBoxCollections*	GetBoxCollections		(int nRow)	const { return (TBoxCollections*) GetRow(nRow); }
	TBoxCollections*	GetCurrentBoxCollections()			const { return (TBoxCollections*) GetCurrentRow(); }

protected:
	virtual	void		OnDefineQuery			();
	virtual	void		OnPrepareQuery			();
	virtual DataObj*	OnCheckPrimaryKey		(int /*nRow*/, SqlRecord*);
	virtual	void		OnPreparePrimaryKey		(int /*nRow*/, SqlRecord*);
	virtual CString		GetDuplicateKeyMsg		(SqlRecord*);
	virtual DataObj*	GetDuplicateKeyPos		(SqlRecord*);
};

/////////////////////////////////////////////////////////////////////////////
//					class DBTBoxEntries definition
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
class TB_EXPORT DBTBoxEntries : public DBTSlaveBuffered
{ 
	DECLARE_DYNAMIC (DBTBoxEntries)

public:
	DBTBoxEntries (CRuntimeClass* pClass, CAbstractFormDoc* pDocument);

public:
	TBoxes*			GetMasterRecord			()			const { return (TBoxes*) m_pDBTMaster->GetRecord(); }
	DBoxes*			GetDocument				()			const { return (DBoxes*) m_pDocument; }
	TBoxEntries*	GetBoxEntries			()			const { return (TBoxEntries*) GetRecord(); }
	TBoxEntries*	GetBoxEntries			(int nRow)	const { return (TBoxEntries*) GetRow(nRow); }
	TBoxEntries*	GetCurrentBoxEntries	()			const { return (TBoxEntries*) GetCurrentRow(); }

protected:
	virtual	void		OnDefineQuery		();
	virtual	void		OnPrepareQuery		();
	virtual void		OnPrepareAuxColumns	(SqlRecord*);
	virtual DataObj*	OnCheckPrimaryKey	(int /*nRow*/, SqlRecord*);
	virtual	void		OnPreparePrimaryKey	(int /*nRow*/, SqlRecord*);
	virtual CString		GetDuplicateKeyMsg	(SqlRecord*);
	virtual DataObj*	GetDuplicateKeyPos	(SqlRecord*);
};

///////////////////////////////////////////////////////////////////////////////
//							DBoxes
///////////////////////////////////////////////////////////////////////////////
//
class TB_EXPORT DBoxes : public CAbstractFormDoc, public ADMBoxesObj
{ 
	DECLARE_DYNCREATE(DBoxes)

	virtual	ADMObj*	GetADM () 	{ return this; }

public: 
	DBoxes(); 
	~DBoxes();

public:
	DataBool						m_bAutoNum;
	DBTBoxes*						m_pDBTBoxes;
	DBTBoxCollections*				m_pDBTBoxCollections;
	DBTBoxEntries*					m_pDBTBoxEntries;
	DataStr							m_ImageBox;

public:
    virtual DBTBoxes*			GetDBTMaster					()			const { return m_pDBTBoxes; }
    virtual TBoxes*				GetBoxes						()			const { return m_pDBTBoxes->GetBoxes(); }
	virtual TBoxCollections*	GetBoxCollections				()			const { return m_pDBTBoxCollections->GetBoxCollections(); }
	virtual TBoxCollections*	GetBoxCollections				(int nRow)	const { return m_pDBTBoxCollections->GetBoxCollections(nRow); }
	virtual TBoxCollections*	GetCurrentBoxCollections		()			const { return m_pDBTBoxCollections->GetCurrentBoxCollections(); }
	virtual TBoxEntries*		GetBoxEntries					()			const { return m_pDBTBoxEntries->GetBoxEntries(); }
	virtual TBoxEntries*		GetBoxEntries					(int nRow)	const { return m_pDBTBoxEntries->GetBoxEntries(nRow); }
	virtual TBoxEntries*		GetCurrentBoxEntries			()			const { return m_pDBTBoxEntries->GetCurrentBoxEntries(); }

public:	
	virtual BOOL				OnInitDocument					();
	virtual BOOL				OnAttachData					();
	virtual BOOL				OnInitAuxData					();
	virtual BOOL				OnPrepareAuxData				();
	virtual BOOL				OnOkTransaction					();
	virtual BOOL				OnOkDelete						();
	
public:
	void						ManageReadOnly					();
	void						ManageBodyEditReadOnly			();
	void						DoIsColsedBoxCollectionChanged	();
	DataStr						GetImageBoxName					();
		
protected:
	virtual void				OnParsedControlCreated			(CParsedCtrl* pCtrl);

protected:	
	//{{AFX_MSG(DBoxes)
	afx_msg void OnIsClosedChanged								();
	afx_msg void OnIsColsedBoxCollectionChanged					();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#include "endh.dex"
