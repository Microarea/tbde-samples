using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinFormsLabel = System.Windows.Forms.Label;

namespace TbApiTester
{
    public class LabelManager
    {
        private readonly TbApiTester form;

        public LabelManager(TbApiTester form)
        {
            this.form = form;
        }

        public void InitializeLabels()
        {
            //////////// Label descriptive GET DATA SERVICE (DataServiceManager)
            form.labelDataService.Text = "The DataService microservice exposes the possibility of extracting data that are defined through \n" +
                                         "standard and custom xml contained in the reference objects folder.\n" +
                                         "It then allows you to extract the data defined by a hotlink or radar query.";

            //////////// Label descriptive Microservice (Assembly-version)
            form.labelAVersion.Text = "Micro-service exposes an API called assemblyVersion that allows\n" +
                                      "the current version of the micro-service to be returned.";

            //////////// Label descriptive MAGIC LINK GETXMLDATA (TbServerManager)
            form.labelMagicLinkGet.Text = "The TbServerGate microservice exposes the possibility to menage business objects\n" +
                                          "based on MagicLink desktop technology.";


            //////////// Label descriptive REPORTING SERVICE (RsManager)
            form.labelRS.Text = "The ReportingServices microservice exposes the possibility " +
                                "of launching a report and obtaining the extracted data.\n" +
                                "The microservice supports both Xml and Json format.\n";

            //////////// Label descriptive  (WebMethod)
            form.labelWmDescription.Text = "The TbServerGate microservice exposes the possibility to access\n" +
                                           "TbWebMethods (previously SOAP/WCF) via Rest.\n"; 
                                        


            //////////// Label descriptive  (DMS)
            form.labelDms.Text = "The DMS (Document Management System) it allows for storing, sharing,\n" +
                                 "and managing electronic documents.\n" +
                                 "Is a solution for digital document management.";

            //////////// Label descriptive  (DATAMANAGER LockManager )
            form.labelDescLock.Text = "The lock action corresponds to writing a record in the TB_Locks table for each locked data item, \n" +
                                 "while the unlock action corresponds to removing the record from this table.";
                                 

        }
    }
}
