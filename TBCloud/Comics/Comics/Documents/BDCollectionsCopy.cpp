
#include "stdafx.h"

// Library declarations
//NOW INCLUDED IN COMMON PCH: #include <tboledb\sqltable.h>

#include <Comics\Dbl\TCollections.h>

#include "DCollections.h"
#include "BDCollectionsCopy.h"
#include "UICollectionsCopy.hjson"

#ifdef _DEBUG
#undef THIS_FILE                                                        
static char THIS_FILE[] = __FILE__;     
#endif                                

/////////////////////////////////////////////////////////////////////////////
// 				class BDCollectionsCopy Implementation
/////////////////////////////////////////////////////////////////////////////
//-----------------------------------------------------------------------------
IMPLEMENT_DYNCREATE(BDCollectionsCopy, CTBActivityDocument)

BEGIN_MESSAGE_MAP(BDCollectionsCopy, CTBActivityDocument)
	//{{AFX_MSG_MAP(BDCollectionsCopy)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//----------------------------------------------------------------------------
BDCollectionsCopy::BDCollectionsCopy()
	:
	m_bExecuting					(FALSE),
	m_TRCollections					(this)
{
	m_bBatch = TRUE;

	// segmenti di primary key vanno in UpperCase
	m_OldCollection.SetUpperCase();
	m_NewCollection.SetUpperCase();

	CustomizeFrame(FALSE);
	CustomizeActions(E_ACTIVITY_PANELACTION::ACTIVITY_COLLAPSE, TRUE);
	CustomizeResults(E_ACTIVITYTYPE::ACTIVITY_PROGRESS);
}

//----------------------------------------------------------------------------
BOOL BDCollectionsCopy::InitDocument()
{
	return CTBActivityDocument::InitDocument();
}

//----------------------------------------------------------------------------
void BDCollectionsCopy::DeleteContents()
{
	CTBActivityDocument::DeleteContents();
}       

//-----------------------------------------------------------------------------
BOOL BDCollectionsCopy::OnAttachData()
{              
	GetHotLink<HKLCollections>(_T("HKLCollectionsInstance"))->SetSelDisable(HKLCollections::ALL);
	
	DECLARE_VAR_JSON(NewCollection);
	DECLARE_VAR_JSON(OldCollection);
	DECLARE_VAR_JSON(bSetNewDisabled);

	SetHeaderTitle(_TB("Creation of a new Collection based on an old Collection code."), TRUE);
	SetHeaderSubTitle(_TB("The new Collection will be inserted using the same data as the original Collection."));

	return __super::OnAttachData();
}

//-----------------------------------------------------------------------------
void BDCollectionsCopy::DisableControlsForBatch()
{

}

//----------------------------------------------------------------------------
void BDCollectionsCopy::OnBatchExecute()
{                              
	if (m_NewCollection.IsEmpty() || m_OldCollection.IsEmpty())
	{
		Message(_TB("Both old and new Collection codes are required"), MB_OK | MB_ICONSTOP);
		return;
	}
		
	m_bExecuting = TRUE;
	
	Execute();
	
	m_pMessages->Show(TRUE);
	m_bExecuting = FALSE;
}

//----------------------------------------------------------------------------
BOOL BDCollectionsCopy::Execute()
{
	BOOL bOK = TRUE;
	ClearGauge(2);

	bOK = CreateNewCollection();
	if (bOK)
		UpdateGauge();

    if (m_BatchScheduler.IsAborted())
    {
    	UpdateStateProc(_TB("New Collection code creation interrupted by the user."), FALSE);   
    	return FALSE;
    }              

	bOK ? 	UpdateStateProc(_TB("Creation of new Collection code completed")) :
			UpdateStateProc(_TB("Errors creating new Collection code"));

	MessageBeep(MB_OK);

	return TRUE;
}

//----------------------------------------------------------------------------
BOOL BDCollectionsCopy::CreateNewCollection()
{             
	DataBool bOK = FALSE;
	ClearGauge(1);
	ADMCollectionsObj* pADM = (ADMCollectionsObj*)AfxGetTbCmdManager()->RunDocument(ADM_CLASS(ADMCollectionsObj), szBackgroundViewMode, NULL, NULL, NULL);

	
	if (!pADM)
		return bOK;
	
		pADM->GetCollections()->f_Collection = m_OldCollection;
		pADM->GetDocument()->BrowseRecord();
		
		TCollections* pLocalRec =  new TCollections();

		*pLocalRec = *(pADM->GetCollections());
				
		pADM->ADMNewDocument();

		*(pADM->GetCollections())= *pLocalRec;
		pADM->GetCollections()->f_Collection = m_NewCollection;
		
		if (m_bSetNewDisabled)
			pADM->GetCollections()->f_Disabled = TRUE;
		
		bOK = pADM->ADMSaveDocument();
	
		::AfxGetTbCmdManager()->DestroyDocument(pADM);
		SAFE_DELETE(pLocalRec);

	return bOK;
}

//----------------------------------------------------------------------------
void BDCollectionsCopy::UpdateStateProc(CString strMsg, BOOL bClear /*= TRUE*/)
{
	DataStr sStateProc;
	if (bClear)
		sStateProc.Clear();

	sStateProc += strMsg;

	SetGaugeTitle(sStateProc.Str());

	UpdateDataView();
}
