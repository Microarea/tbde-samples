#include "stdafx.h"

// Library declarations
#include <Comics/Dbl/TBoxes.h>
#include <Items\Dbl\TItem.h>
//Local declarations
#include "BDBoxesCopy.h"
#include "UIBoxesCopy.hjson"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__; 
#endif
														  
static TCHAR szParamGroupCode				[]	= _T("p1");
static TCHAR szParamBOM						[]	= _T("p2");

//////////////////////////////////////////////////////////////////////////////
//             			class DBTBoxesCopy definition
//////////////////////////////////////////////////////////////////////////////
//
//-----------------------------------------------------------------------------	
IMPLEMENT_DYNAMIC(DBTBoxesCopy, DBTSlaveBuffered)

//-----------------------------------------------------------------------------	
DBTBoxesCopy::DBTBoxesCopy
	(
		CRuntimeClass*		pClass, 
		CAbstractFormDoc*	pDocument
	)
	:
	DBTSlaveBuffered (pClass, pDocument,_NS_DBT("DBTBoxesCopy"), ALLOW_EMPTY_BODY, FALSE)  
{}

//-----------------------------------------------------------------------------
DataObj* DBTBoxesCopy::OnCheckPrimaryKey	(int /*nRow*/, SqlRecord*)
{ 
	return NULL; 
}

//-----------------------------------------------------------------------------
void DBTBoxesCopy::OnPreparePrimaryKey(int nRow, SqlRecord* pSqlRec)
{  }

////////////////////////////////////////////////////////////////////////////
// 				class BDSostituzioneComponenti Implementation
/////////////////////////////////////////////////////////////////////////////
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE(BDBoxesCopy, CWizardFormDoc)

//-----------------------------------------------------------------------------
BEGIN_MESSAGE_MAP(BDBoxesCopy, CWizardFormDoc)
//{{AFX_MSG_MAP(BDSostituzioneComponenti)
	//ON_COMMAND				(ID_BOXESCOPY_SELECT,				OnSelectDeselect)
	//ON_UPDATE_COMMAND_UI	(ID_BOXESCOPY_SELECT,					OnUpdateSelectDeselectStatus)
	ON_EN_VALUE_CHANGED		(IDC_BOXESCOPY_ITEMS_RADIO_ALL,			OnAllItemChanged)

//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//----------------------------------------------------------------------------
BDBoxesCopy::BDBoxesCopy()
	:
	m_bItemSel		(TRUE),
	m_bAllItem		(FALSE),
	m_pTRItems		(NULL),
	m_pDBTBoxesCopy (NULL)
{ 
	m_bBatch		= TRUE;
	m_ToItem.		SetUpperCase ();
	m_FromItem.		SetUpperCase ();

	SetHeaderTitle(_TB("WELCOME IN THE BOXES COPY PROCEDURE\nThis wizard allows select the boxes associated to an item, copy and create a new boxes."), TRUE);
	SetHeaderSubTitle(_TB("In this tab you have to choose the kind of action and where perform it."));
}

//----------------------------------------------------------------------------
BDBoxesCopy::~BDBoxesCopy()
{
	//if (m_pTblBomExpl && m_pTblBomExpl->IsOpen())		m_pTblBomExpl->Close();
}

//-----------------------------------------------------------------------------
BOOL BDBoxesCopy::OnAttachData()
{              
	__super::OnAttachData();

	SetFormTitle(_TB("Boexes Copy"));

	m_pDBTBoxesCopy = new DBTBoxesCopy(RUNTIME_CLASS(TBoxEntries), this);
		
	DECLARE_VAR_JSON(ToItem);
	DECLARE_VAR_JSON(FromItem);
	DECLARE_VAR_JSON(bItemSel);
	DECLARE_VAR_JSON(bAllItem);

	return TRUE;
}

//-----------------------------------------------------------------------------
void BDBoxesCopy::DisableControlsForBatch()
{
	m_FromItem.SetReadOnly(m_bAllItem);
	m_ToItem.SetReadOnly(m_bAllItem);
}

//-----------------------------------------------------------------------------
void BDBoxesCopy::OnAllItemChanged()
{
	m_FromItem.Clear();
	m_ToItem.Clear();
	UpdateDataView();
}

//----------------------------------------------------------------------------
void BDBoxesCopy::OnSelectDeselect()
{
	BOOL bAtLeastOne = FALSE;
	m_bSelect = !m_bSelect; 
	/*
	for (int i = 0; i<= m_pDBTBoxesCopy->GetUpperBound();  i++)
	{
		TBoxEntries* pRec = m_pDBTBoxesCopy->GetDetail(i);
		//Mig. 4059 - se ECO presente, non selezionabile
		if (pRec->l_ECONo.IsEmpty())
		{
			pRec->l_Selected = m_bSelect;// && !(m_bUseECO && pRec->l_Configurable);
			bAtLeastOne |= (BOOL)pRec->l_Selected;
		}
	}
	if (!bAtLeastOne)
		m_bSelect = FALSE;

	if (WEB)
	{
		m_ButtonSelectedText = m_BtnSelect ? _TB("Deselect") : _TB("Select");
	}
	else {
		if (m_BtnSelect)
			m_bSelect ? m_BtnSelect->SetText(_TB("Deselect")) : m_BtnSelect->SetText(_TB("Select"));
	}
	*/
	UpdateDataView();
	m_pMessages->Show(TRUE);
}

//-----------------------------------------------------------------------------
void BDBoxesCopy::OnUpdateSelectDeselectStatus(CCmdUI* pCmdUI)
{
	//BOOL bResultTabActive = GetWizardView()->GetWizardCurrentStep() == IDD_SUBSBOMITEM_WIZ_BE;
	BOOL bResultTabActive = TRUE;

	pCmdUI->Enable(bResultTabActive);
}

//-----------------------------------------------------------------------------
BOOL BDBoxesCopy::LoadDBT()
{              
	if (!m_pDBTBoxesCopy)
		return FALSE;

	m_pDBTBoxesCopy->Init();

	BOOL bFound = FALSE;
	
	TBoxEntries aTBoxEntries;

	TRY
	{
		
	}
	CATCH(SqlException, e)	
	{
		Message (_TB("Database error updating the tables!"), MB_ICONSTOP);    
		return FALSE;
	}
	END_CATCH	


	m_pMessages->Show(TRUE);
	return bFound;	    	
}

//----------------------------------------------------------------------------
void BDBoxesCopy::OnBatchExecute()
{     

	if (m_BatchScheduler.IsAborted())	
		m_pMessages->Add(_TB("Processing interrupted by the user.\n"), CMessages::MSG_WARNING);

	/*if (CheckConsistencyData())
	{
		m_pTbContext->StartTransaction();
		if (!ReplacementAlgorithm())
		{
			m_pMessages->Add(_TB("Processing not completed\n"), CMessages::MSG_WARNING);
			m_pTbContext->Rollback();
		}
		else
		{
			m_pTbContext->Commit();
			m_pMessages->Add(_TB("Processing end"), CMessages::MSG_HINT);
		}
		m_pTbContext->UnlockAll();
	}
	else
	{
		m_pMessages->Show(TRUE);
		return;
	}	
	m_pMessages->Show(TRUE);*/
	
	m_pDBTBoxesCopy->RemoveAll();
	
	UpdateDataView();
}

//----------------------------------------------------------------------------
BOOL BDBoxesCopy::OnInitDocument()
{
	//m_pRecBOM			= new TBillOfMaterials;
	//m_pTblBOM			= new SqlTable(m_pRecBOM,		GetReadOnlySqlSession());
	
	return TRUE;
}


//----------------------------------------------------------------------------
BOOL BDBoxesCopy::EnableWizardNextButton(BOOL bWizDlg1 /*= TRUE*/, BOOL bEnable /*= TRUE*/)
{
	if (!GetWizardView() )
	{
		ASSERT(FALSE);
		return FALSE;
	}

	UINT tabID = GetWizardView()->GetWizardCurrentStep();
	if(!tabID)
	{
		ASSERT(FALSE);
		return FALSE;
	}

	//if (
	//		(bWizDlg1 && tabID == IDD_BOXESCOPY_FILTERS /*||
	//		!bWizDlg1 && tabID == IDD_BOXESCOPY_WIZ_BE*/)
	//	)
	//{
	//	CWnd * pWnd = GetWizardView()->GetDlgItem(IDC_WIZARD_NEXT);
	//	if (!pWnd)
	//	{
	//		ASSERT(FALSE);
	//		return FALSE;
	//	}
	//	pWnd->EnableWindow(bEnable);
	//	return TRUE;
	//}

	return FALSE;
}

//----------------------------------------------------------------------------
void BDBoxesCopy::OnBatchCompleted()
{
	__super::OnBatchCompleted();

}

//----------------------------------------------------------------------------
void BDBoxesCopy::OnPinUnpin(UINT nID)
{
	#ifndef TB_CLOUD
	if (GetTileDialog(nID)->IsPinned())
		return;
	#endif

	/*if (nID == IDD_TD_SUBSBOMITEM_ACTIONS_VALIDITYPERIOD)
	{
		m_bCompAllPeriod = TRUE;
		m_CompValidFrom.Clear();
		m_CompValidTo.Clear();
		m_CompValidFrom.SetReadOnly(m_bCompAllPeriod);
		m_CompValidTo.SetReadOnly(m_bCompAllPeriod);
		UpdateDataView();
	}*/
	
}

//chiamata solo da desktop
//-----------------------------------------------------------------------------
void BDBoxesCopy::OnBEEnableButton(CBodyEdit* pBodyEdit, CBEButton* pButton)
{
	__super::OnBEEnableButton(pBodyEdit, pButton);

	//if (pBodyEdit->GetBodyEditID() == IDC_BOXESCOPY_COMPONENTS)
	//{
	//	if (pButton->m_nID == ID_BOXESCOPY_SELECT)
	//	{
	//		m_BtnSelect = pButton;
	//		m_BtnSelect->EnableButton(TRUE);
	//	}
	//}
}
//
////-----------------------------------------------------------------------------
//void BDBoxesCopy::ExecuteUpdateDataView()
//{
//	// abilitazione bottoni/menu (solo web)
//	if (WEB)
//	{
//		m_bEnableBtn = TRUE;
//	}
//
//	__super::ExecuteUpdateDataView();//la chiamata al padre deve essere per ultima
//}

//-----------------------------------------------------------------------------
void BDBoxesCopy::OnWizardActivate(UINT nIDD)
{

	//if (nIDD == IDD_SUBSBOMITEM_ACTION)
	//{
	//	SetHeaderTitle(_TB("WELCOME IN THE BILL OF MATERIALS COMPONENTS MAINTENANCE PROCEDURE\nThis wizard allows to replace a component with another one, delete an already existing component or insert a new one."), TRUE);
	//	SetHeaderSubTitle(_TB("In this tab you have to choose the kind of action and where perform it."));

	//}

	//else if (nIDD == IDD_SUBSBOMITEM_FILTERS)
	//{
	//	SetHeaderTitle(_TB(""));

	//	if (m_bBOMCompReplace)
	//		SetHeaderSubTitle(_TB("Here you have to choose the component to delete and indicate the component that will replace it with the relation between the UoM."));
	//	else if (m_bBOMCompInsert)
	//		SetHeaderSubTitle(_TB("Here you have to indicate the component to insert and its quantity."));
	//	else if (m_bBOMCompDelete)
	//		SetHeaderSubTitle(_TB("Here you have to choose the component to delete."));
	//}
	//else if (nIDD == IDD_SUBSBOMITEM_WIZ_BE)
	//{
	//	SetHeaderTitle(_TB(""));
	//	SetHeaderSubTitle(_TB("Here you have to choose the Bill of Materials where perform the selected actions."));
	//}
}

//----------------------------------------------------------------------------
LRESULT BDBoxesCopy::OnWizardNext(UINT nIDD)
{
	/*if (nIDD == IDD_SUBSBOMITEM_ACTION)
	{

		if (!m_bCompAllPeriod)
		{
			if (m_CompValidFrom.IsEmpty() || m_CompValidTo.IsEmpty())
			{
				AfxMessageBox(_TB("You have to indicate start or end validity date!"));
				return WIZARD_SAME_TAB;
			}
		}

		if (m_bBOM && m_BOM.IsEmpty())
		{
			AfxMessageBox(cwsprintf(_TB("You have to indicate a %s."), m_sTextColumn.Str()));
			return WIZARD_SAME_TAB;
		}

		if (m_bBOMVariant_SelBOM_Var && m_BOMVariant.IsEmpty())
		{
			AfxMessageBox(_TB("You have to indicate a Variant."));
			return WIZARD_SAME_TAB;
		}
		return WIZARD_DEFAULT_TAB;
	}
	else if (nIDD == IDD_SUBSBOMITEM_FILTERS)
	{	
		CString strMsg;

		if (!m_bBOMCompInsert)
		{
			if (m_OldComponent.IsEmpty())
				strMsg += cwsprintf(_TB("\nYou have to select an old {0-%s}!"), m_sComponent.Str());
			if (m_bBOMCompReplace && m_NewComponent.IsEmpty())
				strMsg += cwsprintf(_TB("\nYou have to select a new {0-%s}!"), m_sComponent.Str());
		}

		if (m_bBOMCompInsert && m_NewComponent.IsEmpty())
			strMsg += cwsprintf(_TB("\r\nYou have to select a new {0-%s}!"), m_sComponent.Str());

		if (!strMsg.IsEmpty())
		{
			AfxMessageBox(strMsg);
			return WIZARD_SAME_TAB;
		}*/

		if (!LoadDBT())
			return WIZARD_SAME_TAB;

		return WIZARD_DEFAULT_TAB;
	/*}
	else
		return WIZARD_DEFAULT_TAB;*/
}

//----------------------------------------------------------------------------
LRESULT BDBoxesCopy::OnWizardBack(UINT nIDD)
{
	/*if (nIDD == IDD_SUBSBOMITEM_FILTERS)
	{
		return WIZARD_DEFAULT_TAB;
	}
	else if (nIDD == IDD_SUBSBOMITEM_WIZ_BE)
	{
		return WIZARD_DEFAULT_TAB;
	}*/

	return WIZARD_DEFAULT_TAB;
}


//----------------------------------------------------------------------------------------
TRItems* BDBoxesCopy::GetTRItems(DataStr* aCode /*NULL*/)
{
	if (!m_pTRItems)
		m_pTRItems = new TRItems(this);

	if (aCode && m_pTRItems->GetRecord()->f_Item != *aCode)
		m_pTRItems->FindRecord(*aCode);

	return m_pTRItems;
}

