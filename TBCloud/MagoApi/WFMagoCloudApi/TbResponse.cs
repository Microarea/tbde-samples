using MagoCloudApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagoCloudApi
{
    public class TbResponse
    {
        /// <summary>
        /// status code
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// api returned value object
        /// </summary>
        public object ReturnValue { get; set; }
        /// <summary>
        /// logical fields indicating if api have been performed with success
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// response plain result
        /// </summary>
        public string PlainResult { get; set; }

    }
    public class Query
    {
        /// <summary>
        /// Table Name
        /// </summary>
        public string TableName { get; set; } = string.Empty;
        /// <summary>
        /// Selected Fields
        /// </summary>
        public string[] SelectedFields { get; set; } = null;
        /// <summary>
        /// Join Clause
        /// </summary>
        public string JoinClause { get; set; }

        /// <summary>
        /// Where Clause
        /// </summary>
        public string Where { get; set; }

        /// <summary>
        /// order by fields
        /// </summary>
        public string[] OrderByFields { get; set; }

        /// <summary>
        /// group by fields
        /// </summary>
        public string[] GroupByFields { get; set; }
        /// <summary>
        /// having condition
        /// </summary>

        public string Having { get; set; }
        /// <summary>
        /// Page Number
        /// </summary>
        public int PageNr { get; set; } = 0;
        /// <summary>
        /// Page Size
        /// </summary>
        public int PageSize { get; set; } = 0;
    }
}
