using System;
using Courses.Courses.Model;
using Microarea.Tbf.Model.Remote.Table;
using Microarea.Tbf.Model.MyMagoStudioBase;
using System.Threading.Tasks;
using Microarea.Tbf.Model.Remote;

namespace Courses.Courses.BO
{
	public class CoursesCoursesCourses : MyMagoStudioBO<MMS_Courses, CoursesCoursesCourses>
	{
		private static readonly string BONamespace = "Courses.Courses.DynamicDocuments.Courses";
		#region BO Variables
		public bool bDynamicOnlyOneRecord;
		public string HeaderStripTitle;
		public string Title;
		#endregion
		private Table<MMS_CoursesInfo> _MMS_CoursesInfo;
		private TableN<MMS_CoursesDetails> _MMS_CoursesDetails;
		public Table<MMS_CoursesInfo> MMS_CoursesInfo { get => _MMS_CoursesInfo; }
		public TableN<MMS_CoursesDetails> MMS_CoursesDetails { get => _MMS_CoursesDetails; }
		
		protected override void Configure()
        {
            MasterTable = new Table<MMS_Courses>("MMS_Courses", this);
            _MMS_CoursesInfo = new Table<MMS_CoursesInfo>("MMS_CoursesInfo", this);
            MasterTable.Attach(MMS_CoursesInfo);
            _MMS_CoursesDetails = new TableN<MMS_CoursesDetails>("MMS_CoursesDetails", this);
            MasterTable.Attach(MMS_CoursesDetails);

            base.Configure();
        }

		public static async Task<CoursesCoursesCourses> CreateUnattendedAsync(ContextInfo contextInfo)
        {
            return await CreateUnattendedAsyncInternal(BONamespace, contextInfo);
        }

        public static async Task<CoursesCoursesCourses> CreateUnattendedAsyncFromCaller(ContextInfo contextInfo, string callerId)
        {
            return await CreateUnattendedAsyncFromCallerInternal(BONamespace, contextInfo, callerId);
        }

        public static async Task<CoursesCoursesCourses> CreateAttendedAsync(ContextInfo contextInfo, string callerId)
        {
            return await CreateAttendedAsyncInternal(BONamespace, contextInfo, callerId);
        }
	}
}