//This file is created automatically by MMS
//maintenance of this file will be done by programmer
//HIGHLY RECOMMENDED: 
//DON'T TOUCH THE METHODS DECORATORS; The decorators are used for update of this file!!!
//DON'T TOUCH MMS REGION

using Microarea.Tbf.Model.MyMagoStudioBase;
using System.Threading.Tasks;
using Microarea.Generic.DataObj;
using Microarea.Tbf.Model.Remote;
using System.Linq;
using Courses.Courses.Model;
using System.Security.Cryptography;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Connections;
using Courses.Courses.BO;
using Microarea.Generic.DiagnosticManager;
using Courses.Courses.Enums;
using Npgsql;
using System;
using Microsoft.EntityFrameworkCore.Storage;
using Microarea.Generic;
using System.Threading;

namespace CoursesCourses.GenerateNewCourses
{
    public partial class CoursesCoursesGenerateNewCourses : MyMagoStudioDocument
    {
        [MyMagoStudioMethodDecorator("ExtractData", "ExtractData")]
        public async Task<ExtractDataResponse> ExtractData(ExtractDataRequest request, ContextInfo contextInfo, string callerDocId)
        {
            ExtractDataResponse response = new ExtractDataResponse();
            ////...add your code here with some awaitable functions/methods ecc....
            bool applyFilter = request.Filter_In.Select.HasValue && request.Filter_In.Select.Value;
            string fromTeacher = string.IsNullOrEmpty(request.Filter_In.FromTeacher) ? string.Empty : request.Filter_In.FromTeacher;
            string toTeacher = string.IsNullOrEmpty(request.Filter_In.ToTeacher) ? string.Empty : request.Filter_In.ToTeacher;

            var allCoursesInfo = this.dbContext.DM_MMS_CoursesInfo.Where(c =>
                !applyFilter ? c.CourseId > 0 :
                c.Teacher.CompareTo(fromTeacher) >= 0 && c.Teacher.CompareTo(toTeacher) <= 0);
            var allTeachers = this.dbContext.DM_MMS_Teachers.Where(t => !string.IsNullOrEmpty(t.Teacher));
            var allCourses = this.dbContext.DM_MMS_Courses.Where(c => c.CourseId > 0)
                .Join(
                    allCoursesInfo,
                    courses => courses.CourseId,
                    info => info.CourseId,
                    (courses, info) => new
                    {
                        c = courses,
                        i = info
                    }
                );
            List<MMS_Courses_Virtual> completeCourses = new List<MMS_Courses_Virtual>();
            foreach (var courseComplete in allCourses)
            {
                MMS_Courses_Virtual myRec = new MMS_Courses_Virtual();
                myRec.CourseId = courseComplete.c.CourseId;
                myRec.CourseLevel = courseComplete.c.CourseLevel;
                myRec.Description = courseComplete.c.Description;
                myRec.PriceADay = courseComplete.i.PriceADay;
                myRec.Teacher = courseComplete.i.Teacher;
                myRec.Selected = false;

                completeCourses.Add(myRec);
            }
            var allCoursesTeachers = completeCourses.Join
                (
                    allTeachers,
                    courses => courses.Teacher,
                    teachers => teachers.Teacher,
                    (courses, teachers) => new
                    {
                        c = courses,
                        t = teachers
                    }
                );
            foreach (var courseComplete in completeCourses)
            {
                var foundTeacher = allCoursesTeachers.ToList().Find(t => t.t.Teacher.CompareTo(courseComplete.Teacher) == 0);
                if (foundTeacher is not null)
                    courseComplete.TeacherName = foundTeacher.t.Description;
            }
            response.Courses_Out.RecordsToInsertOrUpdate.AddRange(completeCourses);
            return response;
        }


        [MyMagoStudioMethodDecorator("BatchExecute", "BatchExecute")]
        public async Task<BatchExecuteResponse> BatchExecute(BatchExecuteRequest request, ContextInfo contextInfo, string callerDocId)
        {
            BatchExecuteResponse response = new BatchExecuteResponse();
            //...add your code here with some awaitable functions/methods ecc....

            CoursesCoursesCourses coursesDoc = await CoursesCoursesCourses.CreateUnattendedAsync(contextInfo/*, callerDocId*/);
            if (coursesDoc is null)
                return response;

            foreach (var course in request.Courses_In)
            {
                var coursesInfo = this.dbContext.DM_MMS_CoursesInfo.Where(row => row.CourseId == course.f_CourseId.Value).FirstOrDefault();
                var coursesDetails = this.dbContext.DM_MMS_CoursesDetails.Where(row => row.CourseId == course.f_CourseId.Value);
                var courses = this.dbContext.DM_MMS_Courses.Where(c => c.CourseId == course.f_CourseId.Value).FirstOrDefault();
                //coursesDoc.MasterTable.Record.f_CourseId.Value = course.f_CourseId.Value;
                if (!await coursesDoc.NewRecord(response))
                    continue;

                //valorizza il master
                coursesDoc.MasterTable.Record.f_CourseLevel.Value = courses.f_CourseLevel.Value;
                //await coursesDoc.FireValueChanged(coursesDoc.MasterTable, coursesDoc.MasterTable.Record.f_CourseLevel);

                coursesDoc.MasterTable.Record.f_Description.Value = $"{courses.f_Description.Value} - From copy";
                //await coursesDoc.FireValueChanged(coursesDoc.MasterTable, coursesDoc.MasterTable.Record.f_Description);

                coursesDoc.MasterTable.Record.f_Notes.Value = courses.f_Notes.Value;
                //await coursesDoc.FireValueChanged(coursesDoc.MasterTable, coursesDoc.MasterTable.Record.f_Notes);

                coursesDoc.MasterTable.Record.f_StartDate.Value = courses.f_StartDate.Value;//new System.DateTimeOffset(new System.DateTime(1799, 12, 31));
                //await coursesDoc.FireValueChanged(coursesDoc.MasterTable, coursesDoc.MasterTable.Record.f_StartDate);

                //valorizza l'info 1-1
                coursesDoc.MMS_CoursesInfo.Record.f_CourseId.Value = coursesInfo.f_CourseId.Value;

                //if (coursesDoc.MasterTable.Record.f_CourseLevel.Value == Enums.CourseLevel.Expert)
                //  coursesDoc.MMS_CoursesInfo.Record.f_Days.Value = 1;//coursesInfo.f_Days.Value;
                coursesDoc.MMS_CoursesInfo.Record.f_Days.Value = coursesInfo.f_Days.Value;
                await coursesDoc.FireValueChanged(coursesDoc.MMS_CoursesInfo, coursesDoc.MMS_CoursesInfo.Record.f_Days);

                coursesDoc.MMS_CoursesInfo.Record.f_Notes.Value = coursesInfo.f_Notes.Value;
                //await coursesDoc.FireValueChanged(coursesDoc.MMS_CoursesInfo, coursesDoc.MMS_CoursesInfo.Record.f_Notes);

                coursesDoc.MMS_CoursesInfo.Record.f_PriceADay.Value = coursesInfo.f_PriceADay.Value;
                //await coursesDoc.FireValueChanged(coursesDoc.MMS_CoursesInfo, coursesDoc.MMS_CoursesInfo.Record.f_PriceADay);

                coursesDoc.MMS_CoursesInfo.Record.f_Teacher.Value = coursesInfo.f_Teacher.Value;
                //await coursesDoc.FireValueChanged(coursesDoc.MMS_CoursesInfo, coursesDoc.MMS_CoursesInfo.Record.f_Teacher);

                //valorizza details 1-n
                foreach (var detail in coursesDetails)
                {
                    MMS_CoursesDetails myDetail = await coursesDoc.MMS_CoursesDetails.AddRow();
                    if (myDetail is null)
                        continue;

                    myDetail.f_CourseId.Value = coursesDoc.MasterTable.Record.f_CourseId.Value;
                    myDetail.f_Line.Value = detail.f_Line.Value;

                    myDetail.f_Notes.Value = detail.f_Notes.Value;
                    //await coursesDoc.FireValueChanged(coursesDoc.MMS_CoursesDetails, myDetail.f_Notes);

                    myDetail.f_Days.Value = 100;//detail.f_Days.Value;
                    await coursesDoc.FireValueChanged(coursesDoc.MMS_CoursesDetails, myDetail.f_Days);

                    myDetail.f_CustSuppType.Value = detail.f_CustSuppType.Value;
                    //await coursesDoc.FireValueChanged(coursesDoc.MMS_CoursesDetails, myDetail.f_CustSuppType);

                    myDetail.f_CustSupp.Value = detail.f_CustSupp.Value;
                    //await coursesDoc.FireValueChanged(coursesDoc.MMS_CoursesDetails, myDetail.f_CustSupp);

                    //doppiamo i corsi, ma i nuovi non devono essere invoiced
                    myDetail.f_Invoiced.Value = false;//detail.f_Invoiced.Value;
                    //await coursesDoc.FireValueChanged(coursesDoc.MMS_CoursesDetails, myDetail.f_Invoiced);

                }

                if (await coursesDoc.SaveRecord(response))
                    response.Courses_Out.RecordsToInsertOrUpdate.Add(course);
                //response.DiagnosticItems.AddRange(coursesDoc.Diagnostic.));
            }
            await coursesDoc.Close();
            return response;
        }


        //[MyMagoStudioMethodDecorator("Clicked", "ExampleCourse", "GENERATENEWCOURSES_toolbarTopButton_1")]
        //public async Task<ExampleCourseResponse> ExampleCourse(ExampleCourseRequest request, ContextInfo contextInfo, string callerDocId)
        //{
        //    ExampleCourseResponse response = new ExampleCourseResponse();
        //    //...add your code here with some awaitable functions/methods ecc....
        //    /*ERPBillOfMaterialsBillOfMaterials myBom =*/ 
        //    ERPBillOfMaterialsBillOfMaterials.CreateAttendedAsync(contextInfo, callerDocId);
        //    //myBom.MasterTable.Record.f_BOM.Value = "BEVDIS";
        //    //bool ok = await myBom.BrowseRecord(response);
        //    return response;
        //}


        //[MyMagoStudioMethodDecorator("Clicked", "ExampleCourse", "GENERATENEWCOURSES_toolbarTopButton_1")]
        //public async Task<ExampleCourseResponse> ExampleCourse(ExampleCourseRequest request, ContextInfo contextInfo, string callerDocId)
        //{
        //    ExampleCourseResponse response = new ExampleCourseResponse();
        //    //...add your code here with some awaitable functions/methods ecc....
        //    return response;
        //}

        private void OnChange(Object sender)
        {
            int myInt = 0;
        }

        [MyMagoStudioMethodDecorator("Clicked", "ManyTestsOnClick", "GENERATENEWCOURSES_toolbarTopButton_1")]
        public async Task<ManyTestsOnClickResponse> ManyTestsOnClick(ManyTestsOnClickRequest request, ContextInfo contextInfo, string callerDocId)
        {
            ManyTestsOnClickResponse response = new ManyTestsOnClickResponse();
            IDbContextTransaction transaction = null;
            //...add your code here with some awaitable functions/methods ecc....
            int rows = 0;

            ////esempio update
            //try
            //{
            //    int nCourse = 1;
            //    var courseToUpdate = this.dbContext.DM_MMS_Courses.Where(c => c.CourseId == nCourse).FirstOrDefault();
            //    if (courseToUpdate is not null)
            //    {
            //        courseToUpdate.Description = "Course 5 from update db";
            //        dbContext.DM_MMS_Courses.Update(courseToUpdate);
            //        rows = this.dbContext.SaveChanges();
            //    }
            //    else
            //        response.AddDiagnosticItem($"CourseId {nCourse} doesn't exist!", Microarea.Interfaces.DiagnosticType.Warning);
            //}
            //catch (Exception e)
            //{
            //    response.AddDiagnosticItem(e.ToString(), Microarea.Interfaces.DiagnosticType.FatalError);
            //}

            ////esempio insert
            //try
            //{
            //    MMS_Courses myRec = new MMS_Courses();
            //    myRec.CourseId = 100;
            //    myRec.Description = "Course new from DM insert";
            //    dbContext.DM_MMS_Courses.Add(myRec);
            //    rows = this.dbContext.SaveChanges();
            //    response.AddDiagnosticItem(rows != 1 ? "Insert wasn't executed!" : "Insert was correctly executed!", Microarea.Interfaces.DiagnosticType.Information);
            //}
            //catch (Exception e)
            //{
            //    response.AddDiagnosticItem(e.ToString(), Microarea.Interfaces.DiagnosticType.FatalError);
            //}

            ////esempio delete
            //try
            //{
            //    //var courseToDelete = this.dbContext.DM_MMS_Courses.Where(c => c.CourseId == 160).FirstOrDefault();
            //    var courseToDelete = new MMS_Courses();
            //    courseToDelete.CourseId = 160;
            //    if (courseToDelete is not null)
            //    {
            //        dbContext.DM_MMS_Courses.Remove(courseToDelete);
            //        rows = this.dbContext.SaveChanges();
            //    }
            //}
            //catch (Exception e)
            //{
            //    response.AddDiagnosticItem(e.ToString(), Microarea.Interfaces.DiagnosticType.FatalError);
            //}

            ////esempio update/insert con transaction
            //try
            //{
            //    //transaction = dbContext.Database.BeginTransaction();
            //    //if (transaction is not null)
            //    //{
            //        MMS_Courses myRec = new MMS_Courses();
            //        myRec.CourseId = 160;
            //        myRec.Description = "Course 160 new from DM insert";
            //        dbContext.DM_MMS_Courses.Add(myRec);
            //        rows = dbContext.SaveChanges();
            //        myRec = new MMS_Courses();
            //        myRec.CourseId = 161;
            //        myRec.Description = "Course 161 new from DM insert";
            //        dbContext.DM_MMS_Courses.Add(myRec);
            //        rows = dbContext.SaveChanges();
            //        transaction.Commit();
            //    //}
            //}
            //catch (Exception e)
            //{
            //    //if (transaction is not null)
            //    //    transaction.Rollback();
            //    response.AddDiagnosticItem(e.ToString(), Microarea.Interfaces.DiagnosticType.FatalError);
            //}
            //finally
            //{
            //    //if (transaction is not null)
            //    //    transaction.Dispose();
            //}

            ////esempio autocommit
            //MMS_Courses myRec = new MMS_Courses();
            //myRec.CourseId = 160;
            //myRec.Description = "Course 160 new from DM insert";
            //AutoComitModifies(response, myRec);

            //myRec = new MMS_Courses();
            //myRec.CourseId = 161;
            //myRec.Description = "Course 161 new from DM insert";
            //AutoComitModifies(response, myRec);
            ////

            //run standartd document as BO in insert record
            ERPCompanyActivityCodes activityCodes = await ERPCompanyActivityCodes.CreateAttendedAsync(contextInfo, callerDocId);
            activityCodes.MasterTable.Record.f_ActivityCode.ValueChanged += OnChange;
            //if (activityCodes is null)
            //    return response;
            //Thread.Sleep(2000);
            activityCodes.MasterTable.Record.f_ActivityCode.Value = "000000"; //"99XXX"; //"99100" ;
            await activityCodes.BrowseRecord(response);
            //ERPBillOfMaterialsBillOfMaterials erpBOM = await ERPBillOfMaterialsBillOfMaterials.CreateAttendedAsync(contextInfo, callerDocId);
            //if (erpBOM is null)
            //    return response;
            ////Thread.Sleep(2000);
            //erpBOM.MasterTable.Record.f_BOM.Value = "BEVDIS"; //"99XXX"; //"99100" ;
            ////erpBOM.intruso = true;
            //await erpBOM.BrowseRecord(response);
            //if (await activityCodes.EditRecord(response))
            //{
            //    await activityCodes.FireValueChanged(activityCodes.MasterTable, activityCodes.MasterTable.Record.f_ActivityCode);
            //    activityCodes.MasterTable.Record.f_Description.Value = "000000 bzz";
            //    await activityCodes.FireValueChanged(activityCodes.MasterTable, activityCodes.MasterTable.Record.f_Description);
            //    await activityCodes.SaveRecord(response);
            //}
            ////////await activityCodes.Next();
            //activityCodes.MasterTable.Record.f_ActivityCode.Value = "99100"; 
            //if (await activityCodes.EditRecord(response))
            //{
            //    await activityCodes.FireValueChanged(activityCodes.MasterTable, activityCodes.MasterTable.Record.f_ActivityCode);
            //    activityCodes.MasterTable.Record.f_Description.Value = $"{activityCodes.MasterTable.Record.f_ActivityCode.Value} bzz";
            //    await activityCodes.FireValueChanged(activityCodes.MasterTable, activityCodes.MasterTable.Record.f_Description);
            //    await activityCodes.SaveRecord(response);
            //}
            //////await activityCodes.Prev();
            //////await activityCodes.Prev();
            //////await activityCodes.Next();
            //if (!await activityCodes.NewRecord(response))
            //    return response;
            //activityCodes.MasterTable.Record.f_ActivityCode.Value = "000000"; //"99XXX"; //"99100" ;
            ////activityCodes.MasterTable.Record.f_Description.Value = "99100 - Proposto from BO";
            //await activityCodes.EditRecord(response);

            ////prova cattiva
            //activityCodes = await ERPCompanyActivityCodes.CreateAttendedAsync(contextInfo, callerDocId);
            //if (activityCodes is null)
            //    return response;
            //activityCodes.MasterTable.Record.f_ActivityCode.Value = "99100"; //"99XXX"; //"99100" ;
            //await activityCodes.EditRecord(response);

            ////activityCodes.MasterTable.Record.f_Description.Value = "99100 - Ins from BO";
            ////await activityCodes.FireValueChanged(activityCodes.MasterTable, activityCodes.MasterTable.Record.f_Description, "IDC_DESCRIPTION");
            ////await activityCodes.SaveRecord(response);

            return response;
        }

        private bool AutoComitModifies(ManyTestsOnClickResponse response, MMS_Courses myRec)
        {
            int rows = 0;
            if (myRec is null)
                return false;
            try
            {
                dbContext.DM_MMS_Courses.Add(myRec);
                rows = dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                response.AddDiagnosticItem($"Row with key CourseId={myRec.CourseId} is not added!", Microarea.Interfaces.DiagnosticType.Warning);
                return false;
            }
            
            return true;
        }

        [MyMagoStudioMethodDecorator("DataForTransactionChecked", "FiltersValidate")]
        public async Task<FiltersValidateResponse> FiltersValidate(FiltersValidateRequest request, ContextInfo contextInfo, string callerDocId)
        {
            FiltersValidateResponse response = new FiltersValidateResponse();
            //...add your code here with some awaitable functions/methods ecc....
            if (string.IsNullOrEmpty(request.Filter_In.FromTeacher) && string.IsNullOrEmpty(request.Filter_In.ToTeacher))
                response.ResponseOK = true;
            else
                response.ResponseOK = request.Filter_In.FromTeacher.CompareTo(request.Filter_In.ToTeacher) <= 0;
            if (!response.ResponseOK)
                response.AddDiagnosticItem("Filter is not valid!", Microarea.Interfaces.DiagnosticType.Error);

            return response;
        }

        #region MMS AUTOMATICALLY ADDS NEW METHODS HERE
        #endregion





    }
}