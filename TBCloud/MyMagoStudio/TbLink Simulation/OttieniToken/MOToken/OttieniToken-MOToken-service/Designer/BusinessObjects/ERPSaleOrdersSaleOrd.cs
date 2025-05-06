using System;
using OttieniToken.MOToken.Model;
using Microarea.Tbf.Model.Remote.Table;
using Microarea.Tbf.Model.MyMagoStudioBase;
using System.Threading.Tasks;
using Microarea.Tbf.Model.Remote;

namespace OttieniToken.MOToken.BO
{
	public class ERPSaleOrdersSaleOrd : MyMagoStudioBO<MA_SaleOrd, ERPSaleOrdersSaleOrd>
	{
		private static readonly string BONamespace = "ERP.SaleOrders.Documents.SaleOrd";
		#region BO Variables
		public string Storage1SaleOrdHKLSelector;
		public string PickUpPointBranchesHKLSelector;
		public string DeliveryToCodeHKLSelector;
		public string DeliveryToBranchesHKLSelector;
		public Int16 CurrencyDecimal;
		public Int16 NACurrencyDecimal;
		public Int16 CurrencyDecimalDetail;
		public Int16 NACurrencyDecimalDetail;
		public bool bDynamicOnlyOneRecord;
		public string BatchScheduledTaskJson;
		public string Title;
		public string ManItemDataDrawing;
		public string ManItemDataNotes;
		public bool ManItemDataInProcessBOM;
		public int ManItemDataMRPPolicy;
		public double ManItemDataLeadTime;
		public Int16 ManItemDataOrderReleaseDays;
		public double ManItemDataProductionCost;
		public double ManItemDataRMCost;
		public double ManItemDataInHouseProcessingCost;
		public double ManItemDataOutsourcedProcessingCost;
		public double ManItemDataSetupCost;
		public DateTime ManItemDataProductionCostLastChange;
		public double ManItemDataItemData_LastCost;
		public double ManItemDataStandardCost;
		public string ManItemDataMO;
		public bool ManItemDatabBillOfMaterialsPlus;
		public bool ManItemDatabAlsoMOChild;
		public bool ManItemDatabMRP;
		public bool ManItemDatabMultiStepRouting;
		public string ManItemDataItem;
		public string ManItemDataVariant;
		public string ManItemDataDescription;
		public string ManItemDataUoM;
		public bool UpdateManagerbDialogDelete;
		public string UpdateManagerDialogCancelDesc;
		public string UpdateManagerDialogCaption;
		public DateTime UpdateManagerAppDate;
		public bool UpdateManagerbDeletion;
		public bool UpdateManagerbCancellation;
		public bool UpdateManagerbEditButton;
		public bool UpdateManagerbDialogDeletion_BG;
		public string UpdateManagerDescOK;
		public string UpdateManagerDescEdit;
		public string UpdateManagerDescCancel;
		public string UpdateManagerImageCancel;
		public bool UpdateManagerbReportTemplate;
		public bool UpdateManagerbPrinterWithPrintPreview;
		public string UpdateManagerReportTitle;
		public string UpdateManagerReportNameSpace;
		public bool CheckPricesbActive;
		public bool bActivateButtonOpenVariants;
		public string sFilename;
		public string sFileDescription;
		public bool bEnableUpload;
		public bool bEnableDownload;
		public bool bEnableDelete;
		public bool bEnablePreview;
		public bool bEnableSend;
		public bool bEnableBrowser;
		public bool bShowAttachmentDockingPane;
		public bool bShowAccDefButton;
		public bool bCheckAvailability;
		public bool bUseProductionLeadTime;
		public bool bUsePurchaseTime;
		public DateTime EstimatedDate;
		public DateTime ExpectedDate;
		public bool bEnableEDDBtn;
		public double ItemDataOnHandActual;
		public double ItemDataFinalOnHand;
		public double ItemDataMinimumStock;
		public string ItemDataItem;
		public string ItemDataVariant;
		public string ItemDataDescription;
		public string ItemDataUoM;
		public double ItemDataBookInventoryActual;
		public double ItemDataBookInvValue;
		public double ItemDataOrderedSupplierActual;
		public double ItemDataActInProduction;
		public double ItemDataActCustReserved;
		public double ItemDataActReservedBySales;
		public double ItemDataActReservedByProd;
		public double ItemDataActualAvailaibility;
		public double ItemDataBookInvDelta;
		public double ItemDataFinalBookInv;
		public double ItemDataDeltaOnHand;
		public double ItemDataOrderedSupplierDelta;
		public double ItemDataOrderedSupplierIsFinal;
		public double ItemDataDeltaInProduction;
		public double ItemDataFinInProduction;
		public double ItemDataDeltaCustReserved;
		public double ItemDataFinCustReserved;
		public double ItemDataDeltaReservedByProd;
		public double ItemDataFinReservedByProd;
		public double ItemDataFinalAvailaibility;
		public double ItemDataActualAllocated;
		public double ItemDataDeltaAllocated;
		public double ItemDataFinalAllocated;
		public int ItemDataKind;
		public int ItemDataValueWith;
		public double ItemDataNetWeight;
		public double ItemDataGrossWeight;
		public double ItemDataMaxStock;
		public double ItemDataReorderingLot;
		public double ItemDataProductionLot;
		public string ItemDataItemPicture;
		public bool ItemDatabAllocationManage;
		public bool ItemDatabStorageValuationManage;
		public double ItemDataStorageBookInventoryActual;
		public double ItemDataStorageBookInvValue;
		public double ItemDataStorageProdInvActual;
		public double ItemDataActualStorageQty;
		public double ItemDataActCustStorageReserved;
		public double ItemDataActualSupplierStorageOrdered;
		public double ItemDataActualStorageAvailaibility;
		public double ItemDataStorageMinimumStock;
		public double ItemDataStorageMaximumStock;
		public double ItemDataStorageActReservedByProd;
		public double ItemDataStorageBookInvDelta;
		public double ItemDataStorageBookInvFinal;
		public double ItemDataStorageProdInvDelta;
		public double ItemDataStorageProdInvFinal;
		public double ItemDataDeltaStorageQty;
		public double ItemDataFinalStorageQty;
		public double ItemDataDeltaCustStorageReserved;
		public double ItemDataFinCustStorageReserved;
		public double ItemDataDeltaSupplierStorageOrdered;
		public double ItemDataFinalSupplierStorageOrdered;
		public double ItemDataFinalStorageAvailaibility;
		public double ItemDataStorageDeltaReservedByProd;
		public double ItemDataStorageFinReservedByProd;
		public double ItemDataActualStorageAllocated;
		public double ItemDataDeltaStorageAllocated;
		public double ItemDataFinalStorageAllocated;
		public string ItemDataStorage;
		public bool ItemDatabIsNotDBTMaster;
		public bool ItemDatabStorageDataTab;
		public bool ItemDatabLifoFifoTab;
		public bool ItemDatabAccountingTypeIsEnabled;
		public bool ItemDatabWeightedAverage;
		public string ItemDataCRItemDataDocHKLSelector;
		public bool bLoadQuotationsActivated;
		public bool ManageSalespersonComm;
		public bool ManageAreaManagerComm;
		public bool Print;
		public bool bIsActivatedMasterData_BR;
		public bool bManageDocumentRowPriceList;
		public bool bDrawingAsItemAlias;
		public bool bLotsManagement;
		public bool bIsActivatedWMS;
		public bool bAllocationManage;
		public bool bIsActivatedJob;
		public bool bIsActivatedCostAccounting;
		public bool bIsActivatedProductLines;
		public bool bIsActivatedWMSShipping;
		public double AdvanceAmount;
		public bool IntallmentRegenerate;
		public bool AmountRegenerate;
		public double InstallmentsTot;
		public double Delta;
		public string DocShipToDescri;
		public string BillsShipToDescri;
		public string ShipToDescri;
		public bool bUseTaxSummaryInDocCurr;
		public bool bMultiStorage;
		public bool bComponentReservation;
		public bool bCheckExistItem;
		public bool bEnableBtn;
		public bool bEnableDetailTile;
		public Int16 nCodItemLength;
		public bool bCustomLoadComponents;
		public string AddQty1Descri;
		public string AddQty2Descri;
		public string AddQty3Descri;
		public string AddQty4Descri;
		public double DeliveredGauge;
		public string DeliveredGaugeBarColor;
		public string DeliveredStatusTileFooter;
		public string InvoicedGaugeDescri;
		public double InvoicedGauge;
		public string InvoicedGaugeBarColor;
		public string InvoicedStatusTileFooter;
		public string CreditLimitGaugeBarColor;
		public string ImageStatusSaleOrd;
		public double CreditLimitGauge;
		public string CreditLimitGaugeFooter;
		public bool bCreditLimitIsClickable;
		public bool bAccountingTypeIsEnabled;
		public bool bAutomaticNumbering;
		public bool bEnableCtrlInEdit;
		public string PickUpPointDescri;
		public string DeliveryToDescri;
		public string CollapsedTitleMainData;
		public string CollapsedTitleCurrency;
		public string CollapsedTitleDelivery;
		public string CollapsedTitleShippingTotals;
		public string CollapsedTitleTotals;
		public string CollapsedTitleCharges;
		public string CollapsedTitleBank;
		public string CollapsedTitleRecipients;
		public string CollapsedTitleShipping;
		public string CollapsedTitleTaxSummary;
		public string sMasterTypePickUpPoint;
		public string sMasterTypeDeliveryCode;
		public string sMasterTypeSpecificatorF1;
		public string sMasterTypeSpecificatorF2;
		public string sComponents;
		public string sComponent;
		public string sCompDescri;
		public double FixingEuro;
		public bool FixingEuroVisible;
		public bool FixingStandardVisible;
		public string FixingEuroVisibleCaption;
		public bool bPymtScheduleAutomaticEnabled;
		public bool bSendEmailEnabled;
		public bool bSendPostaLiteEnabled;
		public bool bCanDoExecuteTotal;
		public bool bCanDoDocumentCopy;
		public bool bNewDeclIntentMng;
		public bool bManualDeclIntentMng;
		public bool bIsEnabledNewDeclIntentMng;
		public bool bTaxSummOffset;
		public string HeaderStripTitle;
		public Int16 ElapsedTimePrecision;
		public Int16 MoneyDecimal;
		public Int16 NAMoneyDecimal;
		#endregion
		private Table<MA_SaleOrdSummary> _Charges;
		private Table<MA_SaleOrdShipping> _Shipping;
		private Table<MA_SaleOrdNotes> _Notes;
		private TableN<MA_SaleOrdDetails> _Detail;
		private TableN<MA_SaleOrdTaxSummary> _TaxSummary;
		private TableN<MA_SaleOrdPymtSched> _PymtSchedule;
		private TableN<MA_SaleOrdReferences> _References;
		private TableN<MA_SaleOrdDetailsAccDef> _DBTSaleOrdDetailsAccDef;
		private TableN<MA_SaleOrdComponents> _Components;
		private TableN<MA_SaleOrdDetailVar> _DBTSaleOrdVariants;
		public Table<MA_SaleOrdSummary> Charges { get => _Charges; }
		public Table<MA_SaleOrdShipping> Shipping { get => _Shipping; }
		public Table<MA_SaleOrdNotes> Notes { get => _Notes; }
		public TableN<MA_SaleOrdDetails> Detail { get => _Detail; }
		public TableN<MA_SaleOrdTaxSummary> TaxSummary { get => _TaxSummary; }
		public TableN<MA_SaleOrdPymtSched> PymtSchedule { get => _PymtSchedule; }
		public TableN<MA_SaleOrdReferences> References { get => _References; }
		public TableN<MA_SaleOrdDetailsAccDef> DBTSaleOrdDetailsAccDef { get => _DBTSaleOrdDetailsAccDef; }
		public TableN<MA_SaleOrdComponents> Components { get => _Components; }
		public TableN<MA_SaleOrdDetailVar> DBTSaleOrdVariants { get => _DBTSaleOrdVariants; }
		
		protected override void Configure()
        {
            MasterTable = new Table<MA_SaleOrd>("SaleOrder", this);
            _Charges = new Table<MA_SaleOrdSummary>("Charges", this);
            MasterTable.Attach(Charges);
            _Shipping = new Table<MA_SaleOrdShipping>("Shipping", this);
            MasterTable.Attach(Shipping);
            _Notes = new Table<MA_SaleOrdNotes>("Notes", this);
            MasterTable.Attach(Notes);
            _Detail = new TableN<MA_SaleOrdDetails>("Detail", this);
            MasterTable.Attach(Detail);
            _TaxSummary = new TableN<MA_SaleOrdTaxSummary>("TaxSummary", this);
            MasterTable.Attach(TaxSummary);
            _PymtSchedule = new TableN<MA_SaleOrdPymtSched>("PymtSchedule", this);
            MasterTable.Attach(PymtSchedule);
            _References = new TableN<MA_SaleOrdReferences>("References", this);
            MasterTable.Attach(References);
            _DBTSaleOrdDetailsAccDef = new TableN<MA_SaleOrdDetailsAccDef>("DBTSaleOrdDetailsAccDef", this);
            MasterTable.Attach(DBTSaleOrdDetailsAccDef);
            _Components = new TableN<MA_SaleOrdComponents>("Components", this);
            Detail.Attach(Components);
            _DBTSaleOrdVariants = new TableN<MA_SaleOrdDetailVar>("DBTSaleOrdVariants", this);
            Detail.Attach(DBTSaleOrdVariants);

            base.Configure();
        }

		public static async Task<ERPSaleOrdersSaleOrd> CreateUnattendedAsync(ContextInfo contextInfo)
        {
            return await CreateUnattendedAsyncInternal(BONamespace, contextInfo);
        }

        public static async Task<ERPSaleOrdersSaleOrd> CreateUnattendedAsyncFromCaller(ContextInfo contextInfo, string callerId)
        {
            return await CreateUnattendedAsyncFromCallerInternal(BONamespace, contextInfo, callerId);
        }

        public static async Task<ERPSaleOrdersSaleOrd> CreateAttendedAsync(ContextInfo contextInfo, string callerId)
        {
            return await CreateAttendedAsyncInternal(BONamespace, contextInfo, callerId);
        }
	}
}