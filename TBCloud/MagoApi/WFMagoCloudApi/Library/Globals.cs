using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MagoCloudApi.Libraries
{
    public enum OperationType { None, GetData, SetData, GetFirstDocument, StressTest, GetSchema, GetParameters, ExistData };
    public enum CloudStatusType { None, EnvironmentSelected, PreLogin, Logged, Connected }

    //===================================================================================
    class Globals
    {
        public delegate void FontChangedEventHandler(object sender, MonthChangedEventArgs e);
        public static event FontChangedEventHandler FontChanged;

        public static Font CurrentFont
        {
            get { return currentFont; }
            //set
            //{
            //    currentFont = value;
            //    //FontChanged?.Invoke(null, new FontChangedEventArgs(value.FontFamily.Name, value.Size));
            //}
        }
        private static Font currentFont =  new Font("Arial", 10);

        public static int WebServiceDesktopTimeout { get; set; } = 100000;

        public static bool? IsCloud { get; set; } = null;
        public static bool IsStandardSelected { get; set; } = true;
        public static bool IsAllUsersSelected { get; set; } = false;
        public static bool IsUserSelected { get; set; } = false;

        public static string Application { get; set; }
        public static string Module { get; set; }
        public static string DocumentReport { get; set; }
        //public static DocumentInfo DocumentInfo { get; set; }
        public static string LastTestFolder { get; set; }
        public static string AuthenticationToken { get; set; }
        public static DateTime ApplicationDate { get; set; }
        public static string NameSpace { get; set; }
        public static string CurrentProfile { get; set; }
        public static string Company { get; set; }
        public static string User { get; set; }
        public static bool NtAuthentication { get; set; }
        public static FormWindowState WindowState { get; set; }
        public static float FontSize { get; set; }
        public static string FontType { get; set; }
        public static bool UseApproximation { get; set; }
        public static Color BackGroundColor { get; set; }
        public static string GetDataText { get; set; }
        public static string SetDataText { get; set; }
        public static string SetDataTextResult { get; set; }
        public static List<string> StressTests { get; set; } = new List<string>();
        public static bool CheckApproximation { get; set; }
        public static string DocumentParameters { get; set; }
        public static bool IsDocument { get; set; }
        public static bool IsValid { get; set; }
        public static string UserForRequest { get; set; }
        public static string UserForNSUri { get; set; }
        public static string ProducerKey { get; set; }

        public static string CloudEnvironment { get; set; }
        public static string CloudBaseUrl { get; set; }
        public static string SubscriptionKey { get; set; }
        public static string SubscriptionDescription { get; set; }
        public static string CloudUser { get; set; }
        public static string CloudProcess { get; set; }
        public static string CloudPassword { get; set; }
        public static CloudStatusType CloudStatus { get; set; }
        public static List<string> RecentList { get; internal set; }
        public static bool UseHttps { get; set; }
        public static bool UseForwardAuth { get; set; }
        public static int PortNumber { get; internal set; }
        public static bool GodMode { get; internal set; }
    }
}
