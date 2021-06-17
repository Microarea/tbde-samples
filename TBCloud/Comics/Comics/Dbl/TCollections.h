
#pragma once

//NOW INCLUDED IN COMMON PCH: #include <TbGeneric\DataObj.h>

//NOW INCLUDED IN COMMON PCH: #include <tboledb\sqlrec.h>

//NOW INCLUDED IN COMMON PCH: #include <tbges\hotlink.h>
//NOW INCLUDED IN COMMON PCH: #include <tbges\tblread.h>
//NOW INCLUDED IN COMMON PCH: #include <tbges\tblupdat.h>

#include "beginh.dex"

/////////////////////////////////////////////////////////////////////////////
//	SqlRecord					### TCollections ###	
/////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT TCollections : public SqlRecord
{
	DECLARE_DYNCREATE(TCollections) 

public:
	DataStr		f_Collection;
	DataStr		f_Description;
	DataStr		f_Notes;
	DataBool	f_Disabled;
	
public:
	TCollections(BOOL bCallInit = TRUE);

public:
    virtual void	BindRecord();
		
public:
	static  LPCTSTR  GetStaticName();
};

/////////////////////////////////////////////////////////////////////////////
//	Hotlink						### HKLCollections ###		
/////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT HKLCollections : public HotKeyLink
{
	DECLARE_DYNCREATE (HKLCollections)

public:
	enum SelectionDisable { ACTIVE, DISABLE, ALL};

protected:
	SelectionDisable    m_SelectionDisable;

public:
	HKLCollections();

public:
    void SetSelDisable	    (SelectionDisable   SelectionDisable)	{ m_SelectionDisable = SelectionDisable; 	}

// implementation
private:
	void DefineDisable ();
	void PrepareDisable();

protected:
	virtual void		OnDefineQuery	(SelectionType nQuerySelection = DIRECT_ACCESS);
	virtual void		OnPrepareQuery	(DataObj*, SelectionType nQuerySelection = DIRECT_ACCESS);
	virtual DataObj*	GetDataObj		() const { return &(GetRecord()->f_Collection); };
	virtual BOOL		IsValid			();
	
public:
	TCollections* 	GetRecord 		() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TCollections)));
			return (TCollections*) m_pRecord;
		}
};
/////////////////////////////////////////////////////////////////////////////
//	TableReader					### TRCollections ###	
/////////////////////////////////////////////////////////////////////////////
//
class TB_EXPORT TRCollections : public TableReader
{
	DECLARE_DYNAMIC(TRCollections)

public:
	DataStr	m_Collection;

public:
	TRCollections(CAbstractFormDoc* pDocument = NULL);

protected:
	virtual void	OnDefineQuery();
	virtual void	OnPrepareQuery();
	virtual BOOL 	IsEmptyQuery();

public:
	FindResult	FindRecord(const DataStr& aBoxNo);

	TCollections* GetRecord() const
	{
		ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TCollections)));
		return (TCollections*)m_pRecord;
	}
};


#include "endh.dex"
