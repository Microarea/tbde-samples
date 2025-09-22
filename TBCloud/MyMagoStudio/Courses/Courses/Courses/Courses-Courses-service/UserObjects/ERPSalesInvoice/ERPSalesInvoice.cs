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
using Courses.Courses.Enums;
using System;
using Courses.Courses.BO;
using Microarea.Tbf.Model.Interfaces.DataManager;

namespace ERPSales.Invoice
{
    public partial class ERPSalesInvoice : MyMagoStudioDocument
    {
        [MyMagoStudioMethodDecorator("CanDoClick", "LoadButtonCDC", "CDINVOICE_toolbarTopButton_1")]
        public async Task<LoadButtonCDCResponse> LoadButtonCDC(LoadButtonCDCRequest request, ContextInfo contextInfo, string callerDocId)
        {
            LoadButtonCDCResponse response = new LoadButtonCDCResponse();
            //...add your code here with some awaitable functions/methods ecc....

            if (MyMagoStudioDocumentStatus.FormMode != DocumentFormMode.New)
                response.ResponseOK = false;

            return response;
        }

        [MyMagoStudioMethodDecorator("Clicked", "LoadButtonC", "CDINVOICE_toolbarTopButton_1")]
        public async Task<LoadButtonCResponse> LoadButtonC(LoadButtonCRequest request, ContextInfo contextInfo, string callerDocId)
        {
            LoadButtonCResponse response = new LoadButtonCResponse();
            //...add your code here with some awaitable functions/methods ecc....


            var query = new Query
            {
                TableName = "MA_CustSupp",
                SelectedFields = ["*"]
            };
            var prova = await APICaller.QuerySelect(query);

            //SELECT
            //    cd.CourseID,
            //    cd.Line,
            //    ci.CoursePrice AS PriceADay,
            //    ci.CourseDays,
            //    c.CourseDate AS StartDate
            //FROM
            //    MMS_CoursesDetails cd
            //INNER JOIN
            //    MMS_CoursesInfo ci ON cd.CourseID = ci.CourseID
            //INNER JOIN
            //    MMS_Courses c ON cd.CourseID = c.CourseID
            //WHERE
            //    COALESCE(cd.Invoiced, '0') = '0' AND
            //    cd.CustSuppType = @CustSuppTypeIN AND
            //    cd.CustSupp = @CustSuppIN;

            var courseList = dbContext.DM_MMS_CoursesDetails
                .Where(cd =>
                !cd.Invoiced.Value
                && cd.CustSuppType == request.CustSuppTypeIN
                && cd.CustSupp == request.CustSuppIN)
                .Join(dbContext.DM_MMS_CoursesInfo,
                    cd => cd.CourseID,
                    ci => ci.CourseID,
                    (cd, ci) => new { cd, ci })
                .Join(dbContext.DM_MMS_Courses,
                    temp => temp.cd.CourseID,
                    c => c.CourseID,
                    (temp, c) => new
                    {
                        CourseID = c.CourseID,
                        Line = temp.cd.Line,
                        PriceADay = temp.ci.CoursePrice,
                        CourseDays = temp.ci.CourseDays,
                        StartDate = c.CourseDate

                    });

            // Se query e` null torno la resposnse
            if (courseList is null)
                return response;

            // Se la lista di righe da inserire nel documento di vendita non e` inizializzata la istanzio
            if (response.SaleDocDetailsOUT.RecordsToInsertOrUpdate is null)
                response.SaleDocDetailsOUT.RecordsToInsertOrUpdate = new System.Collections.Generic.List<Courses.Courses.Model.MA_SaleDocDetail>();

            // Ciclo i risultati della query
            foreach (var course in courseList)
            {
                if (course is null) continue;

                // Modello della griglia SalDocDetails
                MA_SaleDocDetail row = new MA_SaleDocDetail();

                row.EnableValueChangedChain = true;
                row.f_LineType.Value = Enums.Line_Type.Service; // Stiamo fatturando un servizio
                row.f_Item.Value = string.Empty; // Non abbiamo un item code
                row.f_Item.EmitValueChanged = true;
                row.f_Description.Value = $"Corso {course.CourseID} iniziato in data {course.CourseDays}";
                row.f_UoM.Value = "Pers";
                row.f_DiscountFormula.Value = "15";
                row.f_DiscountFormula.EmitValueChanged = true;
                row.f_Qty.Value = (double)course.CourseDays; // Numero dei giorni
                //row.f_Qty.EmitValueChanged = true;
                row.f_UnitValue.Value = (double)course.PriceADay; // Prezzo per giorno
                row.f_UnitValue.EmitValueChanged = true;
                row.f_TaxCode.Value = "22"; // IVA
                row.f_TaxCode.EmitValueChanged = true;

                // Mando la mia row in response come record da inserire nel BE
                response.SaleDocDetailsOUT.RecordsToInsertOrUpdate.Add(row);

                // Aggiungo l'ID del corso alla lista statica in Shared
                Shared.Shared.AddCourseId(course.CourseID);

            }

            return response;
        }

        
        [MyMagoStudioMethodDecorator("ExtraTransacting", "InvoiceET")]
        public async Task<InvoiceETResponse> InvoiceET(InvoiceETRequest request, ContextInfo contextInfo, string callerDocId)
        {
            InvoiceETResponse response = new InvoiceETResponse();
            //...add your code here with some awaitable functions/methods ecc....

            int rows = 0;
            // Se non sono in stato di New response secca ed esco
            if (MyMagoStudioDocumentStatus.FormMode != DocumentFormMode.New)
                return response;

            // Verifico che i parametri in request siano valorizzati correttamente
            if (string.IsNullOrEmpty(request.CustSuppIN) ||
                request.CustSuppTypeIN != Enums.CustSupp_Type.Customer)
            {
                response.ResponseOK = false;
                response.AddDiagnosticItem("Attenzione: CustSupp o CustSuppType errato / mancante!", Microarea.Interfaces.DiagnosticType.Error);
            }

            var addedCourseIds = Shared.Shared.GetAddedCourseIds();

            //SELECT *
            //FROM 
            //    MMS_CoursesDetails cd
            //WHERE
            //    cd.CourseID IN(@AddedCourseId1, @AddedCourseId2, ..., @AddedCourseIdN) AND
            //    cd.CustSuppType = @CustSuppTypeIN AND
            //    cd.CustSupp = @CustSuppIN AND
            //    cd.Invoiced IS NOT NULL AND
            //    cd.Invoiced = 0;

            // Query per ottenere i corsi da fatturare in base a CustSuppType, CustSupp e se non sono ancora fatturati
            var coursesToInvoice = dbContext.DM_MMS_CoursesDetails.Where(cd =>
                addedCourseIds.Contains(cd.CourseID)
                && cd.CustSuppType == request.CustSuppTypeIN
                && cd.CustSupp.CompareTo(request.CustSuppIN) == 0
                && cd.Invoiced.HasValue
                && !cd.Invoiced.Value);

            if(coursesToInvoice is null)
                return response;

            // Iterazione tra il risultato della query per impostare invoiced a true
            foreach (var record in coursesToInvoice)
            {
                if (record is null)
                    continue;

                record.Invoiced = true;
            }

            try
            {
                dbContext.DM_MMS_CoursesDetails.UpdateRange(coursesToInvoice.ToArray()); // Metodo UpdateRange di Entity Framework
                // ToArray() converte coursesToInvoice in un array, che e` il formato atteso da UpdateRange.
                rows = await dbContext.SaveChangesAsync();  // SaveChangesAsync ritorna le modifiche affected e valorizzo il mio contatore.
                response.AddDiagnosticItem($"{rows} righe aggiornate", Microarea.Interfaces.DiagnosticType.Information);
            }
            catch (Exception e)
            {
                response.ResponseOK = false;
                response.AddDiagnosticItem(e.ToString(), Microarea.Interfaces.DiagnosticType.Error); // Se Exepcion diagnostica dell' eccezione
            }

            Shared.Shared.ClearCourseIds();

            return response;
        }

        
        [MyMagoStudioMethodDecorator("Clicked", "OpenCoursesC", "CDINVOICE_toolbarTopButton_2")]
        public async Task<OpenCoursesCResponse> OpenCoursesC(OpenCoursesCRequest request, ContextInfo contextInfo, string callerDocId)
        {
            OpenCoursesCResponse response = new OpenCoursesCResponse();
            //...add your code here with some awaitable functions/methods ecc....

            // Ottengo la lista degli ID dei corsi aggiunti ai dettagli del documento di vendita
            // La lista viene filtrata e rimuovo eventuali duplicati
            var coursesIds = Shared.Shared.GetAddedCourseIds()?.Distinct().ToList();
            if(coursesIds.Count == 0 || coursesIds is null)
                return response;

            // Itero la lista di ID dei corsi
            foreach (var coursesId in coursesIds)
            {
                var doc = await CoursesCoursesCourses.CreateAttendedAsync(contextInfo, callerDocId);
                if (doc is null)
                {
                    response.AddDiagnosticItem($"Errore durante istanziazione nel ciclo, doc {coursesId}", Microarea.Interfaces.DiagnosticType.Error);
                    continue;
                }
                doc.MasterTable.Record.f_CourseID.Value = coursesId;
                // Eseguo il browse del documento
                var browseOK = await doc.BrowseRecord(response);
                // Se il browse fallisce aggiungo una diagnostica
                if (!browseOK)
                {
                    response.AddDiagnosticItem($"Errore in Browse del documento {coursesId}", Microarea.Interfaces.DiagnosticType.Error);
                    continue;
                }
                // Infine comunico in diagnostica quale record ho aperto
                response.AddDiagnosticItem($"Documento {coursesId} aperto", Microarea.Interfaces.DiagnosticType.Information);
            }

                return response;
        }

        #region MMS AUTOMATICALLY ADDS NEW METHODS HERE
        #endregion


    }
}