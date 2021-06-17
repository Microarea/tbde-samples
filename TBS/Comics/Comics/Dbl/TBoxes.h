
#pragma once

#include "beginh.dex"

/////////////////////////////////////////////////////////////////////////////
//	SqlRecord					### TBoxes ###	
/////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT TBoxes : public SqlRecord
{
	DECLARE_DYNCREATE(TBoxes) 

public:
	DataStr		f_BoxNo;
	DataDate	f_CreationDate;
	DataDate	f_ClosingDate;
	DataBool	f_IsClosed;
	DataStr		f_LastName;
	DataStr		f_Name;
	DataStr		f_Telephone1;
	DataStr		f_Telephone2;
	DataStr		f_Mail;
	DataPerc	f_Discount;
	DataStr		f_Notes;

	DataStr		l_BmpStatusBox;
	
public:
	TBoxes(BOOL bCallInit = TRUE);

public:
    virtual void	BindRecord();
		
public:
	static  LPCTSTR  GetStaticName();
};

/////////////////////////////////////////////////////////////////////////////
//	SqlRecord					### TBoxCollections ###	
/////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT TBoxCollections : public SqlRecord
{
	DECLARE_DYNCREATE(TBoxCollections) 

public:
	DataStr		f_BoxNo;
	DataStr		f_Collection;
	DataDate	f_CreationDate;
	DataStr		f_FromNumber;
	DataStr		f_LastReceiptNumber;
	DataStr		f_LastIssuedNumber;
	DataDate	f_LastReceiptDate;
	DataDate	f_LastIssuedDate;
	DataDate	f_ClosingDate;
	DataBool	f_IsClosed;
	DataStr		f_Notes;

	DataStr		l_CollectionDescri;
	
public:
	TBoxCollections(BOOL bCallInit = TRUE);

public:
    virtual void	BindRecord();
		
public:
	static  LPCTSTR  GetStaticName();
};

/////////////////////////////////////////////////////////////////////////////
//	SqlRecord					### TBoxEntries ###	
/////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT TBoxEntries : public SqlRecord
{
	DECLARE_DYNCREATE(TBoxEntries) 

public:
	DataStr		f_BoxNo;
	DataStr		f_Item;
	DataDate	f_ReceiptDate;

	DataStr		l_ItemDescri;

public:
	TBoxEntries(BOOL bCallInit = TRUE);

public:
    virtual void	BindRecord();
		
public:
	static  LPCTSTR  GetStaticName();
};

/////////////////////////////////////////////////////////////////////////////
//			class  TEnhBoxesSelection definition		
/////////////////////////////////////////////////////////////////////////////
//
//==========================================================================
class TB_EXPORT TEnhBoxesSelection : public TBoxes
{
	DECLARE_DYNCREATE(TEnhBoxesSelection) 
	
public:
	DataBool	l_IsSelected;
	DataStr		l_CollectionNotes;
	DataDate	l_CollectionCreationDate;

	DataStr		l_Item;
	DataStr		l_Collection;
	DataDate	l_LoadingDate;

public:
	TEnhBoxesSelection(BOOL bCallInit = TRUE);
	
public:
    virtual void	BindRecord	();	
};

/////////////////////////////////////////////////////////////////////////////
//	TableReader					### TRBoxes ###	
/////////////////////////////////////////////////////////////////////////////
//
class TB_EXPORT TRBoxes : public TableReader
{
	DECLARE_DYNAMIC(TRBoxes)
	
public:
	DataStr	m_BoxNo;
	
public:
	TRBoxes (CAbstractFormDoc* pDocument = NULL);
		
protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();

public:	
	FindResult	FindRecord(const DataStr& aBoxNo);
	
	TBoxes* GetRecord() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TBoxes)));
			return (TBoxes*) m_pRecord;
		}
};

/////////////////////////////////////////////////////////////////////////////
//	TableReader					### TRBoxesLastName ###	
/////////////////////////////////////////////////////////////////////////////
//
class TB_EXPORT TRBoxesLastName : public TableReader
{
	DECLARE_DYNAMIC(TRBoxesLastName)
	
public:
	DataStr	m_BoxNo;
	DataStr	m_LastName;
	
public:
	TRBoxesLastName (CAbstractFormDoc* pDocument = NULL);
		
protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();

public:	
	FindResult	FindRecord(const DataStr& aBoxNo, const DataStr& aLastName);
	
	TBoxes* GetRecord() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TBoxes)));
			return (TBoxes*) m_pRecord;
		}
};

/////////////////////////////////////////////////////////////////////////////
//	TableReader					### TRBoxEntries ###	
/////////////////////////////////////////////////////////////////////////////
//
class TB_EXPORT TRBoxEntries : public TableReader
{
	DECLARE_DYNAMIC(TRBoxEntries)
	
public:
	DataStr	m_BoxNo;
	DataStr	m_Item;
	
public:
	TRBoxEntries (CAbstractFormDoc* pDocument = NULL);
		
protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();

public:	
	FindResult	FindRecord(const DataStr& aBoxNo, const DataStr& aItem);
	
	TBoxEntries* GetRecord() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TRBoxEntries)));
			return (TBoxEntries*) m_pRecord;
		}
};

/////////////////////////////////////////////////////////////////////////////
//						class TUBoxCollections definition
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
class TB_EXPORT TUBoxCollections : public TableUpdater
{
	DECLARE_DYNAMIC(TUBoxCollections)
	
public:
	DataStr m_BoxNo;
	DataStr m_Collection;
	
public:
	TUBoxCollections (CAbstractFormDoc* pDocument = NULL, CMessages* pMessages = NULL);

protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();

public:
	FindResult FindRecord(const DataStr& aBoxNo, const DataStr& aCollection, BOOL bLock = FALSE);
	TBoxCollections* GetRecord() const
		{
			ASSERT_KINDOF(TBoxCollections, m_pRecord);
			return (TBoxCollections*) m_pRecord;
		}
};

/////////////////////////////////////////////////////////////////////////////
//						class TUBoxEntries definition
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
class TB_EXPORT TUBoxEntries : public TableUpdater
{
	DECLARE_DYNAMIC(TUBoxEntries)
	
public:
	DataStr m_BoxNo;
	DataStr m_Item;
	
public:
	TUBoxEntries (CAbstractFormDoc* pDocument = NULL, CMessages* pMessages = NULL);

protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();

public:
	FindResult FindRecord(const DataStr& aBoxNo, const DataStr& aItem, BOOL bLock = FALSE);
	TBoxEntries* GetRecord() const
		{
			ASSERT_KINDOF(TBoxEntries, m_pRecord);
			return (TBoxEntries*) m_pRecord;
		}
};

/////////////////////////////////////////////////////////////////////////////
//							RRBoxesLastName
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT RRBoxesLastName : public RowsetReader
{
	DECLARE_DYNAMIC(RRBoxesLastName)
	
public:
	DataStr m_LastName;
	
public:
	RRBoxesLastName (CAbstractFormDoc* pDocument = NULL);

public:
	// local useful function
	FindResult	FindRecord(const DataStr& aLastName);
							
	TBoxes* GetRecord		() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TBoxes)));
			return (TBoxes*) m_pRecord;
		}

protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();
};

/////////////////////////////////////////////////////////////////////////////
//							RRBoxEntries
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT RRBoxEntries : public RowsetReader
{
	DECLARE_DYNAMIC(RRBoxEntries)
	
public:
	DataStr m_BoxNo;
	
public:
	RRBoxEntries (CAbstractFormDoc* pDocument = NULL);

public:
	// local useful function
	FindResult	FindRecord(const DataStr& aBoxNo);
							
	TBoxEntries* GetRecord		() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TBoxEntries)));
			return (TBoxEntries*) m_pRecord;
		}

protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();
};

/////////////////////////////////////////////////////////////////////////////
//	Hotlink						### HKLBoxes ###		
/////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT HKLBoxes : public HotKeyLink
{
	DECLARE_DYNCREATE (HKLBoxes)

public:
	enum SelectionDisable { ACTIVE, DISABLE, BOTH };

protected:
	SelectionDisable    m_SelectionDisable;

public:
	HKLBoxes();

public:
    void SetSelDisable	    (SelectionDisable   SelectionDisable)	{ m_SelectionDisable = SelectionDisable; 	}

// implementation
private:
	void DefineDisable ();
	void PrepareDisable();

protected:
	virtual void		OnDefineQuery	(SelectionType nQuerySelection = DIRECT_ACCESS);
	virtual void		OnPrepareQuery	(DataObj*, SelectionType nQuerySelection = DIRECT_ACCESS);
	virtual DataObj*	GetDataObj		() const { return &(GetRecord()->f_BoxNo); };
	virtual BOOL		IsValid			();
	virtual	BOOL		Customize		(const DataObjArray&);
	
public:
	TBoxes* 	GetRecord 		() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TBoxes)));
			return (TBoxes*) m_pRecord;
		}
};

#include "endh.dex"