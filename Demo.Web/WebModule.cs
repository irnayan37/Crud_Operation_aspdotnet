using Autofac;
using Demo.Infrastructure.Data;
using Demo.Web.Data;
using Demo.Web.Utility;

namespace Demo.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;
        public WebModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<HtmlEmailUtility>().As<IEmailUtililty>();//Transient bydefault
            //builder.RegisterType<HtmlEmailUtility>().As<IEmailUtililty>().SingleInstance();
            //builder.RegisterType<HtmlEmailUtility>().As<IEmailUtililty>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().AsSelf().
              WithParameter("connectionSring",_connectionString).
               WithParameter("migrationAssembly",_migrationAssembly);
            base.Load(builder);
        }
    }
}
