using System.Web;
using System.Web.Mvc;

namespace MVCCore.MongoDB.CRUD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
