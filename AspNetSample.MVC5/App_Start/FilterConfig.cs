using System.Web;
using System.Web.Mvc;

namespace AspNetSample.MeetingMinutesSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
