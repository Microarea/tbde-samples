
#pragma once

#include <Items\Documents\DItems.h>

#include "beginh.dex"

class HKLCollections;

//////////////////////////////////////////////////////////////////////////////
//             				CDCollectionItems
//////////////////////////////////////////////////////////////////////////////
//
class CDCollectionItems : public CClientDoc
{
protected:
	DECLARE_DYNCREATE(CDCollectionItems)

public:
	CDCollectionItems();
	~CDCollectionItems();

private:
	DItems*	GetServerDoc() const
	{
		ASSERT(m_pServerDocument && m_pServerDocument->IsKindOf(RUNTIME_CLASS(DItems)));
		return (DItems*)m_pServerDocument;
	}

public:
	DItems* GetDocument() const { return (DItems*)GetServerDoc(); }

protected:
	virtual BOOL OnAttachData();

protected:
	//{{AFX_MSG(CarichiClientDoc)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#include "endh.dex"
