using System.Web;
using System.Web.Mvc;

namespace _10_MVC01_Youtube_Proje
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
