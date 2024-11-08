//This file is created automatically by MMS
//maintenance of this file will be done by programmer
//HIGHLY RECOMMENDED: 
//DON'T TOUCH THE METHODS DECORATORS; The decorators are used for update of this file!!!
//DON'T TOUCH MMS REGION

using Microarea.Tbf.Model.MyMagoStudioBase;
using System.Threading.Tasks;
using Microarea.Generic.DataObj;
using Microarea.Tbf.Model.Remote;

namespace ERPCompany.ActivityCodes
{
    public partial class ERPCompanyActivityCodes : MyMagoStudioDocument
    {
        [MyMagoStudioMethodDecorator("ValueChanged", "Description_ValueChanged", "IDC_DESCRIPTION")]
        public async Task<Description_ValueChangedResponse> Description_ValueChanged(Description_ValueChangedRequest request, ContextInfo contextInfo, string callerDocId)
        {
            Description_ValueChangedResponse response = new Description_ValueChangedResponse();
            //...add your code here with some awaitable functions/methods ecc....
            response.Description_Out = $"{request.Description_In} from MS";
            return response;
        }

        #region MMS AUTOMATICALLY ADDS NEW METHODS HERE
        #endregion
    }
}