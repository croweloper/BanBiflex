using System.Web;
using System.Web.Mvc;

namespace BanBif.BanBiFlex.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
