
#pragma once

//NOW INCLUDED IN COMMON PCH: #include <tbges\dbt.h>
//NOW INCLUDED IN COMMON PCH: #include <tbges\tabber.h>

// Dbl

// Components

// Locals
#include "beginh.dex"

class DBTBoxesCopy;
class TBoxEntries;
class TRItems;

//=============================================================================
class TB_EXPORT BDBoxesCopy : public CWizardFormDoc
{
	DECLARE_DYNCREATE(BDBoxesCopy)

public:	
	BDBoxesCopy	();
	~BDBoxesCopy	();

public:
	BOOL		m_bSelect;
	DataStr		m_ToItem;
	DataStr		m_FromItem;
	DataBool	m_bItemSel;
	DataBool	m_bAllItem;

	DBTBoxesCopy*			m_pDBTBoxesCopy;
	CBEButton*				m_BtnSelect;
	DataStr					m_ButtonSelectedText;

public:
	TRItems*					m_pTRItems;
	TRItems*					GetTRItems(DataStr* sItem = NULL);
	
public:	
	//virtual BOOL 	CanDoReport					()							{return FALSE;}
	//virtual	DataStr	GetNewComponent				() 							{return m_NewComponent; }
	//		void    SetNewCompDescr				(const DataStr& aDescri)  	{m_NewCompDesc = aDescri;}
	//virtual	DataStr	GetBaseUoMNewComponent		();
	//		BOOL	CreateECO					(ADMInUse& ADM, BOOL bNewDoc, TBoxEntries* pElem);
	//		BOOL	AddECOCompLine				(TECOComponents* pRecComp, TBoxEntries* pElem);
	//		BOOL	DeleteECOCompLine			(TECOComponents* pRecComp, TBoxEntries* pElem, BOOL bDelete = FALSE);
	//		CString	OnGetBitmapProperties		(TBoxEntries* pRec);
			BOOL    LoadDBT						();
	virtual void	OnPinUnpin					(UINT nID);
	virtual LRESULT	OnWizardNext				(UINT nIDD);
	virtual LRESULT OnWizardBack				(UINT nIDD);
	virtual void	OnWizardActivate			(UINT nIDD);
	//virtual BOOL	OnGetToolTipProperties		(CBETooltipProperties* pTooltip);
	//virtual BOOL    OnGetCustomColor			(const CBodyEdit*, CBodyEditRowSelected* /*CurRow*/);
	virtual void	OnBEEnableButton			(CBodyEdit* pBodyEdit, CBEButton* pButton);
	//virtual void	ExecuteUpdateDataView		();

private:
	/*TBillOfMaterials*			m_pRecBOM;
	SqlTable*					m_pTblBOM;
	TBillOfMaterialsComp*		m_pRecComp;
	SqlTable*					m_pTblComp;
	TVariants*					m_pRecVariants;
	SqlTable*					m_pTblVariants;
	TVariantsComponents*		m_pVarComp;
	SqlTable*					m_pTblVarComp;
	TTmpBOMExplosions*			m_pRecBomExpl;
	SqlTable*					m_pTblBomExpl;
	
	CBOMExplosion*				m_pAlgEspl;

	TRBillOfMaterialsCompForSubId	m_TRBom4SubID;
	TRBillOfMaterials				m_TRBillOfMaterials;
	TRNotConfirmedECO				m_TRNotConfirmedECO;*/

private:
	/*void	PrepareComponentsQuery		(SqlTable& aTable,		TBillOfMaterialsComp& aRec);
	void	PrepareVariantsCompQuery	(SqlTable& aTable,		TVariantsComponents& aRec);
	void	SelectionVariant			( HKLVariants*			pHKLVariants);
	BOOL	OpenTablesMaster			();
	BOOL	OpenPreparationTables		(BOOL bUseDistinct);
	BOOL    CheckConsistencyData		();
	void	DefineQueryBomExplosion		();
	BOOL	IsSubstitutionRecursive		(const DataStr& sComp, const DataStr& sVariant);
	BOOL	SaveADM						(ADMInUse ADM);
	void	ReattachOldBOMItemHotLink	();
	void	ReattachNewBOMItemHotLink	();
		*/
protected:	      
	virtual BOOL	OnAttachData 			();
	virtual void	OnBatchExecute			();
	virtual void    OnBatchCompleted		();
	virtual	BOOL	OnInitDocument			();
	virtual	void	DisableControlsForBatch	() ;
	//virtual void	OnPrepareForFind		(HotKeyLinkObj* pHKL, SqlRecord* pRec);
			BOOL	EnableWizardNextButton(BOOL bWizDlg1 = TRUE, BOOL bEnable = TRUE);


		/*	BOOL		ReplacementAlgorithm			();	
			BOOL		SearchComponents				();
			BOOL		SearchBOM						();
			void		PrepareQueryBOMs				();
			void		PrepareQueryVariants			();
			void		DefineQueryBOMs					();
			void		DefineQueryVariants				();
			void		DefineQueryVariantsComp			(BOOL bUseDistinct);
			void		PrepareQueryVariantsComp		();
			void		DefineQueryComponents			();
			void		PrepareQueryComponents			();
			BOOL		ModifyBOMComponent				(ADMInUse& ADM, BOOL bNewDoc, TBoxEntries* pElem);
			BOOL		BOMVariantModification			(ADMVariantsObj*		pADMVariants,	TBoxEntries* pElem);
			BOOL		BOMModification					(ADMBillOfMaterialsObj*	pADMBom,		TBoxEntries* pElem);
			void		CascadeModificationInVariant	(TBoxEntries* pElem);
			void		DefineCascadeModInVarQuery		();
			void		PrepareCascadeModInVarQuery		(TBoxEntries* pElem);
			BOOL		CtrlParameters					();
			BOOL		CtrlRecurs						();
			
			BOOL		ErrorsFromCalculateTotBOMPercentage(TBoxEntries* pElem);
			DataPerc	CalculateTotBOMPercentage		(TBoxEntries* pElem);*/

protected:	// Generated message map functions
	//{{AFX_MSG( BDBoxCopy)             
	afx_msg void OnSelectDeselect					();
	afx_msg void OnUpdateSelectDeselectStatus		(CCmdUI*);
	afx_msg	void OnAllItemChanged				();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////
//							DBTDistintaBaseSostComponenti
/////////////////////////////////////////////////////////////////////////////
class TB_EXPORT DBTBoxesCopy : public DBTSlaveBuffered
{ 
	friend class BDBoxesCopy;
	
	DECLARE_DYNAMIC(DBTBoxesCopy)

public:
	DBTBoxesCopy
		(
			CRuntimeClass*		pClass, 
			CAbstractFormDoc*	pDocument
		);

public:
	TBoxEntries*	GetCurrent	() 			const	{ return (TBoxEntries*)	GetCurrentRow();} 
	BDBoxesCopy*		GetDocument	()			const	{ return (BDBoxesCopy*)	m_pDocument;	}
	TBoxEntries*	GetDetail	(int nRow) 	const 	{ return (TBoxEntries*)	GetRow(nRow);	} 
	TBoxEntries*	GetDetail	()		   	const	{ return (TBoxEntries*)	GetRecord(); 	}

protected:
	virtual	void		OnDefineQuery		()				{}
	virtual	void		OnPrepareQuery		()				{}
	virtual DataObj*	OnCheckPrimaryKey	(int /*nRow*/, SqlRecord*);
	virtual void		OnPreparePrimaryKey	(int /*nRow*/, SqlRecord*);
};



#include "endh.dex"