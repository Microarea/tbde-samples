using System;
using Courses.Courses.Model;
using Microarea.Tbf.Model.Remote.Table;
using Microarea.Tbf.Model.MyMagoStudioBase;
using System.Threading.Tasks;
using Microarea.Tbf.Model.Remote;

namespace Courses.Courses.BO
{
	public class ERPCompanyActivityCodes : MyMagoStudioBO<MA_ActivityCodes, ERPCompanyActivityCodes>
	{
		private static readonly string BONamespace = "ERP.Company.Documents.ActivityCodes";
		#region BO Variables
		public bool bDynamicOnlyOneRecord;
		public string Title;
		public string HeaderStripTitle;
		#endregion
		
		protected override void Configure()
        {
            MasterTable = new Table<MA_ActivityCodes>("ActivityCode", this);

            base.Configure();
        }

		public static async Task<ERPCompanyActivityCodes> CreateUnattendedAsync(ContextInfo contextInfo)
        {
            return await CreateUnattendedAsyncInternal(BONamespace, contextInfo);
        }

        public static async Task<ERPCompanyActivityCodes> CreateUnattendedAsyncFromCaller(ContextInfo contextInfo, string callerId)
        {
            return await CreateUnattendedAsyncFromCallerInternal(BONamespace, contextInfo, callerId);
        }

        public static async Task<ERPCompanyActivityCodes> CreateAttendedAsync(ContextInfo contextInfo, string callerId)
        {
            return await CreateAttendedAsyncInternal(BONamespace, contextInfo, callerId);
        }
	}
}