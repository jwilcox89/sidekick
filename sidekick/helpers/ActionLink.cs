using System.Web.Mvc.Ajax;

namespace sidekick
{
    public class ActionLink
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public object RouteValues { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public object HtmlAttributes { get; set; }
    }

    public class AjaxActionLink : ActionLink
    {
        public AjaxOptions Options { get; set; }
    }
}
