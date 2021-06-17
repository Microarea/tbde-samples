
#pragma once

//ERP
#include <Inventory\Documents\DInventoryEntries.h>
#include <Items\Documents\UIItems.h>

//Dbl
#include <Comics\Dbl\TBoxes.h>
#include <Comics\Dbl\TTmpLoadComics.h>

//Documents
#include <Comics\Documents\DBoxes.h>

#include "beginh.dex"

/////////////////////////////////////////////////////////////////////////////
//					class DBTBoxesSelection definition
/////////////////////////////////////////////////////////////////////////////
//
//=============================================================================
class TB_EXPORT DBTBoxesSelection : public DBTSlaveBuffered
{ 
	DECLARE_DYNAMIC (DBTBoxesSelection)

public:
	DBTBoxesSelection (CRuntimeClass* pClass, CAbstractFormDoc* pDocument);

public:
	TEnhBoxesSelection*	GetBoxesSelection		()			const { return (TEnhBoxesSelection*) GetRecord(); }
	TEnhBoxesSelection*	GetBoxesSelection		(int nRow)	const { return (TEnhBoxesSelection*) GetRow(nRow); }
	TEnhBoxesSelection*	GetCurrentBoxesSelection()			const { return (TEnhBoxesSelection*) GetCurrentRow(); }

protected:
	virtual	void		OnDefineQuery			();
	virtual	void		OnPrepareQuery			();
	
	virtual DataObj*	OnCheckPrimaryKey		(int /*nRow*/, SqlRecord*);
	virtual void		OnPreparePrimaryKey		(int /*nRow*/, SqlRecord*);
};

//////////////////////////////////////////////////////////////////////////////
//             			CDLoadBoxInventoryEntries
//////////////////////////////////////////////////////////////////////////////
//
class CDLoadBoxInventoryEntries : public CClientDoc
{
protected:
	DECLARE_DYNCREATE(CDLoadBoxInventoryEntries)

public:
	CDLoadBoxInventoryEntries();
	~CDLoadBoxInventoryEntries();

public:
	DataStr					m_ComicsNo;
	DataStr					m_Collection;
	DataQty					m_LoadQuantity;
	DataStr					m_Item;
	DataStr					m_UoM;

	DBTBoxesSelection*		m_pDBTBoxesSelection;

	TUBoxEntries*			m_pTUBoxEntries;
	TUBoxCollections*		m_pTUBoxCollections;
	TUTmpLoadComics*		m_pTUTmpLoadComics;
	TTmpLoadComics			m_TTmpLoadComics;
	RUTmpLoadComics*		m_pRUTmpLoadComics;

private:
	DInventoryEntries*	GetServerDoc() const 
		{
			ASSERT(m_pServerDocument && m_pServerDocument->IsKindOf(RUNTIME_CLASS(DInventoryEntries))); 
			return (DInventoryEntries*) m_pServerDocument;
		}

protected:
	virtual BOOL OnAttachData					();
	virtual BOOL OnInitAuxData					();
	virtual void OnBeforeCloseDocument			();
	virtual BOOL OnBeforeDeleteRow				(DBTSlaveBuffered*, int /*nRow*/);
	virtual	BOOL OnOkTransaction				();

public:
	BOOL	IsInvRsnLoadBoxChecked				();
	BOOL	IsItemCollectionEntered				();
	void	ExtrapolateComicsInfo				();
	void	OpenBoxesSelectionView();
	void	SelectComics();
	void	SaveTmpRecords();
	void	CheckSelection();
	BOOL	FillGridBoxes();
	BOOL	UpdateBoxes							();
	DataInt	HowManySelectedBox();
	void DeleteTmpRecords();
	BOOL CheckSlaveQty();
	BOOL			BoxAlreadyEntered(DataStr aBox);

public:	
	//{{AFX_MSG(CDLoadBoxInventoryEntries)
	afx_msg void OnCancel();
	afx_msg void OnOk();
	afx_msg void OnItemChanged();
	afx_msg void OnQtyChanged();
	afx_msg void OnSelectionViewQtyChanged();
	afx_msg void OnEscape();
	afx_msg void OnInvRsnChanged();
	//}}AFX_MSG
	
	DECLARE_MESSAGE_MAP()	
};

#include "endh.dex"
