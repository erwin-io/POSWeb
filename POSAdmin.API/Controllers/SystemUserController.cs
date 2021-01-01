using Newtonsoft.Json;
using POSWeb.POSAdmin.API.Filters;
using POSWeb.POSAdmin.API.Helpers;
using POSWeb.POSAdmin.API.Models;
using POSWeb.POSAdmin.Domain.ViewModel;
using POSWeb.POSAdmin.Domain.BindingModel;
using POSWeb.POSAdmin.Facade.Interface;
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
using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;

namespace POSWeb.POSAdmin.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/v1/SystemUser")]
    public class SystemUserController : ApiController
    {
        private readonly ISystemUserFacade _systemUserFacade;
        #region CONSTRUCTORS
        public SystemUserController(ISystemUserFacade systemUserFacade)
        {
            _systemUserFacade = systemUserFacade ?? throw new ArgumentNullException(nameof(systemUserFacade));
        }
        #endregion


    }
}
