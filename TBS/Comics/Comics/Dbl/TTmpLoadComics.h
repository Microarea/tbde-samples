
#pragma once

#include "beginh.dex"

/////////////////////////////////////////////////////////////////////////////
//					class TTmpLoadComics definition
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
class TB_EXPORT TTmpLoadComics : public SqlRecord
{
	DECLARE_DYNCREATE(TTmpLoadComics) 

public:
	DataLng		f_EntryId;
	DataLng		f_SubId;
	DataStr		f_BoxNo;
	DataStr		f_Item;
	DataStr		f_Description;
	DataStr		f_Collection;
	DataDate	f_InvEntryDate;

public:
	TTmpLoadComics(BOOL bCallInit = TRUE);

public:
	virtual void	BindRecord	();	

public:
	static  LPCTSTR  GetStaticName();
};

/////////////////////////////////////////////////////////////////////////////
//						class TUTmpLoadComics definition
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
class TB_EXPORT TUTmpLoadComics : public TableUpdater
{
	DECLARE_DYNAMIC(TUTmpLoadComics)
	
public:
	DataLng m_EntryId;
	DataLng m_SubId;
	DataStr m_BoxNo;
	
public:
	TUTmpLoadComics (CAbstractFormDoc* pDocument = NULL, CMessages* pMessages = NULL);

protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();

public:
	FindResult FindRecord(const DataLng& aEntryId, const DataLng& aSubId, const DataStr& aBoxNo, BOOL bLock = FALSE);
	TTmpLoadComics* GetRecord() const
		{
			ASSERT_KINDOF(TTmpLoadComics, m_pRecord);
			return (TTmpLoadComics*) m_pRecord;
		}
};

/////////////////////////////////////////////////////////////////////////////
//	TableReader					### TRTmpLoadComics ###	
/////////////////////////////////////////////////////////////////////////////

class TB_EXPORT TRTmpLoadComics : public TableReader
{
	DECLARE_DYNAMIC(TRTmpLoadComics)
	
public:
	DataStr m_Item;
	DataStr	m_BoxNo;
	
public:
	TRTmpLoadComics (CAbstractFormDoc* pDocument = NULL);
		
protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();

public:	
	FindResult	FindRecord(const DataStr& aItem, const DataStr& aBoxNo);
	
	TTmpLoadComics* GetRecord() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TTmpLoadComics)));
			return (TTmpLoadComics*) m_pRecord;
		}
};

/////////////////////////////////////////////////////////////////////////////
//							RUTmpLoadComics
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT RUTmpLoadComics : public RowsetUpdater
{
	DECLARE_DYNAMIC(RUTmpLoadComics)
	
public:
	DataLng m_EntryId;
	DataLng m_SubId;
	
public:
	RUTmpLoadComics (CAbstractFormDoc* pDocument = NULL, CMessages* pMessages = NULL);

public:
	// local useful function
	FindResult	FindRecord(const DataLng& aEntryId, const DataLng& aSubId, BOOL bLock = FALSE);
							
	TTmpLoadComics* GetRecord		() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TTmpLoadComics)));
			return (TTmpLoadComics*) m_pRecord;
		}

protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();
};

#include "endh.dex"
