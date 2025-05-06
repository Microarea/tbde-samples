using System;
using Microarea.Tbf.Model.CustomAttributes;

namespace OttieniToken.MOToken.Enums
{
	public sealed class Enums
	{
		private Enums()
		{
		}

		public sealed class DeleteAttachAction
		{
				
				
				private DeleteAttachAction()
    			{
    			}

				public const Int32 DefaultValue = 49152001; 
				
				
				
    			public const Int32 Delete_archived_document = 49152000;
				
				
				
    			public const Int32 Keep_archived_document = 49152001;
				
				
				
    			public const Int32 Ask_before_delete_archived_document = 49152002;
				
				
				
    			public const Int32 Not_allowed = 49152003;
		}
		public sealed class DuplicateAttachAction
		{
				
				
				private DuplicateAttachAction()
    			{
    			}

				public const Int32 DefaultValue = 49217536; 
				
				
				
    			public const Int32 Ask_before = 49217536;
				
				
				
    			public const Int32 Replace_existing_document_with_the_new_one = 49217537;
				
				
				
    			public const Int32 Keep_both_document = 49217538;
				
				
				
    			public const Int32 Dont_replace_and_use_existing_archived_document = 49217539;
				
				
				
    			public const Int32 Refuse_operation = 49217540;
				
				
				
    			public const Int32 Cancel = 49217541;
		}
		public sealed class BarcodeDetectAction
		{
				
				
				private BarcodeDetectAction()
    			{
    			}

				public const Int32 DefaultValue = 49283072; 
				
				
				
    			public const Int32 First_page_only = 49283072;
				
				
				
    			public const Int32 Till_one_valid = 49283073;
		}
		public sealed class BookmarkType
		{
				
				
				private BookmarkType()
    			{
    			}

				public const Int32 DefaultValue = 49348609; 
				
				
				
    			public const Int32 Key = 49348608;
				
				
				
    			public const Int32 Field = 49348609;
				
				
				
    			public const Int32 Category = 49348610;
				
				
				
    			public const Int32 External = 49348611;
				
				
				
    			public const Int32 SOS_Special = 49348612;
				
				
				
    			public const Int32 Variable = 49348613;
		}
		public sealed class OperationType
		{
				
				
				private OperationType()
    			{
    			}

				public const Int32 DefaultValue = 49414144; 
				
				
				
    			public const Int32 EqualsEquals = 49414144;
				
				
				
    			public const Int32 LowerThanGreaterThan = 49414145;
				
				
				
    			public const Int32 LIKE = 49414146;
		}
		public sealed class LogicOperator
		{
				
				
				private LogicOperator()
    			{
    			}

				public const Int32 DefaultValue = 49479680; 
				
				
				
    			public const Int32 AND = 49479680;
				
				
				
    			public const Int32 OR = 49479681;
		}
		public sealed class Delivery_Type_PostaLite
		{
				[AllowISO("IT")]
				
				private Delivery_Type_PostaLite()
    			{
    			}

				public const Int32 DefaultValue = 2147352576; 
				
				
				
    			public const Int32 Posta_Massiva = 2147352576;
				
				
				
    			public const Int32 Posta_Prioritaria = 2147352577;
				
				
				
    			public const Int32 Raccomandata = 2147352578;
				
				
				
    			public const Int32 Raccomandata_AR = 2147352579;
				
				[AllowISO("xxx")]
				
    			public const Int32 Fax = 2147352580;
		}
		public sealed class Print_Type
		{
				
				
				private Print_Type()
    			{
    			}

				public const Int32 DefaultValue = 2147287040; 
				
				
				
    			public const Int32 Only_Front_Minus_BlackSlashWhite = 2147287040;
				
				
				
    			public const Int32 FrontSlashBack_Minus_BlackSlashWhite = 2147287041;
				
				
				
    			public const Int32 Only_Front_Minus_Colors = 2147287042;
				
				
				
    			public const Int32 FrontSlashBack_Minus_Colors = 2147287043;
		}
		public sealed class Addresser_Type
		{
				
				
				private Addresser_Type()
    			{
    			}

				public const Int32 DefaultValue = 2147221504; 
				
				
				
    			public const Int32 No_addresser = 2147221504;
				
				
				
    			public const Int32 Use_company_master_data = 2147221505;
				
				
				
    			public const Int32 Use_subscriber_data = 2147221506;
				
				
				
    			public const Int32 Public_Entity_data_clause_2bComma_Law_august_13_2010_N136 = 2147221507;
		}
		public sealed class Email_Address_Type
		{
				
				
				private Email_Address_Type()
    			{
    			}

				public const Int32 DefaultValue = 2147155968; 
				
				
				
    			public const Int32 All = 2147155968;
				
				
				
    			public const Int32 Normal = 2147155969;
				
				
				
    			public const Int32 Certified = 2147155979;
		}
		public sealed class Barcode_Type
		{
				
				
				private Barcode_Type()
    			{
    			}

				public const Int32 DefaultValue = 5636117; 
				
				
				
    			public const Int32 Ean8 = 5636096;
				
				
				
    			public const Int32 Ean13 = 5636097;
				
				
				
    			public const Int32 Code39 = 5636098;
				
				
				
    			public const Int32 UPC_A = 5636099;
				
				
				
    			public const Int32 UPC_E = 5636100;
				
				
				
    			public const Int32 Extended_Code_39 = 5636101;
				
				
				
    			public const Int32 Interleaved_2_of_5 = 5636102;
				
				
				
    			public const Int32 Code_128_auto = 5636103;
				
				
				
    			public const Int32 Codabar = 5636104;
				
				
				
    			public const Int32 ZIP_Code = 5636105;
				
				
				
    			public const Int32 MSI_Plessey = 5636106;
				
				
				
    			public const Int32 Code_93 = 5636107;
				
				
				
    			public const Int32 Extended_code_93 = 5636108;
				
				
				
    			public const Int32 UCC128 = 5636109;
				
				
				
    			public const Int32 HIBC = 5636110;
				
				
				
    			public const Int32 PDF417 = 5636111;
				
				
				
    			public const Int32 UPCEMinusE0 = 5636112;
				
				
				
    			public const Int32 UPCEMinusE1 = 5636113;
				
				
				
    			public const Int32 Code_128_A = 5636114;
				
				
				
    			public const Int32 Code_128_B = 5636115;
				
				
				
    			public const Int32 Code_128_C = 5636116;
				
				
				
    			public const Int32 Default = 5636117;
				
				
				
    			public const Int32 Ean_128 = 5636118;
				
				
				
    			public const Int32 DataMatrix = 5636119;
				
				
				
    			public const Int32 MicroQR = 5636120;
				
				
				
    			public const Int32 QR = 5636121;
				
				
				
    			public const Int32 Swiss_QRMinusBill = 5636122;
		}
		public sealed class Report_Status
		{
				
				
				private Report_Status()
    			{
    			}

				public const Int32 DefaultValue = -1048576; 
				
				
				
    			public const Int32 Success = -1048576;
				
				
				
    			public const Int32 No_Data_Found = -1048575;
				
				
				
    			public const Int32 Fatal_Error = -1048574;
				
				
				
    			public const Int32 User_aborted = -1048573;
				
				
				
    			public const Int32 Printing_Preview = -1048572;
				
				
				
    			public const Int32 Script_aborted = -1048571;
				
				
				
    			public const Int32 Script_calls_Quit = -1048570;
		}
		public sealed class AsyncStatus
		{
				
				
				private AsyncStatus()
    			{
    			}

				public const Int32 DefaultValue = 2147090432; 
				
				
				
    			public const Int32 Started = 2147090432;
				
				
				
    			public const Int32 In_Progress = 2147090433;
				
				
				
    			public const Int32 Success = 2147090434;
				
				
				
    			public const Int32 Failed = 2147090435;
				
				
				
    			public const Int32 Aborted = 2147090436;
				
				
				
    			public const Int32 Cancel_Ok = 2147090437;
				
				
				
    			public const Int32 Cancel_Failed = 2147090438;
				
				
				
    			public const Int32 Waiting = 2147090439;
		}
		public sealed class Gender
		{
				
				
				private Gender()
    			{
    			}

				public const Int32 DefaultValue = 2097152; 
				
				
				
    			public const Int32 Male = 2097152;
				
				
				
    			public const Int32 Female = 2097153;
		}
		public sealed class EWORKERPROCESSINGTYPE_
		{
				
				
				private EWORKERPROCESSINGTYPE_()
    			{
    			}

				public const Int32 DefaultValue = 2051407874; 
				
				
				
    			public const Int32 Setup = 2051407872;
				
				
				
    			public const Int32 Processing = 2051407873;
				
				
				
    			public const Int32 Both = 2051407874;
				
				
				
    			public const Int32 None = 2051407875;
		}
		public sealed class EWORKERGROUPINGTYPE
		{
				
				
				private EWORKERGROUPINGTYPE()
    			{
    			}

				public const Int32 DefaultValue = 2051473414; 
				
				
				
    			public const Int32 Customer = 2051473408;
				
				
				
    			public const Int32 Job = 2051473409;
				
				
				
    			public const Int32 Item = 2051473410;
				
				
				
    			public const Int32 Operation = 2051473411;
				
				
				
    			public const Int32 WC = 2051473412;
				
				
				
    			public const Int32 MO = 2051473413;
				
				
				
    			public const Int32 MO_Routing_Step = 2051473414;
		}
		public sealed class CourseLevel
		{
				
				
				private CourseLevel()
    			{
    			}

				public const Int32 DefaultValue = 531496960; 
				
				
				
    			public const Int32 Base = 531496960;
				
				
				
    			public const Int32 Advanced = 531496961;
				
				
				
    			public const Int32 Expert = 531496962;
		}
		public sealed class Tax_Journal
		{
				
				
				private Tax_Journal()
    			{
    			}

				public const Int32 DefaultValue = 131073; 
				
				
				
    			public const Int32 Purchase = 131072;
				
				
				
    			public const Int32 Sale = 131073;
				
				
				
    			public const Int32 Retail_Sale = 131074;
				
				[AllowISO("IT,TR")]
				
    			public const Int32 Retail_Sale_to_be_distributed = 131075;
				
				[AllowISO("IT")]
				
    			public const Int32 Sale_Suspended = 131076;
				
				[AllowISO("IT")]
				
    			public const Int32 Purchase_Suspended = 131077;
		}
		public sealed class Tax_Sign
		{
				
				
				private Tax_Sign()
    			{
    			}

				public const Int32 DefaultValue = 327680; 
				
				
				
    			public const Int32 Positive = 327680;
				
				
				
    			public const Int32 Negative = 327681;
		}
		public sealed class Balance_Type
		{
				
				
				private Balance_Type()
    			{
    			}

				public const Int32 DefaultValue = 3145730; 
				
				
				
    			public const Int32 Opening = 3145728;
				
				
				
    			public const Int32 First_Month = 3145729;
				
				
				
    			public const Int32 Standard = 3145730;
				
				
				
    			public const Int32 Last_Month = 3145731;
				
				
				
    			public const Int32 Closing = 3145732;
		}
		public sealed class Operation
		{
				
				
				private Operation()
    			{
    			}

				public const Int32 DefaultValue = 4390912; 
				
				
				
    			public const Int32 Pure = 4390912;
				
				
				
    			public const Int32 Closing = 4390913;
				
				
				
    			public const Int32 Opening = 4390914;
				
				
				
    			public const Int32 Purchase = 4390915;
				
				
				
    			public const Int32 Sale = 4390916;
				
				
				
    			public const Int32 Retail_Sale = 4390917;
				
				
				
    			public const Int32 Retail_Sale_to_be_distributed = 4390918;
				
				
				
    			public const Int32 Sale_Suspended = 4390919;
				
				
				
    			public const Int32 Purchase_Suspended = 4390920;
				
				
				
    			public const Int32 Suspended_Payment = 4390921;
		}
		public sealed class Payment_Schedule_Action
		{
				
				
				private Payment_Schedule_Action()
    			{
    			}

				public const Int32 DefaultValue = 4587520; 
				
				
				
    			public const Int32 Ignore = 4587520;
				
				
				
    			public const Int32 Open = 4587521;
				
				
				
    			public const Int32 Close = 4587522;
		}
		public sealed class DocDot_NoDot_Management
		{
				
				
				private DocDot_NoDot_Management()
    			{
    			}

				public const Int32 DefaultValue = 4718592; 
				
				
				
    			public const Int32 Mandatory = 4718592;
				
				
				
    			public const Int32 Optional = 4718593;
				
				
				
    			public const Int32 Not_Managed = 4718594;
		}
		public sealed class DocDot_Date_Management
		{
				
				
				private DocDot_Date_Management()
    			{
    			}

				public const Int32 DefaultValue = 4849664; 
				
				
				
    			public const Int32 Mandatory = 4849664;
				
				
				
    			public const Int32 Optional = 4849665;
				
				
				
    			public const Int32 Not_Managed = 4849666;
		}
		public sealed class Debit_Credit
		{
				
				
				private Debit_Credit()
    			{
    			}

				public const Int32 DefaultValue = 4980736; 
				
				
				
    			public const Int32 Debit = 4980736;
				
				
				
    			public const Int32 Credit = 4980737;
		}
		public sealed class Journal_Entry_GL_Type
		{
				
				
				private Journal_Entry_GL_Type()
    			{
    			}

				public const Int32 DefaultValue = 5177344; 
				
				
				
    			public const Int32 Normal = 5177344;
				
				
				
    			public const Int32 Adjustment = 5177345;
				
				
				
    			public const Int32 Closing = 5177346;
				
				
				
    			public const Int32 Opening = 5177347;
		}
		public sealed class Data_Type
		{
				
				
				private Data_Type()
    			{
    			}

				public const Int32 DefaultValue = 5308416; 
				
				
				
    			public const Int32 Purchases = 5308416;
				
				
				
    			public const Int32 Sales = 5308417;
				
				
				
    			public const Int32 Retail_Sales = 5308418;
				
				[AllowISO("IT,TR")]
				
    			public const Int32 Retail_Sales_distributed = 5308419;
		}
		public sealed class Journal_Entry_Type
		{
				
				
				private Journal_Entry_Type()
    			{
    			}

				public const Int32 DefaultValue = 6225920; 
				
				
				
    			public const Int32 Pure = 6225920;
				
				
				
    			public const Int32 Issued_Documents = 6225921;
				
				
				
    			public const Int32 Received_Documents = 6225922;
		}
		public sealed class GL_Line_Amount_Type
		{
				
				
				private GL_Line_Amount_Type()
    			{
    			}

				public const Int32 DefaultValue = 6356992; 
				
				
				
    			public const Int32 Ignore = 6356992;
				
				
				
    			public const Int32 Taxable_Amount = 6356993;
				
				
				
    			public const Int32 Tax = 6356994;
				
				
				
    			public const Int32 Total = 6356995;
		}
		public sealed class Journal_Entry_Value_Type
		{
				
				
				private Journal_Entry_Value_Type()
    			{
    			}

				public const Int32 DefaultValue = 9306112; 
				
				
				
    			public const Int32 Actual = 9306112;
				
				
				
    			public const Int32 Forecast = 9306113;
		}
		public sealed class Fixing_Calculation
		{
				
				
				private Fixing_Calculation()
    			{
    			}

				public const Int32 DefaultValue = 9764864; 
				
				
				
    			public const Int32 None = 9764864;
				
				
				
    			public const Int32 History = 9764865;
		}
		public sealed class Fiscal_Printout
		{
				
				
				private Fiscal_Printout()
    			{
    			}

				public const Int32 DefaultValue = 10223617; 
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Endorsement = 10223616;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 GL_Journal = 10223617;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Tax_Journals_General_Summary = 10223618;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Tax_Settlement = 10223619;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Purchases = 10223620;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Purchases_SummDot = 10223621;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Sales = 10223624;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Sales_SummDot = 10223625;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 EU_Annotations = 10223628;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 EU_Annotations_SummDot = 10223629;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Sales_with_EU_Purchases = 10223630;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Sales_with_EU_Purchases_SummDot = 10223631;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Retail_Sales = 10223632;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Retail_Sales_SummDot = 10223633;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Retail_Sales_to_be_distributed = 10223634;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Retail_Sales_to_be_distributed_SummDot = 10223635;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Distribution_Spread = 10223636;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Standard_Balance_Sheet = 10223637;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Standard_Balance_Sheet_Comparative = 10223638;
				
				
				
    			public const Int32 Agreement_Letter = 10223639;
				
				
				
    			public const Int32 Agreement = 10223640;
				[Activation("ERP.Payables")]
				
				
    			public const Int32 Payment_Order = 10223642;
				[Activation("ERP.Payables")]
				
				
    			public const Int32 Payment_Advice = 10223643;
				[Activation("ERP.VouchersReceivables")]
				
				
    			public const Int32 Collection_Voucher = 10223644;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Trial_Balance = 10223648;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Cascade_Financial_Statement = 10223649;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Cascade_Profit_Loss = 10223650;
				
				
				
    			public const Int32 Circular_Letter = 10223651;
				[Activation("ERP.MasterData_BR")]
				
				
    			public const Int32 Boleto = 10223652;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Declaration_of_Intent_Letter = 10223653;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Declaration_of_Intent_Annulment = 10223654;
				[Activation("ERP.SDDMandatePrint")]
				
				
    			public const Int32 SDD_Mandate = 10223655;
				
				
				
    			public const Int32 Compensation_Letter = 10223656;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Cascade_Financial_Statement_Comparative = 10223657;
				[Activation("ERP.Accounting")]
				
				
    			public const Int32 Cascade_Profit_Loss_Comparative = 10223658;
				[Activation("ERP.Plafond & ERP.Accounting_IT")]
				
				
    			public const Int32 Declaration_of_Intent_Journal = 10223659;
				[Activation("ERP.FixedAssets")]
				
				
    			public const Int32 Detailed_Fixed_Assets_Journal = 10223660;
				[Activation("ERP.FixedAssets")]
				
				
    			public const Int32 Detailed_History_Fixed_Assets_Journal = 10223661;
				[Activation("ERP.FixedAssets")]
				
				
    			public const Int32 Grouped_Fixed_Assets_Journal = 10223662;
				[Activation("ERP.FixedAssets")]
				
				
    			public const Int32 History_Fixed_Assets_Journal = 10223663;
				[Activation("ERP.FixedAssets & ERP.BalanceDepreciation")]
				
				
    			public const Int32 Detailed_Fixed_Assets_Sectional_Inventory_Journal = 10223664;
				[Activation("ERP.FixedAssets & ERP.BalanceDepreciation")]
				
				
    			public const Int32 Detailed_History_Fixed_Assets_Sectional_Inventory_Journal = 10223665;
				[Activation("ERP.FixedAssets & ERP.BalanceDepreciation")]
				
				
    			public const Int32 Grouped_Fixed_Assets_Sectional_Inventory_Journal = 10223666;
				[Activation("ERP.Dunnings")]
				
				
    			public const Int32 Dunning_Letter = 10223667;
		}
		public sealed class Tax_Regime
		{
				
				
				private Tax_Regime()
    			{
    			}

				public const Int32 DefaultValue = 11534339; 
				
				
				
    			public const Int32 Total_exemption = 11534336;
				[Activation("ERP.Accounting_CH")]
				
				
    			public const Int32 LumpMinussum = 11534337;
				[Activation("ERP.Accounting_CH")]
				
				
    			public const Int32 Above_collection = 11534338;
				
				
				
    			public const Int32 Above_turnover = 11534339;
		}
		public sealed class Reverse_Charge
		{
				
				
				private Reverse_Charge()
    			{
    			}

				public const Int32 DefaultValue = 2031616; 
				
				
				
    			public const Int32 Ignore_Reverse_Charge = 2031616;
				
				
				
    			public const Int32 Total_Reverse_Charge = 2031617;
				
				[AllowISO("IT,HU,RO,ES,DE")]
				
    			public const Int32 Partial_Reverse_Charge = 2031618;
		}
		public sealed class Tax_Operation_Type
		{
				
				
				private Tax_Operation_Type()
    			{
    			}

				public const Int32 DefaultValue = 28377088; 
				
				
				
    			public const Int32 Automatic = 28377088;
				
				
				
    			public const Int32 Operation_excluded = 28377089;
				
				
				
    			public const Int32 Operation_included = 28377090;
		}
		public sealed class Tax_Communication_Payment_Type
		{
				
				
				private Tax_Communication_Payment_Type()
    			{
    			}

				public const Int32 DefaultValue = 28442624; 
				
				
				
    			public const Int32 Not_splittable = 28442624;
				
				
				
    			public const Int32 Splittable = 28442625;
				
				
				
    			public const Int32 Retails = 28442626;
		}
		public sealed class Accounting_Inventory_Book_Printout
		{
				
				
				private Accounting_Inventory_Book_Printout()
    			{
    			}

				public const Int32 DefaultValue = 30998528; 
				
				
				
    			public const Int32 Cascade_Financial_Statement = 30998528;
				
				
				
    			public const Int32 Cascade_Financial_Statement_Comparative = 30998529;
				
				
				
    			public const Int32 Cascade_Profit_Loss = 30998530;
				
				
				
    			public const Int32 Cascade_Profit_Loss_Comparative = 30998531;
				
				
				
    			public const Int32 Accounting_Inventory = 30998532;
				
				
				
    			public const Int32 CustomerSlashSupplier_Balance_Sheet = 30998533;
				
				
				
    			public const Int32 CustomerSlashSupplier_Balance_Sheet_by_Account = 30998534;
				
				
				
    			public const Int32 Documents_to_be_IssuedSlashReceived = 30998535;
				
				
				
    			public const Int32 EU_Balance_Sheet = 30998536;
				
				
				
    			public const Int32 EU_Balance_Sheet_Cascade = 30998537;
				
				
				
    			public const Int32 EU_Balance_Sheet_Abbreviated = 30998538;
				
				
				
    			public const Int32 EU_Balance_Sheet_Abbreviated_Cascade = 30998539;
				
				
				
    			public const Int32 EU_Profit_Loss = 30998540;
				
				
				
    			public const Int32 EU_Memorandum = 30998541;
				
				
				
    			public const Int32 Basel_II_Balance_Sheet = 30998542;
				
				
				
    			public const Int32 Basel_II_Balance_Sheet_Cascade = 30998543;
				
				
				
    			public const Int32 Basel_II_Profit_Loss = 30998544;
				
				
				
    			public const Int32 Fixed_Assets_Journal = 30998545;
				
				
				
    			public const Int32 Fixed_Assets_Journal_Balance_Regime = 30998546;
				
				
				
    			public const Int32 Fixed_Assets_in_Balance_Sheet_Notes = 30998547;
				
				
				
    			public const Int32 Fixed_Assets_in_Balance_Sheet_Notes_Balance_Regime = 30998548;
				
				
				
    			public const Int32 Standard_Balance_Sheet = 30998549;
				
				
				
    			public const Int32 Standard_Balance_Sheet_Comparative = 30998550;
		}
		public sealed class Accounting_Inventory_Attachments_Line_Type
		{
				
				
				private Accounting_Inventory_Attachments_Line_Type()
    			{
    			}

				public const Int32 DefaultValue = 31064064; 
				
				
				
    			public const Int32 Manual = 31064064;
				
				
				
    			public const Int32 Account_Balance = 31064065;
				
				
				
    			public const Int32 Group_Balance = 31064066;
		}
		public sealed class Tax_Declaration_Action_On_Total
		{
				
				
				private Tax_Declaration_Action_On_Total()
    			{
    			}

				public const Int32 DefaultValue = 31129600; 
				
				
				
    			public const Int32 Sum = 31129600;
				
				
				
    			public const Int32 Subtract = 31129601;
				
				
				
    			public const Int32 Ignore = 31129602;
		}
		public sealed class Tax_Declaration_Amount_Type
		{
				
				
				private Tax_Declaration_Amount_Type()
    			{
    			}

				public const Int32 DefaultValue = 31195136; 
				
				
				
    			public const Int32 Deductible = 31195136;
				
				
				
    			public const Int32 Nondeductible = 31195137;
				
				
				
    			public const Int32 DeductiblePlusNondeductible = 31195138;
				
				
				
    			public const Int32 Exigible_Previous_Years = 31195139;
				
				
				
    			public const Int32 Not_Exigible_Next_Years = 31195140;
				
				
				
    			public const Int32 Not_Exigible_Cash_Next_Years = 31195141;
				
				
				
    			public const Int32 Tax_Summaries = 31195142;
				
				
				
    			public const Int32 Split_Payment = 31195143;
		}
		public sealed class Tax_Declaration_Column_Type
		{
				
				
				private Tax_Declaration_Column_Type()
    			{
    			}

				public const Int32 DefaultValue = 31850496; 
				
				
				
    			public const Int32 TaxablePlusTax = 31850496;
				
				
				
    			public const Int32 Taxable = 31850497;
				
				
				
    			public const Int32 Tax = 31850498;
		}
		public sealed class Postpone_Sales_Tax_Type
		{
				
				
				private Postpone_Sales_Tax_Type()
    			{
    			}

				public const Int32 DefaultValue = 2162688; 
				
				
				
    			public const Int32 First_Day_next_period = 2162688;
				
				
				
    			public const Int32 Same_Day_next_period = 2162689;
				
				
				
    			public const Int32 Last_Day_next_period = 2162690;
		}
		public sealed class Postpone_Sales_Tax_Period
		{
				
				
				private Postpone_Sales_Tax_Period()
    			{
    			}

				public const Int32 DefaultValue = 2228224; 
				
				
				
    			public const Int32 Next_Quarter = 2228224;
				
				
				
    			public const Int32 Next_Month = 2228225;
		}
		public sealed class Balance_Type_for_Transfer
		{
				
				
				private Balance_Type_for_Transfer()
    			{
    			}

				public const Int32 DefaultValue = 5046272; 
				
				
				
    			public const Int32 Trial = 5046272;
				
				
				
    			public const Int32 Balance = 5046273;
		}
		public sealed class ZM_Declaration_Period
		{
				
				
				private ZM_Declaration_Period()
    			{
    			}

				public const Int32 DefaultValue = 851968; 
				
				
				
    			public const Int32 Monthly = 851968;
				
				
				
    			public const Int32 TwoMinusMonthly = 851969;
				
				
				
    			public const Int32 Quarterly = 851970;
				
				
				
    			public const Int32 Yearly = 851971;
		}
		public sealed class CustSuppListType
		{
				
				
				private CustSuppListType()
    			{
    			}

				public const Int32 DefaultValue = 12320768; 
				
				
				
    			public const Int32 Ignore = 12320768;
				
				
				
    			public const Int32 Taxable_Amount = 12320769;
				
				
				
    			public const Int32 Not_Taxable = 12320770;
				
				
				
    			public const Int32 Exempt = 12320771;
				
				
				
    			public const Int32 Taxable_Amount_Not_In_Invoice = 12320772;
				
				
				
    			public const Int32 Taxable_Amount_With_Tax = 12320773;
		}
		public sealed class ThreeNineFour_Declaration_Type
		{
				
				
				private ThreeNineFour_Declaration_Type()
    			{
    			}

				public const Int32 DefaultValue = 42598407; 
				
				
				
    			public const Int32 Operations_made_by_UE_Subjects = 42598400;
				
				
				
    			public const Int32 Operations_made_by_EXTRAMinusUE_Subjects = 42598401;
				
				
				
    			public const Int32 Simplified_invoices_issued_with_taxno = 42598402;
				
				
				
    			public const Int32 Simplified_invoices_issued_no_taxno = 42598403;
				
				
				
    			public const Int32 Simplified_invoices_received = 42598404;
				
				
				
    			public const Int32 Simplified_invoices_received_suspended = 42598405;
				
				
				
    			public const Int32 Simplified_invoices_received_receipt = 42598406;
				
				
				
    			public const Int32 Corrections_invoices = 42598407;
				
				
				
    			public const Int32 Self_invoices = 42598408;
				
				
				
    			public const Int32 Invoices_issued_on_Behalf_of_DotDotDot = 42598409;
				
				
				
    			public const Int32 Retail_Sales_Type_I1 = 42598410;
				
				
				
    			public const Int32 Retail_Sales_Type_I2 = 42598411;
				
				
				
    			public const Int32 Annulled_Invoices = 42598412;
				
				
				
    			public const Int32 Special_Regime_Purchase = 42598413;
		}
		public sealed class Form_of_Ownership
		{
				
				
				private Form_of_Ownership()
    			{
    			}

				public const Int32 DefaultValue = 4456448; 
				
				
				
    			public const Int32 OneOne_Autonomous_Regions = 4456448;
				
				
				
    			public const Int32 OneTwo_Wholly_stateMinusowned_companies = 4456449;
				
				
				
    			public const Int32 OneThree_National_research_and_development_institutes = 4456450;
				
				
				
    			public const Int32 OneFour_National_companies_and_corporations = 4456451;
				
				
				
    			public const Int32 OneFive_Companies_that_are_subsidiaries_of_wholly_stateMinusowned_companies_and_companies_in_which_one_or_more_wholly_stateMinusowned_companies_have_a_holding = 4456452;
				
				
				
    			public const Int32 OneSix_Other_state_economic_units_not_transformed_into_companies_or_autonomous_corporations = 4456453;
				
				
				
    			public const Int32 TwoOne_StateMinusowned_domestic_and_foreign_companies_state_capital_below_50 = 4456454;
				
				
				
    			public const Int32 TwoTwo_Companies_with_domestic_and_foreign_state_and_private_capital_state_capital_below_50 = 4456455;
				
				
				
    			public const Int32 TwoThree_Companies_with_state_and_private_domestic_capital_state_capital_below_50 = 4456456;
				
				
				
    			public const Int32 TwoFour_Companies_with_state_and_foreign_private_capital_state_capital_below_50 = 4456457;
				
				
				
    			public const Int32 TwoFive_Companies_with_domestic_and_foreign_state_capital_state_capital_GreaterThanEquals_50 = 4456458;
				
				
				
    			public const Int32 TwoSix_Companies_with_domestic_and_foreign_state_and_private_capital_state_capital_GreaterThanEquals50 = 4456459;
				
				
				
    			public const Int32 TwoSeven_Companies_with_state_and_domestic_private_capital_state_capital_GreaterThanEquals50 = 4456460;
				
				
				
    			public const Int32 TwoEight_Companies_with_state_and_foreign_private_capital_state_capital_GreaterThanEquals50 = 4456461;
				
				
				
    			public const Int32 TwoNine_Companies_representing_subsidiaries_of_companies_with_more_than_50_state_capitalComma_inclusiveComma_and_companies_in_which_one_or_more_companies_with_more_than_50_state_capitalComma_inclusiveComma_hold_between_50_and_100_of_their_capital_stock = 4456462;
				
				
				
    			public const Int32 ThreeOne_General_partnerships = 4456463;
				
				
				
    			public const Int32 ThreeTwo_Limited_partnerships = 4456464;
				
				
				
    			public const Int32 ThreeThree_Partnerships_limited_by_shares = 4456465;
				
				
				
    			public const Int32 ThreeFour_Joint_stock_companies = 4456466;
				
				
				
    			public const Int32 ThreeFive_Limited_liability_companies = 4456467;
				
				
				
    			public const Int32 ThreeSix_Agricultural_companies = 4456468;
				
				
				
    			public const Int32 ThreeSeven_StateMinusowned_companies_privatised_during_the_reporting_year = 4456469;
				
				
				
    			public const Int32 FourOne_Consumer_cooperatives = 4456470;
				
				
				
    			public const Int32 FourTwo_Craft_cooperatives = 4456471;
				
				
				
    			public const Int32 FourThree_Unprocessed_agricultural_cooperatives_and_associations = 4456472;
				
				
				
    			public const Int32 FourFour_Credit_cooperatives = 4456473;
				
				
				
    			public const Int32 FiveZero_Societies_belonging_to_political_and_public_organisations_and_institution_ = 4456474;
		}
		public sealed class Quality_Nomenclature
		{
				
				
				private Quality_Nomenclature()
    			{
    			}

				public const Int32 DefaultValue = 4521984; 
				
				
				
    			public const Int32 OneOne_Economic_director = 4521984;
				
				
				
    			public const Int32 OneTwo_Chief_accountant = 4521985;
				
				
				
    			public const Int32 OneThree_Other_person_empowered_by_law = 4521986;
				
				
				
    			public const Int32 TwoOne_Authorised_natural_personsComma_members_of_the_auditor = 4521987;
				
				
				
    			public const Int32 TwoTwo_Authorised_legal_entitiesComma_members_of_the_supervisory_board = 4521988;
		}
		public sealed class Distribution
		{
				
				
				private Distribution()
    			{
    			}

				public const Int32 DefaultValue = 196608; 
				
				
				
    			public const Int32 Fixed = 196608;
				
				
				
    			public const Int32 Taxable_amount = 196609;
				
				
				
    			public const Int32 Qty = 196610;
				
				
				
    			public const Int32 Gross_Weight = 196611;
				
				
				
    			public const Int32 Net_Weight = 196612;
				
				
				
    			public const Int32 Cubage = 196613;
				
				
				
    			public const Int32 NoDot_of_packs = 196614;
		}
		public sealed class AGO_Operation_Type
		{
				
				
				private AGO_Operation_Type()
    			{
    			}

				public const Int32 DefaultValue = 2032467968; 
				
				
				
    			public const Int32 Purchase_Invoice = 2032467968;
				
				
				
    			public const Int32 Sale_Invoice = 2032467969;
				
				
				
    			public const Int32 Retail = 2032467970;
				
				
				
    			public const Int32 Retail_monthly_not_managed = 2032467971;
				
				
				
    			public const Int32 Pure_Accounting_Entry = 2032467972;
				
				
				
    			public const Int32 Adjustment_not_managed = 2032467973;
		}
		public sealed class Bill_Type
		{
				
				
				private Bill_Type()
    			{
    			}

				public const Int32 DefaultValue = 5373952; 
				
				
				[DenyISO("RO,RS,HR,BR,CH")]
    			public const Int32 Cash_Order = 5373952;
				
				
				[DenyISO("BR,CH,ES")]
    			public const Int32 Bill_of_Exchange = 5373953;
				
				
				[DenyISO("RO,RS,HR,BR,CH,ES,DE")]
    			public const Int32 PaN = 5373954;
				
				
				[DenyISO("RO,RS,HR,BR")]
    			public const Int32 SEPA_SDD_Core = 5373955;
				
				[AllowISO("RO,RS,HR,BR")]
				
    			public const Int32 Check = 5373956;
				
				[AllowISO("IT,ES,DE,CH,FR,GB,AT")]
				
    			public const Int32 SEPA_SDD_B2B = 5373957;
				
				[AllowISO("ES")]
				
    			public const Int32 Bank_Draft = 5373958;
				
				[AllowISO("ES")]
				
    			public const Int32 Confirming = 5373959;
		}
		public sealed class Payment_Order_Type
		{
				
				
				private Payment_Order_Type()
    			{
    			}

				public const Int32 DefaultValue = 5439488; 
				
				
				[DenyISO("RO")]
    			public const Int32 Check = 5439488;
				
				
				[DenyISO("RO")]
    			public const Int32 Bank_Draft = 5439489;
				
				
				
    			public const Int32 Bank_Transfer = 5439490;
				
				
				[DenyISO("CH,RO,RS,HR,BR,ES")]
    			public const Int32 Cash_Order = 5439491;
				
				
				[DenyISO("CH,RO,RS,HR,BR,DE")]
    			public const Int32 PaN = 5439492;
				
				
				[DenyISO("ES")]
    			public const Int32 SEPA_SDD_Core = 5439493;
				
				
				[DenyISO("ES")]
    			public const Int32 Foreign_Bank_Transfer = 5439494;
				
				[AllowISO("CH")]
				
    			public const Int32 Bank_Slip = 5439495;
				
				[AllowISO("CH")]
				
    			public const Int32 Postal_Slip = 5439496;
				
				[AllowISO("CH")]
				
    			public const Int32 Postal_Money_Order = 5439497;
				
				[AllowISO("CH")]
				
    			public const Int32 International_Money_Order = 5439498;
				
				[AllowISO("ES")]
				
    			public const Int32 Confirming = 5439499;
		}
		public sealed class Payment_Schedule_Installment_Type
		{
				
				
				private Payment_Schedule_Installment_Type()
    			{
    			}

				public const Int32 DefaultValue = 5505024; 
				
				
				
    			public const Int32 Opening = 5505024;
				
				
				
    			public const Int32 Closing = 5505025;
		}
		public sealed class Bill_Grouping_Type
		{
				
				
				private Bill_Grouping_Type()
    			{
    			}

				public const Int32 DefaultValue = 6881280; 
				
				
				
    			public const Int32 Do_Not_Group = 6881280;
				
				
				
    			public const Int32 Same_Date = 6881281;
				
				
				
    			public const Int32 Same_Period = 6881282;
		}
		public sealed class Closing_Installment_Type
		{
				
				
				private Closing_Installment_Type()
    			{
    			}

				public const Int32 DefaultValue = 6946816; 
				
				
				
    			public const Int32 Normal = 6946816;
				
				
				
    			public const Int32 Allowance = 6946817;
				
				
				
    			public const Int32 Reopening = 6946818;
				
				
				
    			public const Int32 Exchange_Rate = 6946819;
				
				
				
    			public const Int32 Overpayment = 6946820;
				
				
				
    			public const Int32 Withholding_Tax = 6946821;
				
				
				
    			public const Int32 Revaluation = 6946822;
		}
		public sealed class Presentation
		{
				
				
				private Presentation()
    			{
    			}

				public const Int32 DefaultValue = 1376260; 
				
				
				
    			public const Int32 Subject_to_Collection = 1376256;
				
				
				
    			public const Int32 After_Collection = 1376257;
				
				
				
    			public const Int32 At_Due_Date = 1376258;
				
				
				
    			public const Int32 Upon_Discount = 1376259;
				
				
				
    			public const Int32 Ignore = 1376260;
				[Activation("ERP.AP_AR_Plus")]
				
				
    			public const Int32 Factoring = 1376261;
		}
		public sealed class GL_Journal_Notes_Type
		{
				
				
				private GL_Journal_Notes_Type()
    			{
    			}

				public const Int32 DefaultValue = 10813440; 
				
				
				
    			public const Int32 Installment_NoDotComma_Document_NoDotComma_Document_Date = 10813440;
				
				
				
    			public const Int32 Installment_NoDotComma_Document_NoDotComma_Due_Date = 10813441;
				
				
				
    			public const Int32 Payment_OrderSlashBillSlashVoucher_NoDot = 10813442;
				
				
				
    			public const Int32 Document_NoDotComma_Document_Date = 10813443;
				
				
				
    			public const Int32 Document_NoDotComma_Due_Date = 10813444;
				
				
				
    			public const Int32 Document_NoDot = 10813445;
				
				
				
    			public const Int32 Document_NoDotComma_Document_DateComma_Due_Date = 10813446;
				
				
				
    			public const Int32 Installment_NoDotComma_Document_NoDotComma_Document_and_Due_Date = 10813447;
				
				
				
    			public const Int32 Installment_NoDotComma_Document_NoDotComma_Document_and_Due_DateComma_Contract_and_Project_Code = 10813448;
		}
		public sealed class Charges_Type_for_Foreign_Bank_Transfer
		{
				
				
				private Charges_Type_for_Foreign_Bank_Transfer()
    			{
    			}

				public const Int32 DefaultValue = 25559040; 
				
				
				
    			public const Int32 Mandant_and_Beneficiary_debit = 25559040;
				
				
				
    			public const Int32 Mandant_debit = 25559041;
				
				
				
    			public const Int32 Beneficiary_debit_ = 25559042;
		}
		public sealed class Bill_Status
		{
				
				
				private Bill_Status()
    			{
    			}

				public const Int32 DefaultValue = 5701632; 
				
				
				
    			public const Int32 Received = 5701632;
				
				
				
    			public const Int32 Presented = 5701633;
				
				
				
    			public const Int32 Collected = 5701634;
				
				
				
    			public const Int32 Transferred = 5701635;
				
				
				
    			public const Int32 Outstanding = 5701636;
				
				[AllowISO("BR")]
				
    			public const Int32 Returned_1 = 5701637;
				
				[AllowISO("BR")]
				
    			public const Int32 Represented = 5701638;
				
				[AllowISO("BR")]
				
    			public const Int32 Returned_2 = 5701639;
				
				
				
    			public const Int32 Blank = 5701640;
				
				
				
    			public const Int32 Issued = 5701641;
				
				
				
    			public const Int32 Paid = 5701642;
		}
		public sealed class Factoring_Type
		{
				
				
				private Factoring_Type()
    			{
    			}

				public const Int32 DefaultValue = 5242880; 
				
				
				
    			public const Int32 Without_recourse = 5242880;
				
				
				
    			public const Int32 With_recourse = 5242881;
		}
		public sealed class SEPA_Transaction_Type
		{
				
				
				private SEPA_Transaction_Type()
    			{
    			}

				public const Int32 DefaultValue = 29425665; 
				
				
				
    			public const Int32 First = 29425664;
				
				
				
    			public const Int32 Recurrent = 29425665;
				
				
				
    			public const Int32 Final = 29425666;
				
				
				
    			public const Int32 OneMinusOff = 29425667;
		}
		public sealed class Reclassification_line_type
		{
				
				
				private Reclassification_line_type()
    			{
    			}

				public const Int32 DefaultValue = 12058624; 
				
				
				
    			public const Int32 Normal = 12058624;
				
				
				
    			public const Int32 Subtotal_Level_1 = 12058625;
				
				
				
    			public const Int32 Progressive_Total = 12058626;
				
				
				
    			public const Int32 Side_calculation = 12058627;
				
				
				
    			public const Int32 Title = 12058628;
				
				
				
    			public const Int32 Subtotal_Level_2 = 12058629;
				
				
				
    			public const Int32 Subtotal_Level_3 = 12058630;
		}
		public sealed class Cash_Flow_type
		{
				[AllowISO("BG")]
				
				private Cash_Flow_type()
    			{
    			}

				public const Int32 DefaultValue = 8781828; 
				
				
				
    			public const Int32 Cash = 8781824;
				
				
				
    			public const Int32 Main_Activities = 8781825;
				
				
				
    			public const Int32 Investments = 8781826;
				
				
				
    			public const Int32 Financials = 8781827;
				
				
				
    			public const Int32 Ignore = 8781828;
		}
		public sealed class Reclassification_balance_type
		{
				
				
				private Reclassification_balance_type()
    			{
    			}

				public const Int32 DefaultValue = 8847360; 
				
				
				
    			public const Int32 Balance = 8847360;
				
				
				
    			public const Int32 Opening_Balance = 8847361;
				
				
				
    			public const Int32 Side = 8847362;
				
				
				
    			public const Int32 With_Offset = 8847363;
				
				[AllowISO("BG")]
				
    			public const Int32 Opening_Minus_Balance_if_Opening_GreaterThan_Balance = 8847364;
				
				[AllowISO("BG")]
				
    			public const Int32 Opening_Minus_Balance_if_Opening_LowerThan_Balance = 8847365;
		}
		public sealed class Reclassification_balance_sign
		{
				
				
				private Reclassification_balance_sign()
    			{
    			}

				public const Int32 DefaultValue = 8912896; 
				
				
				
    			public const Int32 Plus = 8912896;
				
				
				
    			public const Int32 Minus = 8912897;
		}
		public sealed class Balance_Section_Type
		{
				
				
				private Balance_Section_Type()
    			{
    			}

				public const Int32 DefaultValue = 25755648; 
				
				
				
    			public const Int32 Nothing = 25755648;
				
				
				
    			public const Int32 Normal = 25755649;
				
				
				
    			public const Int32 Consolidated = 25755650;
				
				
				
    			public const Int32 Abbreviated = 25755651;
				
				
				
    			public const Int32 Abbreviated_Simplified_until_2013 = 25755652;
				
				
				
    			public const Int32 Micro_Company = 25755653;
		}
		public sealed class BankStatementStatus
		{
				
				
				private BankStatementStatus()
    			{
    			}

				public const Int32 DefaultValue = 458752; 
				
				
				
    			public const Int32 To_Be_Processed = 458752;
				
				
				
    			public const Int32 In_process = 458753;
				
				
				
    			public const Int32 Processed = 458754;
		}
		public sealed class Bank_Statement_Field
		{
				
				
				private Bank_Statement_Field()
    			{
    			}

				public const Int32 DefaultValue = 1114112; 
				
				
				
    			public const Int32 Posting_Date = 1114112;
				
				
				
    			public const Int32 Value_Date = 1114113;
				
				
				
    			public const Int32 Debit = 1114114;
				
				
				
    			public const Int32 Credit = 1114115;
				
				
				
    			public const Int32 Amount = 1114116;
				
				
				
    			public const Int32 Reason = 1114117;
				
				
				
    			public const Int32 Reason_description = 1114118;
				
				
				
    			public const Int32 Description = 1114119;
				
				
				
    			public const Int32 Additional_Description = 1114120;
		}
		public sealed class Brazilian_Banks_File_Layout
		{
				[AllowISO("BR")]
				
				private Brazilian_Banks_File_Layout()
    			{
    			}

				public const Int32 DefaultValue = 393216; 
				
				
				
    			public const Int32 Not_Managed = 393216;
				
				
				
    			public const Int32 CNAB240 = 393217;
				
				
				
    			public const Int32 CNAB400 = 393218;
		}
		public sealed class Brazilian_Banks_File_Name
		{
				[AllowISO("BR")]
				
				private Brazilian_Banks_File_Name()
    			{
    			}

				public const Int32 DefaultValue = 20971520; 
				
				
				
    			public const Int32 Standard = 20971520;
				
				
				
    			public const Int32 Date = 20971521;
				
				
				
    			public const Int32 Number = 20971522;
		}
		public sealed class Barcode_Data
		{
				
				
				private Barcode_Data()
    			{
    			}

				public const Int32 DefaultValue = 27721728; 
				
				
				
    			public const Int32 Item = 27721728;
				
				
				
    			public const Int32 Manufacturing_Order = 27721729;
				
				
				
    			public const Int32 Lot = 27721730;
				
				
				
    			public const Int32 Unit_of_Measure = 27721731;
				
				
				
    			public const Int32 Quantity = 27721732;
				
				
				
    			public const Int32 Weight = 27721733;
				
				
				
    			public const Int32 Volume = 27721734;
				
				
				
    			public const Int32 Purchase_Order = 27721735;
				
				
				
    			public const Int32 Storage_Unit = 27721736;
				
				
				
    			public const Int32 Bin = 27721737;
				
				
				
    			public const Int32 Free = 27721738;
				
				
				
    			public const Int32 Lot_Expiry_Date_YYMMDD = 27721739;
				
				
				
    			public const Int32 Cost_Center = 27721740;
				
				
				
    			public const Int32 Internal_IdDot_NoDot = 27721741;
		}
		public sealed class Barcode_Variable_Data
		{
				
				
				private Barcode_Variable_Data()
    			{
    			}

				public const Int32 DefaultValue = 2032664576; 
				
				
				
    			public const Int32 Weight = 2032664576;
				
				
				
    			public const Int32 Price = 2032664577;
				
				
				
    			public const Int32 Ignore = 2032664578;
		}
		public sealed class BOM_Component_Type
		{
				
				
				private BOM_Component_Type()
    			{
    			}

				public const Int32 DefaultValue = 7798784; 
				
				
				
    			public const Int32 Item = 7798784;
				
				
				
    			public const Int32 Phantom = 7798787;
				
				
				
    			public const Int32 Notes = 7798789;
				
				
				
    			public const Int32 Reference = 7798790;
		}
		public sealed class NonMinusRegistered_Component_Type
		{
				
				
				private NonMinusRegistered_Component_Type()
    			{
    			}

				public const Int32 DefaultValue = 7864320; 
				
				
				
    			public const Int32 Materials = 7864320;
				
				
				
    			public const Int32 Production_Cost = 7864321;
		}
		public sealed class Line_Variation_Type
		{
				
				
				private Line_Variation_Type()
    			{
    			}

				public const Int32 DefaultValue = 10551296; 
				
				
				
    			public const Int32 Enter = 10551296;
				
				
				
    			public const Int32 Edit = 10551297;
				
				
				
    			public const Int32 Delete = 10551298;
		}
		public sealed class BOM_Check_Type
		{
				
				
				private BOM_Check_Type()
    			{
    			}

				public const Int32 DefaultValue = 10944512; 
				
				
				
    			public const Int32 None = 10944512;
				
				
				
    			public const Int32 BOM_Description = 10944513;
				
				
				
    			public const Int32 Aligned_Operation_Times = 10944514;
				
				
				
    			public const Int32 Component_Code_Existence = 10944515;
				
				
				
    			public const Int32 BOM_Code_Existence = 10944516;
				
				
				
    			public const Int32 Component_Item_Status = 10944517;
				
				
				
    			public const Int32 BOM_Item_Status = 10944518;
				
				
				
    			public const Int32 Variant_Existence = 10944519;
				
				
				
    			public const Int32 Linked_BOMs_being_Designed = 10944520;
				
				
				
    			public const Int32 BOMs_being_Designed = 10944521;
				
				
				
    			public const Int32 Purchase_Type_BOMs = 10944522;
				
				
				
    			public const Int32 BOMs_without_routing_Steps = 10944523;
				
				
				
    			public const Int32 OperationSlashWork_Center_Existence = 10944524;
				
				
				
    			public const Int32 At_Least_One_Time_on_Steps = 10944525;
				
				
				
    			public const Int32 Component_Validity_End_Date_Exceeded = 10944526;
				
				
				
    			public const Int32 Recursiveness_Check = 10944527;
		}
		public sealed class Steps_Numbering
		{
				
				
				private Steps_Numbering()
    			{
    			}

				public const Int32 DefaultValue = 21037056; 
				
				
				
    			public const Int32 Manual = 21037056;
				
				
				
    			public const Int32 Auto_1_2_3DotDotDot = 21037057;
				
				
				
    			public const Int32 Auto_10_20_30DotDotDot = 21037058;
				
				
				
    			public const Int32 Auto_100_200_300DotDotDot = 21037059;
		}
		public sealed class Production_Plan_Row_Status
		{
				
				
				private Production_Plan_Row_Status()
    			{
    			}

				public const Int32 DefaultValue = 21364736; 
				
				
				
    			public const Int32 Proposed = 21364736;
				
				
				
    			public const Int32 Fulfilled = 21364737;
		}
		public sealed class Description_on_Subcontracting_DN
		{
				
				
				private Description_on_Subcontracting_DN()
    			{
    			}

				public const Int32 DefaultValue = 24576000; 
				
				
				
    			public const Int32 Step_Plus_Operation_Description = 24576000;
				
				
				
    			public const Int32 Step_Plus_Notes = 24576001;
				
				
				
    			public const Int32 Operation_Description_Plus_Notes = 24576002;
				
				
				
    			public const Int32 Component_List = 24576003;
				
				
				
    			public const Int32 Product_Description = 24576004;
		}
		public sealed class MRP_Policy
		{
				
				
				private MRP_Policy()
    			{
    			}

				public const Int32 DefaultValue = 22609920; 
				
				
				
    			public const Int32 Daily_Requirement = 22609920;
				
				
				
    			public const Int32 Lot = 22609923;
				
				
				
    			public const Int32 By_Job = 22609926;
		}
		public sealed class EWORKERMESSAGETYPE_
		{
				
				
				private EWORKERMESSAGETYPE_()
    			{
    			}

				public const Int32 DefaultValue = 2051342336; 
				
				
				
    			public const Int32 Hint = 2051342336;
				
				
				
    			public const Int32 Warning = 2051342337;
				
				
				
    			public const Int32 Error = 2051342338;
		}
		public sealed class ECO_Status
		{
				
				
				private ECO_Status()
    			{
    			}

				public const Int32 DefaultValue = 26148864; 
				
				
				
    			public const Int32 Proposed = 26148864;
				
				
				
    			public const Int32 In_progress = 26148865;
				
				
				
    			public const Int32 Confirmed = 26148866;
		}
		public sealed class Brasil_Tax_Type
		{
				
				
				private Brasil_Tax_Type()
    			{
    			}

				public const Int32 DefaultValue = 29032450; 
				
				
				
    			public const Int32 II = 29032448;
				
				
				
    			public const Int32 IPI = 29032449;
				
				
				
    			public const Int32 PIS = 29032450;
				
				
				
    			public const Int32 COFINS = 29032451;
				
				
				
    			public const Int32 ICMS = 29032452;
				
				
				
    			public const Int32 ICMSMinusST = 29032453;
				
				
				
    			public const Int32 SUFRAMA = 29032454;
				
				
				
    			public const Int32 SIMPLES = 29032455;
				
				
				
    			public const Int32 ISS = 29032456;
				
				
				
    			public const Int32 IR = 29032457;
				
				
				
    			public const Int32 CS = 29032458;
				
				
				
    			public const Int32 INSS = 29032459;
				
				
				
    			public const Int32 Presumed_Credit = 29032460;
		}
		public sealed class Autonumbering_Type
		{
				
				
				private Autonumbering_Type()
    			{
    			}

				public const Int32 DefaultValue = 29097984; 
				
				
				
    			public const Int32 Specific_Tax_Rules_for_Tax_Calculation = 29097984;
				
				
				
    			public const Int32 General_Tax_Rules = 29097985;
				
				
				
    			public const Int32 Tax_Rules_for_Nota_Fiscal_to_be_imported = 29097986;
		}
		public sealed class Nota_Fiscal_Reference_Type
		{
				
				
				private Nota_Fiscal_Reference_Type()
    			{
    			}

				public const Int32 DefaultValue = 29229056; 
				
				
				
    			public const Int32 CTe = 29229056;
				
				
				
    			public const Int32 Nota_Fiscal = 29229057;
				
				
				
    			public const Int32 NFe = 29229058;
				
				
				
    			public const Int32 Fiscal_Receipt = 29229059;
				
				
				
    			public const Int32 Agrarian_Producer_NF = 29229060;
		}
		public sealed class Nota_Fiscal_Type_Action
		{
				
				
				private Nota_Fiscal_Type_Action()
    			{
    			}

				public const Int32 DefaultValue = 29556736; 
				
				
				
    			public const Int32 Ignore = 29556736;
				
				
				
    			public const Int32 Sum = 29556737;
				
				
				
    			public const Int32 Subtract = 29556738;
		}
		public sealed class Vehicle_Type
		{
				
				
				private Vehicle_Type()
    			{
    			}

				public const Int32 DefaultValue = 29622272; 
				
				
				
    			public const Int32 Tractor = 29622272;
				
				
				
    			public const Int32 Trailer = 29622273;
		}
		public sealed class Vehicle_Type_Property
		{
				
				
				private Vehicle_Type_Property()
    			{
    			}

				public const Int32 DefaultValue = 29687808; 
				
				
				
    			public const Int32 Own_Vehicle = 29687808;
				
				
				
    			public const Int32 Vehicle_of_Third_Parties = 29687809;
		}
		public sealed class Vehicle_Fuel_Type
		{
				
				
				private Vehicle_Fuel_Type()
    			{
    			}

				public const Int32 DefaultValue = 29753344; 
				
				
				
    			public const Int32 Petrol = 29753344;
				
				
				
    			public const Int32 Grain_Alcohol = 29753345;
				
				
				
    			public const Int32 Diesel = 29753346;
				
				
				
    			public const Int32 Natural_Gas = 29753347;
		}
		public sealed class Romaneio_Status
		{
				
				
				private Romaneio_Status()
    			{
    			}

				public const Int32 DefaultValue = 29818880; 
				
				
				
    			public const Int32 Open = 29818880;
				
				
				
    			public const Int32 Confirmed = 29818881;
				
				
				
    			public const Int32 Closed = 29818882;
		}
		public sealed class NFe_Issuing_Purpose
		{
				
				
				private NFe_Issuing_Purpose()
    			{
    			}

				public const Int32 DefaultValue = 29949952; 
				
				
				
    			public const Int32 NFe_Normal = 29949952;
				
				
				
    			public const Int32 NFe_AdjDot_Credit_Transfer = 29949953;
				
				
				
    			public const Int32 NFe_AdjDot_Compensation_ICMS_ST = 29949954;
				
				
				
    			public const Int32 NFe_AddDot_Quantity = 29949955;
				
				
				
    			public const Int32 NFe_AddDot_Price = 29949956;
				
				
				
    			public const Int32 NFe_AddDot_Taxable_Amount_Correction = 29949957;
				
				
				
    			public const Int32 NFe_Return = 29949958;
				
				
				
    			public const Int32 NFe_Import = 29949959;
				
				
				
    			public const Int32 NFe_Export = 29949960;
		}
		public sealed class Customer_Presence_Indicator
		{
				
				
				private Customer_Presence_Indicator()
    			{
    			}

				public const Int32 DefaultValue = 30277632; 
				
				
				
    			public const Int32 Not_Applicable = 30277632;
				
				
				
    			public const Int32 In_Presence_Operation = 30277633;
				
				
				
    			public const Int32 Not_In_Presence_Operation_Minus_Internet = 30277634;
				
				
				
    			public const Int32 Not_In_Presence_Operation_Minus_Telephone = 30277635;
				
				
				
    			public const Int32 Receipt_with_Home_Delivery = 30277636;
				
				
				
    			public const Int32 Not_In_Presence_Operation_Minus_Other_cases = 30277637;
				
				
				
    			public const Int32 Presence_Operation__Off_premises = 30277638;
		}
		public sealed class Importer
		{
				
				
				private Importer()
    			{
    			}

				public const Int32 DefaultValue = 30539776; 
				
				
				
    			public const Int32 Company = 30539776;
				
				
				
    			public const Int32 Supplier = 30539777;
		}
		public sealed class Intermediation_Type
		{
				
				
				private Intermediation_Type()
    			{
    			}

				public const Int32 DefaultValue = 30605312; 
				
				
				
    			public const Int32 One_Minus_On_ones_own = 30605312;
				
				
				
    			public const Int32 Two_Minus_On_Orders = 30605313;
				
				
				
    			public const Int32 Three_Minus_On_request_of_Others = 30605314;
		}
		public sealed class Pick_up_Point_Type
		{
				
				
				private Pick_up_Point_Type()
    			{
    			}

				public const Int32 DefaultValue = 30670851; 
				
				
				
    			public const Int32 Company = 30670848;
				
				
				
    			public const Int32 Customer = 30670849;
				
				
				
    			public const Int32 Supplier = 30670850;
				
				
				
    			public const Int32 Blank = 30670851;
		}
		public sealed class Delivery_To_Type
		{
				
				
				private Delivery_To_Type()
    			{
    			}

				public const Int32 DefaultValue = 30736388; 
				
				
				
    			public const Int32 Company = 30736384;
				
				
				
    			public const Int32 Customer = 30736385;
				
				
				
    			public const Int32 Supplier = 30736386;
				
				
				
    			public const Int32 Carrier = 30736387;
				
				
				
    			public const Int32 Blank = 30736388;
		}
		public sealed class Shipping_Type
		{
				
				
				private Shipping_Type()
    			{
    			}

				public const Int32 DefaultValue = 30867456; 
				
				
				
    			public const Int32 By_Sea = 30867456;
				
				
				
    			public const Int32 By_River = 30867457;
				
				
				
    			public const Int32 By_Lake = 30867458;
				
				
				
    			public const Int32 By_Air = 30867459;
				
				
				
    			public const Int32 By_Post = 30867460;
				
				
				
    			public const Int32 By_Rail = 30867461;
				
				
				
    			public const Int32 By_Road = 30867462;
				
				
				
    			public const Int32 By_Channel_Slash_Supply_chain_Network = 30867463;
				
				
				
    			public const Int32 By_Own_means = 30867464;
				
				
				
    			public const Int32 Issue_Slash_Fictitious_Receipt = 30867465;
		}
		public sealed class Receipt_Tax_Type
		{
				
				
				private Receipt_Tax_Type()
    			{
    			}

				public const Int32 DefaultValue = 31260672; 
				
				
				
    			public const Int32 Credit = 31260672;
				
				
				
    			public const Int32 Cost = 31260673;
		}
		public sealed class Declaration_Type
		{
				
				
				private Declaration_Type()
    			{
    			}

				public const Int32 DefaultValue = 31326208; 
				
				
				
    			public const Int32 A_Minus_Profile_A = 31326208;
				
				
				
    			public const Int32 B_Minus_Profile_B = 31326209;
				
				
				
    			public const Int32 C_Minus_Profile_C = 31326210;
		}
		public sealed class ActivityType
		{
				
				
				private ActivityType()
    			{
    			}

				public const Int32 DefaultValue = 31391744; 
				
				
				
    			public const Int32 One_Minus_Industrial = 31391744;
				
				
				
    			public const Int32 Two_Minus_Equivalent_to_industrial = 31391745;
				
				
				
    			public const Int32 Three_Minus_Other = 31391746;
		}
		public sealed class Item_Type_for_SPED
		{
				
				
				private Item_Type_for_SPED()
    			{
    			}

				public const Int32 DefaultValue = 31719424; 
				
				
				
    			public const Int32 ZeroZero_Minus_Resale_goods = 31719424;
				
				
				
    			public const Int32 ZeroOne_Minus_Raw_material = 31719425;
				
				
				
    			public const Int32 ZeroTwo_Minus_Packing = 31719426;
				
				
				
    			public const Int32 ZeroThree_Minus_In_processing = 31719427;
				
				
				
    			public const Int32 ZeroFour_Minus_Finished_product = 31719428;
				
				
				
    			public const Int32 ZeroFive_Minus_ByMinusproduct = 31719429;
				
				
				
    			public const Int32 ZeroSix_Minus_Semifinished = 31719430;
				
				
				
    			public const Int32 ZeroSeven_Minus_Consumable = 31719431;
				
				
				
    			public const Int32 ZeroEight_Minus_Fixed_asset = 31719432;
				
				
				
    			public const Int32 ZeroNine_Minus_Service = 31719433;
				
				
				
    			public const Int32 OneZero_Minus_Other = 31719434;
		}
		public sealed class IPI_Settlement_Type
		{
				
				
				private IPI_Settlement_Type()
    			{
    			}

				public const Int32 DefaultValue = 31784960; 
				
				
				
    			public const Int32 Zero_Minus_Monthly = 31784960;
				
				
				
    			public const Int32 One_Minus_Every_10_days = 31784961;
		}
		public sealed class Relevant_Scale_Indicator
		{
				
				
				private Relevant_Scale_Indicator()
    			{
    			}

				public const Int32 DefaultValue = 13041664; 
				
				
				
    			public const Int32 Ignore = 13041664;
				
				
				
    			public const Int32 Yes = 13041665;
				
				
				
    			public const Int32 No = 13041666;
		}
		public sealed class Operation_Type
		{
				
				
				private Operation_Type()
    			{
    			}

				public const Int32 DefaultValue = 1703936; 
				
				
				
    			public const Int32 Expense = 1703936;
				
				
				
    			public const Int32 Income = 1703937;
				
				
				
    			public const Int32 Advance_for_Expense = 1703938;
				
				
				
    			public const Int32 Money_Transfer_In = 1703939;
				
				
				
    			public const Int32 Money_Transfer_Out = 1703940;
				
				
				
    			public const Int32 Advance_from_Customer = 1703941;
				
				
				
    			public const Int32 Advance_to_Supplier = 1703942;
				
				
				
    			public const Int32 Collection_from_Customer = 1703943;
				
				
				
    			public const Int32 Payment_to_Supplier = 1703944;
				
				
				
    			public const Int32 Expense_On_Advance = 1703945;
		}
		public sealed class Document_Type_in_Cash_Expense
		{
				
				
				private Document_Type_in_Cash_Expense()
    			{
    			}

				public const Int32 DefaultValue = 1835008; 
				
				
				
    			public const Int32 Fiscal_Voucher = 1835008;
				
				
				
    			public const Int32 Fiscal_Receipt = 1835009;
		}
		public sealed class Charges_Calculation_Type
		{
				
				
				private Charges_Calculation_Type()
    			{
    			}

				public const Int32 DefaultValue = 10747904; 
				
				
				
    			public const Int32 Goods_Total = 10747904;
				
				
				
    			public const Int32 For_Pack_number = 10747905;
				
				
				
    			public const Int32 For_Weight = 10747906;
				
				
				
    			public const Int32 For_Shipping = 10747907;
				
				
				
    			public const Int32 Goods_Total_greater_than = 10747908;
				
				
				
    			public const Int32 Goods_Total_less_than = 10747909;
				
				
				
    			public const Int32 PercDot_increase_for_Sales_in_area = 10747910;
				
				
				
    			public const Int32 Fixed_increase_for_Sales_in_area = 10747911;
		}
		public sealed class Ledger_Type
		{
				
				
				private Ledger_Type()
    			{
    			}

				public const Int32 DefaultValue = 3014656; 
				
				
				
    			public const Int32 Assets = 3014656;
				
				
				
    			public const Int32 Equity_and_Liabilities = 3014657;
				
				
				
    			public const Int32 Memorandum = 3014658;
				
				
				
    			public const Int32 Loss_Expenses = 3014659;
				
				
				
    			public const Int32 Profit_Incomes = 3014660;
				
				
				
    			public const Int32 Transitional = 3014661;
		}
		public sealed class Account_Type
		{
				
				
				private Account_Type()
    			{
    			}

				public const Int32 DefaultValue = 3080194; 
				
				
				
    			public const Int32 Customer = 3080192;
				
				
				
    			public const Int32 Supplier = 3080193;
				
				
				
    			public const Int32 Pure_Accounting = 3080194;
		}
		public sealed class Ignore_Debit_and_Credit
		{
				
				
				private Ignore_Debit_and_Credit()
    			{
    			}

				public const Int32 DefaultValue = 8192002; 
				
				
				
    			public const Int32 Debit = 8192000;
				
				
				
    			public const Int32 Credit = 8192001;
				
				
				
    			public const Int32 Ignore = 8192002;
		}
		public sealed class Direct_Account_Type
		{
				
				
				private Direct_Account_Type()
    			{
    			}

				public const Int32 DefaultValue = 8257540; 
				
				
				
    			public const Int32 Revenues = 8257536;
				
				
				
    			public const Int32 Variable_Cost = 8257537;
				
				
				
    			public const Int32 Specific_Fixed_Cost = 8257538;
				
				
				
    			public const Int32 Common_Fixed_Cost = 8257539;
				
				
				
    			public const Int32 Ignore = 8257540;
		}
		public sealed class Full_Account_Type
		{
				
				
				private Full_Account_Type()
    			{
    			}

				public const Int32 DefaultValue = 8323077; 
				
				
				
    			public const Int32 Revenues = 8323072;
				
				
				
    			public const Int32 Primary_Cost = 8323073;
				
				
				
    			public const Int32 Manufacturing_Cost = 8323074;
				
				
				
    			public const Int32 Total_Cost = 8323075;
				
				
				
    			public const Int32 EconomicMinustechnical_Cost = 8323076;
				
				
				
    			public const Int32 Ignore = 8323077;
				
				
				
    			public const Int32 EconomicMinustechnical_Cost_Taxes_InclDot = 8323078;
		}
		public sealed class Document_to_be_issuedSlashreceived_type
		{
				
				
				private Document_to_be_issuedSlashreceived_type()
    			{
    			}

				public const Int32 DefaultValue = 30932992; 
				
				
				
    			public const Int32 Ignore = 30932992;
				
				
				
    			public const Int32 Invoices_To_Be_Issued = 30932993;
				
				
				
    			public const Int32 Credit_Notes_To_Be_Issued = 30932994;
				
				
				
    			public const Int32 Invoices_To_Be_Received = 30932995;
				
				
				
    			public const Int32 Credit_Notes_To_Be_Received = 30932996;
		}
		public sealed class Document_Accounting_Rules_Operation_Type
		{
				
				
				private Document_Accounting_Rules_Operation_Type()
    			{
    			}

				public const Int32 DefaultValue = 12845060; 
				
				
				
    			public const Int32 Domestic_Purchase = 12845056;
				
				
				
    			public const Int32 Domestic_Purchase_Exempt = 12845057;
				
				
				
    			public const Int32 EU_Purchase = 12845058;
				
				
				
    			public const Int32 Extra_EU_Purchase = 12845059;
				
				
				
    			public const Int32 Domestic_Sales = 12845060;
				
				
				
    			public const Int32 EU_Sales = 12845061;
				
				
				
    			public const Int32 Extra_EU_Sales = 12845062;
		}
		public sealed class Document_Accounting_Rules_Item_Type
		{
				
				
				private Document_Accounting_Rules_Item_Type()
    			{
    			}

				public const Int32 DefaultValue = 12910592; 
				
				
				
    			public const Int32 Goods = 12910592;
				
				
				
    			public const Int32 Service = 12910593;
		}
		public sealed class Document_Accounting_Rules_Food_Type
		{
				
				
				private Document_Accounting_Rules_Food_Type()
    			{
    			}

				public const Int32 DefaultValue = 12976128; 
				
				
				
    			public const Int32 Ignore = 12976128;
				
				
				
    			public const Int32 TakeMinusAway_Food = 12976129;
				
				
				
    			public const Int32 Dine_In_Food = 12976130;
		}
		public sealed class Territory_Type
		{
				
				
				private Territory_Type()
    			{
    			}

				public const Int32 DefaultValue = 983041; 
				
				
				
    			public const Int32 Special_Statute = 983040;
				
				
				
    			public const Int32 Ordinary_Statute = 983041;
		}
		public sealed class Tax_Advance_Method
		{
				
				
				private Tax_Advance_Method()
    			{
    			}

				public const Int32 DefaultValue = 1048576; 
				
				
				
    			public const Int32 One_Minus_Historical = 1048576;
				
				
				
    			public const Int32 Two_Minus_Forecast = 1048577;
				
				
				
    			public const Int32 Three_Minus_Analytical_Minus_Actual = 1048578;
				
				
				
    			public const Int32 Four_Minus_Subjects_operating_in_particular_sectors = 1048579;
		}
		public sealed class Person
		{
				
				
				private Person()
    			{
    			}

				public const Int32 DefaultValue = 1769473; 
				
				
				
    			public const Int32 Account_Manager = 1769472;
				
				
				
    			public const Int32 Legal_Representative = 1769473;
				
				
				
    			public const Int32 Natural = 1769474;
				
				
				
    			public const Int32 Heir_Minus_Liquidator = 1769475;
		}
		public sealed class Address
		{
				
				
				private Address()
    			{
    			}

				public const Int32 DefaultValue = 1966081; 
				
				
				
    			public const Int32 Registered_Office = 1966080;
				
				
				
    			public const Int32 Administrative_Office = 1966081;
				
				
				
    			public const Int32 Account_Location = 1966082;
				
				
				
    			public const Int32 Account_Manager = 1966083;
				
				
				
    			public const Int32 Fiscal_Domicile = 1966084;
				
				
				
    			public const Int32 Executive_Offices = 1966085;
				
				
				
    			public const Int32 Branch = 1966086;
				
				
				
    			public const Int32 Delegate = 1966087;
		}
		public sealed class Amount_RepDot
		{
				
				
				private Amount_RepDot()
    			{
    			}

				public const Int32 DefaultValue = 2293761; 
				
				
				
    			public const Int32 Commas = 2293760;
				
				
				
    			public const Int32 Full_Stops = 2293761;
		}
		public sealed class External_Date_Representation
		{
				
				
				private External_Date_Representation()
    			{
    			}

				public const Int32 DefaultValue = 2359296; 
				
				
				
    			public const Int32 DDSlashMMSlashYY = 2359296;
				
				
				
    			public const Int32 MMSlashDDSlashYY = 2359297;
				
				
				
    			public const Int32 YYSlashMMSlashDD = 2359298;
		}
		public sealed class External_Time_Representation
		{
				
				
				private External_Time_Representation()
    			{
    			}

				public const Int32 DefaultValue = 2424833; 
				
				
				
    			public const Int32 PMMinusAM = 2424832;
				
				
				
    			public const Int32 European = 2424833;
		}
		public sealed class Inventory_Valuation_Type
		{
				
				
				private Inventory_Valuation_Type()
    			{
    			}

				public const Int32 DefaultValue = 11272195; 
				
				
				[DenyISO("RO,PL,US,CN,JP,BR")]
    			public const Int32 LIFO_Annual = 11272192;
				
				
				[DenyISO("RO,PL,US,CN,JP,BR")]
    			public const Int32 FIFO_Annual = 11272193;
				
				
				[DenyISO("CN,JP")]
    			public const Int32 Average = 11272194;
				
				
				
    			public const Int32 Standard = 11272195;
				
				
				
    			public const Int32 Last = 11272196;
				
				[AllowISO("NONSIDEVEVEDEREMAI")]
				
    			public const Int32 Second_last = 11272197;
				
				
				[DenyISO("BR")]
    			public const Int32 LIFO = 11272198;
				
				
				[DenyISO("BR")]
    			public const Int32 FIFO = 11272199;
				
				
				
    			public const Int32 Last_from_BOM = 11272200;
				
				
				
    			public const Int32 Last_from_Manufacturing = 11272201;
				
				
				
    			public const Int32 Supplier_Price_List = 11272202;
				
				
				[DenyISO("BR")]
    			public const Int32 Weighted_Average = 11272203;
				
				[AllowISO("CN,JP")]
				
    			public const Int32 Average_of_Period = 11272204;
				
				[AllowISO("NONSIDEVEVEDEREMAI")]
				
    			public const Int32 By_Lots = 11272205;
				
				
				
    			public const Int32 Weighted_Average_of_Period = 11272206;
		}
		public sealed class Fiscal_Period
		{
				
				
				private Fiscal_Period()
    			{
    			}

				public const Int32 DefaultValue = 12124160; 
				
				
				
    			public const Int32 Month = 12124160;
				
				
				
    			public const Int32 Quarter = 12124161;
				
				
				
    			public const Int32 Half_Year = 12124162;
				
				
				
    			public const Int32 Year = 12124163;
		}
		public sealed class Tax_Code_Purchase_Type
		{
				
				
				private Tax_Code_Purchase_Type()
    			{
    			}

				public const Int32 DefaultValue = 262145; 
				
				
				
    			public const Int32 Capital_goods = 262144;
				
				
				
    			public const Int32 Goods_for_resale = 262145;
				
				[AllowISO("RO")]
				
    			public const Int32 Other_goods_and_services_for_company_needs = 262146;
				
				[AllowISO("ES")]
				
    			public const Int32 Special_regime_Compensation = 262147;
				
				[AllowISO("RO")]
				
    			public const Int32 Services = 262148;
		}
		public sealed class Type_of_plafond
		{
				
				
				private Type_of_plafond()
    			{
    			}

				public const Int32 DefaultValue = 4325376; 
				
				
				
    			public const Int32 Ignore = 4325376;
				
				
				
    			public const Int32 Inside = 4325377;
				
				
				
    			public const Int32 When_Importing = 4325378;
				
				
				
    			public const Int32 For_IntraMinusEU_Purchases = 4325379;
		}
		public sealed class Calendar_day
		{
				
				
				private Calendar_day()
    			{
    			}

				public const Int32 DefaultValue = 21889024; 
				
				
				
    			public const Int32 Disabled = 21889024;
				
				
				
    			public const Int32 Excluded = 21889025;
				
				
				
    			public const Int32 Holiday = 21889026;
				
				
				
    			public const Int32 Partial_Holiday = 21889027;
				
				
				
    			public const Int32 Working = 21889028;
		}
		public sealed class Weeks_Day
		{
				
				
				private Weeks_Day()
    			{
    			}

				public const Int32 DefaultValue = 23855111; 
				
				
				
    			public const Int32 Monday = 23855104;
				
				
				
    			public const Int32 Tuesday = 23855105;
				
				
				
    			public const Int32 Wednesday = 23855106;
				
				
				
    			public const Int32 Thursday = 23855107;
				
				
				
    			public const Int32 Friday = 23855108;
				
				
				
    			public const Int32 Saturday = 23855109;
				
				
				
    			public const Int32 Sunday = 23855110;
				
				
				
    			public const Int32 No_One = 23855111;
		}
		public sealed class Capacity_Management
		{
				
				
				private Capacity_Management()
    			{
    			}

				public const Int32 DefaultValue = 21102592; 
				
				
				
    			public const Int32 Average = 21102592;
				
				
				
    			public const Int32 Daily = 21102593;
		}
		public sealed class Processing_result
		{
				
				
				private Processing_result()
    			{
    			}

				public const Int32 DefaultValue = 21299203; 
				
				
				
    			public const Int32 No_availability = 21299201;
				
				
				
    			public const Int32 Underflow_data = 21299202;
				
				
				
    			public const Int32 Ok = 21299203;
				
				
				
    			public const Int32 Calendar_without_turns = 21299204;
				
				
				
    			public const Int32 WC_or_machine_not_exist = 21299206;
				
				
				
    			public const Int32 Calendar_not_exist = 21299207;
				
				
				
    			public const Int32 Unexpected_Error = 21299208;
				
				
				
    			public const Int32 Database_Error = 21299209;
		}
		public sealed class Tax_type
		{
				[AllowISO("BR")]
				
				private Tax_type()
    			{
    			}

				public const Int32 DefaultValue = 21430274; 
				
				
				
    			public const Int32 Real_Profit = 21430272;
				
				
				
    			public const Int32 Estimated_Profit = 21430273;
				
				
				
    			public const Int32 Simple_National = 21430274;
				
				
				
    			public const Int32 Simple_National_Minus_Excess = 21430275;
				
				
				
    			public const Int32 MEI = 21430276;
		}
		public sealed class Telematic_Declaration_type
		{
				[AllowISO("IT,CH,BG,RO,HU,FR,DE,AT,ES,GB")]
				
				private Telematic_Declaration_type()
    			{
    			}

				public const Int32 DefaultValue = 2032074752; 
				
				
				
    			public const Int32 All = 2032074752;
				[Activation("ERP.770")]
				
				
    			public const Int32 Unique_Certification = 2032074753;
				
				[AllowISO("IT")]
				
    			public const Int32 Tax_Data_Annual_Reporting = 2032074754;
				
				[AllowISO("IT")]
				
    			public const Int32 Issued_Declarations_of_Intent_Communication = 2032074755;
				[Activation("ERP.TaxCommunication")]
				
				
    			public const Int32 Tax_Communication = 2032074756;
				[Activation("ERP.770")]
				
				
    			public const Int32 SevenSevenZero_On_File = 2032074757;
				[Activation("ERP.Intrastat")]
				[AllowISO("IT")]
				
    			public const Int32 IntraMinusEU_Operations_Lists = 2032074758;
				
				[AllowISO("IT")]
				
    			public const Int32 F24 = 2032074759;
				[Activation("ERP.BlackList2014")]
				
				
    			public const Int32 Operations_with_Black_List_Countries = 2032074760;
				[Activation("ERP.SanMarinoPurchases")]
				
				
    			public const Int32 San_Marino_Purchases = 2032074761;
				
				[AllowISO("RO")]
				
    			public const Int32 Tax_Declaration_394 = 2032074762;
				
				[AllowISO("RO")]
				
    			public const Int32 VIES_Monthly_Declaration = 2032074763;
				
				[AllowISO("BG")]
				
    			public const Int32 Tax_Journals_and_Tax_Return = 2032074764;
				[Activation("ERP.XBRL")]
				
				
    			public const Int32 XBRL = 2032074765;
				[Activation("ERP.BEOConnector")]
				
				
    			public const Int32 BO = 2032074766;
				[Activation("ERP.FiscoAziendaConnector")]
				
				
    			public const Int32 Fisco_Azienda = 2032074767;
				
				[AllowISO("IT,AT,ES,GB")]
				
    			public const Int32 Tax_Settlement = 2032074768;
				
				[AllowISO("HU")]
				
    			public const Int32 Declaration_65M = 2032074769;
				
				[AllowISO("FR")]
				
    			public const Int32 Computerized_Accounting_Entries = 2032074770;
				
				[AllowISO("DE")]
				
    			public const Int32 GoBD = 2032074771;
				
				[AllowISO("DE,AT")]
				
    			public const Int32 ZM_Declaration = 2032074772;
				
				[AllowISO("RO")]
				
    			public const Int32 Tax_Declaration_300 = 2032074773;
				
				[AllowISO("BG")]
				
    			public const Int32 Payroll = 2032074774;
				
				[AllowISO("CH")]
				
    			public const Int32 Tax_Statement = 2032074775;
				
				[AllowISO("RO")]
				
    			public const Int32 Balance_Sheet = 2032074776;
		}
		public sealed class ESP_Log_Level
		{
				
				
				private ESP_Log_Level()
    			{
    			}

				public const Int32 DefaultValue = 11862016; 
				
				
				
    			public const Int32 ESP_Error_ = 11862016;
				
				
				
    			public const Int32 ESP_Warning = 11862017;
		}
		public sealed class Cross_References
		{
				
				
				private Cross_References()
    			{
    			}

				public const Int32 DefaultValue = 27066368; 
				
				
				
    			public const Int32 All = 27066368;
				
				
				
    			public const Int32 Transfer_Order = 27066369;
				
				
				
    			public const Int32 Inventory_Entry = 27066370;
				
				
				
    			public const Int32 Customer_Quotation = 27066371;
				
				
				
    			public const Int32 Sale_Order = 27066372;
				
				
				
    			public const Int32 Supplier_Quotation = 27066373;
				
				
				
    			public const Int32 Purchase_Order = 27066374;
				
				
				
    			public const Int32 PreShipping_For_Delivery = 27066375;
				
				
				
    			public const Int32 PreShipping_For_Return = 27066376;
				
				
				
    			public const Int32 PreShipping_For_InterStorage_Movement = 27066377;
				
				
				
    			public const Int32 GoodsReceipt_For_Delivery = 27066378;
				
				
				
    			public const Int32 GoodsReceipt_For_Return = 27066379;
				
				
				
    			public const Int32 GoodsReceipt_For_InterStorage_Movement = 27066380;
				
				
				
    			public const Int32 Return_To_Supplier = 27066381;
				
				
				
    			public const Int32 Return_From_Customer = 27066382;
				
				
				
    			public const Int32 Delivery_Note = 27066383;
				
				
				
    			public const Int32 Subcontractor_Delivery_Note = 27066384;
				
				
				
    			public const Int32 Accompanying_Invoice = 27066385;
				
				
				
    			public const Int32 Correction_Accompanying_Invoice = 27066386;
				
				
				
    			public const Int32 Immediate_Invoice = 27066387;
				
				
				
    			public const Int32 Correction_Invoice = 27066388;
				
				
				
    			public const Int32 Credit_Note = 27066389;
				
				
				
    			public const Int32 Debit_Note = 27066390;
				
				
				
    			public const Int32 Receipt = 27066391;
				
				
				
    			public const Int32 Correction_Receipt = 27066392;
				
				
				
    			public const Int32 NonMinusCollected_Receipt = 27066393;
				
				
				
    			public const Int32 Paragon = 27066394;
				
				
				
    			public const Int32 Correction_Paragon = 27066395;
				
				
				
    			public const Int32 Invoice_for_Advance = 27066396;
				
				
				
    			public const Int32 ProForma_Invoice = 27066397;
				
				
				
    			public const Int32 Interstorage_movement_Document = 27066398;
				
				
				
    			public const Int32 Picking_List = 27066399;
				
				
				
    			public const Int32 Bill_Of_Lading = 27066400;
				
				
				
    			public const Int32 SubDot_BoL = 27066401;
				
				
				
    			public const Int32 Purchase_Invoice = 27066402;
				
				
				
    			public const Int32 Correction_Purchase_Invoice = 27066403;
				
				
				
    			public const Int32 Credit_Note_Purchase = 27066404;
				
				
				
    			public const Int32 Debit_Note_Purchase = 27066405;
				
				
				
    			public const Int32 Invoice_Purchase_for_Advance = 27066406;
				
				
				
    			public const Int32 WMS_Inventory = 27066407;
				
				
				
    			public const Int32 Bin = 27066408;
				
				
				
    			public const Int32 Inspection_Order = 27066409;
				
				
				
    			public const Int32 Inspection_Notes = 27066410;
				
				
				
    			public const Int32 Manufacturing_Order = 27066411;
				
				
				
    			public const Int32 Transfer_Request = 27066412;
				
				
				
    			public const Int32 Inventory_Entry_Scrap = 27066413;
				
				
				
    			public const Int32 Inventory_Entry_Goods_to_be_receipt = 27066414;
				
				
				
    			public const Int32 Purchase_Request = 27066415;
				
				
				
    			public const Int32 Shop_Ticket = 27066416;
				
				
				
    			public const Int32 Additional_Charges = 27066417;
				
				
				
    			public const Int32 Pure_Accounting = 27066418;
				
				
				
    			public const Int32 Issued_Accounting = 27066419;
				
				
				
    			public const Int32 Received_Accounting = 27066420;
				
				
				
    			public const Int32 PreShipping_For_Subcontracting = 27066421;
				
				
				
    			public const Int32 Payable = 27066422;
				
				
				
    			public const Int32 Receivable = 27066423;
				
				
				
    			public const Int32 Cost_Accounting_Entry = 27066424;
				
				
				
    			public const Int32 Fee = 27066425;
				
				
				
    			public const Int32 Intra_Arrival = 27066426;
				
				
				
    			public const Int32 Intra_Dispatch = 27066427;
				
				
				
    			public const Int32 Fixed_Assets_Entry = 27066428;
				
				
				
    			public const Int32 Pure_Forecast = 27066429;
				
				
				
    			public const Int32 Issued_Forecast = 27066430;
				
				
				
    			public const Int32 Received_Forecast = 27066431;
				
				
				
    			public const Int32 Retail_Revaluation_Document = 27066432;
				
				
				
    			public const Int32 Receipt_for_Interstorage_Movement = 27066433;
				
				
				
    			public const Int32 PreShipping_by_Consignment = 27066434;
				
				
				
    			public const Int32 GoodsReceipt_by_Consignment = 27066435;
				
				
				
    			public const Int32 Entries_Sales_People = 27066436;
				
				
				
    			public const Int32 BOM_Posting = 27066437;
				
				
				
    			public const Int32 Subcontractor_Purchase_Order = 27066438;
				
				
				
    			public const Int32 Fiscal_Bill = 27066439;
				
				[AllowISO("BR")]
				
    			public const Int32 Nota_Fiscal_for_Customer = 27066440;
				
				[AllowISO("BR")]
				
    			public const Int32 Nota_Fiscal_for_Supplier = 27066441;
				
				[AllowISO("BR")]
				
    			public const Int32 Romaneio = 27066442;
				
				[AllowISO("BR")]
				
    			public const Int32 Import_Declaration = 27066443;
				
				
				
    			public const Int32 WMS_Inventory_with_Bin_Assignment = 27066444;
				
				[AllowISO("BR")]
				
    			public const Int32 Correction_Letter_for_Customer = 27066445;
				
				[AllowISO("BR")]
				
    			public const Int32 Correction_Letter_for_Supplier = 27066446;
				
				
				
    			public const Int32 Production_Plan = 27066447;
				
				
				
    			public const Int32 Customer_Contract = 27066448;
				
				
				
    			public const Int32 Bank_Statement = 27066452;
				
				
				
    			public const Int32 WT_Transfer_Order = 27066454;
				
				
				
    			public const Int32 Inventory_Document = 27066455;
				
				
				
    			public const Int32 MT_Transfer_Data = 27066460;
				
				
				
    			public const Int32 MRP_Purchase_Request = 27066461;
				
				
				
    			public const Int32 Stock_Replenishment = 27066463;
				
				
				
    			public const Int32 Purchase_Cancellation_Invoice = 27066464;
				
				
				
    			public const Int32 Sale_Cancellation_Invoice = 27066465;
				
				
				
    			public const Int32 Invoice_From_Fiscal_Bill = 27066466;
				
				
				
    			public const Int32 SelfInvoice = 27066468;
				
				
				
    			public const Int32 SelfCredit_Note = 27066469;
				
				
				
    			public const Int32 PPT_Entries = 27066470;
		}
		public sealed class Electronic_Ivoicing_Status
		{
				
				
				private Electronic_Ivoicing_Status()
    			{
    			}

				public const Int32 DefaultValue = 32112640; 
				
				[AllowISO("IT,BR,RO")]
				
    			public const Int32 DraftSlashNot_Sent = 32112640;
				
				[AllowISO("BR")]
				
    			public const Int32 Validated = 32112641;
				
				[AllowISO("BR")]
				
    			public const Int32 Transferred = 32112642;
				
				[AllowISO("BR")]
				
    			public const Int32 Approved = 32112643;
				
				[AllowISO("BR")]
				
    			public const Int32 Not_Approved = 32112644;
				
				[AllowISO("BR")]
				
    			public const Int32 Cancelled = 32112645;
				
				[AllowISO("BR")]
				
    			public const Int32 To_Be_Corrected = 32112646;
				
				[AllowISO("BR")]
				
    			public const Int32 Rejected = 32112647;
				
				[AllowISO("BR")]
				
    			public const Int32 Contingency_FSMinusDA = 32112648;
				
				[AllowISO("BR")]
				
    			public const Int32 Trasferred_in_Contingency = 32112649;
				
				[AllowISO("BR")]
				
    			public const Int32 Rejected_in_Contingency = 32112650;
				
				[AllowISO("BR")]
				
    			public const Int32 Approved_in_Contingency = 32112651;
				
				[AllowISO("BR")]
				
    			public const Int32 Not_Approved_in_Contingency = 32112652;
				
				[AllowISO("BR")]
				
    			public const Int32 Temporary_Receipt_of_Services = 32112653;
				
				[AllowISO("BR")]
				
    			public const Int32 Closed = 32112654;
		}
		public sealed class Return_Status_Type
		{
				
				
				private Return_Status_Type()
    			{
    			}

				public const Int32 DefaultValue = 32178176; 
				
				[AllowISO("BR")]
				
    			public const Int32 Service_Status = 32178176;
				
				[AllowISO("BR")]
				
    			public const Int32 Send_NFe = 32178177;
				
				[AllowISO("BR")]
				
    			public const Int32 Consult_NFe = 32178178;
				
				[AllowISO("BR")]
				
    			public const Int32 Cancelled_NFe = 32178179;
				
				[AllowISO("BR")]
				
    			public const Int32 Consult_DFe_Distribution = 32178180;
				
				[AllowISO("BR")]
				
    			public const Int32 Unpack_ResNFe = 32178181;
				
				[AllowISO("BR")]
				
    			public const Int32 Unpack_ProcNFe = 32178182;
				
				[AllowISO("BR")]
				
    			public const Int32 Unpack_ResEvento = 32178183;
				
				[AllowISO("BR")]
				
    			public const Int32 Unpack_ProcEvento = 32178184;
		}
		public sealed class Event_Type
		{
				
				
				private Event_Type()
    			{
    			}

				public const Int32 DefaultValue = 32243712; 
				
				[AllowISO("BR")]
				
    			public const Int32 None = 32243712;
				
				[AllowISO("BR")]
				
    			public const Int32 Transmission_to_SEFAZ = 32243713;
				
				[AllowISO("BR")]
				
    			public const Int32 Consultation = 32243714;
				
				[AllowISO("BR")]
				
    			public const Int32 Send_Mail_to_Recipient = 32243715;
				
				[AllowISO("BR")]
				
    			public const Int32 Print_Danfe = 32243716;
				
				[AllowISO("BR")]
				
    			public const Int32 Cancellation = 32243717;
				
				[AllowISO("BR")]
				
    			public const Int32 Print_Danfe_in_Contingency = 32243718;
				
				[AllowISO("BR")]
				
    			public const Int32 Transmission_to_SEFAZ_in_Contingency = 32243719;
				
				[AllowISO("BR")]
				
    			public const Int32 Consultation_in_Contingency = 32243720;
				
				[AllowISO("BR")]
				
    			public const Int32 Processing = 32243721;
				
				[AllowISO("BR")]
				
    			public const Int32 CCe_Transmission_to_SEFAZ = 32243722;
				
				[AllowISO("BR")]
				
    			public const Int32 Print_CCe = 32243723;
				
				[AllowISO("BR")]
				
    			public const Int32 CCe_Send_Mail_to_Recipient = 32243724;
				
				[AllowISO("BR")]
				
    			public const Int32 MDFMinuse_Closing = 32243725;
				
				[AllowISO("BR")]
				
    			public const Int32 MDFMinuse_Add_Driver = 32243726;
				
				[AllowISO("BR")]
				
    			public const Int32 MDFMinuse_Add_DFe = 32243727;
				
				[AllowISO("BR")]
				
    			public const Int32 NFe_Summary = 32243762;
				
				[AllowISO("BR")]
				
    			public const Int32 NFe_Complete = 32243763;
				
				[AllowISO("BR")]
				
    			public const Int32 NFe_Event_Summary = 32243764;
				
				[AllowISO("BR")]
				
    			public const Int32 NFe_Event_Complete = 32243765;
				
				[AllowISO("BR")]
				
    			public const Int32 Recipient_Manifestation = 32243766;
		}
		public sealed class Documents_Deletion_Operation_Status
		{
				
				
				private Documents_Deletion_Operation_Status()
    			{
    			}

				public const Int32 DefaultValue = 23265280; 
				
				
				
    			public const Int32 Counted = 23265280;
				
				
				
    			public const Int32 To_Delete = 23265281;
				
				
				
    			public const Int32 Ignored = 23265282;
				
				
				
    			public const Int32 Deleting = 23265283;
				
				
				
    			public const Int32 Deleted = 23265284;
				
				
				
    			public const Int32 In_Error = 23265285;
		}
		public sealed class Assisted_Documents_Deletion_Action
		{
				
				
				private Assisted_Documents_Deletion_Action()
    			{
    			}

				public const Int32 DefaultValue = 22478848; 
				
				
				
    			public const Int32 Blank = 22478848;
				
				
				
    			public const Int32 Delete = 22478849;
				
				
				
    			public const Int32 Ignore = 22478850;
		}
		public sealed class Visibility_use_for
		{
				
				
				private Visibility_use_for()
    			{
    			}

				public const Int32 DefaultValue = 42729472; 
				
				
				
    			public const Int32 Item_Supplier_Prices = 42729472;
				
				
				
    			public const Int32 Item_Customer_Prices = 42729473;
		}
		public sealed class Asynchronous_Batch_Status
		{
				
				
				private Asynchronous_Batch_Status()
    			{
    			}

				public const Int32 DefaultValue = 1310720; 
				
				
				
    			public const Int32 Created = 1310720;
				
				
				
    			public const Int32 Waiting_To_Run = 1310721;
				
				
				
    			public const Int32 Running = 1310722;
				
				
				
    			public const Int32 Ran_To_Completion = 1310723;
				
				
				
    			public const Int32 Ran_To_Error = 1310724;
				
				
				
    			public const Int32 To_Be_Canceled = 1310725;
				
				
				
    			public const Int32 To_Be_Aborted = 1310726;
				
				
				
    			public const Int32 Completed_Successfully = 1310727;
				
				
				
    			public const Int32 Completed_With_Errors = 1310728;
				
				
				
    			public const Int32 Canceled = 1310729;
				
				
				
    			public const Int32 Aborted = 1310730;
		}
		public sealed class AsynchronousBatch_Type
		{
				
				
				private AsynchronousBatch_Type()
    			{
    			}

				public const Int32 DefaultValue = 43450368; 
				
				
				
    			public const Int32 QueueBatch = 43450368;
				
				
				
    			public const Int32 GoBatch = 43450369;
		}
		public sealed class AsynchronousBatch_Mago_Status
		{
				
				
				private AsynchronousBatch_Mago_Status()
    			{
    			}

				public const Int32 DefaultValue = 43515904; 
				
				
				
    			public const Int32 None = 43515904;
				
				
				
    			public const Int32 Error = 43515905;
				
				
				
    			public const Int32 Warning = 43515906;
				
				
				
    			public const Int32 Info = 43515907;
		}
		public sealed class Web_Colours
		{
				
				
				private Web_Colours()
    			{
    			}

				public const Int32 DefaultValue = 43646982; 
				
				
				
    			public const Int32 Started = 43646976;
				
				
				
    			public const Int32 Partial = 43646977;
				
				
				
    			public const Int32 Done = 43646978;
				
				
				
    			public const Int32 Error = 43646979;
				
				
				
    			public const Int32 Disabled = 43646980;
				
				
				
    			public const Int32 Create = 43646981;
				
				
				
    			public const Int32 Empty = 43646982;
		}
		public sealed class Cost_Center_Type
		{
				
				
				private Cost_Center_Type()
    			{
    			}

				public const Int32 DefaultValue = 7929856; 
				
				
				
    			public const Int32 Production = 7929856;
				
				
				
    			public const Int32 Auxiliary = 7929857;
				
				
				
    			public const Int32 Shared = 7929858;
				
				
				
    			public const Int32 Functional = 7929859;
		}
		public sealed class Cost_Accounting_Entry_Type
		{
				
				
				private Cost_Accounting_Entry_Type()
    			{
    			}

				public const Int32 DefaultValue = 7995392; 
				
				
				
    			public const Int32 Budget = 7995392;
				
				
				
    			public const Int32 Actual = 7995393;
				
				
				
    			public const Int32 Forecast = 7995394;
		}
		public sealed class Cost_Center_Distribution_Type
		{
				
				
				private Cost_Center_Distribution_Type()
    			{
    			}

				public const Int32 DefaultValue = 8060928; 
				
				
				
    			public const Int32 Free = 8060928;
				
				
				
    			public const Int32 Square_meter_of_area = 8060929;
				
				
				
    			public const Int32 NoDot_of_Direct_Employees = 8060930;
				
				
				
    			public const Int32 NoDot_of_Indirect_Employees = 8060931;
				
				
				
    			public const Int32 Total_NoDot_of_Employees = 8060932;
				
				
				
    			public const Int32 Depreciation_ = 8060933;
		}
		public sealed class Job_Distribution_Type
		{
				
				
				private Job_Distribution_Type()
    			{
    			}

				public const Int32 DefaultValue = 8126464; 
				
				
				
    			public const Int32 Free = 8126464;
				
				
				
    			public const Int32 NoDot_of_Machine_Hours = 8126465;
				
				
				
    			public const Int32 Depreciation_ = 8126466;
		}
		public sealed class Cost_Center_Nature
		{
				
				
				private Cost_Center_Nature()
    			{
    			}

				public const Int32 DefaultValue = 8585218; 
				
				
				
    			public const Int32 Cost = 8585216;
				
				
				
    			public const Int32 Revenue = 8585217;
				
				
				
    			public const Int32 Profit = 8585218;
		}
		public sealed class Credit_Limit_Check_Type
		{
				
				
				private Credit_Limit_Check_Type()
    			{
    			}

				public const Int32 DefaultValue = 28049408; 
				
				
				
    			public const Int32 Ignore = 28049408;
				
				
				
    			public const Int32 Notify = 28049409;
				
				
				
    			public const Int32 Block = 28049410;
				
				
				
    			public const Int32 Post_Order_as_Blocked = 28049411;
		}
		public sealed class Credit_Type
		{
				
				
				private Credit_Type()
    			{
    			}

				public const Int32 DefaultValue = 28114944; 
				
				
				
    			public const Int32 Ordered = 28114944;
				
				
				
    			public const Int32 Delivered = 28114945;
				
				
				
    			public const Int32 Invoices_no_Receivables = 28114946;
		}
		public sealed class Credit_Block_Type
		{
				
				
				private Credit_Block_Type()
    			{
    			}

				public const Int32 DefaultValue = 28180480; 
				
				
				
    			public const Int32 Automatic = 28180480;
				
				
				
    			public const Int32 Manual = 28180481;
				
				
				
    			public const Int32 Unblocked = 28180482;
		}
		public sealed class Wait_time_management
		{
				
				
				private Wait_time_management()
    			{
    			}

				public const Int32 DefaultValue = 21168128; 
				
				
				
    			public const Int32 Prompt = 21168128;
				
				
				
    			public const Int32 Truncated = 21168129;
		}
		public sealed class Queue_time_origin
		{
				
				
				private Queue_time_origin()
    			{
    			}

				public const Int32 DefaultValue = 21233664; 
				
				
				
    			public const Int32 From_step = 21233664;
				
				
				
    			public const Int32 Generalized = 21233665;
		}
		public sealed class Alternate_WC_criterion
		{
				
				
				private Alternate_WC_criterion()
    			{
    			}

				public const Int32 DefaultValue = 21626880; 
				
				
				
    			public const Int32 Preferential = 21626880;
				
				
				
    			public const Int32 Evenness_of_loading = 21626881;
				
				
				
    			public const Int32 By_priority = 21626882;
				
				
				
    			public const Int32 WC_internal = 21626883;
				
				
				
    			public const Int32 WC_outsourced = 21626884;
		}
		public sealed class Alternate_steps_criterion
		{
				
				
				private Alternate_steps_criterion()
    			{
    			}

				public const Int32 DefaultValue = 21757952; 
				
				
				
    			public const Int32 Preferential = 21757952;
				
				
				
    			public const Int32 Alternate_code = 21757953;
				
				
				
    			public const Int32 Shortest_duration = 21757954;
				
				
				
    			public const Int32 Lowest_cost = 21757955;
		}
		public sealed class Scheduling_type
		{
				
				
				private Scheduling_type()
    			{
    			}

				public const Int32 DefaultValue = 21823488; 
				
				
				
    			public const Int32 New = 21823488;
				
				
				
    			public const Int32 Added = 21823489;
				
				
				
    			public const Int32 Replaced = 21823490;
				
				
				
    			public const Int32 From_gantt = 21823491;
				
				
				
    			public const Int32 From_histogram = 21823492;
		}
		public sealed class Select_InMinushouse_Outsourced
		{
				
				
				private Select_InMinushouse_Outsourced()
    			{
    			}

				public const Int32 DefaultValue = 23134208; 
				
				
				
    			public const Int32 All = 23134208;
				
				
				
    			public const Int32 InMinushouse_only = 23134209;
				
				
				
    			public const Int32 Outsourced_only = 23134210;
		}
		public sealed class Scheduling_mode
		{
				
				
				private Scheduling_mode()
    			{
    			}

				public const Int32 DefaultValue = 23199744; 
				
				
				
    			public const Int32 Indicated_on_orders = 23199744;
				
				
				
    			public const Int32 All_earliness = 23199745;
				
				
				
    			public const Int32 All_tardiness = 23199746;
		}
		public sealed class Processing_type
		{
				
				
				private Processing_type()
    			{
    			}

				public const Int32 DefaultValue = 24182784; 
				
				
				
    			public const Int32 Setup = 24182784;
				
				
				
    			public const Int32 Processing = 24182785;
				
				
				
    			public const Int32 Both = 24182786;
		}
		public sealed class Load_view_type
		{
				
				
				private Load_view_type()
    			{
    			}

				public const Int32 DefaultValue = 24313856; 
				
				
				
    			public const Int32 Simple = 24313856;
				
				
				
    			public const Int32 Aggregated_by_wc = 24313857;
		}
		public sealed class Alternate_criterion_in_routing
		{
				
				
				private Alternate_criterion_in_routing()
    			{
    			}

				public const Int32 DefaultValue = 24838144; 
				
				
				
    			public const Int32 Preferential = 24838144;
				
				
				
    			public const Int32 Alternate_code = 24838145;
				
				
				
    			public const Int32 Lowest_cost = 24838146;
		}
		public sealed class Round
		{
				
				
				private Round()
    			{
    			}

				public const Int32 DefaultValue = 786432; 
				
				
				
    			public const Int32 None = 786432;
				
				
				
    			public const Int32 Up = 786433;
				
				
				
    			public const Int32 Down = 786434;
				
				
				
    			public const Int32 Mathematical_absDot_valDot = 786435;
				
				
				
    			public const Int32 Mathematical_with_sign = 786436;
		}
		public sealed class Fixing_Type
		{
				
				
				private Fixing_Type()
    			{
    			}

				public const Int32 DefaultValue = 11075584; 
				
				
				
    			public const Int32 Actual = 11075584;
				
				
				
    			public const Int32 Sales = 11075585;
				
				
				
    			public const Int32 Purchases = 11075586;
		}
		public sealed class Fixing_related_to_1_Eur
		{
				
				
				private Fixing_related_to_1_Eur()
    			{
    			}

				public const Int32 DefaultValue = 1900544; 
				
				
				
    			public const Int32 Dont_display_ = 1900544;
				
				
				
    			public const Int32 Display_also = 1900545;
				
				
				
    			public const Int32 Display_only = 1900546;
		}
		public sealed class Use_Customer_or_Contact
		{
				
				
				private Use_Customer_or_Contact()
    			{
    			}

				public const Int32 DefaultValue = 2031616000; 
				
				
				
    			public const Int32 Customer = 2031616000;
				
				
				
    			public const Int32 Contact = 2031616001;
		}
		public sealed class References
		{
				
				
				private References()
    			{
    			}

				public const Int32 DefaultValue = 524289; 
				
				
				
    			public const Int32 Separately = 524288;
				
				
				
    			public const Int32 Before_Each_Items_List = 524289;
				
				
				
    			public const Int32 Document_Top = 524290;
				
				
				
    			public const Int32 Document_Bottom = 524291;
				
				
				
    			public const Int32 Standard = 524293;
		}
		public sealed class CustSupp_Type
		{
				
				
				private CustSupp_Type()
    			{
    			}

				public const Int32 DefaultValue = 3211264; 
				
				
				
    			public const Int32 Customer = 3211264;
				
				
				
    			public const Int32 Supplier = 3211265;
		}
		public sealed class Debit_Tax_on_Free_Samples
		{
				
				
				private Debit_Tax_on_Free_Samples()
    			{
    			}

				public const Int32 DefaultValue = 3276802; 
				
				
				
    			public const Int32 Always = 3276800;
				
				
				
    			public const Int32 Never = 3276801;
				
				
				
    			public const Int32 Item_Basis = 3276802;
		}
		public sealed class CustSupp_Kind
		{
				
				
				private CustSupp_Kind()
    			{
    			}

				public const Int32 DefaultValue = 7733248; 
				
				
				
    			public const Int32 Domestic = 7733248;
				
				
				
    			public const Int32 EU = 7733249;
				
				
				
    			public const Int32 NonMinusEU = 7733250;
		}
		public sealed class Send_type
		{
				
				
				private Send_type()
    			{
    			}

				public const Int32 DefaultValue = 11337728; 
				
				
				
    			public const Int32 No_Send = 11337728;
				
				
				
    			public const Int32 Email = 11337729;
				
				
				
    			public const Int32 Fax = 11337730;
		}
		public sealed class Use_CustomerSlashSupplier_Email
		{
				
				
				private Use_CustomerSlashSupplier_Email()
    			{
    			}

				public const Int32 DefaultValue = 11403265; 
				
				
				
    			public const Int32 Never = 11403264;
				
				
				
    			public const Int32 Always = 11403265;
				
				
				
    			public const Int32 When_the_references_eMinusMail_is_missed = 11403266;
		}
		public sealed class Mail_send_type
		{
				
				
				private Mail_send_type()
    			{
    			}

				public const Int32 DefaultValue = 12451840; 
				
				
				
    			public const Int32 No_Send = 12451840;
				
				
				
    			public const Int32 To = 12451841;
				
				
				
    			public const Int32 Cc = 12451842;
				
				
				
    			public const Int32 Bcc = 12451843;
		}
		public sealed class ICMS_Taxpayer_Type
		{
				
				
				private ICMS_Taxpayer_Type()
    			{
    			}

				public const Int32 DefaultValue = 30212096; 
				
				
				
    			public const Int32 ICMS_Taxpayer = 30212096;
				
				
				
    			public const Int32 Exempt_Taxpayer = 30212097;
				
				
				
    			public const Int32 No_Taxpayer = 30212098;
		}
		public sealed class Tax_Document_Type
		{
				[AllowISO("ES")]
				
				private Tax_Document_Type()
    			{
    			}

				public const Int32 DefaultValue = 33226752; 
				
				
				
    			public const Int32 Tax_Number = 33226752;
				
				
				
    			public const Int32 Tax_Number_Intra = 33226753;
				
				
				
    			public const Int32 Passport = 33226754;
				
				
				
    			public const Int32 Official_Document_in_the_Country = 33226755;
				
				
				
    			public const Int32 Residence_Certificate = 33226756;
				
				
				
    			public const Int32 Other_Document = 33226757;
		}
		public sealed class EDI_File_Type
		{
				
				
				private EDI_File_Type()
    			{
    			}

				public const Int32 DefaultValue = 9043968; 
				
				
				
    			public const Int32 PRICAT = 9043968;
				
				
				
    			public const Int32 DESADV = 9043969;
				
				
				
    			public const Int32 ORDRSP = 9043970;
				
				
				
    			public const Int32 ORDERS = 9043971;
				
				
				
    			public const Int32 SLSRPT = 9043972;
				
				
				
    			public const Int32 INVRPT = 9043973;
				
				
				
    			public const Int32 INVOIC = 9043974;
		}
		public sealed class EDI_File_Status
		{
				
				
				private EDI_File_Status()
    			{
    			}

				public const Int32 DefaultValue = 9109504; 
				
				
				
    			public const Int32 Loaded = 9109504;
				
				
				
    			public const Int32 In_processing = 9109505;
		}
		public sealed class EDI_Data_Type
		{
				
				
				private EDI_Data_Type()
    			{
    			}

				public const Int32 DefaultValue = 8978432; 
				
				
				
    			public const Int32 UoM = 8978432;
				
				
				
    			public const Int32 Currency = 8978440;
				
				
				
    			public const Int32 Tax_Code = 8978441;
				[Activation("ERP.VariantsPlus")]
				
				
    			public const Int32 Size = 8978437;
				[Activation("ERP.VariantsPlus")]
				
				
    			public const Int32 Color = 8978438;
				[Activation("ERP.VariantsPlus")]
				
				
    			public const Int32 Textile = 8978439;
		}
		public sealed class EDI_Import_Status
		{
				
				
				private EDI_Import_Status()
    			{
    			}

				public const Int32 DefaultValue = 10289152; 
				
				
				
    			public const Int32 To_Transcode = 10289152;
				
				
				
    			public const Int32 To_Discard = 10289153;
				
				
				
    			public const Int32 To_Confirm = 10289154;
				
				
				
    			public const Int32 Importable = 10289155;
				
				
				
    			public const Int32 To_Complete = 10289156;
				
				
				
    			public const Int32 Imported = 10289157;
		}
		public sealed class Fixed_Asset_Category_Type
		{
				
				
				private Fixed_Asset_Category_Type()
    			{
    			}

				public const Int32 DefaultValue = 7012352; 
				
				
				
    			public const Int32 Tangible = 7012352;
				
				
				
    			public const Int32 Intangible = 7012353;
		}
		public sealed class Fixed_Asset_Disposal_Type
		{
				
				
				private Fixed_Asset_Disposal_Type()
    			{
    			}

				public const Int32 DefaultValue = 7143424; 
				
				
				
    			public const Int32 Ignore = 7143424;
				
				
				
    			public const Int32 Sale = 7143425;
				
				
				
    			public const Int32 Scrap = 7143426;
		}
		public sealed class Fixed_Asset_Acquisition_Type
		{
				
				
				private Fixed_Asset_Acquisition_Type()
    			{
    			}

				public const Int32 DefaultValue = 7208960; 
				
				
				
    			public const Int32 New_Purchase = 7208960;
				
				
				
    			public const Int32 Second_Hand_Purchase = 7208961;
				
				
				
    			public const Int32 Company_Fixed_Asset = 7208962;
				
				
				
    			public const Int32 Assignment_by_Owner_or_Partners = 7208963;
				
				
				
    			public const Int32 Assignment_by_Public_Authority = 7208964;
				
				
				
    			public const Int32 Leasing = 7208965;
				
				[AllowISO("HU")]
				
    			public const Int32 Development_reserves = 7208966;
		}
		public sealed class Method_applied_for_first_fiscal_year_calculation
		{
				
				
				private Method_applied_for_first_fiscal_year_calculation()
    			{
    			}

				public const Int32 DefaultValue = 11468800; 
				
				
				
    			public const Int32 Depreciation_starting_date = 11468800;
				
				
				
    			public const Int32 Next_month = 11468801;
				
				
				[DenyISO("BG")]
    			public const Int32 Next_quarterly = 11468802;
				
				[AllowISO("BG")]
				
    			public const Int32 Month_deprDot_starting_date = 11468803;
				
				[AllowISO("CH")]
				
    			public const Int32 Fiscal_year_opening_date = 11468804;
		}
		public sealed class Method_of_Depreciation
		{
				
				
				private Method_of_Depreciation()
    			{
    			}

				public const Int32 DefaultValue = 11730944; 
				
				
				
    			public const Int32 Linear = 11730944;
				
				
				[DenyISO("BG")]
    			public const Int32 Regressive = 11730945;
				
				
				[DenyISO("BG")]
    			public const Int32 Accelerated = 11730946;
				
				[AllowISO("BG")]
				
    			public const Int32 Activity = 11730947;
				
				[AllowISO("BG")]
				
    			public const Int32 Declining_Balance = 11730948;
				
				[AllowISO("BG")]
				
    			public const Int32 Staggered_Decreasing_Balance = 11730949;
				
				[AllowISO("BG")]
				
    			public const Int32 Irregular_Decreasing = 11730950;
				
				[AllowISO("BG")]
				
    			public const Int32 Decreasing_Sum_of_Year_Digits = 11730951;
				
				[AllowISO("BG")]
				
    			public const Int32 Staggered_Increasing_Balance = 11730952;
				
				[AllowISO("BG")]
				
    			public const Int32 Irregular_Increasing = 11730953;
				
				[AllowISO("BG")]
				
    			public const Int32 Increasing_Sum_of_Year_Digits = 11730954;
		}
		public sealed class Period_of_posting_depreciation
		{
				
				
				private Period_of_posting_depreciation()
    			{
    			}

				public const Int32 DefaultValue = 65536; 
				
				
				
    			public const Int32 Monthly = 65536;
				
				
				
    			public const Int32 Quarterly = 65537;
				
				
				
    			public const Int32 Yearly = 65538;
		}
		public sealed class IBC_Date_Type
		{
				
				
				private IBC_Date_Type()
    			{
    			}

				public const Int32 DefaultValue = 3997696; 
				
				
				
    			public const Int32 Posting_Date = 3997696;
				
				
				
    			public const Int32 Document_Date = 3997697;
		}
		public sealed class IBC_Document_Class
		{
				
				
				private IBC_Document_Class()
    			{
    			}

				public const Int32 DefaultValue = 4063232; 
				
				
				
    			public const Int32 Orders = 4063232;
				
				
				
    			public const Int32 Delivery_Notes = 4063233;
				
				
				
    			public const Int32 Invoices = 4063234;
		}
		public sealed class IBC_Document_Cycle
		{
				
				
				private IBC_Document_Cycle()
    			{
    			}

				public const Int32 DefaultValue = 4128768; 
				
				
				
    			public const Int32 Sales = 4128768;
				
				
				
    			public const Int32 Purchases = 4128769;
		}
		public sealed class IBC_Aging_Periods_Type
		{
				
				
				private IBC_Aging_Periods_Type()
    			{
    			}

				public const Int32 DefaultValue = 4194304; 
				
				
				
    			public const Int32 Delay = 4194304;
				
				
				
    			public const Int32 Due = 4194305;
				
				
				
    			public const Int32 Exposed = 4194306;
		}
		public sealed class Archive_Type
		{
				
				
				private Archive_Type()
    			{
    			}

				public const Int32 DefaultValue = 3801088; 
				
				
				
    			public const Int32 Sale_Documents = 3801088;
				
				
				
    			public const Int32 Tax_Exigibility_Variations = 3801089;
				
				
				
    			public const Int32 Payment_Orders = 3801090;
				
				
				
    			public const Int32 Intrastat_Entries = 3801091;
				
				
				
    			public const Int32 Salespeople_Entries = 3801092;
				
				
				
    			public const Int32 Inventory_Entries = 3801093;
				
				
				
    			public const Int32 Payments_Schedules = 3801094;
				
				
				
    			public const Int32 Journal_Entries = 3801095;
				
				
				
    			public const Int32 Production_Plans = 3801096;
				
				
				
    			public const Int32 Fixed_Assets_Entries = 3801097;
				
				
				
    			public const Int32 Sale_Orders = 3801098;
				
				
				
    			public const Int32 Customer_Quotations = 3801099;
				
				
				
    			public const Int32 Purchase_Orders = 3801100;
				
				
				
    			public const Int32 Fees = 3801101;
				
				
				
    			public const Int32 Cost_Accounting_Entries = 3801102;
				
				
				
    			public const Int32 Manufacturing_Orders = 3801103;
				
				
				
    			public const Int32 Purchase_Requisitions = 3801104;
				
				
				
    			public const Int32 Shop_Ticket = 3801105;
				
				
				
    			public const Int32 Manufacturing_Job = 3801106;
				
				
				
    			public const Int32 Manufacturing_Work_In_Progress = 3801107;
				
				
				
    			public const Int32 Purchase_Documents = 3801108;
				
				
				
    			public const Int32 Supplier_Quotations = 3801109;
				
				
				
    			public const Int32 Quota_Request = 3801110;
				
				
				
    			public const Int32 Test_Order = 3801111;
				
				
				
    			public const Int32 Test_Bill = 3801112;
				
				
				
    			public const Int32 Work_Orders = 3801113;
				
				
				
    			public const Int32 Additional_Charges = 3801114;
				
				
				
    			public const Int32 Receipts_for_Single_Step_LIFOSlashFIFO = 3801115;
				
				
				
    			public const Int32 Cash_Sessions = 3801116;
				
				
				
    			public const Int32 Inspection_Order = 3801117;
				
				
				
    			public const Int32 Inspection_Notes = 3801118;
				
				
				
    			public const Int32 PreShipping = 3801119;
				
				
				
    			public const Int32 GoodsReceipt = 3801120;
				
				
				
    			public const Int32 WMS_Inventory = 3801121;
				
				
				
    			public const Int32 Declaration_of_Intent = 3801122;
				
				
				
    			public const Int32 Transfer_Request = 3801123;
				
				
				
    			public const Int32 Change_Retail_Data = 3801124;
				
				
				
    			public const Int32 POS = 3801125;
				
				
				
    			public const Int32 Romaneio = 3801126;
				
				
				
    			public const Int32 Import_Declaration = 3801127;
				
				
				
    			public const Int32 Correction_Letter_for_Customer = 3801128;
				
				
				
    			public const Int32 Correction_Letter_for_Supplier = 3801129;
				
				
				
    			public const Int32 Cash_Transfer = 3801130;
				
				
				
    			public const Int32 Shipments = 3801133;
				
				
				
    			public const Int32 Bank_Statements = 3801135;
				
				
				
    			public const Int32 Inventory_Document = 3801136;
				
				
				
    			public const Int32 CGM = 3801138;
				
				
				
    			public const Int32 Stock_Replenishment = 3801141;
				
				
				
    			public const Int32 EDI_Import_Files = 3801142;
				
				
				
    			public const Int32 EDI_Messages_Structure = 3801143;
				
				
				
    			public const Int32 EDI_PRICAT_ID = 3801144;
				
				
				
    			public const Int32 EDI_DESADV_ID = 3801145;
				
				
				
    			public const Int32 EDI_INVOIC_ID = 3801149;
		}
		public sealed class Non_Fiscal_Document_Type
		{
				
				
				private Non_Fiscal_Document_Type()
    			{
    			}

				public const Int32 DefaultValue = 3735554; 
				
				
				
    			public const Int32 Bill = 3735552;
				
				
				
    			public const Int32 Payment_Order = 3735553;
				
				
				
    			public const Int32 Sale_Order = 3735554;
				
				
				
    			public const Int32 Guller = 3735555;
				
				
				
    			public const Int32 Customer_Quotation = 3735556;
				
				
				
    			public const Int32 Purchase_Order = 3735557;
				
				
				
    			public const Int32 Journal_Entry_Reference_NoDot = 3735558;
				
				
				
    			public const Int32 Production_Plan = 3735559;
				
				
				
    			public const Int32 Job = 3735560;
				
				
				
    			public const Int32 Cost_Accounting_Entry_Reference_NoDot = 3735561;
				
				
				
    			public const Int32 Manufacturing_Orders = 3735562;
				
				
				
    			public const Int32 Manufacturing_Job = 3735563;
				
				
				
    			public const Int32 Purchase_Requisitions = 3735564;
				
				
				
    			public const Int32 Shop_Ticket = 3735565;
				
				
				
    			public const Int32 Picking_List = 3735566;
				
				
				
    			public const Int32 Simulation = 3735567;
				
				
				
    			public const Int32 Supplier_Quotation = 3735568;
				
				
				
    			public const Int32 Forecast_Journal_Entry_Reference_NoDot_ = 3735569;
				
				
				
    			public const Int32 Consolidated_Balance_Sheet = 3735570;
				
				
				
    			public const Int32 Accounting_Simulations = 3735571;
				
				
				
    			public const Int32 Quota_Request = 3735572;
				
				
				
    			public const Int32 Test_Order = 3735573;
				
				
				
    			public const Int32 Test_Bill = 3735574;
				
				
				
    			public const Int32 Bills_Slip_NoDot = 3735575;
				
				
				
    			public const Int32 Production_Run = 3735577;
				
				
				
    			public const Int32 Payment_Orders_Slip_NoDot = 3735579;
				
				
				
    			public const Int32 Additional_Charges = 3735580;
				
				
				
    			public const Int32 Web_Price_List = 3735581;
				
				
				
    			public const Int32 Cash_Sessions = 3735582;
				
				
				
    			public const Int32 Cash_Expense_Statement = 3735583;
				
				
				
    			public const Int32 ProForma_Invoice = 3735584;
				
				
				
    			public const Int32 Fixed_Assets_Entry_Reference_NoDot = 3735585;
				
				
				
    			public const Int32 Inspection_Order = 3735586;
				
				
				
    			public const Int32 Inspection_Notes = 3735587;
				
				
				
    			public const Int32 Picking_List_Minus_Logistics = 3735588;
				
				
				
    			public const Int32 Factoring = 3735589;
				
				
				
    			public const Int32 Factoring_Slip_NoDot = 3735590;
				
				
				
    			public const Int32 Transfer_Order = 3735591;
				
				
				
    			public const Int32 PreShipping_For_Delivery = 3735592;
				
				
				
    			public const Int32 PreShipping_For_Return = 3735593;
				
				
				
    			public const Int32 PreShipping_For_InterStorage_Movement = 3735594;
				
				
				
    			public const Int32 Goods_Receipt = 3735595;
				
				
				
    			public const Int32 Goods_Receipt_For_Return = 3735596;
				
				
				
    			public const Int32 Goods_Receipt_For_InterStorage_Movement = 3735597;
				
				
				
    			public const Int32 WMS_Inventory = 3735598;
				
				
				
    			public const Int32 Transfer_Request = 3735599;
				
				
				
    			public const Int32 PreShipping_For_Subcontracting = 3735600;
				
				
				
    			public const Int32 Change_Retail_Data = 3735601;
				
				
				
    			public const Int32 PreShipping_by_Consignment = 3735602;
				
				
				
    			public const Int32 Goods_Receipt_by_Consignment = 3735603;
				
				
				
    			public const Int32 BOM_Posting = 3735604;
				
				
				
    			public const Int32 Boleto_NoDot = 3735605;
				
				
				
    			public const Int32 Romaneio = 3735606;
				
				
				
    			public const Int32 Compensation_NoDot = 3735607;
				
				
				
    			public const Int32 Tools_NoDot = 3735608;
				
				
				
    			public const Int32 Tools_Families_NoDot = 3735609;
				
				
				
    			public const Int32 Inventory_Document = 3735612;
		}
		public sealed class Counter_Prefix_Format
		{
				
				
				private Counter_Prefix_Format()
    			{
    			}

				public const Int32 DefaultValue = 24969217; 
				
				
				
    			public const Int32 None = 24969216;
				
				
				
    			public const Int32 TwoMinusdigit_Year_yy = 24969217;
				
				
				
    			public const Int32 FourMinusdigit_Year_yyyy = 24969218;
				
				
				
    			public const Int32 With_Prefix_Letter_Yy = 24969219;
				
				
				
    			public const Int32 Group_and_Month_monthly_numbering = 24969220;
				
				
				
    			public const Int32 Group_monthly_numbering = 24969221;
				
				
				
    			public const Int32 Group_yearly_numbering = 24969222;
				
				
				
    			public const Int32 Custom = 24969223;
		}
		public sealed class Context_Type
		{
				
				
				private Context_Type()
    			{
    			}

				public const Int32 DefaultValue = 30015488; 
				
				
				
    			public const Int32 All = 30015488;
				
				
				
    			public const Int32 Customer_Quotation = 30015489;
				
				
				
    			public const Int32 Sale_Order = 30015490;
				
				
				
    			public const Int32 Supplier_Quotation = 30015491;
				
				
				
    			public const Int32 Purchase_Order = 30015492;
				
				
				
    			public const Int32 Sale_Document = 30015493;
				
				
				
    			public const Int32 Purchase_Document = 30015494;
				
				
				
    			public const Int32 Inventory_Entry = 30015495;
				
				
				
    			public const Int32 Inventory_Adjustment = 30015496;
				
				
				
    			public const Int32 WMS_Inventory = 30015497;
				
				
				
    			public const Int32 PreShipping = 30015498;
				
				
				
    			public const Int32 Goods_Receipt = 30015499;
				
				
				
    			public const Int32 Inspection_Order = 30015500;
				
				
				
    			public const Int32 Inspection_Notes = 30015501;
		}
		public sealed class File_Type
		{
				
				
				private File_Type()
    			{
    			}

				public const Int32 DefaultValue = 30081024; 
				
				
				
    			public const Int32 Fixed_Column = 30081024;
				
				
				
    			public const Int32 With_Separator = 30081025;
				
				
				
    			public const Int32 XML = 30081026;
				
				
				
    			public const Int32 JSON = 30081027;
		}
		public sealed class Field_name
		{
				
				
				private Field_name()
    			{
    			}

				public const Int32 DefaultValue = 30146560; 
				
				
				
    			public const Int32 None = 30146560;
				
				
				
    			public const Int32 Item = 30146561;
				
				
				
    			public const Int32 Quantity = 30146562;
				
				
				
    			public const Int32 Unit_Value = 30146563;
				
				
				
    			public const Int32 Discount = 30146564;
				
				
				
    			public const Int32 Lot = 30146565;
				
				
				
    			public const Int32 Zone = 30146566;
				
				
				
    			public const Int32 Bin = 30146567;
				
				
				
    			public const Int32 Storage_Unit = 30146568;
				
				
				
    			public const Int32 Special_Stock = 30146569;
				
				
				
    			public const Int32 Special_Stock_Code = 30146570;
				
				
				
    			public const Int32 Internal_Serial_No = 30146571;
		}
		public sealed class Separator_Type
		{
				
				
				private Separator_Type()
    			{
    			}

				public const Int32 DefaultValue = 30343168; 
				
				
				
    			public const Int32 Comma = 30343168;
				
				
				
    			public const Int32 Semicolon = 30343169;
				
				
				
    			public const Int32 tab = 30343170;
				
				
				
    			public const Int32 space = 30343171;
		}
		public sealed class Decimal_Separator_Type
		{
				
				
				private Decimal_Separator_Type()
    			{
    			}

				public const Int32 DefaultValue = 30408705; 
				
				
				
    			public const Int32 Blank = 30408704;
				
				
				
    			public const Int32 Comma = 30408705;
				
				
				
    			public const Int32 Dot = 30408706;
		}
		public sealed class Intrastat_Summary
		{
				
				
				private Intrastat_Summary()
    			{
    			}

				public const Int32 DefaultValue = 1638400; 
				
				
				
    			public const Int32 Monthly = 1638400;
				
				
				[DenyISO("BG,RO,HU,PL,ES,FR,GB")]
    			public const Int32 Quarterly = 1638401;
				
				
				[DenyISO("IT,RO,HU,PL,ES,FR,GB")]
    			public const Int32 Annual = 1638402;
		}
		public sealed class Intrastat_Nature_of_transaction
		{
				
				
				private Intrastat_Nature_of_transaction()
    			{
    			}

				public const Int32 DefaultValue = 5767168; 
				
				[AllowISO("IT")]
				
    			public const Int32 One__Purchase_Sale_Barter_included = 5767168;
				
				[AllowISO("IT")]
				
    			public const Int32 Two__Goods_Return_or_Replacement = 5767169;
				
				[AllowISO("IT")]
				
    			public const Int32 Three__Private_Government_Aid_or_EU_Funds = 5767170;
				
				[AllowISO("IT")]
				
    			public const Int32 Four__Operations_in_view_of_Out_Subcontracting = 5767171;
				
				[AllowISO("IT")]
				
    			public const Int32 Five__Following_Operation_Out_Subcontracting = 5767172;
				
				[AllowISO("IT")]
				
    			public const Int32 Six__Transaction_on_Goods_without_Ownership_Transfer = 5767173;
				
				[AllowISO("IT")]
				
    			public const Int32 Seven__Operation_as_Common_Defense_Program = 5767174;
				
				[AllowISO("IT")]
				
    			public const Int32 Eight__Supply_of_Machinery_for_Building_Contract = 5767175;
				
				[AllowISO("IT")]
				
    			public const Int32 Nine__Other_Transactions = 5767176;
				
				[AllowISO("IT")]
				
    			public const Int32 A__Purchase_Sale_Barter_included = 5767177;
				
				[AllowISO("IT")]
				
    			public const Int32 B__Goods_Return_or_Replacement = 5767178;
				
				[AllowISO("IT")]
				
    			public const Int32 C__Private_Government_Aid_or_EU_Funds = 5767179;
				
				[AllowISO("IT")]
				
    			public const Int32 D__Operations_in_view_of_Out_Subcontracting = 5767180;
				
				[AllowISO("IT")]
				
    			public const Int32 E__Following_Operation_Out_Subcontracting = 5767181;
				
				[AllowISO("IT")]
				
    			public const Int32 F__Transaction_on_Goods_without_Ownership_Transfer = 5767182;
				
				[AllowISO("IT")]
				
    			public const Int32 G__Operation_as_Common_Defense_Program = 5767183;
				
				[AllowISO("IT")]
				
    			public const Int32 H__Supply_of_Machinery_for_Building_Contract = 5767184;
				
				[AllowISO("IT")]
				
    			public const Int32 I__Other_Transactions = 5767185;
				
				[AllowISO("IT")]
				
    			public const Int32 One__Transactions_with_transfer_of_ownership_against_financial_consideration = 5767368;
				
				[AllowISO("IT")]
				
    			public const Int32 Two__Return_and_replacement_of_goods_free_of_charge = 5767369;
				
				[AllowISO("IT")]
				
    			public const Int32 Three__Transactions_with_transfer_of_ownership_without_financial_consideration_stock = 5767370;
				
				[AllowISO("IT")]
				
    			public const Int32 Four__Transactions_with_a_view_to_processing_for_third_parties = 5767371;
				
				[AllowISO("IT")]
				
    			public const Int32 Five__Transactions_following_processing_for_third_parties = 5767372;
				
				[AllowISO("IT")]
				
    			public const Int32 Seven__Transactions_with_a_view_to_or_following_customs_clearance = 5767373;
				
				[AllowISO("IT")]
				
    			public const Int32 Eight__Transactions_involving_the_supply_of_materials_for_a_construction_contractDot = 5767374;
				
				[AllowISO("IT")]
				
    			public const Int32 Nine__Other_transactions_that_cannot_be_classified_under_other_codes = 5767375;
				
				[AllowISO("IT")]
				
    			public const Int32 A__Transactions_with_transfer_of_ownership_against_financial_consideration = 5767376;
				
				[AllowISO("IT")]
				
    			public const Int32 B__Return_and_replacement_of_goods_free_of_charge = 5767377;
				
				[AllowISO("IT")]
				
    			public const Int32 C__Transactions_with_transfer_of_ownership_without_financial_consideration_stock = 5767378;
				
				[AllowISO("IT")]
				
    			public const Int32 D__Transactions_with_a_view_to_processing_for_third_parties = 5767379;
				
				[AllowISO("IT")]
				
    			public const Int32 E__Transactions_following_processing_for_third_parties = 5767380;
				
				[AllowISO("IT")]
				
    			public const Int32 F__Transactions_with_a_view_to_or_following_customs_clearance = 5767381;
				
				[AllowISO("IT")]
				
    			public const Int32 G__Transactions_involving_the_supply_of_materials_for_a_construction_contractDot = 5767382;
				
				[AllowISO("IT")]
				
    			public const Int32 H__Other_transactions_that_cannot_be_classified_under_other_codes = 5767383;
				
				[AllowISO("IT")]
				
    			public const Int32 OneDot1_Outright_saleSlashpurchaseComma_except_trade_with_private_parties = 5767388;
				
				[AllowISO("IT")]
				
    			public const Int32 OneDot2_Direct_trade_with_or_by_private_consumers = 5767389;
				
				[AllowISO("IT")]
				
    			public const Int32 TwoDot1_Return_of_goods = 5767390;
				
				[AllowISO("IT")]
				
    			public const Int32 TwoDot2_Replacement_of_returned_goods = 5767391;
				
				[AllowISO("IT")]
				
    			public const Int32 TwoDot3_Replacement_eDotgDot_under_warranty_of_goods_not_returned = 5767392;
				
				[AllowISO("IT")]
				
    			public const Int32 ThreeDot1_Movement_toSlashfrom_a_warehouse_excluding_callMinusoff_stock = 5767393;
				
				[AllowISO("IT")]
				
    			public const Int32 ThreeDot2_Shipment_for_viewing_or_trial_for_sale_including_callMinusoff_stock = 5767394;
				
				[AllowISO("IT")]
				
    			public const Int32 ThreeDot3_Finance_leasing = 5767395;
				
				[AllowISO("IT")]
				
    			public const Int32 ThreeDot4_Transactions_involving_a_transfer_of_ownership_without_consideration = 5767396;
				
				[AllowISO("IT")]
				
    			public const Int32 FourDot1_Goods_to_be_returned_to_the_original_member_state_or_exporting_country = 5767397;
				
				[AllowISO("IT")]
				
    			public const Int32 FourDot2_Goods_not_required_to_return_to_the_initial_Member_State_or_the_exporting_country = 5767398;
				
				[AllowISO("IT")]
				
    			public const Int32 FiveDot1_Goods_returning_to_the_initial_Member_State_or_the_exporting_country = 5767399;
				
				[AllowISO("IT")]
				
    			public const Int32 FiveDot2_Goods_not_returning_to_the_initial_Member_State_or_the_exporting_country = 5767400;
				
				[AllowISO("IT")]
				
    			public const Int32 SevenDot1_Release_for_free_circulation_in_one_State_with_subsequent_export_to_another = 5767401;
				
				[AllowISO("IT")]
				
    			public const Int32 SevenDot2_Transport_of_goods_from_one_State_to_another_for_export = 5767402;
				
				[AllowISO("IT")]
				
    			public const Int32 NineDot1_RentalComma_loan_and_operational_leasing_for_a_period_exceeding_24_months = 5767403;
				
				[AllowISO("IT")]
				
    			public const Int32 NineDot9_Other = 5767404;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 OneDot1_TransDot_with_compensation_Minus_Direct_purchaseSlashsale = 5767188;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 OneDot2_TransDot_with_compensation_Minus_Supply_for_sale_on_approval_after_trial = 5767189;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 OneDot3_TransDot_with_compensation_Minus_Barter_trade_payment_in_goods = 5767190;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 OneDot4_TransDot_with_compensation_Minus_Finance_lease_hire_purchase = 5767191;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,RO,ES,FR,GB")]
    			public const Int32 OneDot5_TransDot_with_compensation_Minus_Other = 5767192;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 TwoDot1_Return_Minus_Return_of_goods = 5767193;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 TwoDot2_Return_Minus_Replacement_for_returned_goods = 5767194;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 TwoDot3_Return_Minus_Replacement_for_goods_not_being_returned = 5767195;
				
				[AllowISO("  ")]
				
    			public const Int32 ThreeDot1_TransDot_No_compensation_Minus_Goods_delivered_under_aid_programmes_financed_by_the_EU = 5767196;
				
				[AllowISO("  ")]
				
    			public const Int32 ThreeDot2_TransDot_No_compensation_Minus_Other_general_government_aid_deliveries = 5767197;
				
				[AllowISO("  ")]
				
    			public const Int32 ThreeDot3_TransDot_No_compensation_Minus_Other_aid_deliveries_individualsComma_nonMinusgovDot_organizations = 5767198;
				
				[AllowISO("  ")]
				
    			public const Int32 ThreeDot4_TransDot_No_compensation_Minus_Other_transaction_without_compensation = 5767199;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 FourDot1_Operations_with_a_view_to_processing_under_contract_Minus_goods_to_be_returned_to_sender = 5767200;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 FiveDot1_Operations_following_processing_under_contract_Minus_goods_returned_to_sender = 5767201;
				
				[AllowISO("  ")]
				
    			public const Int32 SixDot1_Particular_transactionsComma_hireComma_loanComma_operational_leasing = 5767202;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 Seven___Operations_under_joint_defence_projects = 5767203;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 Eight___Supply_of_building_materials_and_equipment = 5767204;
				
				[AllowISO("  ")]
				
    			public const Int32 Nine___Other_transactions_not_recorded_elsewhere = 5767205;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 FourDot2_Operations_with_a_view_to_processing_under_contract_Minus_goods_not_returned_to_sender = 5767206;
				
				[AllowISO("  ")]
				
    			public const Int32 FourDot3_Operations_with_a_view_to_processing_repair_and_maintenance_free = 5767207;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 FiveDot2_Operations_following_processing_under_contract_Minus_goods_not_returned_to_sender = 5767208;
				
				[AllowISO("  ")]
				
    			public const Int32 FiveDot3_Operations_following_processing_repair_and_maintenance_free = 5767209;
				
				[AllowISO("  ")]
				
    			public const Int32 SixDot2_Particular_transactionsComma_other_goods_for_temporary_use = 5767210;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 TwoDot9_Return_Minus_Others = 5767211;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 Three___TransDot_No_Compensation = 5767212;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 Six___Particular_transactions = 5767213;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,ES,FR,GB")]
    			public const Int32 NineDot1_Other_transactionsComma_not_recorded_elsewhere_Minus_hireComma_loanComma_operational_lease = 5767214;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,RO,ES,FR,GB")]
    			public const Int32 NineDot2_Other_transactionsComma_not_recorded_elsewhere_Minus_others = 5767215;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,BG,ES,FR,GB")]
    			public const Int32 OneDot9_TransDot_with_compensation_Minus_Other = 5767216;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("PL,HU,BG,ES,FR,GB")]
    			public const Int32 NineDot9_Other_transactionsComma_not_recorded_elsewhere_Minus_others = 5767217;
				
				[AllowISO("HU")]
				
    			public const Int32 OneOne_TransDot_with_compensation_Minus_Outright_purchaseSlashsale = 5767218;
				
				[AllowISO("HU")]
				
    			public const Int32 OneTwo_TransDot_with_compensation_Minus_Supply_for_sale_on_approval_after_trial = 5767219;
				
				[AllowISO("HU")]
				
    			public const Int32 OneThree_TransDot_with_compensation_Minus_Barter_trade_compensation_in_kind = 5767220;
				
				[AllowISO("HU")]
				
    			public const Int32 OneFour_TransDot_with_compensation_Minus_Financial_leasing_hireMinuspurchase = 5767221;
				
				[AllowISO("HU")]
				
    			public const Int32 OneSix_TransDot_with_compensation_Minus_Physical_assets_brought_into_the_business = 5767222;
				
				[AllowISO("HU")]
				
    			public const Int32 OneSeven_TransDot_with_compensation_Minus_ReMinusexport = 5767223;
				
				[AllowISO("HU")]
				
    			public const Int32 OneNine_TransDot_with_compensation_Minus_Other = 5767224;
				
				[AllowISO("HU")]
				
    			public const Int32 TwoOne_Return_Minus_Return_of_goods = 5767225;
				
				[AllowISO("HU")]
				
    			public const Int32 TwoTwo_Return_Minus_Replacement_for_returned_goods = 5767226;
				
				[AllowISO("HU")]
				
    			public const Int32 TwoThree_Return_Minus_Replacement_for_goods_not_being_returned = 5767227;
				
				[AllowISO("HU")]
				
    			public const Int32 TwoNine_Return_Minus_Other = 5767228;
				
				[AllowISO("HU")]
				
    			public const Int32 ThreeZero_Transactions_without_financial_or_in_kind_compensation = 5767229;
				
				[AllowISO("HU")]
				
    			public const Int32 FourOne_Operations_with_a_view_to_processing_under_contract_Minus_Goods_expected = 5767230;
				
				[AllowISO("HU")]
				
    			public const Int32 FourTwo_Operations_with_a_view_to_processing_under_contract_Minus_Goods_not_expected = 5767231;
				
				[AllowISO("HU")]
				
    			public const Int32 FiveOne_Operations_following_processing_under_contract_Minus_Goods_returning = 5767232;
				
				[AllowISO("HU")]
				
    			public const Int32 FiveTwo_Operations_following_processing_under_contract_Minus_Goods_not_returning = 5767233;
				
				[AllowISO("HU")]
				
    			public const Int32 FiveNine_Operations_following_processing_under_contract_Minus_Return_of_leftMinusover = 5767234;
				
				[AllowISO("HU")]
				
    			public const Int32 SevenZero_Operations_under_joint_defence_projects = 5767235;
				
				[AllowISO("HU")]
				
    			public const Int32 EightOne_Supply_of_building_materials_and_equipment_Minus_For_less_than_one_year = 5767236;
				
				[AllowISO("HU")]
				
    			public const Int32 EightTwo_Supply_of_building_materials_and_equipment_Minus_For_more_than_one_year = 5767237;
				
				[AllowISO("HU")]
				
    			public const Int32 NineOne_Other_transactions_Minus_HireComma_loan_and_operational_leasing_longer_than_24_months = 5767238;
				
				[AllowISO("HU")]
				
    			public const Int32 NineTwo_Other_transactions_Minus_Indirect_trade = 5767239;
				
				[AllowISO("HU")]
				
    			public const Int32 NineThree_Other_transactions_Minus_Store_movements = 5767240;
				
				[AllowISO("HU")]
				
    			public const Int32 NineNine_Other_transactions_Minus_Others = 5767241;
				
				[AllowISO("PL")]
				
    			public const Int32 OneOne__TransDot_with_compensation_Minus_Direct_purchaseSlashsale = 5767248;
				
				[AllowISO("PL")]
				
    			public const Int32 OneTwo__TransDot_with_compensation_Minus_Supply_for_sale_on_approval_after_trial = 5767249;
				
				[AllowISO("PL")]
				
    			public const Int32 OneThree__TransDot_with_compensation_Minus_Barter_trade_compensation_in_kind = 5767250;
				
				[AllowISO("PL")]
				
    			public const Int32 OneFour__TransDot_with_compensation_Minus_Financial_leasing_hireMinuspurchase = 5767251;
				
				[AllowISO("PL")]
				
    			public const Int32 OneNine__TransDot_with_compensation_Minus_Other = 5767252;
				
				[AllowISO("PL")]
				
    			public const Int32 TwoOne__Return_Minus_Return_of_goods = 5767253;
				
				[AllowISO("PL")]
				
    			public const Int32 TwoTwo__Return_Minus_Replacement_for_returned_goods = 5767254;
				
				[AllowISO("PL")]
				
    			public const Int32 TwoThree__Return_Minus_Replacement_for_goods_not_being_returned = 5767255;
				
				[AllowISO("PL")]
				
    			public const Int32 TwoNine__Return_Minus_Other = 5767256;
				
				[AllowISO("PL")]
				
    			public const Int32 ThreeZero__Transactions_without_financial_or_in_kind_compensation = 5767257;
				
				[AllowISO("PL")]
				
    			public const Int32 FourOne__Operations_with_a_view_to_processing_under_contract_Minus_Goods_expected = 5767258;
				
				[AllowISO("PL")]
				
    			public const Int32 FourTwo__Operations_with_a_view_to_processing_under_contract_Minus_Goods_not_expected = 5767259;
				
				[AllowISO("PL")]
				
    			public const Int32 FiveOne__Operations_following_processing_under_contract_Minus_Goods_returning = 5767260;
				
				[AllowISO("PL")]
				
    			public const Int32 FiveTwo__Operations_following_processing_under_contract_Minus_Goods_not_returning = 5767261;
				
				[AllowISO("PL")]
				
    			public const Int32 SixOne__Particular_transactions_for_domestic_needs_Minus_BioMinuscomponent = 5767262;
				
				[AllowISO("PL")]
				
    			public const Int32 SixTwo__Particular_transactions_for_domestic_needs_Minus_BioMinusmass = 5767263;
				
				[AllowISO("PL")]
				
    			public const Int32 SixThree__Particular_transactions_for_domestic_needs_Minus_BioMinusfuels = 5767264;
				
				[AllowISO("PL")]
				
    			public const Int32 SevenZero__Operations_under_joint_defence_projects = 5767265;
				
				[AllowISO("PL")]
				
    			public const Int32 EightZero__Deliveries_of_construction_materials_and_technical_equipment = 5767266;
				
				[AllowISO("PL")]
				
    			public const Int32 NineOne__Other_transactions_Minus_HireComma_loan_and_operational_leasing_longer_than_24_months = 5767267;
				
				[AllowISO("PL")]
				
    			public const Int32 NineNine__Other_transactions_Minus_Others = 5767268;
				
				[AllowISO("RO")]
				
    			public const Int32 FourDot3_Goods_for_processingComma_treated_as_assimilated_intracommunity_operations = 5767269;
				
				[AllowISO("RO")]
				
    			public const Int32 FiveDot3_Goods_obtained_after_processing_of_goods_previously_declared_under_code_4Dot3 = 5767270;
				
				[AllowISO("RO")]
				
    			public const Int32 NineDot2_Indirect_trade = 5767271;
				
				[AllowISO("ES")]
				
    			public const Int32 OneOne_Outright_saleSlashpurchaseComma_except_trade_with_private_parties = 5767278;
				
				[AllowISO("ES")]
				
    			public const Int32 OneTwo_Direct_trade_with_or_by_private_consumers = 5767279;
				
				[AllowISO("ES")]
				
    			public const Int32 OneThree_deleted_Barter_compensation_in_kind = 5767280;
				
				[AllowISO("ES")]
				
    			public const Int32 OneFour_deleted_Financial_lease_rentMinuspurchase = 5767281;
				
				[AllowISO("ES")]
				
    			public const Int32 OneNine_deleted_Other = 5767282;
				
				[AllowISO("ES")]
				
    			public const Int32 TwoOne_Return_of_goods = 5767283;
				
				[AllowISO("ES")]
				
    			public const Int32 TwoTwo_Substitution_of_returned_goods = 5767284;
				
				[AllowISO("ES")]
				
    			public const Int32 TwoThree_Substitution_for_exampleComma_under_warranty_of_goods_not_returned = 5767285;
				
				[AllowISO("ES")]
				
    			public const Int32 TwoNine_deleted_Other = 5767286;
				
				[AllowISO("ES")]
				
    			public const Int32 ThreeOne_Movement_toSlashfrom_a_warehouse = 5767287;
				
				[AllowISO("ES")]
				
    			public const Int32 ThreeTwo_Shipment_for_viewing_or_trial_for_sale = 5767288;
				
				[AllowISO("ES")]
				
    			public const Int32 ThreeThree_Finance_leasing = 5767289;
				
				[AllowISO("ES")]
				
    			public const Int32 FourOne_Goods_to_be_returned_to_the_original_member_state_or_exporting_country = 5767290;
				
				[AllowISO("ES")]
				
    			public const Int32 FourTwo_Goods_not_required_to_return_to_the_initial_Member_State_or_the_exporting_country = 5767291;
				
				[AllowISO("ES")]
				
    			public const Int32 FourFour_deleted_Repair_or_maintenance_free_of_charge = 5767292;
				
				[AllowISO("ES")]
				
    			public const Int32 FourFive_deleted_Repair_or_maintenance_for_consideration = 5767293;
				
				[AllowISO("ES")]
				
    			public const Int32 FiveOne_Goods_returning_to_the_initial_Member_State_or_the_exporting_country = 5767294;
				
				[AllowISO("ES")]
				
    			public const Int32 FiveTwo_Goods_not_returning_to_the_initial_Member_State_or_the_exporting_country = 5767295;
				
				[AllowISO("ES")]
				
    			public const Int32 FiveFour_deleted_Repair_or_maintenance_free_of_charge = 5767296;
				
				[AllowISO("ES")]
				
    			public const Int32 FiveFive_deleted_Repair_or_maintenance_for_consideration = 5767297;
				
				[AllowISO("ES")]
				
    			public const Int32 SevenZero_deleted_Operations_in_the_framework_of_joint_defense_projects_or_other_joint_production_intergovernmental_programs = 5767298;
				
				[AllowISO("ES")]
				
    			public const Int32 EightZero_Transactions_involving_the_supply_of_construction_materials_and_technical_equipment = 5767299;
				
				[AllowISO("ES")]
				
    			public const Int32 NineOne_RentComma_loan_and_operating_lease_for_a_period_exceeding_twentyMinusfour_months = 5767300;
				
				[AllowISO("ES")]
				
    			public const Int32 NineNine_deleted_Others = 5767301;
				
				[AllowISO("ES")]
				
    			public const Int32 ThreeFour_Transactions_involving_a_transfer_of_ownership_without_consideration = 5767302;
				
				[AllowISO("ES")]
				
    			public const Int32 SevenOne_Release_for_free_circulation_in_one_State_with_subsequent_export_to_another = 5767303;
				
				[AllowISO("ES")]
				
    			public const Int32 SevenTwo_Transport_of_goods_from_one_State_to_another_for_export = 5767304;
				
				[AllowISO("ES")]
				
    			public const Int32 NineTwo_Others = 5767305;
				
				[AllowISO("FR")]
				
    			public const Int32 OneOne__Firm_purchase_Slash_sale = 5767308;
				
				[AllowISO("FR")]
				
    			public const Int32 OneTwo__Direct_trade_withSlashby_private_consumers_inclDot_distance_sales = 5767309;
				
				[AllowISO("FR")]
				
    			public const Int32 OneThree__deleted_Barter_compensation_in_kind = 5767310;
				
				[AllowISO("FR")]
				
    			public const Int32 OneFour__deleted_Purchases_by_private = 5767311;
				
				[AllowISO("FR")]
				
    			public const Int32 OneNine__deleted_Transaction_resulting_in_a_transfer_of_property_other_than_11Comma12Comma13Comma14 = 5767312;
				
				[AllowISO("FR")]
				
    			public const Int32 TwoOne__Return_of_goods = 5767313;
				
				[AllowISO("FR")]
				
    			public const Int32 TwoTwo__Substitution_of_returned_goods = 5767314;
				
				[AllowISO("FR")]
				
    			public const Int32 TwoThree__Substitution_for_exampleComma_under_warranty_of_goods_not_returned = 5767315;
				
				[AllowISO("FR")]
				
    			public const Int32 TwoNine__deleted_Return_of_goods_other_than_21Comma_22Comma_23Dot = 5767316;
				
				[AllowISO("FR")]
				
    			public const Int32 ThreeZero__deleted_NonMinustemporary_transaction_involving_transfer_of_ownership_without_transaction_compensatory = 5767317;
				
				[AllowISO("FR")]
				
    			public const Int32 FourOne__Goods_expected_to_return_to_the_initial_Member_State_of_dispatch = 5767318;
				
				[AllowISO("FR")]
				
    			public const Int32 FourTwo__Goods_expected_to_return_to_a_Member_State_other_than_the_initial_Member_State_of_dispatch = 5767319;
				
				[AllowISO("FR")]
				
    			public const Int32 FiveOne__Goods_returning_to_the_initial_Member_State_of_dispatch = 5767320;
				
				[AllowISO("FR")]
				
    			public const Int32 FiveTwo__Goods_returning_to_a_Member_State_other_than_the_initial_Member_State_of_dispatch = 5767321;
				
				[AllowISO("FR")]
				
    			public const Int32 SevenZero__deleted_Operations_in_the_framework_of_joint_defense_projects_or_other_joint_production_intergovDot_programs = 5767322;
				
				[AllowISO("FR")]
				
    			public const Int32 EightZero__Transactions_involving_the_supply_of_construction_materials_and_technical_equipment = 5767323;
				
				[AllowISO("FR")]
				
    			public const Int32 NineOne__HireComma_loanComma_and_operational_leasing_longer_twentyMinusfour_months = 5767324;
				
				[AllowISO("FR")]
				
    			public const Int32 NineNine__Others = 5767325;
				
				[AllowISO("FR")]
				
    			public const Int32 ThreeOne__Movements_toSlashfrom_a_warehouse = 5767326;
				
				[AllowISO("FR")]
				
    			public const Int32 ThreeTwo__Supply_for_sale_on_approval_or_after_trial_including_call_off_stock = 5767327;
				
				[AllowISO("FR")]
				
    			public const Int32 ThreeThree__Financial_leasing = 5767328;
				
				[AllowISO("FR")]
				
    			public const Int32 ThreeFour__Transactions_involving_transfer_of_ownership_without_financial_compensation = 5767329;
				
				[AllowISO("FR")]
				
    			public const Int32 SevenOne__Release_of_goods_for_free_circulation_in_one_Member_State_with_subsequent_export_to_another_Member_State = 5767330;
				
				[AllowISO("FR")]
				
    			public const Int32 SevenTwo__Transportation_of_goods_from_one_Member_State_to_another_Member_State_quasiMinusexportsDot = 5767331;
				
				[AllowISO("GB")]
				
    			public const Int32 OneZero_All_transactions_involving_actual_or_intended_change_of_ownership_for_a_consideration = 5767338;
				
				[AllowISO("GB")]
				
    			public const Int32 OneSix_Credit_note_where_the_goods_are_not_returnedDot = 5767339;
				
				[AllowISO("GB")]
				
    			public const Int32 OneSeven_Transactions_which_must_be_included_on_SDs_but_not_shown_in_boxes_8_or_9_of_VAT_return = 5767340;
				
				[AllowISO("GB")]
				
    			public const Int32 OneEight_Transactions_which_must_be_included_in_boxes_8_or_9_of_the_VAT_return_but_are_not_required_in_SD = 5767341;
				
				[AllowISO("GB")]
				
    			public const Int32 TwoZero_Returned_goods_and_replacement_goods_free_of_charge = 5767342;
				
				[AllowISO("GB")]
				
    			public const Int32 ThreeZero_Free_of_charge_FOC_transactions_involving_permanent_change_of_ownershipDot = 5767343;
				
				[AllowISO("GB")]
				
    			public const Int32 ThreeSeven_Free_of_charge_FOC_not_shown_in_boxes_8_or_9 = 5767344;
				
				[AllowISO("GB")]
				
    			public const Int32 ThreeEight_Free_of_charge_FOC_included_in_boxes_8_or_9 = 5767345;
				
				[AllowISO("GB")]
				
    			public const Int32 FourZero_Goods_sent_or_received_for_processing = 5767346;
				
				[AllowISO("GB")]
				
    			public const Int32 FiveZero_Goods_returned_or_received_following_processing = 5767347;
				
				[AllowISO("GB")]
				
    			public const Int32 SevenZero_Joint_defence_or_other_joint_interMinusgovernmental_production_programmes_eg_airbus = 5767348;
				
				[AllowISO("GB")]
				
    			public const Int32 SevenSeven_Joint_defence_not_shown_in_boxes_8_or_9 = 5767349;
				
				[AllowISO("GB")]
				
    			public const Int32 SevenEight_Joint_defence_included_in_boxes_8_or_9 = 5767350;
				
				[AllowISO("GB")]
				
    			public const Int32 EightZero_Supply_of_building_materials_and_equipment_as_part_of_a_general_construction = 5767351;
				
				[AllowISO("GB")]
				
    			public const Int32 EightSeven_Supply_of_building_materials_not_shown_in_boxes_8_or_9 = 5767352;
				
				[AllowISO("GB")]
				
    			public const Int32 EightEight_Supply_of_building_materials_included_in_boxes_8_or_9 = 5767353;
				
				[AllowISO("GB")]
				
    			public const Int32 NineZero_Other_transactions_which_do_not_fit_any_of_the_above_descriptionsDot = 5767354;
				
				[AllowISO("GB")]
				
    			public const Int32 NineSeven_Other_transactions_not_shown_in_boxes_8_or_9 = 5767355;
				
				[AllowISO("GB")]
				
    			public const Int32 NineEight_Other_transactions_included_in_boxes_8_or_9 = 5767356;
		}
		public sealed class Intrastat_Mode_of_Transport
		{
				
				
				private Intrastat_Mode_of_Transport()
    			{
    			}

				public const Int32 DefaultValue = 5832706; 
				
				
				[DenyISO("HU,GB")]
    			public const Int32 One_By_Sea = 5832704;
				
				
				[DenyISO("GB")]
    			public const Int32 Two_By_Rail = 5832705;
				
				
				[DenyISO("GB")]
    			public const Int32 Three_By_Road = 5832706;
				
				
				[DenyISO("GB")]
    			public const Int32 Four_By_Air = 5832707;
				
				
				[DenyISO("GB")]
    			public const Int32 Five_Consignment_by_post = 5832708;
				
				
				[DenyISO("GB")]
    			public const Int32 Seven_Fixed_Transport_Installations = 5832709;
				
				
				[DenyISO("GB")]
    			public const Int32 Eight_Transport_by_inland_waterway = 5832710;
				
				
				[DenyISO("GB")]
    			public const Int32 Nine_Own_Propulsion = 5832711;
				
				
				[DenyISO("PL,ES,GB")]
    			public const Int32 Six_Not_allocated = 5832712;
				
				[AllowISO("GB")]
				
    			public const Int32 FromSlashTo_Great_Britain_XU = 5832713;
				
				[AllowISO("GB")]
				
    			public const Int32 FromSlashTo_Northern_Ireland_XI = 5832714;
		}
		public sealed class Intrastat_Operation_Type
		{
				
				
				private Intrastat_Operation_Type()
    			{
    			}

				public const Int32 DefaultValue = 5898240; 
				
				
				
    			public const Int32 Initial_Supplier = 5898240;
				
				
				
    			public const Int32 Transferring_Purchaser = 5898241;
				
				
				
    			public const Int32 Final_Purchaser = 5898242;
				
				
				
    			public const Int32 Not_Triangular = 5898243;
				
				
				
    			public const Int32 TriangDot_with_Processing = 5898244;
				
				
				
    			public const Int32 Statistical_purpose_only = 5898245;
		}
		public sealed class Intrastat_Dispatches_Regime
		{
				
				
				private Intrastat_Dispatches_Regime()
    			{
    			}

				public const Int32 DefaultValue = 5963782; 
				
				[AllowISO("  ")]
				
    			public const Int32 One__Definitive_Shipment = 5963776;
				
				[AllowISO("  ")]
				
    			public const Int32 Two__Temporary_Shipment_for_Processing = 5963777;
				
				[AllowISO("  ")]
				
    			public const Int32 Three__Reshipment_after_Temporary_Processing = 5963778;
				
				[AllowISO("IT")]
				
    			public const Int32 C__CostComma_Insurance_and_FreightComma_FreightSlashCarriage_Paid_toDotDotDot = 5963779;
				
				[AllowISO("IT")]
				
    			public const Int32 D__Delivered_at_FrontierComma_FDot_On_BoardComma_Duty_Paid_and_Unpaid = 5963780;
				
				[AllowISO("IT")]
				
    			public const Int32 E__Ex_Factory = 5963781;
				
				[AllowISO("IT")]
				
    			public const Int32 F__Free_CarrierComma_OverboardComma_On_Board = 5963782;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 EXW_exMinusworks = 5963786;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 FCA_franco_carrier = 5963787;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 FAS_free_alongside_ship = 5963788;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 FOB_free_on_board = 5963789;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 CFR_cost_and_freight = 5963790;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 CIF_costComma_insurance_and_freight = 5963791;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 CPT_carriage_paid_to = 5963792;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 CIP_carriage_and_insurance_paid_to = 5963793;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("BG,RO,PL,ES,FR,GB")]
    			public const Int32 DAF_delivered_at_frontier = 5963794;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("BG,RO,PL,ES,FR,GB")]
    			public const Int32 DES_delivered_exMinusship = 5963795;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("BG,RO,PL,ES,FR,GB")]
    			public const Int32 DEQ_delivered_exMinusquay = 5963796;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("BG,RO,PL,ES,FR,GB")]
    			public const Int32 DDU_delivered_duty_unpaid = 5963797;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 DDP_delivered_duty_paid = 5963798;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("BG,PL,ES,FR")]
    			public const Int32 XXX_delivery_terms_other_than_the_above = 5963799;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR,ES")]
    			public const Int32 DAT_Delivered_at_Terminal = 5963800;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 DAP_Delivered_at_Place = 5963801;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR,GB")]
    			public const Int32 DPU_Delivered_to_the_unloaded_place = 5963802;
				
				[AllowISO("FR")]
				
    			public const Int32 TwoZero_Transfer_of_stock_under_a_deposit_contractComma_without_transfer_of_ownership = 5963806;
				
				[AllowISO("FR")]
				
    			public const Int32 OneZero_Correction_of_the_DEB_initially_presented_in_regime_code_20 = 5963807;
				
				[AllowISO("FR")]
				
    			public const Int32 TwoOne_Exempt_delivery_and_transfer = 5963808;
				
				[AllowISO("FR")]
				
    			public const Int32 TwoFive_Commercial_regularization_leading_to_a_reduction_in_value_such_as_discount = 5963809;
				
				[AllowISO("FR")]
				
    			public const Int32 TwoSix_Commercial_regularization_resulting_in_an_increase_in_value = 5963810;
				
				[AllowISO("FR")]
				
    			public const Int32 TwoNine_Other_expeditions = 5963811;
				
				[AllowISO("FR")]
				
    			public const Int32 ThreeOne_ReMinusinvoicing_as_part_of_a_triangular_transaction = 5963812;
		}
		public sealed class Intrastat_Adjustment_Sign
		{
				
				
				private Intrastat_Adjustment_Sign()
    			{
    			}

				public const Int32 DefaultValue = 6029313; 
				
				
				
    			public const Int32 Positive = 6029312;
				
				
				
    			public const Int32 Negative = 6029313;
		}
		public sealed class Intrastat_Arrivals_Regime
		{
				
				
				private Intrastat_Arrivals_Regime()
    			{
    			}

				public const Int32 DefaultValue = 6160390; 
				
				[AllowISO("  ")]
				
    			public const Int32 Four__Definitive_Introduction = 6160384;
				
				[AllowISO("  ")]
				
    			public const Int32 Five__Temporary_Introduction_for_Processing = 6160385;
				
				[AllowISO("  ")]
				
    			public const Int32 Six__Introduction_after_Temporary_Processing = 6160386;
				
				[AllowISO("IT")]
				
    			public const Int32 C__CostComma_Insurance_and_FreightComma_FreightSlashCarriage_Paid_toDotDotDot = 6160387;
				
				[AllowISO("IT")]
				
    			public const Int32 D__Delivered_at_FrontierComma_FDot_On_BoardComma_Duty_Paid_and_Unpaid = 6160388;
				
				[AllowISO("IT")]
				
    			public const Int32 E__Ex_Factory = 6160389;
				
				[AllowISO("IT")]
				
    			public const Int32 F__Free_CarrierComma_OverboardComma_On_Board = 6160390;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 EXW_exMinusworks = 6160394;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 FCA_franco_carrier = 6160395;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 FAS_free_alongside_ship = 6160396;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 FOB_free_on_board = 6160397;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 CFR_cost_and_freight = 6160398;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 CIF_costComma_insurance_and_freight = 6160399;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 CPT_carriage_paid_to = 6160400;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 CIP_carriage_and_insurance_paid_to = 6160401;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("BG,RO,PL,ES,FR,GB")]
    			public const Int32 DAF_delivered_at_frontier = 6160402;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("BG,RO,PL,ES,FR,GB")]
    			public const Int32 DES_delivered_exMinusship = 6160403;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("BG,RO,PL,ES,FR,GB")]
    			public const Int32 DEQ_delivered_exMinusquay = 6160404;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("BG,RO,PL,ES,FR,GB")]
    			public const Int32 DDU_delivered_duty_unpaid = 6160405;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 DDP_delivered_duty_paid = 6160406;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("BG,PL,ES,FR")]
    			public const Int32 XXX_delivery_terms_other_than_the_above = 6160407;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR,ES")]
    			public const Int32 DAT_Delivered_at_Terminal = 6160408;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR")]
    			public const Int32 DAP_Delivered_at_Place = 6160409;
				[Activation("ERP.Intrastat_NO_IT")]
				
				[DenyISO("FR,GB")]
    			public const Int32 DPU_Delivered_to_the_unloaded_place = 6160410;
				
				[AllowISO("FR")]
				
    			public const Int32 OneOne_Taxable_intraMinuscommunity_acquisition_in_France = 6160414;
				
				[AllowISO("FR")]
				
    			public const Int32 OneNine_Other_introductions = 6160415;
		}
		public sealed class Intrastat_Rounding_Type
		{
				
				
				private Intrastat_Rounding_Type()
    			{
    			}

				public const Int32 DefaultValue = 10354690; 
				
				
				
    			public const Int32 Lower = 10354688;
				
				
				
    			public const Int32 Upper = 10354689;
				
				
				
    			public const Int32 Mathematical = 10354690;
		}
		public sealed class Statistical_procedure
		{
				
				
				private Statistical_procedure()
    			{
    			}

				public const Int32 DefaultValue = 26017792; 
				
				
				
    			public const Int32 One_Minus_Transactions_with_goodsComma_declared_like_an_acquisition_into_the_same_referent_period = 26017792;
				
				
				
    			public const Int32 Two_Minus_Transactions_with_goodsComma_declared_like_an_acquisition_into_an_other_referent_period = 26017793;
				
				
				
    			public const Int32 Three_Minus_Transactions_forSlashafter_processing_of_goods_by_contract = 26017794;
				
				
				
    			public const Int32 Four_Minus_Triangular_operations = 26017795;
				
				
				
    			public const Int32 Five_Minus_Others = 26017796;
		}
		public sealed class Intrastat_Supply_Type
		{
				
				
				private Intrastat_Supply_Type()
    			{
    			}

				public const Int32 DefaultValue = 589824; 
				
				
				
    			public const Int32 Blank = 589824;
				
				
				
    			public const Int32 Immediately = 589825;
				
				
				
    			public const Int32 More_Times = 589826;
		}
		public sealed class Intrastat_Collection_Type
		{
				
				
				private Intrastat_Collection_Type()
    			{
    			}

				public const Int32 DefaultValue = 655360; 
				
				
				
    			public const Int32 Blank = 655360;
				
				
				
    			public const Int32 Credit = 655361;
				
				
				
    			public const Int32 Bank_Transfer = 655362;
				
				
				
    			public const Int32 Other = 655363;
		}
		public sealed class Requesting_Party
		{
				
				
				private Requesting_Party()
    			{
    			}

				public const Int32 DefaultValue = 3866624; 
				
				
				
    			public const Int32 None = 3866624;
				
				
				
    			public const Int32 Customer = 3866625;
				
				
				
    			public const Int32 Supplier = 3866626;
		}
		public sealed class Valuation_Type
		{
				
				
				private Valuation_Type()
    			{
    			}

				public const Int32 DefaultValue = 4259840; 
				
				
				
    			public const Int32 Based_on_ABC_Analysis = 4259840;
				
				
				
    			public const Int32 Always = 4259841;
				
				
				
    			public const Int32 Never = 4259842;
		}
		public sealed class Ignore_CustomerSlash_Supplier_Type
		{
				
				
				private Ignore_CustomerSlash_Supplier_Type()
    			{
    			}

				public const Int32 DefaultValue = 6094850; 
				
				
				
    			public const Int32 Customer = 6094848;
				
				
				
    			public const Int32 Supplier = 6094849;
				
				
				
    			public const Int32 Ignore = 6094850;
		}
		public sealed class Inventory_Action
		{
				
				
				private Inventory_Action()
    			{
    			}

				public const Int32 DefaultValue = 6291456; 
				
				
				
    			public const Int32 Ignore = 6291456;
				
				
				
    			public const Int32 Sum = 6291457;
				
				
				
    			public const Int32 Subtract = 6291458;
				
				
				
    			public const Int32 Update = 6291459;
		}
		public sealed class Cost_for_ABC_Analysis
		{
				
				
				private Cost_for_ABC_Analysis()
    			{
    			}

				public const Int32 DefaultValue = 6488064; 
				
				
				
    			public const Int32 Last = 6488064;
				
				
				
    			public const Int32 SecondMinusLast = 6488065;
				
				
				
    			public const Int32 Average = 6488066;
				
				
				
    			public const Int32 Standard = 6488067;
				
				
				
    			public const Int32 LIFO = 6488068;
				
				
				
    			public const Int32 FIFO = 6488069;
		}
		public sealed class Cost_Accounting_Reason
		{
				
				
				private Cost_Accounting_Reason()
    			{
    			}

				public const Int32 DefaultValue = 8519683; 
				
				
				
    			public const Int32 Consumption = 8519680;
				
				
				[DenyISO("DE")]
    			public const Int32 Costs = 8519681;
				
				
				[DenyISO("DE")]
    			public const Int32 Revenues = 8519682;
				
				
				
    			public const Int32 Ignore = 8519683;
		}
		public sealed class Line_Cost_Origin
		{
				
				
				private Line_Cost_Origin()
    			{
    			}

				public const Int32 DefaultValue = 11993091; 
				
				
				
    			public const Int32 Entry_Amount = 11993088;
				
				
				
    			public const Int32 CIG = 11993089;
				
				
				
    			public const Int32 Ignore = 11993091;
		}
		public sealed class Reason_Type
		{
				
				
				private Reason_Type()
    			{
    			}

				public const Int32 DefaultValue = 12189702; 
				
				
				
    			public const Int32 Initial = 12189696;
				
				
				
    			public const Int32 Cancel_Initial = 12189697;
				
				
				
    			public const Int32 Load = 12189698;
				
				
				
    			public const Int32 Cancel_Load = 12189699;
				
				
				
    			public const Int32 Unload = 12189700;
				
				
				
    			public const Int32 Cancel_Unload = 12189701;
				
				
				
    			public const Int32 Nothing = 12189702;
		}
		public sealed class Entry_Type_for_LifoSlashFifo_batch_eval
		{
				
				
				private Entry_Type_for_LifoSlashFifo_batch_eval()
    			{
    			}

				public const Int32 DefaultValue = 12255235; 
				
				
				
    			public const Int32 Load_Variation = 12255232;
				
				
				
    			public const Int32 Cancel_Load_variation = 12255233;
				
				
				
    			public const Int32 Split_variation = 12255234;
				
				
				
    			public const Int32 Nothing = 12255235;
		}
		public sealed class Check_on_Inventory_Entries_posting_date
		{
				
				
				private Check_on_Inventory_Entries_posting_date()
    			{
    			}

				public const Int32 DefaultValue = 12386304; 
				
				
				
    			public const Int32 No_check = 12386304;
				
				
				
    			public const Int32 Check_on_storage_inventory_entries = 12386305;
				
				
				
    			public const Int32 Generic_check_on_inventory_entries_ = 12386306;
		}
		public sealed class Loader_Type
		{
				
				
				private Loader_Type()
    			{
    			}

				public const Int32 DefaultValue = 26214400; 
				
				
				
    			public const Int32 Company = 26214400;
				
				
				
    			public const Int32 Customer = 26214401;
				
				
				
    			public const Int32 Supplier = 26214402;
				
				
				
    			public const Int32 Carrier = 26214403;
		}
		public sealed class Owner_Type
		{
				
				
				private Owner_Type()
    			{
    			}

				public const Int32 DefaultValue = 26279936; 
				
				
				
    			public const Int32 Company = 26279936;
				
				
				
    			public const Int32 Customer = 26279937;
				
				
				
    			public const Int32 Supplier = 26279938;
				
				
				
    			public const Int32 None = 26279939;
		}
		public sealed class Align_Data_in_Inventory_Closing
		{
				
				
				private Align_Data_in_Inventory_Closing()
    			{
    			}

				public const Int32 DefaultValue = 26345472; 
				
				
				
    			public const Int32 Only_if_zero_in_current_fiscal_year = 26345472;
				
				
				
    			public const Int32 Always = 26345473;
				
				
				
    			public const Int32 Never = 26345474;
		}
		public sealed class Action_Of_Lifo_Fifo
		{
				
				
				private Action_Of_Lifo_Fifo()
    			{
    			}

				public const Int32 DefaultValue = 26411008; 
				
				
				
    			public const Int32 Not_to_be_tracked = 26411008;
				
				
				
    			public const Int32 Load = 26411009;
				
				
				[DenyISO("BR")]
    			public const Int32 Quantity_IN = 26411010;
				
				
				[DenyISO("BR")]
    			public const Int32 Quantity_OUT = 26411011;
				
				
				[DenyISO("BR")]
    			public const Int32 Positive_Change_Value = 26411012;
				
				
				[DenyISO("BR")]
    			public const Int32 Storage_Transfer = 26411013;
				
				
				
    			public const Int32 Unload = 26411014;
				
				
				[DenyISO("BR")]
    			public const Int32 CIG_Correction_for_Sales = 26411015;
				
				
				[DenyISO("BR")]
    			public const Int32 Not_Set = 26411016;
				
				
				[DenyISO("BR")]
    			public const Int32 Negative_Change_Value = 26411017;
		}
		public sealed class Lifo_Fifo_Line_Source
		{
				
				
				private Lifo_Fifo_Line_Source()
    			{
    			}

				public const Int32 DefaultValue = 26476544; 
				
				
				
    			public const Int32 None = 26476544;
				
				
				
    			public const Int32 Receipt = 26476545;
				
				
				
    			public const Int32 Issue = 26476546;
		}
		public sealed class Inventory_Document_Operation_Type
		{
				
				
				private Inventory_Document_Operation_Type()
    			{
    			}

				public const Int32 DefaultValue = 27131905; 
				
				
				
    			public const Int32 Initial_Inventory = 27131904;
				
				
				
    			public const Int32 Inventory_Adjustment = 27131905;
		}
		public sealed class Line_Cost_Update
		{
				
				
				private Line_Cost_Update()
    			{
    			}

				public const Int32 DefaultValue = 43581440; 
				
				
				
    			public const Int32 Never = 43581440;
				
				
				
    			public const Int32 Always = 43581441;
				
				
				
    			public const Int32 Load_Entries_Only = 43581442;
		}
		public sealed class WAP_Period
		{
				
				
				private WAP_Period()
    			{
    			}

				public const Int32 DefaultValue = 2032271361; 
				
				
				
    			public const Int32 Day = 2032271360;
				
				
				
    			public const Int32 Month = 2032271361;
		}
		public sealed class WAP_Transfer_Between_Storages
		{
				
				
				private WAP_Transfer_Between_Storages()
    			{
    			}

				public const Int32 DefaultValue = 2032336896; 
				
				
				
    			public const Int32 Ignore = 2032336896;
				
				
				
    			public const Int32 WAP_Previous_Period = 2032336897;
				
				
				
    			public const Int32 In_WAP_Calculation = 2032336898;
		}
		public sealed class WAP_Filter_Period
		{
				
				
				private WAP_Filter_Period()
    			{
    			}

				public const Int32 DefaultValue = 2032402432; 
				
				
				
    			public const Int32 Last_12 = 2032402432;
				
				
				
    			public const Int32 Last_36 = 2032402433;
				
				
				
    			public const Int32 Current_Fiscal_Year = 2032402434;
				
				
				
    			public const Int32 Period_selection = 2032402435;
		}
		public sealed class WAP_Movement_Type
		{
				
				
				private WAP_Movement_Type()
    			{
    			}

				public const Int32 DefaultValue = 2032533504; 
				
				
				
    			public const Int32 Nothing = 2032533504;
				
				
				
    			public const Int32 Load = 2032533505;
				
				
				
    			public const Int32 Unload = 2032533506;
				
				
				
    			public const Int32 Storage_Transfer = 2032533507;
				
				
				
    			public const Int32 WAP_Nothing = 2032533508;
				
				
				
    			public const Int32 Return_from_Customer = 2032533509;
				
				
				
    			public const Int32 Negative_Receipt_Adjustment = 2032533510;
		}
		public sealed class Line_Type
		{
				
				
				private Line_Type()
    			{
    			}

				public const Int32 DefaultValue = 3538947; 
				
				
				
    			public const Int32 Notes = 3538944;
				
				
				
    			public const Int32 Reference = 3538945;
				
				
				
    			public const Int32 Service = 3538946;
				
				
				
    			public const Int32 Goods = 3538947;
				
				
				
    			public const Int32 Descriptive = 3538948;
		}
		public sealed class Sale_Type
		{
				
				
				private Sale_Type()
    			{
    			}

				public const Int32 DefaultValue = 3670020; 
				
				
				
    			public const Int32 Total_Free_Sample = 3670016;
				
				
				[DenyISO("BR")]
    			public const Int32 Taxable_Free_Sample = 3670017;
				
				
				
    			public const Int32 Promotion = 3670018;
				
				
				
    			public const Int32 Discount_on_Goods = 3670019;
				
				
				
    			public const Int32 Normal = 3670020;
		}
		public sealed class Reference_Document_Type
		{
				
				
				private Reference_Document_Type()
    			{
    			}

				public const Int32 DefaultValue = 6684681; 
				
				
				
    			public const Int32 Picking_List = 6684672;
				
				
				
    			public const Int32 Sale_Order = 6684673;
				
				
				
    			public const Int32 NonMinusCollected_Receipt = 6684674;
				
				
				
    			public const Int32 Customer_Quotation = 6684675;
				
				
				
    			public const Int32 Inventory_Entry = 6684676;
				
				
				
    			public const Int32 Invoice = 6684677;
				
				
				[DenyISO("RO,PL,CN,JP")]
    			public const Int32 Credit_Note = 6684678;
				
				
				
    			public const Int32 Accompanying_Invoice = 6684679;
				
				
				
    			public const Int32 Receipt = 6684680;
				
				
				
    			public const Int32 Delivery_Note = 6684681;
				
				
				
    			public const Int32 Purchase_Requisition = 6684682;
				
				
				
    			public const Int32 Shop_Ticket = 6684683;
				
				
				
    			public const Int32 Bill_of_Lading = 6684684;
				
				
				
    			public const Int32 Invoice_Purchase = 6684685;
				
				
				[DenyISO("RO,PL,CN,JP")]
    			public const Int32 Credit_Note_Purchase = 6684686;
				
				
				
    			public const Int32 Purchase_Order = 6684687;
				
				
				
    			public const Int32 Supplier_Quotation = 6684688;
				
				
				
    			public const Int32 Quota_Request = 6684689;
				
				
				
    			public const Int32 Test_Order = 6684690;
				
				
				
    			public const Int32 Test_Bill = 6684691;
				
				
				
    			public const Int32 Additional_Charges = 6684693;
				
				
				
    			public const Int32 Subcontractor_Delivery_Note = 6684694;
				
				
				
    			public const Int32 Manufacturing_Order = 6684695;
				
				
				
    			public const Int32 Accounting_Document = 6684696;
				
				
				
    			public const Int32 Scrap_Inventory_Entry = 6684697;
				
				
				
    			public const Int32 Goods_to_be_Returned_Inventory_Entry = 6684698;
				
				
				
    			public const Int32 Receivable = 6684699;
				
				
				
    			public const Int32 Payable = 6684700;
				
				[AllowISO("HU,RO,PL,CN,JP")]
				
    			public const Int32 Correction_Invoice = 6684701;
				
				[AllowISO("HU,RO,PL,CN,JP")]
				
    			public const Int32 Correction_Receipt = 6684702;
				
				
				
    			public const Int32 Return_from_Customer = 6684703;
				
				[AllowISO("HU,RO,PL,CN,JP")]
				
    			public const Int32 Correction_Accompanying_Invoice = 6684704;
				
				[AllowISO("HU,RO,PL,CN,JP")]
				
    			public const Int32 Correction_Purchase_Invoice = 6684705;
				
				
				
    			public const Int32 Return_to_Supplier = 6684706;
				
				
				
    			public const Int32 Invoice_for_Advance = 6684707;
				
				[AllowISO("PL")]
				
    			public const Int32 Paragon = 6684708;
				
				[AllowISO("PL")]
				
    			public const Int32 Correction_Paragon = 6684709;
				
				
				
    			public const Int32 ProForma_Invoice = 6684710;
				
				
				
    			public const Int32 Subcontractor_Bills_of_Lading = 6684711;
				
				
				
    			public const Int32 Invoice_Purchase_for_Advance = 6684712;
				
				[AllowISO("IT,BG")]
				
    			public const Int32 Debit_Note = 6684713;
				
				[AllowISO("IT,BG")]
				
    			public const Int32 Debit_Note_Purchase = 6684714;
				
				
				
    			public const Int32 Interstorage_movement_Document = 6684715;
				
				
				
    			public const Int32 Inspection_Order = 6684716;
				
				
				
    			public const Int32 Inspection_Notes = 6684717;
				
				
				
    			public const Int32 Receipt_for_Interstorage_Movement = 6684718;
				
				
				
    			public const Int32 Purchase_Request = 6684722;
				
				
				
    			public const Int32 Purchase_Cancellation_Invoice = 6684723;
				
				
				
    			public const Int32 Sale_Cancellation_Invoice = 6684724;
				
				
				
    			public const Int32 SelfInvoice = 6684726;
				
				
				
    			public const Int32 SelfCredit_Note = 6684727;
		}
		public sealed class Document_Type_to_be_customized
		{
				
				
				private Document_Type_to_be_customized()
    			{
    			}

				public const Int32 DefaultValue = 9699328; 
				
				
				
    			public const Int32 Delivery_Note = 9699328;
				
				
				
    			public const Int32 Invoice_Sale = 9699329;
				
				
				
    			public const Int32 Accompanying_Invoice = 9699330;
				
				
				
    			public const Int32 Credit_Note = 9699331;
				
				
				
    			public const Int32 Receipt = 9699332;
				
				
				
    			public const Int32 NonMinuscollected_Receipt = 9699333;
				
				
				
    			public const Int32 Bill_of_Lading = 9699334;
				
				
				
    			public const Int32 Invoice_Purchase = 9699335;
				
				
				
    			public const Int32 Credit_Note_Purchase = 9699336;
				
				
				
    			public const Int32 Sale_Order = 9699337;
				
				
				
    			public const Int32 Purchase_Order = 9699338;
				
				
				
    			public const Int32 Customer_Quotation_ = 9699339;
				
				
				
    			public const Int32 Supplier_Quotation_ = 9699340;
				
				
				
    			public const Int32 Manufacturing_Order = 9699341;
				
				
				
    			public const Int32 Return_to_Supplier = 9699342;
				
				
				
    			public const Int32 Inventory_Entry = 9699343;
				
				
				
    			public const Int32 Generic_Document = 9699344;
				
				
				
    			public const Int32 Picking_List = 9699345;
				
				
				
    			public const Int32 Return_from_Customer = 9699346;
				
				
				
    			public const Int32 Subcontractor_Delivery_Note = 9699347;
				
				
				
    			public const Int32 Sale_Correction_Invoice = 9699348;
				
				
				
    			public const Int32 Invoice_for_Advance = 9699349;
				
				
				
    			public const Int32 Correction_Accompanying_Invoice = 9699350;
				
				
				
    			public const Int32 Correction_Receipt = 9699351;
				
				
				
    			public const Int32 Paragon = 9699352;
				
				
				
    			public const Int32 Correction_Paragon = 9699353;
				
				
				
    			public const Int32 Correction_Invoice_Purchase = 9699354;
				
				
				
    			public const Int32 Subcontractor_Bill_Of_Lading = 9699355;
				
				
				
    			public const Int32 ProForma_Invoice = 9699356;
				
				
				
    			public const Int32 Invoice_Purchase_for_Advance = 9699357;
				
				
				
    			public const Int32 Debit_Note = 9699358;
				
				
				
    			public const Int32 Debit_Note_Purchase = 9699359;
				
				
				
    			public const Int32 InterStorage_movement_Document = 9699360;
				
				
				
    			public const Int32 Inspection_Order = 9699361;
				
				
				
    			public const Int32 Inspection_Notes = 9699362;
				
				
				
    			public const Int32 Production_Plan = 9699363;
				
				
				
    			public const Int32 PreShipping = 9699364;
				
				
				
    			public const Int32 GoodsReceipt = 9699365;
				
				
				
    			public const Int32 AdditionalCharges = 9699366;
				
				
				
    			public const Int32 PurchaseRequest = 9699371;
				
				
				
    			public const Int32 Purchase_Cancellation_Invoice = 9699372;
				
				
				
    			public const Int32 Sale_Cancellation_Invoice = 9699373;
				
				
				
    			public const Int32 SelfInvoice = 9699375;
				
				
				
    			public const Int32 SelfCredit_Note = 9699376;
		}
		public sealed class Document_Status_Control_Type
		{
				
				
				private Document_Status_Control_Type()
    			{
    			}

				public const Int32 DefaultValue = 10682368; 
				
				
				
    			public const Int32 Ignore = 10682368;
				
				
				
    			public const Int32 Notify = 10682369;
				
				
				
    			public const Int32 Block = 10682370;
		}
		public sealed class Calculate_Installments_from
		{
				
				
				private Calculate_Installments_from()
    			{
    			}

				public const Int32 DefaultValue = 7602177; 
				
				
				
    			public const Int32 Order_Date = 7602176;
				
				
				
    			public const Int32 Invoice_Date = 7602177;
		}
		public sealed class Generic_control_type
		{
				
				
				private Generic_control_type()
    			{
    			}

				public const Int32 DefaultValue = 11599872; 
				
				
				
    			public const Int32 Ignore = 11599872;
				
				
				
    			public const Int32 Notify = 11599873;
				
				
				
    			public const Int32 Block = 11599874;
		}
		public sealed class Statistical_Charges_Free_Border_Calculation
		{
				
				
				private Statistical_Charges_Free_Border_Calculation()
    			{
    			}

				public const Int32 DefaultValue = 25886720; 
				
				
				
    			public const Int32 Taxable_Amount = 25886720;
				
				
				
    			public const Int32 Net_Weight = 25886721;
				
				
				
    			public const Int32 Gross_Weight = 25886722;
				
				
				
    			public const Int32 Gross_Volume = 25886723;
		}
		public sealed class Purchase_Price_To_Propose
		{
				
				
				private Purchase_Price_To_Propose()
    			{
    			}

				public const Int32 DefaultValue = 29491200; 
				
				
				
    			public const Int32 Do_not_propose = 29491200;
				
				
				
    			public const Int32 Last_Cost = 29491201;
				
				
				
    			public const Int32 Weighted_Average = 29491202;
		}
		public sealed class From_external_program
		{
				
				
				private From_external_program()
    			{
    			}

				public const Int32 DefaultValue = 32505856; 
				
				
				
    			public const Int32 Blank = 32505856;
				
				
				
    			public const Int32 Attempted_Sale = 32505857;
				
				
				
    			public const Int32 Sales_Force_Automation = 32505858;
				
				
				
    			public const Int32 Other = 32505859;
				
				
				
    			public const Int32 CRM_Infinity = 32505860;
				
				
				
    			public const Int32 EMinuscommerce = 32505861;
				
				
				
    			public const Int32 CRM = 32505862;
				
				
				
    			public const Int32 TCPOS = 32505863;
				
				
				
    			public const Int32 ePos = 32505864;
				
				
				
    			public const Int32 InStore_App = 32505865;
				
				
				
    			public const Int32 Digital_Hub = 32505866;
				
				
				
    			public const Int32 Open_eCommerce = 32505867;
				
				
				
    			public const Int32 Open_Pos = 32505868;
				
				
				
    			public const Int32 Mago_API = 32505869;
				
				
				
    			public const Int32 Tilby = 32505870;
				
				
				
    			public const Int32 StocknMove_App = 32505871;
				
				
				
    			public const Int32 Open_WMS = 32505872;
				
				
				
    			public const Int32 OmniPOS = 32505873;
				
				
				
    			public const Int32 Open_MES = 32505874;
				
				
				
    			public const Int32 DH_Data_Exchange = 32505875;
		}
		public sealed class Proposed_Value
		{
				
				
				private Proposed_Value()
    			{
    			}

				public const Int32 DefaultValue = 3932160; 
				
				
				
    			public const Int32 Application_Default = 3932160;
				
				
				
    			public const Int32 Last_Cost = 3932161;
				
				
				
    			public const Int32 Average_Sale_Price = 3932163;
				
				
				
    			public const Int32 Average_Purchase_Price = 3932164;
				
				
				
    			public const Int32 Standard_Cost = 3932165;
				
				
				
    			public const Int32 Policy_Sale_Price_ = 3932166;
				
				
				
    			public const Int32 Policy_Purchase_Price_ = 3932167;
		}
		public sealed class Product_Type
		{
				
				
				private Product_Type()
    			{
    			}

				public const Int32 DefaultValue = 7077888; 
				
				
				
    			public const Int32 General = 7077888;
		}
		public sealed class Stub_Book_Type
		{
				
				
				private Stub_Book_Type()
    			{
    			}

				public const Int32 DefaultValue = 9961472; 
				
				
				
    			public const Int32 Sales = 9961472;
				
				
				
    			public const Int32 Purchases = 9961473;
				
				
				
    			public const Int32 Other = 9961474;
		}
		public sealed class Item_Kind
		{
				
				
				private Item_Kind()
    			{
    			}

				public const Int32 DefaultValue = 22413314; 
				
				
				
    			public const Int32 Semifinished = 22413312;
				
				
				
    			public const Int32 Finished_Product = 22413313;
				
				
				
    			public const Int32 Purchase = 22413314;
		}
		public sealed class Lead_Time_Type
		{
				
				
				private Lead_Time_Type()
    			{
    			}

				public const Int32 DefaultValue = 22544384; 
				
				
				
    			public const Int32 Total = 22544384;
				
				
				
    			public const Int32 Multiple = 22544385;
				
				
				
    			public const Int32 Proportional = 22544386;
		}
		public sealed class Loading_Criterion_Valuation
		{
				
				
				private Loading_Criterion_Valuation()
    			{
    			}

				public const Int32 DefaultValue = 20643840; 
				
				
				
    			public const Int32 Production_Actual_Cost = 20643840;
				
				
				
    			public const Int32 Standard = 20643841;
		}
		public sealed class Item_post_to_inspection
		{
				
				
				private Item_post_to_inspection()
    			{
    			}

				public const Int32 DefaultValue = 20709376; 
				
				
				
    			public const Int32 Set_in_Item_Master = 20709376;
				
				
				
    			public const Int32 Yes = 20709377;
				
				
				
    			public const Int32 No = 20709378;
		}
		public sealed class Comparable_UoM_CoeffDot
		{
				
				
				private Comparable_UoM_CoeffDot()
    			{
    			}

				public const Int32 DefaultValue = 11665408; 
				
				
				
    			public const Int32 None = 11665408;
				
				
				
    			public const Int32 One = 11665409;
				
				
				
    			public const Int32 Two = 11665410;
				
				
				
    			public const Int32 Three = 11665411;
				
				
				
    			public const Int32 Four = 11665412;
		}
		public sealed class Use_Supplier_Lot_as_New_Lot_Number
		{
				
				
				private Use_Supplier_Lot_as_New_Lot_Number()
    			{
    			}

				public const Int32 DefaultValue = 28311552; 
				
				
				
    			public const Int32 Standard = 28311552;
				
				
				
    			public const Int32 Yes = 28311553;
				
				
				
    			public const Int32 No = 28311554;
		}
		public sealed class Perishables_Type
		{
				
				
				private Perishables_Type()
    			{
    			}

				public const Int32 DefaultValue = 28966914; 
				
				
				
    			public const Int32 Perishables_Within_60_Days = 28966912;
				
				
				
    			public const Int32 Perishables_Over_60_Days = 28966913;
				
				
				
    			public const Int32 Other = 28966914;
		}
		public sealed class Attributes_Type
		{
				
				
				private Attributes_Type()
    			{
    			}

				public const Int32 DefaultValue = 2046296064; 
				
				
				
    			public const Int32 Custom = 2046296064;
				
				
				
    			public const Int32 Allergens = 2046296065;
				
				
				
    			public const Int32 Properties = 2046296066;
				
				
				
    			public const Int32 Nutritional_Values = 2046296067;
		}
		public sealed class Custom_Attributes_Field_Type
		{
				
				
				private Custom_Attributes_Field_Type()
    			{
    			}

				public const Int32 DefaultValue = 2046230528; 
				
				
				
    			public const Int32 Text = 2046230528;
				
				
				
    			public const Int32 Integer = 2046230529;
				
				
				
    			public const Int32 Quantity = 2046230530;
				
				
				
    			public const Int32 Date = 2046230531;
				
				
				
    			public const Int32 YesSlashNo = 2046230532;
		}
		public sealed class Job_Type
		{
				
				
				private Job_Type()
    			{
    			}

				public const Int32 DefaultValue = 25034752; 
				
				
				
    			public const Int32 Standard = 25034752;
				
				
				
    			public const Int32 On_a_Time_and_Material_Basis = 25034753;
				
				
				
    			public const Int32 Variant = 25034754;
		}
		public sealed class Lot_Status
		{
				
				
				private Lot_Status()
    			{
    			}

				public const Int32 DefaultValue = 8388608; 
				
				
				
    			public const Int32 To_be_Analyzed = 8388608;
				
				
				
    			public const Int32 Analyzed = 8388609;
				
				
				
    			public const Int32 Incoming = 8388610;
				
				
				
    			public const Int32 Checked = 8388611;
				
				
				
    			public const Int32 Conforming = 8388612;
				
				
				
    			public const Int32 Accepted_with_reserve = 8388613;
				
				
				
    			public const Int32 Not_Conforming = 8388614;
		}
		public sealed class Lot_Selection
		{
				
				
				private Lot_Selection()
    			{
    			}

				public const Int32 DefaultValue = 8454144; 
				
				
				
    			public const Int32 From_Multiple_Lots = 8454144;
				
				
				
    			public const Int32 From_the_same_Lot = 8454145;
				
				
				
    			public const Int32 Manual = 8454146;
				
				
				
    			public const Int32 Standard = 8454147;
		}
		public sealed class Sales_Order_Lot_Fulfil
		{
				
				
				private Sales_Order_Lot_Fulfil()
    			{
    			}

				public const Int32 DefaultValue = 2031747072; 
				
				
				
    			public const Int32 Maintain_Lot_set_on_Sales_Order = 2031747072;
				
				
				
    			public const Int32 Reassign_Lot_according_to_Availability = 2031747073;
		}
		public sealed class Production_progress
		{
				
				
				private Production_progress()
    			{
    			}

				public const Int32 DefaultValue = 20578308; 
				
				
				
    			public const Int32 Released = 20578304;
				
				
				
    			public const Int32 Processing = 20578305;
				
				
				
    			public const Int32 Confirmed = 20578306;
				
				
				
    			public const Int32 Created = 20578307;
				
				
				
    			public const Int32 Proposed_by_MRP = 20578308;
				
				
				
    			public const Int32 Planned_by_CRP = 20578309;
				
				
				
    			public const Int32 Proposed_by_MRPMinusCRP = 20578310;
		}
		public sealed class Job_Ticket_type
		{
				
				
				private Job_Ticket_type()
    			{
    			}

				public const Int32 DefaultValue = 22937600; 
				
				
				
    			public const Int32 By_center_or_machine = 22937600;
				
				
				
    			public const Int32 By_manufacturing_order = 22937602;
		}
		public sealed class Criticality_grade
		{
				
				
				private Criticality_grade()
    			{
    			}

				public const Int32 DefaultValue = 23396353; 
				
				
				
    			public const Int32 Dispatched_from_inventory = 23396352;
				
				
				
    			public const Int32 Feasible = 23396353;
				
				
				
    			public const Int32 Feasible_with_criticality = 23396354;
				
				
				
    			public const Int32 Not_feasible = 23396355;
				
				
				
    			public const Int32 Critical = 23396356;
				
				
				
    			public const Int32 To_bring_forward = 23396357;
				
				
				
    			public const Int32 To_delay = 23396358;
				
				
				
    			public const Int32 To_Cancel = 23396359;
				
				
				
    			public const Int32 Data_error = 23396360;
		}
		public sealed class Confirmed_item_type
		{
				
				
				private Confirmed_item_type()
    			{
    			}

				public const Int32 DefaultValue = 24641536; 
				
				
				
    			public const Int32 Product = 24641536;
				
				
				
    			public const Int32 Second_rate = 24641537;
				
				
				
    			public const Int32 Scrap = 24641538;
				
				
				
    			public const Int32 Returned_Material = 24641539;
				
				
				
    			public const Int32 Waste = 24641540;
				
				
				
    			public const Int32 Component = 24641541;
		}
		public sealed class Step_processing_type
		{
				
				
				private Step_processing_type()
    			{
    			}

				public const Int32 DefaultValue = 24707072; 
				
				
				
    			public const Int32 Normal = 24707072;
				
				
				
    			public const Int32 Not_executed = 24707073;
				
				
				
    			public const Int32 Close_the_order = 24707074;
		}
		public sealed class Print_document
		{
				
				
				private Print_document()
    			{
    			}

				public const Int32 DefaultValue = 25427968; 
				
				
				
    			public const Int32 Manufacturing_order = 25427968;
				
				
				
    			public const Int32 Job_Ticket = 25427969;
				
				
				
    			public const Int32 Picking_list = 25427970;
				
				
				
    			public const Int32 Purchase_order_for_Outsourced_processing = 25427971;
				
				
				
    			public const Int32 DN_for_Outsourced_processing = 25427972;
				
				
				
    			public const Int32 Preprinted_document_for_Outsourced_processing = 25427973;
		}
		public sealed class Lot_genration_moment
		{
				
				
				private Lot_genration_moment()
    			{
    			}

				public const Int32 DefaultValue = 25821186; 
				
				
				
    			public const Int32 Never = 25821184;
				
				
				
    			public const Int32 Manufacturing_order = 25821185;
				
				
				
    			public const Int32 Production_run = 25821186;
				
				
				
    			public const Int32 MO_Confirmation = 25821187;
		}
		public sealed class Average_Consumpions
		{
				
				
				private Average_Consumpions()
    			{
    			}

				public const Int32 DefaultValue = 26083328; 
				
				
				
    			public const Int32 Monthly_Ordered = 26083328;
				
				
				
    			public const Int32 Monthly_Sold = 26083329;
				
				
				
    			public const Int32 Monthly_Consumed = 26083330;
				
				
				
    			public const Int32 Yearly_Ordered = 26083331;
				
				
				
    			public const Int32 Yearly_Sold = 26083332;
				
				
				
    			public const Int32 Yearly_Consumed = 26083333;
		}
		public sealed class Labour_phase
		{
				
				
				private Labour_phase()
    			{
    			}

				public const Int32 DefaultValue = 28573696; 
				
				
				
    			public const Int32 Estimated = 28573696;
				
				
				
    			public const Int32 Actual = 28573697;
		}
		public sealed class Manufacturing_Entry_Type
		{
				
				
				private Manufacturing_Entry_Type()
    			{
    			}

				public const Int32 DefaultValue = 27525120; 
				
				
				
    			public const Int32 Undefined = 27525120;
				
				
				
    			public const Int32 Raw_Materials_Picking = 27525121;
				
				
				
    			public const Int32 Raw_Materials_Reservation = 27525122;
				
				
				
    			public const Int32 Finished_Product_Load = 27525123;
				
				
				
    			public const Int32 Raw_Materials_Unload = 27525124;
				
				
				
    			public const Int32 Processing_From_InMinusHouse_Step = 27525125;
				
				
				
    			public const Int32 Processing_From_Outsourced_Step = 27525126;
				
				
				
    			public const Int32 Subcontractor_Delivery_Note = 27525127;
				
				
				
    			public const Int32 Subcontractor_Order = 27525128;
				
				
				
    			public const Int32 Second_Rate_Load = 27525129;
				
				
				
    			public const Int32 Scrap_Load = 27525130;
				
				
				
    			public const Int32 Returned_Tools = 27525131;
				
				
				
    			public const Int32 Subcontractor_Bill_of_Lading = 27525132;
				
				
				
    			public const Int32 Returned_Raw_Materials = 27525133;
				
				
				
    			public const Int32 BOM_Posting_Finished_Product_Load = 27525134;
				
				
				
    			public const Int32 BOM_Posting_Raw_Materials_Unload = 27525135;
				
				
				
    			public const Int32 Standard_Cost_Semifinished_Picking = 27525136;
				
				
				
    			public const Int32 Standard_Cost_Finished_Product_Load_Adjustment = 27525137;
				
				
				
    			public const Int32 BOM_Posting_Scrap_Load = 27525138;
				
				
				
    			public const Int32 BOM_Posting_Second_Rate_Load = 27525139;
				
				
				
    			public const Int32 Raw_Materials_Picking_Cancellation = 27525140;
				
				
				
    			public const Int32 BOM_Run_Raw_Materials_Unload = 27525141;
				
				
				
    			public const Int32 BOM_Run_Finished_Product_Load = 27525142;
				
				
				
    			public const Int32 BOM_Confirmation_Raw_Materials_Unload = 27525143;
				
				
				
    			public const Int32 BOM_Confirmation_Finished_Product_Load = 27525144;
				
				
				
    			public const Int32 Waste_Load = 27525145;
				
				
				
    			public const Int32 Different_Item_Waste_Load = 27525146;
				
				
				
    			public const Int32 Issue_on_Sales_Documents_Run_Raw_Materials_Unload = 27525147;
				
				
				
    			public const Int32 Issue_on_Sales_Documents_Run_Finished_Product_Load = 27525148;
				
				
				
    			public const Int32 Issue_on_Sales_Documents_Confirmation_Raw_Materials_Unload = 27525149;
				
				
				
    			public const Int32 Issue_on_Sales_Documents_Confirmation_Finished_Product_Load = 27525150;
				
				
				
    			public const Int32 Not_Conforming_Finished_Product_Load = 27525151;
				
				
				
    			public const Int32 Raw_Materials_Unload_Positive_Adjustment = 27525152;
				
				
				
    			public const Int32 Raw_Materials_Unload_Negative_Adjustment = 27525153;
				
				
				
    			public const Int32 Shop_Floor_Storage_Initial_Qty_Adjustment = 27525154;
				
				
				
    			public const Int32 Shop_Floor_Storage_OnMinusHand_Qty_Adjustment = 27525155;
				[Activation("Retail.TCPOS")]
				
				
    			public const Int32 Issue_on_Retail_Sales_Documents_Confirmation_Raw_Materials_Unload = 27525156;
				[Activation("Retail.TCPOS")]
				
				
    			public const Int32 Issue_on_Retail_Sales_Documents_Confirmation_Finished_Product_Load = 27525157;
				[Activation("Retail.TCPOS")]
				
				
    			public const Int32 Issue_on_Retail_Sales_Documents_Waste_Load = 27525158;
				[Activation("Retail.TCPOS")]
				
				
    			public const Int32 Issue_on_Retail_Sales_Documents_Different_Item_Waste_Load = 27525159;
				
				
				
    			public const Int32 Toll_Manufacturing_Raw_Materials_Receipt = 27525160;
				
				
				
    			public const Int32 Toll_Manufacturing_Finished_Product_Delivery_Note = 27525161;
		}
		public sealed class OM_Material_Picking
		{
				
				
				private OM_Material_Picking()
    			{
    			}

				public const Int32 DefaultValue = 7340033; 
				
				
				
    			public const Int32 Data_Collection = 7340032;
				
				
				
    			public const Int32 MO_Confirmation = 7340033;
				
				
				
    			public const Int32 Block = 7340034;
		}
		public sealed class InStore_Inventory_Entries_Type
		{
				
				
				private InStore_Inventory_Entries_Type()
    			{
    			}

				public const Int32 DefaultValue = 10878976; 
				
				
				
    			public const Int32 Storage_Transfer = 10878976;
				
				
				
    			public const Int32 By_Inventory_Reasons = 10878977;
		}
		public sealed class InStore_Inventory_Status
		{
				
				
				private InStore_Inventory_Status()
    			{
    			}

				public const Int32 DefaultValue = 2046427136; 
				
				
				
    			public const Int32 None = 2046427136;
				
				
				
    			public const Int32 Created = 2046427137;
				
				
				
    			public const Int32 To_Be_Sent = 2046427138;
				
				
				
    			public const Int32 Sent = 2046427139;
				
				
				
    			public const Int32 To_Be_Inventoried = 2046427140;
				
				
				
    			public const Int32 Downloaded_By_Mobile = 2046427141;
				
				
				
    			public const Int32 To_Be_Processed = 2046427142;
				
				
				
    			public const Int32 In_Processing = 2046427143;
				
				
				
    			public const Int32 Processed = 2046427144;
		}
		public sealed class Use_Variant_Matrix
		{
				
				
				private Use_Variant_Matrix()
    			{
    			}

				public const Int32 DefaultValue = 2048524288; 
				
				
				
    			public const Int32 Optional = 2048524288;
				
				
				
    			public const Int32 Never = 2048524289;
				
				
				
    			public const Int32 Always = 2048524290;
		}
		public sealed class MRP_Event_Type
		{
				
				
				private MRP_Event_Type()
    			{
    			}

				public const Int32 DefaultValue = 22085636; 
				
				
				
    			public const Int32 Initial_Book_Inv = 22085632;
				
				
				
    			public const Int32 Deposit_from_manufacturing = 22085633;
				
				
				
    			public const Int32 Deposit_from_purchase = 22085634;
				
				
				
    			public const Int32 Deposit_from_Purchase_Request = 22085635;
				
				
				
    			public const Int32 Picking_on_MO = 22085636;
				
				
				
    			public const Int32 Picking_for_subcontracting = 22085637;
				
				
				
    			public const Int32 Sale_Forecasts = 22085638;
				
				
				
    			public const Int32 Sale = 22085640;
				
				
				
    			public const Int32 Manufacturing_schedule_line_number = 22085641;
				
				
				
    			public const Int32 Deposit_from_Reminder_to_the_Customer = 22085642;
		}
		public sealed class MRP_valuation_type
		{
				
				
				private MRP_valuation_type()
    			{
    			}

				public const Int32 DefaultValue = 22347776; 
				
				
				
    			public const Int32 Standard_cost = 22347776;
				
				
				
    			public const Int32 Last_cost = 22347777;
				
				
				
    			public const Int32 Second_last_cost = 22347778;
				
				
				
    			public const Int32 None = 22347779;
		}
		public sealed class MRP_alert_doc_type
		{
				
				
				private MRP_alert_doc_type()
    			{
    			}

				public const Int32 DefaultValue = 23461888; 
				
				
				
    			public const Int32 Customer_order = 23461888;
				
				
				
    			public const Int32 Purchase_order = 23461889;
				
				
				
    			public const Int32 Proposed_manufacturing_order = 23461890;
				
				
				
    			public const Int32 Manufacturing_order = 23461891;
				
				
				
    			public const Int32 Purchase_request = 23461893;
				
				
				
    			public const Int32 Data_error = 23461894;
				
				
				
    			public const Int32 Initial_Book_Inv = 23461895;
				
				
				
    			public const Int32 Sale_Forecast = 23461896;
				
				
				
    			public const Int32 Manufacturing_schedule_line_number = 23461897;
				
				
				
    			public const Int32 Induced_requirement = 23461898;
				
				
				
    			public const Int32 Proposed_purchase_request = 23461899;
				
				
				
    			public const Int32 Proposed_Reminders_to_the_Customer = 23461900;
		}
		public sealed class Simulation_status
		{
				
				
				private Simulation_status()
    			{
    			}

				public const Int32 DefaultValue = 23658496; 
				
				
				
    			public const Int32 New = 23658496;
				
				
				
    			public const Int32 Infinite_capacity = 23658499;
				
				
				
    			public const Int32 MRP = 23658500;
				
				
				
    			public const Int32 All = 23658501;
				
				
				
    			public const Int32 MRP_and_CRP = 23658502;
		}
		public sealed class Manufacturing_status_selection
		{
				
				
				private Manufacturing_status_selection()
    			{
    			}

				public const Int32 DefaultValue = 22675456; 
				
				
				
    			public const Int32 All = 22675456;
				
				
				
    			public const Int32 Created_only = 22675457;
				
				
				
    			public const Int32 Released_only = 22675458;
				
				
				
    			public const Int32 In_progress_only = 22675459;
				
				
				
    			public const Int32 All_except_in_progress = 22675460;
				
				
				
    			public const Int32 Proposed_by_MRP_only = 22675461;
		}
		public sealed class Product_selection
		{
				
				
				private Product_selection()
    			{
    			}

				public const Int32 DefaultValue = 22740992; 
				
				
				
    			public const Int32 All = 22740992;
				
				
				
    			public const Int32 Semifinished_only = 22740993;
				
				
				
    			public const Int32 Finished_product_only = 22740994;
		}
		public sealed class Lead_time_origin
		{
				
				
				private Lead_time_origin()
    			{
    			}

				public const Int32 DefaultValue = 23330817; 
				
				
				
    			public const Int32 Master_Data = 23330816;
				
				
				
    			public const Int32 Routing_or_supplier = 23330817;
		}
		public sealed class Horizon_type
		{
				
				
				private Horizon_type()
    			{
    			}

				public const Int32 DefaultValue = 22806528; 
				
				
				
    			public const Int32 Months = 22806528;
				
				
				
    			public const Int32 Weeks = 22806529;
				
				
				
    			public const Int32 Until = 22806530;
		}
		public sealed class Customer_Forecast_Ratio
		{
				
				
				private Customer_Forecast_Ratio()
    			{
    			}

				public const Int32 DefaultValue = 22872064; 
				
				
				
    			public const Int32 Sum_of_both = 22872064;
				
				
				
    			public const Int32 Biggest_one = 22872065;
		}
		public sealed class Make_or_Buy_Type
		{
				
				
				private Make_or_Buy_Type()
    			{
    			}

				public const Int32 DefaultValue = 2032140288; 
				
				
				
    			public const Int32 Make = 2032140288;
				
				
				
    			public const Int32 Buy = 2032140289;
		}
		public sealed class Storage_Type
		{
				
				
				private Storage_Type()
    			{
    			}

				public const Int32 DefaultValue = 3342336; 
				
				
				
    			public const Int32 Company = 3342336;
				
				
				
    			public const Int32 Dummy = 3342337;
				
				
				
    			public const Int32 OutMinusSubcontracting = 3342338;
				
				
				
    			public const Int32 Subcontracting = 3342339;
		}
		public sealed class Specificator_Type
		{
				
				
				private Specificator_Type()
    			{
    			}

				public const Int32 DefaultValue = 6750211; 
				
				
				
    			public const Int32 Customer = 6750208;
				
				
				
    			public const Int32 Supplier = 6750209;
				
				
				
    			public const Int32 More = 6750210;
				
				
				
    			public const Int32 None = 6750211;
				
				
				
    			public const Int32 Ignore = 6750212;
		}
		public sealed class Open_Orders_Period_Type
		{
				
				
				private Open_Orders_Period_Type()
    			{
    			}

				public const Int32 DefaultValue = 25624576; 
				
				
				
    			public const Int32 Weekly = 25624576;
				
				
				
    			public const Int32 Monthly = 25624577;
		}
		public sealed class Duty_Type
		{
				
				
				private Duty_Type()
    			{
    			}

				public const Int32 DefaultValue = 10616832; 
				
				
				
    			public const Int32 Internal_Revenue = 10616832;
				
				
				
    			public const Int32 RegionsComma_IMU_and_other_local_duties = 10616833;
				[Activation("ERP.INPS")]
				
				
    			public const Int32 INPS_ = 10616834;
				
				
				
    			public const Int32 Other_Government_bodies = 10616835;
		}
		public sealed class Installment_Type
		{
				
				
				private Installment_Type()
    			{
    			}

				public const Int32 DefaultValue = 2686977; 
				
				
				
    			public const Int32 Cash = 2686976;
				
				
				
    			public const Int32 Direct_Payment = 2686977;
				
				
				[DenyISO("ES")]
    			public const Int32 Cash_on_Delivery = 2686978;
				
				
				[DenyISO("ES")]
    			public const Int32 Invoice_at_sight = 2686979;
				
				
				[DenyISO("PL,ES")]
    			public const Int32 Bill_of_Exchange = 2686980;
				
				
				[DenyISO("CH,PL,RO,RS,HR,BR")]
    			public const Int32 Cash_Order = 2686981;
				
				
				
    			public const Int32 Bank_Transfer = 2686982;
				
				
				
    			public const Int32 Check = 2686983;
				
				
				
    			public const Int32 Bank_Draft = 2686984;
				
				
				[DenyISO("BR,ES")]
    			public const Int32 Postal_Money_Order = 2686985;
				
				
				[DenyISO("BR,ES")]
    			public const Int32 National_Money_Order = 2686986;
				
				
				[DenyISO("BR,ES")]
    			public const Int32 International_Money_Order = 2686987;
				
				
				[DenyISO("CH,RO,RS,HR,BR,PL,DE")]
    			public const Int32 PaN = 2686988;
				
				
				[DenyISO("PL")]
    			public const Int32 SEPA_SDD_Core = 2686989;
				
				
				[DenyISO("ES")]
    			public const Int32 Foreign_Check = 2686990;
				
				
				[DenyISO("ES")]
    			public const Int32 Foreign_Bank_Transfer = 2686991;
				
				
				
    			public const Int32 Credit_Card = 2686992;
				
				
				[DenyISO("ES,DE")]
    			public const Int32 Bank_Slip = 2686993;
				
				
				[DenyISO("BR,ES,DE")]
    			public const Int32 Postal_Slip = 2686994;
				
				
				
    			public const Int32 Letter_of_Credit = 2686995;
				[Activation("ERP.AP_AR_Plus")]
				
				
    			public const Int32 Factoring = 2686996;
				
				[AllowISO("IT,ES,DE,CH,FR,GB,AT")]
				
    			public const Int32 SEPA_SDD_B2B = 2686997;
				[Activation("ERP.Retail")]
				
				
    			public const Int32 Bancomat = 2686998;
				[Activation("ERP.Retail")]
				
				
    			public const Int32 Ticket = 2686999;
				
				[AllowISO("BR")]
				
    			public const Int32 Carné = 2687000;
				
				[AllowISO("BR")]
				
    			public const Int32 Promissory_Note = 2687001;
				
				[AllowISO("BR")]
				
    			public const Int32 Duplicate = 2687002;
				
				[AllowISO("BR")]
				
    			public const Int32 Voucher = 2687003;
				
				[AllowISO("ES")]
				
    			public const Int32 Confirming = 2687004;
		}
		public sealed class Tax_Installment
		{
				
				
				private Tax_Installment()
    			{
    			}

				public const Int32 DefaultValue = 2752515; 
				
				
				
    			public const Int32 On_First_Installment = 2752512;
				
				
				
    			public const Int32 On_Last_Installment = 2752513;
				
				
				
    			public const Int32 Only_Tax = 2752514;
				
				
				
    			public const Int32 Among_Installments = 2752515;
		}
		public sealed class Fixed_Day_Round_Off
		{
				
				
				private Fixed_Day_Round_Off()
    			{
    			}

				public const Int32 DefaultValue = 2818050; 
				
				
				
    			public const Int32 Previous = 2818048;
				
				
				
    			public const Int32 Next = 2818049;
				
				
				
    			public const Int32 Mathematical = 2818050;
				
				
				
    			public const Int32 Equal_otherwise_next = 2818051;
		}
		public sealed class Due_Date_Type
		{
				
				
				private Due_Date_Type()
    			{
    			}

				public const Int32 DefaultValue = 2949121; 
				
				
				
    			public const Int32 Date_to_specify = 2949120;
				
				
				
    			public const Int32 Invoice_Date = 2949121;
				
				
				
    			public const Int32 End_of_Month = 2949122;
				
				
				
    			public const Int32 From_End_of_Month_Invoice_Date = 2949123;
				
				
				
    			public const Int32 From_end_of_next_month_of_invoice_date = 2949124;
				[Activation("ERP.MasterData_ES")]
				
				
    			public const Int32 Departure_Date = 2949125;
		}
		public sealed class Rounding_Type_for_Price_List_Recalculation
		{
				
				
				private Rounding_Type_for_Price_List_Recalculation()
    			{
    			}

				public const Int32 DefaultValue = 6553602; 
				
				
				
    			public const Int32 Upper = 6553600;
				
				
				
    			public const Int32 Lower = 6553601;
				
				
				
    			public const Int32 Mathematical = 6553602;
		}
		public sealed class Cost_Type_for_Price_List_Recalculation
		{
				
				
				private Cost_Type_for_Price_List_Recalculation()
    			{
    			}

				public const Int32 DefaultValue = 6619136; 
				
				
				
    			public const Int32 Last = 6619136;
				
				
				
    			public const Int32 Standard = 6619138;
				
				
				
    			public const Int32 Average = 6619139;
		}
		public sealed class Purchase_Unit_Value
		{
				
				
				private Purchase_Unit_Value()
    			{
    			}

				public const Int32 DefaultValue = 9437191; 
				
				
				
    			public const Int32 Last_of_Item_Supplier = 9437184;
				
				
				
    			public const Int32 Standard_of_Item_Supplier = 9437185;
				
				
				
    			public const Int32 Item_SupDot_Qty_Brackets = 9437186;
				
				
				
    			public const Int32 Last_Cost = 9437187;
				
				
				
    			public const Int32 Standard_Cost = 9437188;
				
				
				
    			public const Int32 Average_Purchase_Price = 9437190;
				
				
				
    			public const Int32 No_Default = 9437191;
				
				
				
    			public const Int32 Base_Price = 9437192;
		}
		public sealed class Purchase_Discount
		{
				
				
				private Purchase_Discount()
    			{
    			}

				public const Int32 DefaultValue = 9568263; 
				
				
				
    			public const Int32 Last_of_Item_Supplier = 9568256;
				
				
				
    			public const Int32 Last_of_CommDot_CatDot_Supplier = 9568257;
				
				
				
    			public const Int32 Standard_of_Item_Supplier = 9568258;
				
				
				
    			public const Int32 Item_SupDot_Qty_Brackets = 9568259;
				
				
				
    			public const Int32 Standard_of_Comm_CatDot_Supplier = 9568260;
				
				
				
    			public const Int32 Standard_of_Supplier = 9568261;
				
				
				
    			public const Int32 None = 9568262;
				
				
				
    			public const Int32 First_Valid = 9568263;
				
				
				
    			public const Int32 Item = 9568264;
				
				
				
    			public const Int32 Item_Type = 9568265;
				
				
				
    			public const Int32 Standard_of_CommDotCatDot_Supplier_CatDot = 9568266;
				
				
				
    			public const Int32 Supplier_Item_Type = 9568267;
		}
		public sealed class Sale_Unit_Value
		{
				
				
				private Sale_Unit_Value()
    			{
    			}

				public const Int32 DefaultValue = 9371660; 
				
				
				
    			public const Int32 Last_of_Item_Customer = 9371648;
				
				
				
    			public const Int32 Standard_of_Item_Customer = 9371649;
				
				
				
    			public const Int32 Item_CustDot_Qty_Brackets = 9371650;
				
				
				
    			public const Int32 List_Price = 9371651;
				
				
				
    			public const Int32 Base_Price = 9371652;
				
				
				
    			public const Int32 Last_Cost = 9371653;
				
				
				
    			public const Int32 Standard_Cost = 9371655;
				
				
				
    			public const Int32 Margin_on_Last_Cost = 9371656;
				
				
				
    			public const Int32 Margin_on_Standard_Cost = 9371657;
				
				
				
    			public const Int32 Average_Sale_Price = 9371658;
				
				
				
    			public const Int32 Average_Purchase_Price = 9371659;
				
				
				
    			public const Int32 No_Default = 9371660;
				
				
				
    			public const Int32 Margin_on_Average_Cost = 9371661;
		}
		public sealed class Sales_Discount
		{
				
				
				private Sales_Discount()
    			{
    			}

				public const Int32 DefaultValue = 9502730; 
				
				
				
    			public const Int32 Last_of_Item_Customer = 9502720;
				
				
				
    			public const Int32 Last_of_CommDot_CatDot_Customer = 9502721;
				
				
				
    			public const Int32 Standard_of_Item_Customer = 9502722;
				
				
				
    			public const Int32 Item_CustDot_Qty_Brackets = 9502723;
				
				
				
    			public const Int32 Standard_of_CommDot_CatDot_Customer = 9502724;
				
				
				
    			public const Int32 Standard_of_Customer = 9502725;
				
				
				
    			public const Int32 Price_List_Discount = 9502726;
				
				
				
    			public const Int32 Commodity = 9502727;
				
				
				
    			public const Int32 Item = 9502728;
				
				
				
    			public const Int32 None = 9502729;
				
				
				
    			public const Int32 First_Valid = 9502730;
				
				
				
    			public const Int32 Item_Type = 9502731;
				
				
				
    			public const Int32 Standard_of_CommDotCatDot_Customer_CatDot = 9502732;
				
				
				
    			public const Int32 Customers_Item_Type = 9502733;
				
				
				
    			public const Int32 Standard_of_Customer_CatDot_Item = 9502734;
		}
		public sealed class Purchase_Request_type
		{
				
				
				private Purchase_Request_type()
    			{
    			}

				public const Int32 DefaultValue = 23986176; 
				
				
				
    			public const Int32 Manual = 23986176;
				
				
				
    			public const Int32 From_MRP = 23986177;
		}
		public sealed class Purchase_Request_status
		{
				
				
				private Purchase_Request_status()
    			{
    			}

				public const Int32 DefaultValue = 23068672; 
				
				
				
    			public const Int32 Proposed = 23068672;
				
				
				
    			public const Int32 Fulfilled = 23068673;
				
				
				
    			public const Int32 Approved = 23068674;
				
				
				
    			public const Int32 Rejected = 23068675;
		}
		public sealed class Purchase_Order_Generation_Type
		{
				
				
				private Purchase_Order_Generation_Type()
    			{
    			}

				public const Int32 DefaultValue = 43122689; 
				
				
				
    			public const Int32 Supplier_and_Purchase_ReqDot_No = 43122688;
				
				
				
    			public const Int32 Supplier = 43122689;
				
				
				
    			public const Int32 Supplier_and_Delivery_Date = 43122690;
		}
		public sealed class Sales_Forecast_Management
		{
				
				
				private Sales_Forecast_Management()
    			{
    			}

				public const Int32 DefaultValue = 43188224; 
				
				
				
    			public const Int32 Not_Managed = 43188224;
				
				
				
    			public const Int32 Daily = 43188225;
				
				
				
    			public const Int32 Weekly = 43188226;
				
				
				
    			public const Int32 Monthly = 43188227;
		}
		public sealed class Stock_Replenishment_Document_Type
		{
				
				
				private Stock_Replenishment_Document_Type()
    			{
    			}

				public const Int32 DefaultValue = 2047148032; 
				
				
				
    			public const Int32 Purchase_Order = 2047148032;
				
				
				
    			public const Int32 Purchase_Request = 2047148033;
		}
		public sealed class Purchase_Document_Type
		{
				
				
				private Purchase_Document_Type()
    			{
    			}

				public const Int32 DefaultValue = 9830400; 
				
				
				
    			public const Int32 Bill_of_Lading = 9830400;
				
				
				
    			public const Int32 Invoice = 9830401;
				
				
				
    			public const Int32 Credit_Note = 9830402;
				
				
				
    			public const Int32 Correction_Invoice = 9830403;
				
				
				
    			public const Int32 Subcontractor_Bill_of_Lading = 9830404;
				
				
				
    			public const Int32 Invoice_For_Advance = 9830405;
				
				
				
    			public const Int32 Debit_Note = 9830406;
				
				
				
    			public const Int32 Cancellation_Invoice = 9830407;
		}
		public sealed class Item_Status
		{
				
				
				private Item_Status()
    			{
    			}

				public const Int32 DefaultValue = 9895936; 
				
				
				
    			public const Int32 Conforming = 9895936;
				
				
				
    			public const Int32 Rejected = 9895937;
				
				
				
    			public const Int32 To_be_Returned_to_Supplier = 9895938;
				
				
				
    			public const Int32 Return_to_Supplier = 9895939;
				
				
				
    			public const Int32 Scrap = 9895940;
				
				
				
    			public const Int32 To_be_inspected = 9895941;
				
				
				
    			public const Int32 Under_inspection = 9895942;
				
				
				
    			public const Int32 Inspected = 9895943;
				
				
				
    			public const Int32 Return_to_Supplier_in_two_steps = 9895944;
				
				
				
    			public const Int32 Transferred_in_WMS = 9895945;
				
				
				
    			public const Int32 For_Transfer = 9895947;
				
				
				
    			public const Int32 Return_to_Supplier_after_Rejected = 9895946;
		}
		public sealed class Purchase_Credit_Debit_Note_Variation_Type
		{
				
				
				private Purchase_Credit_Debit_Note_Variation_Type()
    			{
    			}

				public const Int32 DefaultValue = 25952256; 
				
				
				
    			public const Int32 Quantity = 25952256;
				
				
				
    			public const Int32 Value = 25952257;
		}
		public sealed class Field_type
		{
				
				
				private Field_type()
    			{
    			}

				public const Int32 DefaultValue = 25493504; 
				
				
				
    			public const Int32 Text = 25493504;
				
				
				
    			public const Int32 Integer = 25493505;
				
				
				
    			public const Int32 Quantity = 25493506;
				
				
				
    			public const Int32 Money = 25493507;
				
				
				
    			public const Int32 Percent = 25493508;
				
				
				
    			public const Int32 Date = 25493509;
				
				
				
    			public const Int32 Time = 25493510;
				
				
				
    			public const Int32 Bool = 25493511;
				
				
				
    			public const Int32 Path = 25493512;
		}
		public sealed class Work_Method
		{
				
				
				private Work_Method()
    			{
    			}

				public const Int32 DefaultValue = 24772608; 
				
				
				
    			public const Int32 Automatic = 24772608;
				
				
				
    			public const Int32 Semiautomatic = 24772609;
				
				
				
    			public const Int32 Manual = 24772610;
		}
		public sealed class Labour_Type
		{
				
				
				private Labour_Type()
    			{
    			}

				public const Int32 DefaultValue = 28508160; 
				
				
				
    			public const Int32 Processing = 28508160;
				
				
				
    			public const Int32 Setup = 28508161;
		}
		public sealed class MO_Confirmation_Type
		{
				
				
				private MO_Confirmation_Type()
    			{
    			}

				public const Int32 DefaultValue = 2032730112; 
				
				
				
    			public const Int32 MO_Confirmation = 2032730112;
				
				
				
    			public const Int32 Manufacturing_Mobile = 2032730113;
				
				
				
    			public const Int32 Data_Collection = 2032730114;
		}
		public sealed class OnHand_Detail_Items
		{
				
				
				private OnHand_Detail_Items()
    			{
    			}

				public const Int32 DefaultValue = 25165825; 
				
				
				
    			public const Int32 Initial = 25165824;
				
				
				
    			public const Int32 Sale_Order = 25165825;
				
				
				
    			public const Int32 Sale_Order_Component = 25165826;
				
				
				
    			public const Int32 Purchase_Order = 25165827;
				
				
				
    			public const Int32 Final = 25165828;
		}
		public sealed class Customer_Contract_Type
		{
				
				
				private Customer_Contract_Type()
    			{
    			}

				public const Int32 DefaultValue = 25690113; 
				
				
				
    			public const Int32 Programmable = 25690112;
				
				
				
    			public const Int32 Sale = 25690113;
		}
		public sealed class Sale_Order_Priority_Type
		{
				
				
				private Sale_Order_Priority_Type()
    			{
    			}

				public const Int32 DefaultValue = 26935296; 
				
				
				
    			public const Int32 Order_ID = 26935296;
				
				
				
    			public const Int32 Expected_Delivery_Date = 26935297;
				
				
				
    			public const Int32 Order_Line = 26935298;
				
				
				
    			public const Int32 Priority = 26935299;
				
				
				
    			public const Int32 Confirmed_Delivery_Date = 26935300;
				
				
				
    			public const Int32 Order_Date = 26935301;
				
				
				
    			public const Int32 Order_No = 26935302;
		}
		public sealed class Document_Type
		{
				
				
				private Document_Type()
    			{
    			}

				public const Int32 DefaultValue = 3407873; 
				
				
				
    			public const Int32 Picking_List = 3407872;
				
				
				
    			public const Int32 Delivery_Note = 3407873;
				
				
				
    			public const Int32 Invoice = 3407874;
				
				
				
    			public const Int32 Accompanying_Invoice = 3407875;
				
				
				
    			public const Int32 Credit_Note = 3407876;
				
				
				
    			public const Int32 Return_From_Customer = 3407877;
				
				
				
    			public const Int32 Receipt = 3407878;
				
				
				
    			public const Int32 NonMinuscollected_Receipt = 3407879;
				
				
				
    			public const Int32 Subconctractor_Delivery_Note = 3407880;
				
				
				
    			public const Int32 Return_To_Supplier = 3407881;
				
				
				
    			public const Int32 Correction_Invoice = 3407882;
				
				
				
    			public const Int32 Invoice_For_Advance = 3407883;
				
				
				
    			public const Int32 Correction_Accompanying_Invoice = 3407884;
				
				
				
    			public const Int32 Correction_Receipt = 3407885;
				
				
				
    			public const Int32 Paragon = 3407886;
				
				
				
    			public const Int32 Correction_Paragon = 3407887;
				
				
				
    			public const Int32 ProForma_Invoice = 3407888;
				
				
				
    			public const Int32 Debit_Note = 3407889;
				
				
				
    			public const Int32 Interstorage_movement_Document = 3407890;
				
				
				
    			public const Int32 Production_Plan = 3407891;
				
				
				
    			public const Int32 Sale_Cancellation_Invoice = 3407897;
				
				
				
    			public const Int32 SelfInvoice = 3407898;
				
				
				
    			public const Int32 SelfCredit_Note = 3407899;
				
				
				
    			public const Int32 Delivery_Notes_From_Preshipping = 3407900;
		}
		public sealed class Availability_Check_Type
		{
				
				
				private Availability_Check_Type()
    			{
    			}

				public const Int32 DefaultValue = 25100288; 
				
				
				
    			public const Int32 Ignore = 25100288;
				
				
				
    			public const Int32 Warn = 25100289;
				
				
				
    			public const Int32 Block = 25100290;
		}
		public sealed class Display_Items_In_Radar
		{
				
				
				private Display_Items_In_Radar()
    			{
    			}

				public const Int32 DefaultValue = 25231360; 
				
				
				
    			public const Int32 All = 25231360;
				
				
				
    			public const Int32 OnMinusHand = 25231361;
				
				
				
    			public const Int32 OnMinusHand_in_Storage = 25231362;
		}
		public sealed class InterStorage_movement_Document_Type
		{
				
				
				private InterStorage_movement_Document_Type()
    			{
    			}

				public const Int32 DefaultValue = 25296896; 
				
				
				
    			public const Int32 Blank = 25296896;
				
				
				
    			public const Int32 Transfer_between_Storages = 25296897;
				
				
				
    			public const Int32 Storage_Transfer_OUT = 25296898;
				
				
				
    			public const Int32 Storage_Transfer_IN = 25296899;
				
				
				
    			public const Int32 Not_Owned_Storage_Transfer_OUT = 25296900;
				
				
				
    			public const Int32 Not_Owned_Storage_Transfer_IN = 25296901;
		}
		public sealed class Print_Item_Code
		{
				
				
				private Print_Item_Code()
    			{
    			}

				public const Int32 DefaultValue = 27656192; 
				
				
				
    			public const Int32 Company = 27656192;
				
				
				
    			public const Int32 Customer = 27656193;
				
				
				
    			public const Int32 Both = 27656194;
		}
		public sealed class Commission_Type
		{
				
				
				private Commission_Type()
    			{
    			}

				public const Int32 DefaultValue = 2555904; 
				
				
				
    			public const Int32 On_Sale_Price = 2555904;
				
				
				
    			public const Int32 On_Discounted_Sale_Price = 2555905;
				
				
				
    			public const Int32 Margin_on_Last_Cost = 2555906;
				
				
				
    			public const Int32 Margin_on_Average_Cost = 2555907;
				
				
				
    			public const Int32 Margin_on_Standard_Cost = 2555908;
		}
		public sealed class Accrual_Type
		{
				
				
				private Accrual_Type()
    			{
    			}

				public const Int32 DefaultValue = 3473408; 
				
				
				
    			public const Int32 On_Turnover = 3473408;
				
				
				
    			public const Int32 At_Installment_Due_Date = 3473409;
				
				
				
    			public const Int32 On_Collected = 3473410;
				
				
				
    			public const Int32 On_Document_Totally_Collected = 3473411;
		}
		public sealed class Area_Manager_Management
		{
				
				
				private Area_Manager_Management()
    			{
    			}

				public const Int32 DefaultValue = 5570560; 
				
				
				
    			public const Int32 As_Area_Manager = 5570560;
				
				
				
    			public const Int32 As_Salesperson = 5570561;
				
				
				
    			public const Int32 Area_Manager_if_Default = 5570562;
		}
		public sealed class FIRR_Balance_Type
		{
				
				
				private FIRR_Balance_Type()
    			{
    			}

				public const Int32 DefaultValue = 9633792; 
				
				
				
    			public const Int32 OneMinusfirm_Salesperson = 9633792;
				
				
				
    			public const Int32 Multifirm_Salesperson = 9633793;
		}
		public sealed class Commission_Policy_Type
		{
				
				
				private Commission_Policy_Type()
    			{
    			}

				public const Int32 DefaultValue = 11141120; 
				
				
				
    			public const Int32 None = 11141120;
				
				
				
    			public const Int32 Item = 11141121;
				
				
				
    			public const Int32 Salesperson_basis = 11141122;
				
				
				
    			public const Int32 Customer = 11141123;
				
				
				
    			public const Int32 Commodity_Category = 11141124;
				
				
				
    			public const Int32 Item_basis = 11141125;
				
				
				
    			public const Int32 Applied_Discount_ = 11141126;
				
				
				
    			public const Int32 Salesperson_Turnover = 11141127;
				
				
				
    			public const Int32 Item_Amount = 11141128;
				
				
				
    			public const Int32 Customer_Category = 11141129;
				
				
				
    			public const Int32 Item_Category = 11141130;
				
				
				
    			public const Int32 Invoice_Total_ = 11141131;
				
				
				
    			public const Int32 CustomerSlashItem = 11141132;
				
				
				
    			public const Int32 ItemSlashCustomer = 11141133;
		}
		public sealed class Crossing_Policy
		{
				
				
				private Crossing_Policy()
    			{
    			}

				public const Int32 DefaultValue = 11206657; 
				
				
				
    			public const Int32 Commission_Category = 11206656;
				
				
				
    			public const Int32 Code = 11206657;
		}
		public sealed class Ship_to
		{
				
				
				private Ship_to()
    			{
    			}

				public const Int32 DefaultValue = 2032599040; 
				
				
				
    			public const Int32 Company = 2032599040;
				
				
				
    			public const Int32 Customer = 2032599041;
				
				
				
    			public const Int32 Supplier = 2032599042;
		}
		public sealed class SingleMinusstep_LIFOSlashFIFO_Entry_Type
		{
				
				
				private SingleMinusstep_LIFOSlashFIFO_Entry_Type()
    			{
    			}

				public const Int32 DefaultValue = 11796480; 
				
				
				
    			public const Int32 Receipt = 11796480;
				
				
				
    			public const Int32 Issue = 11796481;
				
				
				
    			public const Int32 Positive_Receipt_Adjustment = 11796482;
				
				
				
    			public const Int32 Issue_Adjustment = 11796483;
				
				
				
    			public const Int32 Storage_Transfer_IN = 11796484;
				
				
				
    			public const Int32 Storage_Transfer_OUT = 11796485;
				
				
				
    			public const Int32 Closed_by_Inventory_Closing = 11796486;
				
				
				
    			public const Int32 Cancel_Receipt = 11796487;
				
				
				
    			public const Int32 Cancel_Issue = 11796488;
				
				
				
    			public const Int32 Negative_Receipt_Adjustment = 11796489;
		}
		public sealed class Declaration_of_Intent_Type
		{
				
				
				private Declaration_of_Intent_Type()
    			{
    			}

				public const Int32 DefaultValue = 1507329; 
				
				
				
    			public const Int32 One_Minus_Single_Operation = 1507328;
				
				
				
    			public const Int32 Two_Minus_Limit_Amount = 1507329;
				
				
				
    			public const Int32 Three_Minus_From_Date_to_Date = 1507330;
		}
		public sealed class Shop_Type
		{
				
				
				private Shop_Type()
    			{
    			}

				public const Int32 DefaultValue = 2045640704; 
				
				
				
    			public const Int32 OnMinussite = 2045640704;
				
				
				
    			public const Int32 OnMinusline = 2045640705;
				
				
				
    			public const Int32 Headquarters = 2045640706;
		}
		public sealed class eCommerce_Connector
		{
				
				
				private eCommerce_Connector()
    			{
    			}

				public const Int32 DefaultValue = 2048655361; 
				
				
				
    			public const Int32 KonaKart = 2048655360;
				
				
				
    			public const Int32 Blank = 2048655361;
				
				
				
    			public const Int32 Magento = 2048655362;
				
				
				
    			public const Int32 Shopware = 2048655363;
				
				
				
    			public const Int32 Shopify = 2048655364;
		}
		public sealed class Platform
		{
				
				
				private Platform()
    			{
    			}

				public const Int32 DefaultValue = 2048720896; 
				
				
				
    			public const Int32 Blank = 2048720896;
				
				
				
    			public const Int32 TCPOS = 2048720897;
				
				
				
    			public const Int32 EPOS = 2048720898;
				
				
				
    			public const Int32 TILBY = 2048720899;
				
				
				
    			public const Int32 OTHER = 2048720900;
				
				
				
    			public const Int32 MAGENTO = 2048720901;
				
				
				
    			public const Int32 KONAKART = 2048720902;
				
				
				
    			public const Int32 SHOPWARE = 2048720903;
				
				
				
    			public const Int32 SHOPIFY = 2048720904;
				
				
				
    			public const Int32 OMNIPOS = 2048720905;
		}
		public sealed class Search_for_Supplier_in_Purchase_Order
		{
				
				
				private Search_for_Supplier_in_Purchase_Order()
    			{
    			}

				public const Int32 DefaultValue = 2046623744; 
				
				
				
    			public const Int32 Standard = 2046623744;
				
				
				
    			public const Int32 All_Suppliers = 2046623745;
				
				
				
    			public const Int32 Suppliers_linked_to_the_shop = 2046623746;
		}
		public sealed class TCPOS_Reference_Price
		{
				
				
				private TCPOS_Reference_Price()
    			{
    			}

				public const Int32 DefaultValue = 23920640; 
				
				
				
    			public const Int32 Ignore = 23920640;
				
				
				
    			public const Int32 Base_Price = 23920641;
				
				
				
    			public const Int32 Suggested_Price = 23920642;
		}
		public sealed class Customer_Data
		{
				
				
				private Customer_Data()
    			{
    			}

				public const Int32 DefaultValue = 2046885888; 
				
				
				
    			public const Int32 Overwrite = 2046885888;
				
				
				
    			public const Int32 Not_Overwrite = 2046885889;
		}
		public sealed class Copy_Item_Description
		{
				
				
				private Copy_Item_Description()
    			{
    			}

				public const Int32 DefaultValue = 2048458753; 
				
				
				
    			public const Int32 Ignore = 2048458752;
				
				
				
    			public const Int32 Copy_only_when_inserting_a_new_item = 2048458753;
				
				
				
    			public const Int32 Copy_always = 2048458754;
		}
		public sealed class Post_Voucher_In_Accounting
		{
				
				
				private Post_Voucher_In_Accounting()
    			{
    			}

				public const Int32 DefaultValue = 7667713; 
				
				
				
    			public const Int32 Never = 7667712;
				
				
				
    			public const Int32 Always = 7667713;
				
				
				
    			public const Int32 Use_Transitional_Account = 7667714;
		}
		public sealed class Copy_Item_Description_on_Item_POS_Description
		{
				
				
				private Copy_Item_Description_on_Item_POS_Description()
    			{
    			}

				public const Int32 DefaultValue = 2048589824; 
				
				
				
    			public const Int32 Ignore = 2048589824;
				
				
				
    			public const Int32 Copy_only_when_inserting_a_new_item = 2048589825;
				
				
				
    			public const Int32 Copy_always = 2048589826;
		}
		public sealed class Tax_Sales_Type
		{
				
				
				private Tax_Sales_Type()
    			{
    			}

				public const Int32 DefaultValue = 2048917504; 
				
				
				
    			public const Int32 Goods = 2048917504;
				
				
				
    			public const Int32 Service = 2048917505;
		}
		public sealed class Massive_Inventory_Entries_Group_By
		{
				
				
				private Massive_Inventory_Entries_Group_By()
    			{
    			}

				public const Int32 DefaultValue = 10158080; 
				
				
				
    			public const Int32 Per_DateSlashShop = 10158080;
				
				
				
    			public const Int32 Per_Fiscal_Bill = 10158081;
		}
		public sealed class Accounting_Posting_Group
		{
				
				
				private Accounting_Posting_Group()
    			{
    			}

				public const Int32 DefaultValue = 2045968384; 
				
				
				
    			public const Int32 Per_Day = 2045968384;
				
				
				
    			public const Int32 Per_Customer = 2045968385;
				
				
				
    			public const Int32 Per_Fiscal_Bill = 2045968386;
		}
		public sealed class Fiscal_Bill_posting_in_accounting
		{
				
				
				private Fiscal_Bill_posting_in_accounting()
    			{
    			}

				public const Int32 DefaultValue = 29163521; 
				
				
				
    			public const Int32 Never = 29163520 ;
				
				
				
    			public const Int32 Always = 29163521;
				
				
				
    			public const Int32 From_Date = 29163522;
		}
		public sealed class Subsidy_Groupby
		{
				
				
				private Subsidy_Groupby()
    			{
    			}

				public const Int32 DefaultValue = 11927554; 
				
				
				
    			public const Int32 Subsidy_and_Customer_Card = 11927552;
				
				
				
    			public const Int32 Subsidy_and_Document = 11927553;
				
				
				
    			public const Int32 Subsidy_and_Date = 11927554;
				
				
				
    			public const Int32 SubsidyComma_Date_and_Customer_Card = 11927555;
		}
		public sealed class Group_InterStore_Document
		{
				
				
				private Group_InterStore_Document()
    			{
    			}

				public const Int32 DefaultValue = 2047410177; 
				
				
				
    			public const Int32 No_Grouping = 2047410176;
				
				
				
    			public const Int32 Shop = 2047410177;
				
				
				
    			public const Int32 Company = 2047410178;
		}
		public sealed class Shop_Code_Type
		{
				
				
				private Shop_Code_Type()
    			{
    			}

				public const Int32 DefaultValue = 2046099456; 
				
				
				
    			public const Int32 Shop_Region = 2046099456;
				
				
				
    			public const Int32 Shop_Location = 2046099457;
				
				
				
    			public const Int32 Shop_Type = 2046099458;
				
				
				
    			public const Int32 Shop_Owner = 2046099459;
		}
		public sealed class Shop_Storages_Type
		{
				
				
				private Shop_Storages_Type()
    			{
    			}

				public const Int32 DefaultValue = 24117248; 
				
				
				
    			public const Int32 Main = 24117248;
				
				
				
    			public const Int32 Back = 24117249;
				
				
				
    			public const Int32 Transfer = 24117250;
				
				
				
    			public const Int32 Cross_Docking = 24117251;
				
				
				
    			public const Int32 Of_Till = 24117252;
				
				
				
    			public const Int32 To_Be_Returned = 24117253;
				
				
				
    			public const Int32 Scrap = 24117254;
		}
		public sealed class Code_Missing
		{
				
				
				private Code_Missing()
    			{
    			}

				public const Int32 DefaultValue = 43843584; 
				
				
				
    			public const Int32 Use_Default_Code = 43843584;
				
				
				
    			public const Int32 Not_Sync = 43843585;
		}
		public sealed class Use_Supplier_or_Prospect_Supplier
		{
				
				
				private Use_Supplier_or_Prospect_Supplier()
    			{
    			}

				public const Int32 DefaultValue = 2031681536; 
				
				
				
    			public const Int32 Supplier = 2031681536;
				
				
				
    			public const Int32 Prospect_Supplier = 2031681537;
		}
		public sealed class TESANOperationType
		{
				
				
				private TESANOperationType()
    			{
    			}

				public const Int32 DefaultValue = 32571392; 
				
				
				
    			public const Int32 Insertion_Slash_Refund = 32571392;
				
				
				
    			public const Int32 Variation = 32571393;
				
				
				
    			public const Int32 Cancellation = 32571394;
		}
		public sealed class TESANDocumentType
		{
				
				
				private TESANDocumentType()
    			{
    			}

				public const Int32 DefaultValue = 1441792; 
				
				
				
    			public const Int32 Invoice = 1441792;
				
				
				
    			public const Int32 Commercial_Document = 1441793;
		}
		public sealed class Tool_status
		{
				
				
				private Tool_status()
    			{
    			}

				public const Int32 DefaultValue = 2031812608; 
				
				
				
    			public const Int32 Available = 2031812608;
				
				
				
    			public const Int32 To_be_reconditioned = 2031812609;
				
				
				
    			public const Int32 Under_maintenance = 2031812610;
				
				
				
    			public const Int32 To_be_inspected = 2031812611;
				
				
				
    			public const Int32 Under_inspection = 2031812612;
				
				
				
    			public const Int32 Exhausted = 2031812613;
				
				
				
    			public const Int32 Insufficient_capacity = 2031812614;
				
				
				
    			public const Int32 Used_by_another_MO = 2031812615;
				
				
				
    			public const Int32 Disabled = 2031812616;
				
				
				
    			public const Int32 Not_found = 2031812617;
				
				
				
    			public const Int32 Error = 2031812618;
				
				
				
    			public const Int32 Out_of_order = 2031812619;
		}
		public sealed class Tool_type
		{
				
				
				private Tool_type()
    			{
    			}

				public const Int32 DefaultValue = 2031878144; 
				
				
				
    			public const Int32 By_Quantity = 2031878144;
				
				
				
    			public const Int32 By_Time = 2031878145;
		}
		public sealed class Tool_source
		{
				
				
				private Tool_source()
    			{
    			}

				public const Int32 DefaultValue = 2031943680; 
				
				
				
    			public const Int32 Original = 2031943680;
				
				
				
    			public const Int32 Replaced_by = 2031943681;
				
				
				
    			public const Int32 In_substitution_of = 2031943682;
				
				
				
    			public const Int32 From_tool_family = 2031943683;
		}
		public sealed class Tool_usage
		{
				
				
				private Tool_usage()
    			{
    			}

				public const Int32 DefaultValue = 2032009216; 
				
				
				
    			public const Int32 Routing_step_only = 2032009216;
				
				
				
    			public const Int32 From_start_to_routing_step = 2032009217;
				
				
				
    			public const Int32 From_routing_step_to_end = 2032009218;
				
				
				
    			public const Int32 Whole_MO = 2032009219;
		}
		public sealed class Tool_action
		{
				
				
				private Tool_action()
    			{
    			}

				public const Int32 DefaultValue = 2032205824; 
				
				
				
    			public const Int32 None = 2032205824;
				
				
				
    			public const Int32 Revision_started = 2032205825;
				
				
				
    			public const Int32 Revision_ended = 2032205826;
				
				
				
    			public const Int32 Reconditioning_started = 2032205827;
				
				
				
    			public const Int32 Reconditioning_ended = 2032205828;
				
				
				
    			public const Int32 Set_by_user = 2032205829;
				
				
				
    			public const Int32 Automatically_set = 2032205830;
		}
		public sealed class Parent_Child_Variant_Action
		{
				
				
				private Parent_Child_Variant_Action()
    			{
    			}

				public const Int32 DefaultValue = 2046164993; 
				[Activation("ERP.VariantsPlus")]
				
				
    			public const Int32 Overwrite = 2046164992;
				[Activation("ERP.VariantsPlus")]
				
				
    			public const Int32 Overwrite_on_Demand = 2046164993;
				[Activation("ERP.VariantsPlus")]
				
				
    			public const Int32 Not_Ovewrite = 2046164994;
		}
		public sealed class Variants_Management_Window
		{
				
				
				private Variants_Management_Window()
    			{
    			}

				public const Int32 DefaultValue = 43253761; 
				[Activation("ERP.VariantsPlus")]
				
				
    			public const Int32 Matrix = 43253760;
				[Activation("ERP.VariantsPlus")]
				
				
    			public const Int32 Grid_Selection = 43253761;
				[Activation("ERP.VariantsPlus")]
				
				
    			public const Int32 Simplified = 43253762;
		}
		public sealed class ZGDPRStatus
		{
				
				
				private ZGDPRStatus()
    			{
    			}

				public const Int32 DefaultValue = 917504; 
				
				
				
    			public const Int32 Not_send = 917504;
				
				
				
    			public const Int32 Sent = 917505;
				
				
				
    			public const Int32 Failed_sending = 917506;
		}
		public sealed class CusCourseLevel
		{
				
				
				private CusCourseLevel()
    			{
    			}

				public const Int32 DefaultValue = 531562496; 
				
				
				
    			public const Int32 Base = 531562496;
				
				
				
    			public const Int32 Advanced = 531562497;
				
				
				
    			public const Int32 Expert = 531562498;
		}
	}
}