
#include "stdafx.h"

// ERP
#include <Items\Documents\UIItems.h>

// Dbl
#include <Comics\Dbl\TCollectionAdditionalColumns.h>
#include <Comics\Dbl\TCollections.h>

// Local
#include "CDCollectionItems.h"

#ifdef _DEBUG
#undef THIS_FILE
static char  THIS_FILE[] = __FILE__;
#endif

//////////////////////////////////////////////////////////////////////////////
//             				CDCollectionItems
//////////////////////////////////////////////////////////////////////////////
//
IMPLEMENT_DYNCREATE(CDCollectionItems, CClientDoc)

//-----------------------------------------------------------------------------
BEGIN_MESSAGE_MAP(CDCollectionItems, CClientDoc)
	//{{AFX_MSG_MAP(CDCollectionItems)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//-----------------------------------------------------------------------------
CDCollectionItems::CDCollectionItems()
	:
	CClientDoc()
{
}

//-----------------------------------------------------------------------------
CDCollectionItems::~CDCollectionItems()
{
}

//-----------------------------------------------------------------------------
BOOL CDCollectionItems::OnAttachData()
{
	return TRUE;
}


////-----------------------------------------------------------------------------
//void CDCollectionItems::OnBuildDataControlLinks(CTabDialog* pTabDlg)
//{
//	TItem*							pItems = GetServerDoc()->GetItems();
//	TCollectionAdditionalColumns*	pRec = (TCollectionAdditionalColumns*)pItems->GetAddOnFields(RUNTIME_CLASS(TCollectionAdditionalColumns));
//
//	BEGIN_CUSTOMIZE_ADDLINK(CCategoriesTabDialog, pTabDlg)
//
//		if (pRec)
//		{
//			// I METODO: Cablo nel codice sia la posizione del rettangolo che devo creare, sia gli stili
//			//CRect r(346,367,498,766);//Toglire centratura (dalla Console) controlli e aggiornare il rettangolo
//			//DWORD dwStyle =  ES_AUTOHSCROLL | WS_VISIBLE | WS_TABSTOP| WS_CHILD | WS_EX_WINDOWEDGE;
//			//DWORD dwExStyle = WS_EX_CLIENTEDGE | WS_EX_NOPARENTNOTIFY;
//
//			// II METODO: Utilizzo un control di riferimento appartenente alla tab di interesse e da questo
//			// derivo lo stile e la posizione (che poi verrà opportunamente modificata)
//			CRect r;
//			DWORD dwStyle;
//			DWORD dwExStyle;
//
//			CWnd* pW = pTabDlg->GetDlgItem(IDC_ITM_WEEEAMOUNT2);
//			if (pW)
//			{
//				pW->GetWindowRect(r);
//				pTabDlg->ScreenToClient(r);
//				r.right += 100;
//				r.top += 52;
//				r.bottom += 52;
//
//				dwStyle = pW->GetStyle() | WS_VISIBLE;
//				dwExStyle = pW->GetExStyle();
//			}
//
//			CStrEdit* pEdit = (CStrEdit*)pTabDlg->AddLinkAndCreateControl
//			(
//				(GetServerDoc()->GetItems()->GetColumnName(&(pRec->f_Collection))),
//				dwStyle,
//				r,
//				9999,
//				GetServerDoc()->GetItems(),
//				&(pRec->f_Collection),
//				RUNTIME_CLASS(CStrEdit),
//				m_pHKLCollections
//			);
//			pEdit->ModifyStyleEx(0, dwExStyle);
//			pEdit->SetCtrlCaption(_TB("Collezione"));
//
//			// Creazione della Label
//			/*r.top -= 20;
//			r.bottom -= 20;
//			CStatic stn;
//			VERIFY(stn.CreateEx(0, L"STATIC", _T("Collezione"), WS_VISIBLE|WS_CHILD, r, pTabDlg, IDC_STATIC));
//			stn.SetFont(AfxGetControlFont(), FALSE);
//			stn.UnsubclassWindow();*/
//		}
//
//	END_CUSTOMIZE_ADDLINK()
//}
//


