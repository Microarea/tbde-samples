//This file is created automatically by MMS
//maintenance of this file will be done by programmer
//HIGHLY RECOMMENDED: 
//DON'T TOUCH THE METHODS DECORATORS; The decorators are used for update of this file!!!
//DON'T TOUCH MMS REGION

using Microarea.Tbf.Model.MyMagoStudioBase;
using System.Threading.Tasks;
using Microarea.Generic.DataObj;
using Microarea.Tbf.Model.Remote;
using Courses.Courses.Model;

namespace Courses.Courses.Courses
{
    public partial class CoursesCoursesCourses : MyMagoStudioDocument
    {
        [MyMagoStudioMethodDecorator("ControlsEnabled", "CourseCE")]
        public async Task<CourseCEResponse> CourseCE(CourseCERequest request, ContextInfo contextInfo, string callerDocId)
        {
            CourseCEResponse response = new CourseCEResponse();
            //...add your code here with some awaitable functions/methods ecc....

            if( MyMagoStudioDocumentStatus.FormMode != DocumentFormMode.New )
            {
                response.CourseDateOUT.IsReadOnly = true;
                response.CourseDateOUT.Value = request.CourseDateIN;
            }

            return response;
        }

        
                [MyMagoStudioMethodDecorator("ValueChanged", "CourseLevelVC", "IDD_EMPTYDOCUMENT_VIEW_COURSES_TG_1_COURSES_PANEL_1_COURSES_CMB_4")]
        public async Task<CourseLevelVCResponse> CourseLevelVC(CourseLevelVCRequest request, ContextInfo contextInfo, string callerDocId)
        {
            CourseLevelVCResponse response = new CourseLevelVCResponse();
            //...add your code here with some awaitable functions/methods ecc....

            switch(request.CourseLevelIN)
            {
                case Enums.Enums.CourseLevel.Base:
                    response.CourseDaysOUT = 1;
                    break;
                case Enums.Enums.CourseLevel.Advanced:
                    response.CourseDaysOUT = 2;
                    break;
                case Enums.Enums.CourseLevel.Expert:
                    response.CourseDaysOUT = 3;
                    break;
            }


            return response;
        }

        [MyMagoStudioMethodDecorator("DataForTransactionChecked", "CourseDFTC")]
        public async Task<CourseDFTCResponse> CourseDFTC(CourseDFTCRequest request, ContextInfo contextInfo, string callerDocId)
        {
            CourseDFTCResponse response = new CourseDFTCResponse();
            //...add your code here with some awaitable functions/methods ecc....

            if(request.CourseLevelIN == Enums.Enums.CourseLevel.Expert && request.CourseDaysIN < 3)
            {
                response.AddDiagnosticItem("Attenzione: Livello e durata del corso non congruenti!", Microarea.Interfaces.DiagnosticType.Error);
                response.ResponseOK = false;
            }


            return response;
        }

        
                [MyMagoStudioMethodDecorator("HotlinkValidate", "TeacherValidated", "IDD_EMPTYDOCUMENT_VIEW_COURSES_TM_2_COURSES_TG_1_COURSES_LAYOUT_CONTAINER_1_COURSES_Tile_2_COURSES_EDIT_3")]
        public async Task<TeacherValidatedResponse> TeacherValidated(TeacherValidatedRequest request, ContextInfo contextInfo, string callerDocId)
        {
            TeacherValidatedResponse response = new TeacherValidatedResponse();
            //...add your code here with some awaitable functions/methods ecc....

            if (request.TeacherIN.f_Disabled.Value == true)
                response.AddDiagnosticItem("Valore selezionato NON valido!", Microarea.Interfaces.DiagnosticType.Error);

            response.ResponseOK = true;


            return response;
        }

        [MyMagoStudioMethodDecorator("ValueChanged", "CustSuppTypeVC", "IDD_EMPTYDOCUMENT_VIEW_COURSES_TM_2_COURSES_TG_2_COURSES_PANEL_1_COURSES_BE_1__DYN_COL_2")]
        public async Task<CustSuppTypeVCResponse> CustSuppTypeVC(CustSuppTypeVCRequest request, ContextInfo contextInfo, string callerDocId)
        {
            CustSuppTypeVCResponse response = new CustSuppTypeVCResponse();
            //...add your code here with some awaitable functions/methods ecc....

            response.CurrentRowOUT.Behaviour = MyMagoStudioOneToManyResponseBase<Model.MMS_CoursesDetails>.ApplyToDestination.Update;

            if (response.CurrentRowOUT.RecordsToInsertOrUpdate is null)
                response.CurrentRowOUT.RecordsToInsertOrUpdate = new System.Collections.Generic.List<Model.MMS_CoursesDetails>();

            MMS_CoursesDetails rowToModify = new MMS_CoursesDetails();

            rowToModify.f_CourseID.Value = request.CurrentRowIN[0].f_CourseID.Value;
            rowToModify.f_Line.Value = request.CurrentRowIN[0].f_Line.Value;

            rowToModify.f_CustSuppType.Value = request.CurrentRowIN[0].f_CustSuppType.Value;

            rowToModify.f_CustSupp.Value = string.Empty;
            rowToModify.f_CustSupp.IsModified = true;

            if (request.CurrentRowIN[0].f_CustSuppType.Value == Enums.Enums.CustSupp_Type.Customer)
                rowToModify.f_CustSuppTypeToInt.Value = 0;
            else rowToModify.f_CustSuppTypeToInt.Value = 1;

            rowToModify.f_CustSuppTypeToInt.IsModified = true;

            response.CurrentRowOUT.RecordsToInsertOrUpdate.Add(rowToModify);

            return response;
        }

        [MyMagoStudioMethodDecorator("DataLoaded", "CourseDL")]
        public async Task<CourseDLResponse> CourseDL(CourseDLRequest request, ContextInfo contextInfo, string callerDocId)
        {
            CourseDLResponse response = new CourseDLResponse();
            //...add your code here with some awaitable functions/methods ecc....

            response.BodyEditOUT.Behaviour = MyMagoStudioOneToManyResponseBase<Model.MMS_CoursesDetails>.ApplyToDestination.Update;

            if (request.BodyEditIN is null || request.BodyEditIN.Count == 0) return response;

            if (response.BodyEditOUT.RecordsToInsertOrUpdate is null)
                response.BodyEditOUT.RecordsToInsertOrUpdate = new System.Collections.Generic.List<Model.MMS_CoursesDetails>();

            foreach(var singleRow in request.BodyEditIN)
            {
                if(singleRow is null) continue;

                MMS_CoursesDetails rowToModify = new MMS_CoursesDetails();

                rowToModify.f_CourseID.Value = singleRow.f_CourseID.Value;
                rowToModify.f_Line.Value = singleRow.f_Line.Value;

                rowToModify.f_CustSuppTypeToInt.Value = singleRow.f_CustSuppType.Value == Enums.Enums.CustSupp_Type.Customer ? 0 : 1;

                rowToModify.f_CustSuppTypeToInt.IsModified = true;

                response.BodyEditOUT.RecordsToInsertOrUpdate.Add(rowToModify);


            }



            return response;
        }

        #region MMS AUTOMATICALLY ADDS NEW METHODS HERE
        #endregion


    }
}