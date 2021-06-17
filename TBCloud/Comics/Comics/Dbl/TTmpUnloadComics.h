
#pragma once

#include "beginh.dex"

/////////////////////////////////////////////////////////////////////////////
//					class TTmpUnloadComics definition
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
class TB_EXPORT TTmpUnloadComics : public SqlRecord
{
	DECLARE_DYNCREATE(TTmpUnloadComics) 

public:
	DataLng		f_Document_Id;
	DataInt		f_Line;
	DataStr		f_BoxNo;
	DataLng		f_SubId;
	DataStr		f_LastName;
	DataStr		f_Name;
	DataStr		f_Item;
	DataStr		f_Collection;
	DataDate	f_ReceiptDate;

public:
	TTmpUnloadComics(BOOL bCallInit = TRUE);

public:
	virtual void	BindRecord	();	

public:
	static  LPCTSTR  GetStaticName();
};

/////////////////////////////////////////////////////////////////////////////
//						class TUTmpUnloadComics definition
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
class TB_EXPORT TUTmpUnloadComics : public TableUpdater
{
	DECLARE_DYNAMIC(TUTmpUnloadComics)
	
public:
	DataLng m_Document_Id;
	DataStr m_BoxNo;
	DataStr m_Item;
	
public:
	TUTmpUnloadComics (CAbstractFormDoc* pDocument = NULL, CMessages* pMessages = NULL);

protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();

public:
	FindResult FindRecord(const DataLng& aDocument_Id, const DataStr& aBoxNo, const DataStr& aItem, BOOL bLock = FALSE);
	TTmpUnloadComics* GetRecord() const
		{
			ASSERT_KINDOF(TTmpUnloadComics, m_pRecord);
			return (TTmpUnloadComics*) m_pRecord;
		}
};

/////////////////////////////////////////////////////////////////////////////
//	TableReader					### TRTmpUnloadComics ###	
/////////////////////////////////////////////////////////////////////////////

class TB_EXPORT TRTmpUnloadComics : public TableReader
{
	DECLARE_DYNAMIC(TRTmpUnloadComics)
	
public:
	DataStr m_Item;
	DataStr	m_BoxNo;
	
public:
	TRTmpUnloadComics (CAbstractFormDoc* pDocument = NULL);
		
protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();

public:	
	FindResult	FindRecord(const DataStr& aItem, const DataStr& aBoxNo);
	
	TTmpUnloadComics* GetRecord() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TTmpUnloadComics)));
			return (TTmpUnloadComics*) m_pRecord;
		}
};

/////////////////////////////////////////////////////////////////////////////
//	TableReader					### TRTmpUnloadComicsByDocIdSubId ###	
/////////////////////////////////////////////////////////////////////////////

class TB_EXPORT TRTmpUnloadComicsByDocIdSubId : public TableReader
{
	DECLARE_DYNAMIC(TRTmpUnloadComicsByDocIdSubId)
	
public:
	DataLng m_Document_Id;
	DataLng	m_SubId;
	
public:
	TRTmpUnloadComicsByDocIdSubId (CAbstractFormDoc* pDocument = NULL);
		
protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();

public:	
	FindResult	FindRecord(const DataLng& aDocument_Id, const DataLng& aSubId);
	
	TTmpUnloadComics* GetRecord() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TTmpUnloadComics)));
			return (TTmpUnloadComics*) m_pRecord;
		}
};

/////////////////////////////////////////////////////////////////////////////
//							RUTmpUnloadComics
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT RUTmpUnloadComics : public RowsetUpdater
{
	DECLARE_DYNAMIC(RUTmpUnloadComics)
	
public:
	DataLng	m_Document_Id;
	DataLng	m_SubId;
	
public:
	RUTmpUnloadComics (CAbstractFormDoc* pDocument = NULL, CMessages* pMessages = NULL);

public:
	// local useful function
	FindResult	FindRecord(const DataLng& aDocument_Id, const DataLng& aSubId, BOOL bLock = FALSE);
							
	TTmpUnloadComics* GetRecord		() const
		{
			ASSERT(m_pRecord->IsKindOf(RUNTIME_CLASS(TTmpUnloadComics)));
			return (TTmpUnloadComics*) m_pRecord;
		}

protected:
	virtual void	OnDefineQuery	();
	virtual void	OnPrepareQuery	();
	virtual BOOL 	IsEmptyQuery	();
};

#include "endh.dex"