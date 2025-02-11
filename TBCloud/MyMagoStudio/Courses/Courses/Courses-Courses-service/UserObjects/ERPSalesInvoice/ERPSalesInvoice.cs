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
using System.Reflection.PortableExecutable;
using Courses.Courses.Model;
using Courses.Courses.Enums;
using System;

namespace ERPSales.Invoice
{
    public partial class ERPSalesInvoice : MyMagoStudioDocument
    {
        [MyMagoStudioMethodDecorator("CanDoClick", "LoadCourses_CanDoClick", "CDINVOICE_toolbarTopButton_1")]
        public async Task<LoadCourses_CanDoClickResponse> LoadCourses_CanDoClick(LoadCourses_CanDoClickRequest request, ContextInfo contextInfo, string callerDocId)
        {
            LoadCourses_CanDoClickResponse response = new LoadCourses_CanDoClickResponse();
            //...add your code here with some awaitable functions/methods ecc....
            response.ResponseOK = MyMagoStudioDocumentStatus.FormMode == DocumentFormMode.New;
            return response;
        }

        
        [MyMagoStudioMethodDecorator("Clicked", "LoadCourses_Clicked", "CDINVOICE_toolbarTopButton_1")]
        public async Task<LoadCourses_ClickedResponse> LoadCourses_Clicked(LoadCourses_ClickedRequest request, ContextInfo contextInfo, string callerDocId)
        {
            LoadCourses_ClickedResponse response = new LoadCourses_ClickedResponse();
            if (string.IsNullOrEmpty(request.CustSupp_In))
            {
                response.AddDiagnosticItem("Customer is empty. Select before a Customer!", Microarea.Interfaces.DiagnosticType.Error);
            }
            //...add your code here with some awaitable functions/methods ecc....
            //select I.CourseId, I.PriceADay, H.StartDate from MMS_Courses H inner join  MMS_CoursesInfo I
            //on H.CourseId = I.CourseId
            var courses = dbContext.DM_MMS_Courses1.Where(row => row.CourseId > 0).Join(
                dbContext.DM_MMS_CoursesInfo.Where(c => c.CourseId > 0),
                cHeader => cHeader.CourseId,
                cInfo => cInfo.CourseId,
                (cHeader, cInfo) => new 
                    {
                        CourseId = cInfo.CourseId,
                        PriceADay = cInfo.PriceADay,
                        StartDate = cHeader.StartDate
                    }
                );

            //
            var coursesDetails = dbContext.DM_MMS_CoursesDetails.Where(c => 
                c.CustSuppType == request.CustSuppType_In && c.CustSupp.CompareTo(request.CustSupp_In) == 0 && !c.Invoiced.Value)
                .Join(
                    courses,
                    cDetails => cDetails.CourseId,
                    cHeader => cHeader.CourseId,
                    (cDetails, cHeader) => new
                    {
                        CourseId = cDetails.CourseId,
                        Line = cDetails.Line,
                        Days = cDetails.Days,
                        PriceADay = cHeader.PriceADay,
                        StartDate = cHeader.StartDate,
                    }
                );
            if (coursesDetails is null)
                return response;
            if (response.Detail_Out.RecordsToInsertOrUpdate is null)
                response.Detail_Out.RecordsToInsertOrUpdate = new System.Collections.Generic.List<Courses.Courses.Model.MA_SaleDocDetail>();
            foreach (var courseDetails in coursesDetails)
            {
                if (courseDetails is null)
                    continue;
                MA_SaleDocDetail myDetail = new MA_SaleDocDetail();
                myDetail.f_LineType.Value = Enums.Line_Type.Service;
                myDetail.f_Item.Value = string.Empty;
                myDetail.f_Description.Value = $"Course {courseDetails.CourseId} in date {courseDetails.StartDate} during days {courseDetails.Days}";
                myDetail.f_UoM.Value = "Pers";
                myDetail.f_Qty.Value = (double)courseDetails.Days;
                myDetail.f_UnitValue.Value = (double)courseDetails.PriceADay;
                myDetail.f_TaxCode.Value = "20";
                response.Detail_Out.RecordsToInsertOrUpdate.Add(myDetail);
            }
            return response;
        }

        
        [MyMagoStudioMethodDecorator("ValueChanged", "Customer_ValueChanged", "IDC_DOC_CUSTSUPP")]
        public async Task<Customer_ValueChangedResponse> Customer_ValueChanged(Customer_ValueChangedRequest request, ContextInfo contextInfo, string callerDocId)
        {
            Customer_ValueChangedResponse response = new Customer_ValueChangedResponse();
            //...add your code here with some awaitable functions/methods ecc....
            return response;
        }

        
        [MyMagoStudioMethodDecorator("ExtraTransacting", "Invoice_ExtraTransacting")]
        public async Task<Invoice_ExtraTransactingResponse> Invoice_ExtraTransacting(Invoice_ExtraTransactingRequest request, ContextInfo contextInfo, string callerDocId)
        {
            Invoice_ExtraTransactingResponse response = new Invoice_ExtraTransactingResponse();
            //...add your code here with some awaitable functions/methods ecc....
            int rows = 0;
            if (MyMagoStudioDocumentStatus.FormMode != DocumentFormMode.New)
                return response;

            if (string.IsNullOrEmpty(request.CustSupp_In) || 
                request.CustSuppType_In != Enums.CustSupp_Type.Customer && request.CustSuppType_In   != Enums.CustSupp_Type.Supplier)
            {
                response.ResponseOK = false;
                response.AddDiagnosticItem("CustSupp or CustSuppType errato/missing!", Microarea.Interfaces.DiagnosticType.Error);
            }

            var coursesDetails = dbContext.DM_MMS_CoursesDetails.Where(c =>
                c.CustSuppType == request.CustSuppType_In && c.CustSupp.CompareTo(request.CustSupp_In) == 0 && c.Invoiced.HasValue && !c.Invoiced.Value);
            if (coursesDetails is null)
                return  response;

            foreach (var courseDetails in coursesDetails)
            {
                if (courseDetails is null)
                    continue;
                courseDetails.Invoiced = true;
                
            }
            try
            {
                dbContext.DM_MMS_CoursesDetails.UpdateRange(coursesDetails.ToArray());
                rows = await dbContext.SaveChangesAsync();
                response.AddDiagnosticItem($"{rows} rows was updated!", Microarea.Interfaces.DiagnosticType.Information);
            }
            catch (Exception e)
            {
                response.ResponseOK = false;
                response.AddDiagnosticItem(e.ToString(), Microarea.Interfaces.DiagnosticType.Error);
            }
            
            return response;
        }

        #region MMS AUTOMATICALLY ADDS NEW METHODS HERE
        #endregion
    }
}