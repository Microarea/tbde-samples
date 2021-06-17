
#pragma once

//ERP
#include <Sales\Documents\DReceipt.h>
#include <Items\Components\ItemsAdditional.h>

//Dbl
#include <Comics\Dbl\TTmpUnloadComics.h>
#include <Comics/Dbl/TBoxes.h>

#include "beginh.dex"

class RUTmpUnloadComics;
class TUTmpUnloadComics;
class TRItems;
class TRBoxes;
class TRBoxesLastName;
class RRBoxesLastName;
class TRTmpUnloadComics;
class RRBoxEntries;
class TRTmpUnloadComicsByDocIdSubId;

/////////////////////////////////////////////////////////////////////////////
//					class DBTComicsToBeDelivered definition
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
class TB_EXPORT DBTComicsToBeDelivered : public DBTSlaveBuffered
{ 
	DECLARE_DYNAMIC (DBTComicsToBeDelivered)

public:
	DBTComicsToBeDelivered (CRuntimeClass* pClass, CAbstractFormDoc* pDocument);

public:
	TEnhBoxesSelection*	GetComicsToBeDelivered			()			const { return (TEnhBoxesSelection*) GetRecord(); }
	TEnhBoxesSelection*	GetComicsToBeDelivered			(int nRow)	const { return (TEnhBoxesSelection*) GetRow(nRow); }
	TEnhBoxesSelection*	GetCurrentComicsToBeDeliveredn	()			const { return (TEnhBoxesSelection*) GetCurrentRow(); }

protected:
	virtual	void		OnDefineQuery					();
	virtual	void		OnPrepareQuery					();
	
	virtual DataObj*	OnCheckPrimaryKey				(int /*nRow*/, SqlRecord*);
	virtual void		OnPreparePrimaryKey				(int /*nRow*/, SqlRecord*);
};

//////////////////////////////////////////////////////////////////////////////
//             			CDComicsReceipt
//////////////////////////////////////////////////////////////////////////////
//
class CDComicsReceipt : public CClientDoc
{
protected:
	DECLARE_DYNCREATE(CDComicsReceipt)

public:
	CDComicsReceipt();
	~CDComicsReceipt();

public:
	DBTComicsToBeDelivered*			m_pDBTVirtualComicsToBeDelivered;	// Dato membro che punta al DBT corrispondente, che viene 
																		// ISTANZIATO e attaccato al MASTER nel metodo OnAttachData
	TRItems*						m_pTRItems;
	TRBoxes*						m_pTRBoxes;
	TRBoxesLastName*				m_pTRBoxesLastName;
	TRTmpUnloadComics*				m_pTRTmpUnloadComics;
	TRTmpUnloadComicsByDocIdSubId*	m_pTRTmpUnloadComicsByDocIdSubId;
	TUBoxEntries*					m_pTUBoxEntries;
	TUBoxCollections*				m_pTUBoxCollections;
	TUTmpUnloadComics*				m_pTUTmpUnloadComics;
	RRBoxEntries*					m_pRRBoxEntries;
	RRBoxesLastName*				m_pRRBoxesLastName;
	RUTmpUnloadComics*				m_pRUTmpUnloadComics;
	TTmpUnloadComics				m_TTmpUnloadComics;
	
	DataStr							m_nFilterBoxNo;

private:
	DReceipt* GetServerDoc() const 
		{
			ASSERT(m_pServerDocument && m_pServerDocument->IsKindOf(RUNTIME_CLASS(DReceipt))); 
			return (DReceipt*) m_pServerDocument;
		}

public:
	DReceipt* GetDocument() const { return (DReceipt*) GetServerDoc();}

protected:
	virtual void Customize						();
	virtual BOOL OnInitAuxData					();
	virtual BOOL OnAttachData					();
	virtual void OnBeforeCloseDocument			();
	virtual BOOL OnBeforeDeleteRow				(DBTSlaveBuffered*, int /*nRow*/);
	virtual	BOOL OnOkTransaction				();
	virtual	BOOL OnExtraNewTransaction			();

public: 
	DataStr ExtrapolateCollection				(DataStr aItem);
	BOOL	IsItemCollectionEntered				();
	void	OpenBoxesFilterView					();
	void	OpenComicsToBeDeliveredView			();
	void	ManageReadOnly						();
	void	SaveTmpRecordsAndLoadReceiptLines	();
	void	OnResearchComics					();
	void	OnEnd();
	BOOL	DeleteTmpRecords					();
	BOOL	UpdateBoxes							();
	DataStr	ExtrapolateComicsNo					(DataStr aItem);
	BOOL	ChangeQty							();
	BOOL	CheckFilterBoxNo					();

public:	
	//{{AFX_MSG(CDComicsReceipt)
	afx_msg void OnEnableResearchComics			(CCmdUI* pCmdUI );
	afx_msg void OnOpenFilterSlaveView			();
	afx_msg void OnEscape						();
	afx_msg void OnQtyBEChanged					();
	afx_msg void OnQtyRWChanged					();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#include "endh.dex"
