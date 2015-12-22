using System.Web.Mvc;
using Technica.App_Start;

namespace Technica
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GeneralFilter());
        }
    }
}
