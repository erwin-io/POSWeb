[assembly: WebActivator.PostApplicationStartMethod(typeof(POSWeb.POSAdmin.API.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace POSWeb.POSAdmin.API.App_Start
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Http;
    using POSWeb.POSAdmin.API.Helpers;
    using POSWeb.POSAdmin.Data;
    using POSWeb.POSAdmin.Data.Interface;
    using POSWeb.POSAdmin.Facade;
    using POSWeb.POSAdmin.Facade.Interface;
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
            string connectionString = Configuration.ConnectionString();;
            #region DAL
            container.Register<IDbConnection>(() => new SqlConnection(connectionString), Lifestyle.Scoped);
            container.Register<ISystemUserRepository, SystemUserDAC>(Lifestyle.Scoped);
            container.Register<IEntityInformationRepository, EntityInformationDAC>(Lifestyle.Scoped);
            container.Register<ISystemRoleRepositoryDAC, SystemRoleDAC>(Lifestyle.Scoped);
            #endregion

            #region Facade
            container.Register<ISystemUserFacade, SystemUserFacade>(Lifestyle.Scoped);
            container.Register<IUserAuthFacade, UserAuthFacade>(Lifestyle.Scoped);
            container.Register<ISystemRoleFacade, SystemRoleFacade>(Lifestyle.Scoped);
            #endregion
        }
    }
}