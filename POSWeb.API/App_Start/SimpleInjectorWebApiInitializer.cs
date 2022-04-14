[assembly: WebActivator.PostApplicationStartMethod(typeof(POSWeb.API.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace POSWeb.API.App_Start
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Http;
    using POSWeb.API.Helpers;
    using POSWeb.Data;
    using POSWeb.Data.Interface;
    using POSWeb.Facade;
    using POSWeb.Facade.Interface;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            string connectionString = Configuration.ConnectionString();

            GlobalVariables.goAppHostName = GlobalVariables.GetApplicationConfig("AppHostName");
            GlobalVariables.goOAuthURI = GlobalVariables.GetApplicationConfig("OAuthURI");
            GlobalVariables.goApplicationName = GlobalVariables.GetApplicationConfig("ApplicationName");
            GlobalVariables.goEnableSwagger = bool.Parse(GlobalVariables.GetApplicationConfig("EnableSwagger"));
            GlobalVariables.goEnableAPI = bool.Parse(GlobalVariables.GetApplicationConfig("EnableAPI"));
            GlobalVariables.goDefaultSystemUserProfilePicPath = GlobalVariables.GetApplicationConfig("DefaultSystemUserProfilePic");
            GlobalVariables.goDefaultCrimeIncidentTypeIconFilePath = GlobalVariables.GetApplicationConfig("DefaultCrimeIncidentTypeIconfilePic");
            GlobalVariables.goDefaultEnforcementTypeIconFilePath = GlobalVariables.GetApplicationConfig("DefaultEnforcementTypeIconfilePic");
            GlobalVariables.goDefaultEnforcementUnitIconFilePicPath = GlobalVariables.GetApplicationConfig("DefaultEnforcementUnitIconfilePic");
            GlobalVariables.goDefaultEnforcementStationIconFilePath = GlobalVariables.GetApplicationConfig("DefaultEnforcementStationIconfilePic");
            GlobalVariables.goDefaultSystemUploadRootDirectory = GlobalVariables.GetApplicationConfig("DefaultSystemUploadRootDirectory");
            GlobalVariables.goDefaultCrimeReportMarkerIconFilePath = GlobalVariables.GetApplicationConfig("DefaultCrimeReportMarkerIconFilePath");

            GlobalVariables.goEmailVerificationTempPath = GlobalVariables.GetApplicationConfig("EmailVerificationTempPath");
            GlobalVariables.goChangePasswordTempPath = GlobalVariables.GetApplicationConfig("ChangePasswordTempPath");
            GlobalVariables.goForgotPasswordTempPath = GlobalVariables.GetApplicationConfig("ForgotPasswordTempPath");
            GlobalVariables.goEmailTempProfilePath = GlobalVariables.GetApplicationConfig("EmailTempProfilePath");
            GlobalVariables.goSiteSupportEmail = GlobalVariables.GetApplicationConfig("SiteSupportEmail");
            GlobalVariables.goSiteSupportEmailPassword = GlobalVariables.GetApplicationConfig("SiteSupportEmailPassword");

            GlobalVariables.goClientLandingPageWebsite = GlobalVariables.GetApplicationConfig("ClientLandingPageWebsite");
            #region DAL
            container.Register<IDbConnection>(() => new SqlConnection(connectionString), Lifestyle.Scoped);
            container.Register<ILookupTableRepositoryDAC, LookupTableDAC>(Lifestyle.Scoped);
            container.Register<ISystemUserRepositoryDAC, SystemUserDAC>(Lifestyle.Scoped);
            container.Register<ISystemUserConfigRepositoryDAC, SystemUserConfigDAC>(Lifestyle.Scoped);
            container.Register<ILegalEntityRepository, LegalEntityDAC>(Lifestyle.Scoped);
            container.Register<ISystemWebAdminRoleRepositoryDAC, SystemWebAdminRoleDAC>(Lifestyle.Scoped);
            container.Register<ISystemWebAdminUserRolesRepositoryDAC, SystemWebAdminUserRolesDAC>(Lifestyle.Scoped);
            container.Register<ISystemWebAdminMenuRolesRepositoryDAC, SystemWebAdminMenurRolesDAC>(Lifestyle.Scoped);
            container.Register<ISystemWebAdminRolePrivilegesRepositoryDAC, SystemWebAdminRolePrivilegesDAC>(Lifestyle.Scoped);
            container.Register<ISystemWebAdminMenuRepositoryDAC, SystemWebAdminMenuDAC>(Lifestyle.Scoped);
            container.Register<ISystemWebAdminMenuModuleRepositoryDAC, SystemWebAdminMenuModuleDAC>(Lifestyle.Scoped);
            container.Register<IFileRepositoryRepositoryDAC, FileDAC>(Lifestyle.Scoped);
            container.Register<ILegalEntityAddressRepositoryDAC, LegalEntityAddressDAC>(Lifestyle.Scoped);
            container.Register<ISystemUserVerificationRepositoryDAC, SystemUserVerificationDAC>(Lifestyle.Scoped);
            container.Register<ISystemConfigRepositoryDAC, SystemConfigDAC>(Lifestyle.Scoped);
            #endregion

            #region Facade
            container.Register<ILookupFacade, LookupFacade>(Lifestyle.Scoped);
            container.Register<IFileFacade, FileFacade>(Lifestyle.Scoped);
            container.Register<ISystemUserFacade, SystemUserFacade>(Lifestyle.Scoped);
            container.Register<ISystemWebAdminRoleFacade, SystemWebAdminRoleFacade>(Lifestyle.Scoped);
            container.Register<ISystemWebAdminMenuRolesFacade, SystemWebAdminMenuRolesFacade>(Lifestyle.Scoped);
            container.Register<ISystemWebAdminRolePrivilegesFacade, SystemWebAdminRolePrivilegesFacade>(Lifestyle.Scoped);
            container.Register<IUserAuthFacade, UserAuthFacade>(Lifestyle.Scoped);
            container.Register<ILegalEntityAddressFacade, LegalEntityAddressFacade>(Lifestyle.Scoped);
            container.Register<ISystemUserVerificationFacade, SystemUserVerificationFacade>(Lifestyle.Scoped);
            container.Register<ISystemConfigFacade, SystemConfigFacade>(Lifestyle.Scoped);
            #endregion
        }
    }
}