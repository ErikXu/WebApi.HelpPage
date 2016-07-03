using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApi.HelpPage.Microsoft
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
