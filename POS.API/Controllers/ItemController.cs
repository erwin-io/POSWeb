using Newtonsoft.Json;
using POS.API.Filters;
using POS.API.Helpers;
using POS.API.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace POS.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/v1/Item")]
    public class ItemController : ApiController
    {

        #region CONSTRUCTORS
        public ItemController()
        {
        }
        #endregion
    }
}
