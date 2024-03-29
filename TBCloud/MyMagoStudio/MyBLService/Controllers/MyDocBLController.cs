﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBLService.BaseModel;
using MyBLService.ParametersModel;
using System;
using System.Threading.Tasks;

namespace MyBLService.Controllers
{
    // @@@@@supported starting by TbCloud v.1.3
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "MyDocBL")]
    public class MyDocBLController : ControllerBase
    {
        private readonly ILogger<MyDocBLController> _logger;

        //-----------------------------------------------------------------------------	
        public MyDocBLController(ILogger<MyDocBLController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //-----------------------------------------------------------------------------	
        public IActionResult Get()
        {
            return Content("Welcome to MyMagoStudio Data Entry Sample Controller");
        }

        /// <summary>
        /// In this example I do not consider any input parameter,
        /// but I'm going to compile the 'LocalAuxNotes' filed always automatically
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("DataInitialized")]
        public ActionResult<BaseResponse> DataInitialized([FromBody] DataInitializedRequest request)
        {
            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                TMasterLight tMaster = new TMasterLight();
                //init tMaster from Request
                tMaster.LocalAuxNotes = "this field is local and never will be saved on db; automatically inserted by DataInitialized api :-)";
                response.ReturnValue = tMaster;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL DataInitialized exception  ", e);
            }
        }
        
        /// <summary>
        /// This example shows you how to prepare your data. Here, the 'Description'
        /// field will be made mandatory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("DataLoaded")]
        public ActionResult<BaseResponse> DataLoaded([FromBody] DataLoadedRequest request)
        {
            //in this example I'm going to make Descripton field mandatory
            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null || request.Description == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                TMaster tMaster = new TMaster();
                //init tMaster from Request
                tMaster.Description = request.Description;
                tMaster.Description.Mandatory = true;
                response.ReturnValue = tMaster;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL DataLoaded exception  ", e);
            }
        }

        /// <summary>
        /// This example shows you how to enable/disable your data
        /// in base of corrisponding status of your document. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ControlsEnabled")]
        public ActionResult<BaseResponse> ControlsEnabled([FromBody] ControlsEnabledRequest request)
        {

            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null || request.Description == null || request.Notes == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                TMaster tMaster = new TMaster();
                //init tMaster from Request
                tMaster.Description = request.Description;
                tMaster.Notes = request.Notes;
                
                if (request.FormMode == 2 /*FormModeType.New*/)
                {
                    //example: imagine that New FormMode you have to disabled
                    //Notes field and enabled Description field
                    tMaster.Notes.value = "new notes";
                    tMaster.Notes = request.Notes;
                    tMaster.Notes.IsReadOnly = true;
                    tMaster.Description.value = "new description";
                    tMaster.Description = request.Description;
                    tMaster.Description.IsReadOnly = false;
                }

                if (request.FormMode == 3 /*FormModeType.Edit*/)
                {
                    //example: imagine that Edit FormMode you have to enabled
                    //Notes field and disabled Description field
                    tMaster.Notes = request.Notes;
                    tMaster.Notes.IsReadOnly = false;
                    tMaster.Description = request.Description;
                    tMaster.Description.IsReadOnly = true;
                }
                response.ReturnValue = tMaster;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL ControlsEnabled exception  ", e);
            }
        }

        /// <summary>
        /// In this example, your data will be checked before save. In our case,
        /// when the value of the 'Description' field starts with 'p' and the value of the
        /// field 'Disabled' is true, the value false will be returned and 
        /// the saving will not be carried out
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("TransactionValidation")]
        public ActionResult<BaseResponse> TransactionValidation([FromBody] TransactionValidationRequest request)
        {

            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null || request.Description == null || request.Disabled == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                TMaster tMaster = new TMaster();
                bool ok = true;
                //init tMaster from Request
                tMaster.Description = request.Description;
                tMaster.Disabled = request.Disabled;
                if (tMaster.Description.value.StartsWith("p") && tMaster.Disabled.value)
                    ok = false;               
                response.ReturnValue = ok;
                response.Success = false;
                response.ErrorMessage = new ErrorMessage("Description starts with 'p' and field disabled is false");
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL TransactionValidation exception  ", e);
            }
        }

        /// <summary>
        /// This example shows you to manipuloate your data. For example, when 
        /// 'ContractCode' field has on of these values ('0000' or '9999') you have to
        /// put TRUE on 'Disable' field 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Code_ValueChanged")]
        public ActionResult<BaseResponse> Code_ValueChanged([FromBody] CodeValueChangedRequest request)
        {

            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null || request.ContractCode == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                TMaster tMaster = new TMaster();
                //init tMaster from Request
                tMaster.ContractCode = request.ContractCode;
                tMaster.Disabled = new BaseModel<bool>();
                bool disabled = tMaster.ContractCode.value.CompareTo("0000") == 0 ||
                        tMaster.ContractCode.value.CompareTo("9999") == 0 ? true : false;
                tMaster.Disabled.value = disabled;
                response.ReturnValue = tMaster;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL Code_ValueChanged exception  ", e);
            }
        }
        
        /// <summary>
        /// This example for button click
        /// shows you how to work with your data. In this case, 
        /// when the field 'ContractCode' is empty then the field 'Notes'
        /// will be automatically compiled and will be made editable
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Btn_Clicked")]
        public ActionResult<BaseResponse> Btn_Clicked([FromBody] CodeValueChangedRequest request)
        {

            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null || request.ContractCode == null || request.Notes == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                TMaster tMaster = new TMaster();
                //init tMaster from Request
                tMaster.ContractCode = request.ContractCode;
                tMaster.Notes = request.Notes;
                if (string.IsNullOrEmpty(tMaster.ContractCode.value))
                {
                    tMaster.Notes.value = "inserted automatically from Btn_Clicked api";
                    tMaster.Notes.IsReadOnly = false;
                }
                    
                response.ReturnValue = tMaster;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL Btn_Clicked exception  ", e);
            }
        }

        /// <summary>
        /// This example for extra transacting event, 
        /// shows you how to test the status of your document and then
        /// you will be able to work on save auxiliary data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ExtraTransacting")]
        public ActionResult<BaseResponse> ExtraTransacting([FromBody] ExtraTransactingRequest request)
        {

            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                switch (request.FormMode)
                {
                    case 1: /*FormModeType.Browse*/
                        //in browse mode, the only one extra transactiong 
                        //is for delete operation
                        //save/remove here your extra data
                        break;
                    case 2: /*FormModeType.New*/
                        //save here your extra data
                        break;
                    case 3: /*FormModeType.Edit*/
                        //save here your extra data
                        break;
                    default:
                        //not managed
                        break;
                }
                    
                response.ReturnValue = true;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL ExtraTransacting exception  ", e);
            }
        }

        /// <summary>
        /// In this example, on change of 'description' value in the details grid,
        /// the local field 'AuxDescription' will be automatically compiled and
        /// when the 'description' field starts with 'a' or 'A' then 
        /// the 'valid' field will be disabled
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("BEDescriptionValueChanged")]
        public ActionResult<BaseResponse> BEDescriptionValueChanged([FromBody] BEDescriptionValueChangedRequest request)
        {

            try
            {
                ValidateResponse response = new ValidateResponse();
                if (request == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }

                if (request.MyParamIn == null || request.MyParamIn.Count != 1)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("The request must contains only one row");
                    return new OkObjectResult(response);
                }

                //populate here your structures
                TDetails outItem = new TDetails();
                outItem = request.MyParamIn[0];
                outItem.AuxDescription.value = $"{outItem.Description.value} (BEDescriptionValueChanged api is executed)";
                if (outItem.Description.value.StartsWith("a") || outItem.Description.value.StartsWith("A"))
                    outItem.Valid.IsReadOnly = true;
                else
                    outItem.Valid.IsReadOnly = false;
                response.ReturnValue = outItem;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyDocBL BEDescriptionValueChanged exception  ", e);
            }
        }

        /// <summary>
        /// In this example, in change of the row in the details grid, 
        /// the local field 'AuxDescription' will be automatically compiled
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("BE_RowChanged")]
        public ActionResult<BaseResponse> BE_RowChanged([FromBody] DocBERowChangedRequest request)
        {

            try
            {
                BaseResponse response = new BaseResponse();
                if (request == null)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("Request is bad formatted");
                    return new OkObjectResult(response);
                }
                if (request.MyParamIn == null || request.MyParamIn.Count != 1)
                {
                    response.Success = false;
                    response.ErrorMessage = new ErrorMessage("The request must contains only one row");
                    return new OkObjectResult(response);
                }
                //populate here your structures
                TDetails outItem = new TDetails();
                outItem = request.MyParamIn[0];
                outItem.AuxDescription.value = $"{outItem.Description.value} (BE_RowChanged api is executed)";
                response.ReturnValue = outItem;
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                throw new Exception("MyBatchBLController BE_RowChanged exception  ", e);
            }
        }

        [HttpGet("assemblyversion")]
        //-----------------------------------------------------------------------------	
        public IActionResult ApiAssemblyVersion()
        {
            Version ver = new Version(1, 0);
            return new JsonResult(new { Version = ver.ToString() });
        }
    }
}
