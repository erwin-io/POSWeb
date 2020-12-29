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
    //[Authorize]
    [RoutePrefix("api/v1/UserAuth")]
    public class UserAuthController : ApiController
    {
        private readonly IUserAuthFacade _userAuthFacade;
        #region CONSTRUCTORS
        public UserAuthController(IUserAuthFacade userAuthFacade)
        {
            _userAuthFacade = userAuthFacade ?? throw new ArgumentNullException(nameof(_userAuthFacade));
        }
        #endregion

        [Route("authenticateuser")]
        [HttpGet]
        [SwaggerOperation("get")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(string username, string password)
        {
            AppResponseModel<SystemUserViewModel> response = new AppResponseModel<SystemUserViewModel>();

            if (string.IsNullOrEmpty(username))
            {
                response.Message = string.Format(Messages.Empty, "Username");
                return new POSAPIHttpActionResult<AppResponseModel<SystemUserViewModel>>(Request, HttpStatusCode.BadRequest, response);
            }
            if (string.IsNullOrEmpty(password))
            {
                response.Message = string.Format(Messages.Empty, "Password");
                return new POSAPIHttpActionResult<AppResponseModel<SystemUserViewModel>>(Request, HttpStatusCode.BadRequest, response);
            }


            try
            {
                SystemUserViewModel result = _userAuthFacade.Find(username, password);

                if (result != null)
                {
                    string baseAddress = Url.Content("~/");
                    using (var client = new HttpClient())
                    {

                        var form = new Dictionary<string, string>
                        {
                           {"grant_type", "password"},
                           {"username", username},
                           {"password", password},
                        };
                        var respoonseMessage = client.PostAsync(baseAddress + "/oauth2/token", new FormUrlEncodedContent(form)).Result;
                        string _json = respoonseMessage.Content.ReadAsStringAsync().Result;

                        JObject obj = JsonConvert.DeserializeObject<JObject>(_json);
                        var token = obj.ToObject<TokenViewModel>();
                        if(token != null)
                        {
                            result.Token = token;

                        }
                        else
                        {
                            response.Message = Messages.ServerError;
                            response.DeveloperMessage = string.Format(Messages.CustomError, "Token is null");
                            return new POSAPIHttpActionResult<AppResponseModel<SystemUserViewModel>>(Request, HttpStatusCode.OK, response);
                        }
                    }
                    response.Data = result;
                    response.IsSuccess = true;
                    return new POSAPIHttpActionResult<AppResponseModel<SystemUserViewModel>>(Request, HttpStatusCode.OK, response);
                }
                else
                {
                    response.Message = Messages.NoRecord;
                    return new POSAPIHttpActionResult<AppResponseModel<SystemUserViewModel>>(Request, HttpStatusCode.NotFound, response);
                }

            }
            catch (Exception ex)
            {
                response.DeveloperMessage = ex.Message;
                response.Message = Messages.ServerError;
                //TODO Logging of exceptions
                return new POSAPIHttpActionResult<AppResponseModel<SystemUserViewModel>>(Request, HttpStatusCode.BadRequest, response);
            }
        }
    }
}
