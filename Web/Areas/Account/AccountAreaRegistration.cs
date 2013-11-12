using System.Web.Mvc;

namespace Web.Areas.Account
{
    public class AccountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Account";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name:"Account_default",
                url: "Account/{controller}/{action}/{id}",
                defaults:new {action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Web.Areas.Account.Controllers" }
            );
        }
    }
}
