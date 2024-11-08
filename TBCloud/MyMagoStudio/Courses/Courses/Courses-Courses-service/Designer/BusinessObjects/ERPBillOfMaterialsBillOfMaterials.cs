using System;
using Courses.Courses.Model;
using Microarea.Tbf.Model.Remote.Table;
using Microarea.Tbf.Model.MyMagoStudioBase;
using System.Threading.Tasks;
using Microarea.Tbf.Model.Remote;

namespace Courses.Courses.BO
{
	public class ERPBillOfMaterialsBillOfMaterials : MyMagoStudioBO<MA_BillOfMaterials, ERPBillOfMaterialsBillOfMaterials>
	{
		private static readonly string BONamespace = "ERP.BillOfMaterials.Documents.BillOfMaterials";
		#region BO Variables
		public string sHKLWCSelector;
		public string sHKLItemSelector;
		public string sHKLItemGhostDetailSelector;
		public string sHKLItemGhostAnswSelector;
		public string sHKLCustSuppSelector;
		public string sDescription;
		public string sTitle;
		public bool bUseScrapPercentage;
		public bool bAllowFilterBE;
		public bool bDynamicOnlyOneRecord;
		public string Title;
		public bool CLinksPanel_bLinksPanelEnabled;
		public bool CLinksPanel_bFooter;
		public bool bCheckItemUoM;
		public double TotPercentage;
		public bool bUseDrawings;
		public string BOMStatus;
		public bool Internal;
		public bool Outsourced;
		public string Operation;
		public bool bInsertBefore;
		public bool bInsertAfter;
		public string Supplier;
		public string BOMFromToCopy;
		public bool bBOMComponentToCopy;
		public bool bIsActivatedCompResCleaning;
		public bool bUseTools;
		public string ToolBmp;
		public string FamilyBmp;
		public bool bCheckExistItem;
		public Int16 nLen;
		public bool bEnableButtonAddReference;
		public bool bEnableButtonOpenBOMNavigation;
		public bool bEnableButtonOpenItemBalancesNav;
		public bool bEnableButtonOpenBOMImplosion;
		public bool bEnableButtonOpenBOMExplosion;
		public bool bEnableButtonOpenBOMCosting;
		public bool bEnableButtonOpenSemifinishedBOM;
		public bool bEnableTGOperations;
		public bool bEnableTDAnswers;
		public Int16 nOperationLength;
		public Int16 nItemLength;
		public string DefaultNS;
		public string sHeaderTitle;
		public string sCopyTitle;
		public string sTitleBOM;
		public string sTitleFilterCopy;
		public string sFilterBOM;
		public string sBtnCopy;
		public string sBtnSemifinished;
		public string sHintNavigation;
		public string sHintExplosion;
		public string sHintCosting;
		public string sHintImplosion;
		public string sComponents;
		public string sAccComponents;
		public string sComponent;
		public string sCompQty;
		public string sCompType;
		public string sFixedComp;
		public string sPercCompQty;
		public string sCopyComp;
		public string sHintNavCom;
		public string sIntermediate;
		public string sNSItemType;
		public string sNSCompType;
		public bool bIsFoodRecipe;
		public string sSalesDocOnly;
		public bool LabourbIsEditProcessing;
		public bool LabourbIsRollback;
		public bool LabourbIsMOConfirmation;
		public bool LabourbIsMO;
		public bool LabourbIsBOM;
		public bool LabourbUseOM;
		public bool LabourbIsTotalTime;
		public bool LabourbCollapsed;
		public bool LabourbEnlargeColumns;
		public string LaboursCollapsedTitle;
		public bool LabourbEnableAddRow;
		public bool LabourbEnableInsertRow;
		public bool LabourbEnableDeleteRow;
		public bool LabourbEnableTeamExplodeBtn;
		public bool LabourbRtgStepsOnTab;
		public Int16 RtgStep;
		public string Alternate;
		public Int16 AltRtgStep;
		public string ToolOperation;
		public string OperationDescription;
		public int Usage;
		public bool IsFamily;
		public string Tool;
		public int ProcessingType;
		public int ToolType;
		public bool Fixed;
		public double UsedQuantity;
		public Int32 UsageTime;
		public bool Exclusive;
		public int Source;
		public string SourceTool;
		public string RtgStepTypeBmp;
		public bool ToolsManagementbCollapsed;
		public Int16 ToolsManagementnCharsToolsManagementDescr;
		public bool ToolsManagementbOperationStatusHidden;
		public bool ToolsManagementbBOMStatusHidden;
		public bool ToolsManagementbRtgStepsOnTab;
		public string ToolsManagementsToolsHKLSelector;
		public bool ToolsManagementbAutomaticNumbering;
		public string ToolsManagementsCollapsedTitle;
		public string HeaderStripTitle;
		#endregion
		private Table<MA_BillOfMaterialsDrawings> _BOMDrawings;
		private TableN<MA_BillOfMaterialsRouting> _BOMRoutings;
		private TableN<MA_BillOfMaterialsComp> _BOMComponents;
		private TableN<MA_BillOfMaterialsTools> _DBTToolsManagement;
		public Table<MA_BillOfMaterialsDrawings> BOMDrawings { get => _BOMDrawings; }
		public TableN<MA_BillOfMaterialsRouting> BOMRoutings { get => _BOMRoutings; }
		public TableN<MA_BillOfMaterialsComp> BOMComponents { get => _BOMComponents; }
		public TableN<MA_BillOfMaterialsTools> DBTToolsManagement { get => _DBTToolsManagement; }
		
		protected override void Configure()
        {
            MasterTable = new Table<MA_BillOfMaterials>("BillOfMaterials", this);
            _BOMDrawings = new Table<MA_BillOfMaterialsDrawings>("BOMDrawings", this);
            MasterTable.Attach(BOMDrawings);
            _BOMRoutings = new TableN<MA_BillOfMaterialsRouting>("BOMRoutings", this);
            MasterTable.Attach(BOMRoutings);
            _BOMComponents = new TableN<MA_BillOfMaterialsComp>("BOMComponents", this);
            MasterTable.Attach(BOMComponents);
            _DBTToolsManagement = new TableN<MA_BillOfMaterialsTools>("DBTToolsManagement", this);
            MasterTable.Attach(DBTToolsManagement);

            base.Configure();
        }

		public static async Task<ERPBillOfMaterialsBillOfMaterials> CreateUnattendedAsync(ContextInfo contextInfo)
        {
            return await CreateUnattendedAsyncInternal(BONamespace, contextInfo);
        }

        public static async Task<ERPBillOfMaterialsBillOfMaterials> CreateUnattendedAsyncFromCaller(ContextInfo contextInfo, string callerId)
        {
            return await CreateUnattendedAsyncFromCallerInternal(BONamespace, contextInfo, callerId);
        }

        public static async Task<ERPBillOfMaterialsBillOfMaterials> CreateAttendedAsync(ContextInfo contextInfo, string callerId)
        {
            return await CreateAttendedAsyncInternal(BONamespace, contextInfo, callerId);
        }
	}
}