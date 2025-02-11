//This file is created automatically by MMS
//maintenance of this file will be done by programmer
//HIGHLY RECOMMENDED: 
//DON'T TOUCH THE METHODS DECORATORS; The decorators are used for update of this file!!!
//DON'T TOUCH MMS REGION
using System;
using Microarea.Tbf.Model.MyMagoStudioBase;
using System.Threading.Tasks;
using Microarea.Generic.DataObj;
using Microarea.Tbf.Model.Remote;
using Courses.Courses.Model;

namespace Courses.Courses.Courses
{
    public partial class CoursesCoursesCourses : MyMagoStudioDocument
    {
        [MyMagoStudioMethodDecorator("ValueChanged", "CustSuppType_ValueChanged", "IDD_EMPTYDOCUMENT_VIEW_COURSES_TM_2_COURSES_TG_2_COURSES_PANEL_1_COURSES_BE_1__DYN_COL_2")]
        public async Task<CustSuppType_ValueChangedResponse> CustSuppType_ValueChanged(CustSuppType_ValueChangedRequest request, ContextInfo contextInfo, string callerDocId)
        {
            CustSuppType_ValueChangedResponse response = new CustSuppType_ValueChangedResponse();
            //...add your code here with some awaitable functions/methods ecc....

            //onlyOneRec
            if (request.CoursesDetails_In is null || request.CoursesDetails_In.Count != 1)
            {
                response.AddDiagnosticItem("Bad format request!", Microarea.Interfaces.DiagnosticType.Error);
                return response;
            }

            response.CoursesDetails_Out.Behaviour = MyMagoStudioOneToManyResponseBase<Model.MMS_CoursesDetails>.ApplyToDestination.Update;
            if (response.CoursesDetails_Out.RecordsToInsertOrUpdate is null)
                response.CoursesDetails_Out.RecordsToInsertOrUpdate = new System.Collections.Generic.List<Model.MMS_CoursesDetails>();
            MMS_CoursesDetails myRec = new MMS_CoursesDetails();
            myRec.f_CourseId.Value = request.CoursesDetails_In[0].f_CourseId.Value;
            myRec.f_Line.Value = request.CoursesDetails_In[0].f_Line.Value;
            myRec.f_CustSupp.Value = string.Empty;
            myRec.f_CustSupp.IsModified = true;
            if (request.CoursesDetails_In[0].f_CustSuppType.Value == Enums.Enums.CustSupp_Type.Customer)
                myRec.f_CustSuppTypeToInt.Value = 0;
            else
                myRec.f_CustSuppTypeToInt.Value = 1;

            myRec.f_CustSuppTypeToInt.IsModified = true;
            response.CoursesDetails_Out.RecordsToInsertOrUpdate.Add(myRec);

            //all dbt
            if (request.CoursesDetails_In is null)
            {
                response.AddDiagnosticItem("Bad format request!", Microarea.Interfaces.DiagnosticType.Error);
                return response;
            }

            //response.CoursesDetails_Out.Behaviour = MyMagoStudioOneToManyResponseBase<Model.MMS_CoursesDetails>.ApplyToDestination.Update;
            //if (response.CoursesDetails_Out.RecordsToInsertOrUpdate is null)
            //    response.CoursesDetails_Out.RecordsToInsertOrUpdate = new System.Collections.Generic.List<Model.MMS_CoursesDetails>();

            //foreach (var detail in request.CoursesDetails_In)
            //{
            //    MMS_CoursesDetails myRec = detail;

            //    myRec.f_CustSupp.Value = string.Empty;
            //    myRec.f_CustSupp.IsModified = true;
            //    if (myRec.f_CustSuppType.Value == Enums.Enums.CustSupp_Type.Customer)
            //    {
            //        myRec.f_CustSuppType.Value = Enums.Enums.CustSupp_Type.Supplier;
            //        myRec.f_CustSuppTypeToInt.Value = 1;
            //    }
            //    else
            //    {
            //        myRec.f_CustSuppType.Value = Enums.Enums.CustSupp_Type.Customer;
            //        myRec.f_CustSuppTypeToInt.Value = 0;
            //    }
            //    myRec.f_CompanyName.Value = string.Empty;

            //    myRec.f_CustSuppType.IsModified = true;
            //    myRec.f_CustSuppTypeToInt.IsModified = true;
            //    myRec.f_CompanyName.IsModified = true;
            //    response.CoursesDetails_Out.RecordsToInsertOrUpdate.Add(myRec);
            //}


            return response;
        }

        [MyMagoStudioMethodDecorator("DataLoaded", "Courses_DataLoaded")]
        public async Task<Courses_DataLoadedResponse> Courses_DataLoaded(Courses_DataLoadedRequest request, ContextInfo contextInfo, string callerDocId)
        {
            Courses_DataLoadedResponse response = new Courses_DataLoadedResponse();
            //...add your code here with some awaitable functions/methods ecc....
            if (request.CoursesDetails_In is null || request.CoursesDetails_In.Count == 0)
                return response;
            response.CoursesDetails_Out.Behaviour = MyMagoStudioOneToManyResponseBase<Model.MMS_CoursesDetails>.ApplyToDestination.Update;
            if (response.CoursesDetails_Out.RecordsToInsertOrUpdate is null)
                response.CoursesDetails_Out.RecordsToInsertOrUpdate = new System.Collections.Generic.List<Model.MMS_CoursesDetails>();

            foreach (var requestRec in request.CoursesDetails_In)
            {
                if (requestRec is null)
                    continue;

                response.totalDays_Out += (short)requestRec.f_Days.Value;
                MMS_CoursesDetails myRec = new MMS_CoursesDetails();
                myRec.f_CourseId.Value = requestRec.f_CourseId.Value;
                myRec.f_Line.Value = requestRec.f_Line.Value;
                myRec.f_CustSuppTypeToInt.Value = requestRec.f_CustSuppType.Value == Enums.Enums.CustSupp_Type.Customer ? 0 : 1;
                myRec.f_CustSuppTypeToInt.IsModified = true;
                response.CoursesDetails_Out.RecordsToInsertOrUpdate.Add(myRec);
                
            }
            
            return response;
        }
                
        [MyMagoStudioMethodDecorator("ControlsEnabled", "Courses_ControlsEnabled")]
        public async Task<Courses_ControlsEnabledResponse> Courses_ControlsEnabled(Courses_ControlsEnabledRequest request, ContextInfo contextInfo, string callerDocId)
        {
            Courses_ControlsEnabledResponse response = new Courses_ControlsEnabledResponse();
            //...add your code here with some awaitable functions/methods ecc....
            //if (MyMagoStudioDocumentStatus.FormMode == DocumentFormMode.Edit)
            //{
            //    //response.pOut1.Value = new DateTimeOffset(request.pIn1.Year, request.pIn1.Month, request.pIn1.Day, 0, 0, 0, TimeSpan.Zero);
            //    response.StartDay_Out.Value = request.StartDay_In.Value;
            //    response.StartDay_Out.IsReadOnly = true;
            //}
            return response;
        }
                
        [MyMagoStudioMethodDecorator("DataInitialized", "Courses_DataInitialized")]
        public async Task<Courses_DataInitializedResponse> Courses_DataInitialized(Courses_DataInitializedRequest request, ContextInfo contextInfo, string callerDocId)
        {
            Courses_DataInitializedResponse response = new Courses_DataInitializedResponse();
            //...add your code here with some awaitable functions/methods ecc....
            response.CourseInfo_Days_Out = 1;
            return response;
        }
                
        
        [MyMagoStudioMethodDecorator("DataForTransactionChecked", "Courses_TransactionValidation")]
        public async Task<Courses_TransactionValidationResponse> Courses_TransactionValidation(Courses_TransactionValidationRequest request, ContextInfo contextInfo, string callerDocId)
        {
            Courses_TransactionValidationResponse response = new Courses_TransactionValidationResponse();
            //...add your code here with some awaitable functions/methods ecc....
            response.ResponseOK = (request.CourseLevel_In == Enums.Enums.CourseLevel.Expert ?  request.CourseInfo_Days_In > 2 : true);
            if (!response.ResponseOK)
                response.AddDiagnosticItem("Inconsistent data found. Cannot save!", Microarea.Interfaces.DiagnosticType.Error);  
            return response;
        }

        
       [MyMagoStudioMethodDecorator("RowPrepared", "BEDetails_RowPrepared", "IDD_EMPTYDOCUMENT_VIEW_COURSES_TM_2_COURSES_TG_2_COURSES_PANEL_1_COURSES_BE_1")]
        public async Task<BEDetails_RowPreparedResponse> BEDetails_RowPrepared(BEDetails_RowPreparedRequest request, ContextInfo contextInfo, string callerDocId)
        {
            BEDetails_RowPreparedResponse response = new BEDetails_RowPreparedResponse();
            //...add your code here with some awaitable functions/methods ecc....
            if (request.CoursesDetails_In is null || request.CoursesDetails_In.Count != 1)
                return response;

            MMS_CoursesDetails myRec = new MMS_CoursesDetails();
            myRec.f_CourseId.Value = request.CoursesDetails_In[0].f_CourseId.Value;
            myRec.f_Line.Value = request.CoursesDetails_In[0].f_Line.Value;
            myRec.f_Days.Value = request.CourseInfo_Days;
            response.CoursesDetails_Out.Behaviour = MyMagoStudioOneToManyResponseBase<MMS_CoursesDetails>.ApplyToDestination.Update;
            response.CoursesDetails_Out.RecordsToInsertOrUpdate.Add(myRec);
            response.TotalDays_Out = (short)(request.TotalDays_In + request.CourseInfo_Days);
            return response;
        }

        
        [MyMagoStudioMethodDecorator("ValueChanged", "DaysBE_ValueChanged", "IDD_EMPTYDOCUMENT_VIEW_COURSES_TM_2_COURSES_TG_2_COURSES_PANEL_1_COURSES_BE_1__DYN_COL_5")]
        public async Task<DaysBE_ValueChangedResponse> DaysBE_ValueChanged(DaysBE_ValueChangedRequest request, ContextInfo contextInfo, string callerDocId)
        {
            DaysBE_ValueChangedResponse response = new DaysBE_ValueChangedResponse();
            //...add your code here with some awaitable functions/methods ecc....
            if (request.CoursesDetails_In_OnlyOneRec is null || request.CoursesDetails_In_OnlyOneRec.Count != 1)
                return response;
            MMS_CoursesDetails myRec = new MMS_CoursesDetails();
            response.CoursesDetails_Out.Behaviour = MyMagoStudioOneToManyResponseBase<MMS_CoursesDetails>.ApplyToDestination.Update;
            myRec.f_CourseId.Value = request.CoursesDetails_In_OnlyOneRec[0].f_CourseId;
            myRec.f_Line.Value = request.CoursesDetails_In_OnlyOneRec[0].f_Line;
            short delta = 0;
            if (request.CoursesDetails_In_OnlyOneRec[0].f_Days.Value > request.CourseInfo_Days_In)
            {
                //put default value
                delta = (short)(request.CoursesDetails_In_OnlyOneRec[0].f_Days.Value - request.CourseInfo_Days_In);
                myRec.f_Days.Value = request.CourseInfo_Days_In;
                response.AddDiagnosticItem("Number of days is wrong!", Microarea.Interfaces.DiagnosticType.Warning);
            }
            else 
                myRec.f_Days.Value = request.CoursesDetails_In_OnlyOneRec[0].f_Days.Value;
            response.CoursesDetails_Out.RecordsToInsertOrUpdate.Add(myRec);

            //re-calculate totalDays
            if (request.CoursesDetails_In is not null || request.CoursesDetails_In.Count > 0)
            {
                foreach (var rec in request.CoursesDetails_In)
                {
                    if (rec is null)
                        continue;
                    response.TotalDays_Out += (short)rec.f_Days.Value;
                }
            }
            response.TotalDays_Out -= delta;
            //prova check primary keys
            //bool okCheck = CheckPrimaryKeys(request.CoursesDetails_In, response);

            return response;
        }

        
        [MyMagoStudioMethodDecorator("CanDeleteRow", "BEDetails_CanDeleteRow", "IDD_EMPTYDOCUMENT_VIEW_COURSES_TM_2_COURSES_TG_2_COURSES_PANEL_1_COURSES_BE_1")]
        public async Task<BEDetails_CanDeleteRowResponse> BEDetails_CanDeleteRow(BEDetails_CanDeleteRowRequest request, ContextInfo contextInfo, string callerDocId)
        {
            BEDetails_CanDeleteRowResponse response = new BEDetails_CanDeleteRowResponse();
            //...add your code here with some awaitable functions/ methods ecc....
            if (request.CoursesDetails_In is null || request.CoursesDetails_In.Count != 1)
                return response;
            response.TotalDays_Out = (short)(request.TotalDays_In - (short)request.CoursesDetails_In[0].f_Days.Value);

            return response;
        }

        
                [MyMagoStudioMethodDecorator("ValueChanged", "Teacher_ValueChanged", "IDD_EMPTYDOCUMENT_VIEW_COURSES_TM_2_COURSES_TG_1_COURSES_PANEL_1_COURSES_EDIT_2")]
        public async Task<Teacher_ValueChangedResponse> Teacher_ValueChanged(Teacher_ValueChangedRequest request, ContextInfo contextInfo, string callerDocId)
        {
            Teacher_ValueChangedResponse response = new Teacher_ValueChangedResponse();
            //...add your code here with some awaitable functions/methods ecc....
            response.TeacherComplete_Out = $"{request.HKLTeacher_In.f_Teacher.Value} - {request.HKLTeacher_In.f_Description.Value}";
            return response;
        }  
                

        #region MMS AUTOMATICALLY ADDS NEW METHODS HERE
        #endregion


    }
}