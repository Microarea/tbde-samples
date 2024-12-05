namespace MagoCloudApi.Libraries
{
    //==========================================================================================================================================
    public class XmlGetParametersResult
    {
        public XmlGetParametersResult(string result, bool success)
        {
            Result = result;
            Success = success;
        }

        public string Result { get; set; }
        public bool Success { get; set; }
    }
}