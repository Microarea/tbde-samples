using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace TbApiTester
{
    public class LogManager
    {
        internal DataServiceManager dataServiceManager = new DataServiceManager();
        internal TbServerManager tbServerManager = new TbServerManager();
        internal WebMethodsManager webMethodsManager = new WebMethodsManager();
        internal RsManager rsManager = new RsManager();
        internal DmsManager dmsManager = new DmsManager();
        internal DmMMSManager dmMMSManager = new DmMMSManager();
      
        internal TbFsServiceManager tbFsServiceManager = new TbFsServiceManager();
        public void ClearLogs()
        {
            tbServerManager.requestTbList.Clear();
            tbServerManager.responseTbList.Clear();
        }
    }
}
