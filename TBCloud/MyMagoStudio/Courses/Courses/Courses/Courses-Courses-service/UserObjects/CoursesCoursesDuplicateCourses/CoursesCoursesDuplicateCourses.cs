//This file is created automatically by MMS
//maintenance of this file will be done by programmer
//HIGHLY RECOMMENDED: 
//DON'T TOUCH THE METHODS DECORATORS; The decorators are used for update of this file!!!
//DON'T TOUCH MMS REGION

using Courses.Courses.BO;
using Courses.Courses.Model;
using Microarea.Generic.DataObj;
using Microarea.Tbf.Model.MyMagoStudioBase;
using Microarea.Tbf.Model.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesCourses.DuplicateCourses
{
    public partial class CoursesCoursesDuplicateCourses : MyMagoStudioDocument
    {
        [MyMagoStudioMethodDecorator("DataForTransactionChecked", "DuplicateCoursesDFTC")]
        public async Task<DuplicateCoursesDFTCResponse> DuplicateCoursesDFTC(DuplicateCoursesDFTCRequest request, ContextInfo contextInfo, string callerDocId)
        {
            DuplicateCoursesDFTCResponse response = new DuplicateCoursesDFTCResponse();
            //...add your code here with some awaitable functions/methods ecc....

            bool applyAll = request.FiltersIN.f_All;
            bool applyFilter = request.FiltersIN.f_Select;
            string from = request.FiltersIN.f_FromTeacher;
            string to = request.FiltersIN.f_ToTeacher;

            // Se viene checkato Select, check sui filtri
            if (applyFilter)
            {
                if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                {
                    response.ResponseOK = false;
                    response.AddDiagnosticItem("Valorizza From e To", Microarea.Interfaces.DiagnosticType.Error);
                }
                else if (from.CompareTo(to) > 0)
                {
                    response.ResponseOK = false;
                    response.AddDiagnosticItem("Filtri non congruenti", Microarea.Interfaces.DiagnosticType.Error);
                }

            }
            // Se viene selezionato ALL, nessun check su filtri
            else if (applyAll)
                response.ResponseOK = true;

            // Se arriviamo qui non abbiamo selezionato n� ALL n� Select - quindi KO
            else
            {
                response.ResponseOK = false;
                response.AddDiagnosticItem("Selezionare una tipologia di estrazione", Microarea.Interfaces.DiagnosticType.Error);
            }

            return response;
        }

        [MyMagoStudioMethodDecorator("ExtractData", "DuplicateCoursesED")]
        public async Task<DuplicateCoursesEDResponse> DuplicateCoursesED(DuplicateCoursesEDRequest request, ContextInfo contextInfo, string callerDocId)
        {
            DuplicateCoursesEDResponse response = new DuplicateCoursesEDResponse();
            //...add your code here with some awaitable functions/methods ecc....

            // recupero se checkato Select ed l' eventuale valore dei filtri 
            bool applyFilter = request.FiltersIN.Select.HasValue && request.FiltersIN.Select.Value;
            string fromTeacher = request.FiltersIN.FromTeacher;
            string toTeacher = request.FiltersIN.ToTeacher;

            // select c.*, ci.*
            // from MMS_Courses c inner join MMS_CoursesInfo ci
            // ON c.CourseID = ci.CourseID
            // where c.CourseID > 0 AND ci. CourseTeacher is not null AND
            // (@ApplyFilter = 0 OR (ci.CourseTeacher >= @FromTeacher AND ci.CourseTeacher <= @ToTeacher))
            // ORDER BY c.CourseID
            var courses = dbContext.DM_MMS_Courses.Where(c =>
            c.CourseID > 0)
                .Join(dbContext.DM_MMS_CoursesInfo.Where(ci =>
                !string.IsNullOrEmpty(ci.CourseTeacher)
                && (!applyFilter || (ci.CourseTeacher.CompareTo(fromTeacher) >= 0 && ci.CourseTeacher.CompareTo(toTeacher) <= 0))),
                c => c.CourseID,
                ci => ci.CourseID,
                (c, ci) => new { c, ci }
                )
                .OrderBy(result => result.c.CourseID)
                .ToList();
            //.Join(dbContext.DM_MMS_Teachers,
            //partialResult => partialResult.ci.CourseTeacher,
            //t => t.TeacherCode,
            //(partialResult, t) => new { 
            //    c = partialResult.c,
            //    ci = partialResult.ci,
            //    t = t
            //}).ToList();

            // Inizializziamo una lista vuota di MMS_Results
            List<MMS_Results> results = new List<MMS_Results>();

            // ciclo per inserire una riga di risultati per ogni Corso letto
            foreach (var course in courses)
            {
                MMS_Results result = new MMS_Results();
                result.f_CourseID.Value = course.c.CourseID;
                result.f_CourseDescription.Value = course.c.CourseDescription;
                result.f_CourseDate.Value = (System.DateTime)course.c.CourseDate;
                result.f_CourseLevel.Value = (uint)course.c.CourseLevel;
                result.f_CourseTeacher.Value = course.ci.CourseTeacher;
                // result.f_TeacherName.Value = course.t.TeacherName;
                result.f_CoursePrice.Value = (double)course.ci.CoursePrice;
                result.f_CourseDays.Value = (short)course.ci.CourseDays;
                results.Add(result);
            }

            // aggiungiamo alla response l'intera lista di elementi aggiunti
            response.ResultsOUT.RecordsToInsertOrUpdate.AddRange(results);

            return response;
        }

        [MyMagoStudioMethodDecorator("BatchExecute", "DuplicateCoursesBE")]
        public async Task<DuplicateCoursesBEResponse> DuplicateCoursesBE(DuplicateCoursesBERequest request, ContextInfo contextInfo, string callerDocId)
        {
            DuplicateCoursesBEResponse response = new DuplicateCoursesBEResponse();
            //...add your code here with some awaitable functions/methods ecc....

            CoursesCoursesCourses newCourse = await CoursesCoursesCourses.CreateUnattendedAsync(contextInfo);

            //se newCourse non viene istanziato ritorniamo una risposta vuota
            if (newCourse is null)
            {
                response.AddDiagnosticItem("Errore durante l'inizializzazione del BO", Microarea.Interfaces.DiagnosticType.Error);
                return response;
            }

            int numDoc = 0; // numeratore per sapere quanti Corsi sono stati aggiunti
                            // per ogni riga di risultato, tento di creare un Corso
            foreach (var c in request.ResultsIN)
            {
                if ((bool)!c.Selected) continue; // se sulla riga il Selected � false, passiamo direttamente alla riga successiva

                // tentiamo di entrare in stato di NEW del Corso e in caso di fallimento ritorniamo la diagnostica, ma proseguiamo
                if (!await newCourse.NewRecord(response))
                {
                    response.AddDiagnosticItem($"Errore durante la Duplicazione del documento {c.CourseID}", Microarea.Interfaces.DiagnosticType.Error);
                    continue;
                }
                // non valorizzo courseid xke gia gestito dal doc stesso
                newCourse.MasterTable.Record.f_CourseDescription.Value = $"{c.CourseDescription} - duplicated";
                newCourse.MasterTable.Record.f_CourseDate.Value = DateTime.Now;
                newCourse.MasterTable.Record.f_CourseLevel.Value = (uint)c.CourseLevel;

                newCourse.MMS_CoursesInfo.Record.f_CourseTeacher.Value = c.CourseTeacher;
                //nome docente caricato automaticamente da HKL
                newCourse.MMS_CoursesInfo.Record.f_CoursePrice.Value = (double)c.CoursePrice;
                newCourse.MMS_CoursesInfo.Record.f_CourseDays.Value = (short)c.CourseDays;

                // attendiamo il salvataggio del Record e se andato a buon fine, aggiorniamo il contatore, altrimenti diagnostica
                if (await newCourse.SaveRecord(response))
                    numDoc++;

                else
                {
                    response.AddDiagnosticItem($"Errore durante il Salvataggio del duplicato del Corso {c.CourseID}", Microarea.Interfaces.DiagnosticType.Error);
                    continue;
                }

            }

            // dopo aver terminato i record, chiudiamo il BO con Diagnostica sul numero di Corsi generati
            await newCourse.Close();
            if (numDoc != 1)
                response.AddDiagnosticItem($"Generati {numDoc} nuovi Corsi", Microarea.Interfaces.DiagnosticType.Information);
            else response.AddDiagnosticItem($"Generato {numDoc} nuovo Corso", Microarea.Interfaces.DiagnosticType.Information);

            return response;
        }

        
        [MyMagoStudioMethodDecorator("Clicked", "uploadFile", "DUPLICATECOURSES_toolbarTopButton_1")]
        public async Task<uploadFileResponse> uploadFile(uploadFileRequest request, ContextInfo contextInfo, string callerDocId)
        {
            uploadFileResponse response = new uploadFileResponse();
            //...add your code here with some awaitable functions/methods ecc....

            string originalPath = request.Filters_IN.f_FilePath.Value;

            //string directory = Path.GetDirectoryName(originalPath);
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(originalPath);
            string extension = Path.GetExtension(originalPath);

            string saveAsFile = Path.Combine(filenameWithoutExtension + "_saved" + extension);

            var res = await APICaller.GetFileTextContent(originalPath);
            string content = res.ReturnValue.ToString();
            string newContent = $"{content} modificato dal microservizio";
            var resDelete = await APICaller.DeleteFiles([originalPath]);
            var resSaveAs = await APICaller.SaveFileTextContent(saveAsFile, newContent);

            return response;
        }

        #region MMS AUTOMATICALLY ADDS NEW METHODS HERE
        #endregion

    }
}