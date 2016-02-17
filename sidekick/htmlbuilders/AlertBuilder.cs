using System;
using System.Linq;
using System.Web.Mvc;

namespace sidekick
{
    public class AlertBuilder<TModel> : BuilderBase<TModel>, IDisposable
    {
        private Alert _alert;

        public AlertBuilder(HtmlHelper<TModel> helper, Alert alert)
            : base(helper)
        {
            _alert = alert;

            BuildAlertShell();
        }

        private void BuildAlertShell()
        {
            WriteLine(String.Format("<div class='alert alert-{0}'>", _alert.AlertClass));

            if (_alert.Dismissible)
                WriteLine("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>");

            WriteLine(String.Format("<strong><i class='{0}'></i>&nbsp;{1}</strong>", _alert.Type.GetAttribute<AlertType, HtmlBuilderAttribute>().Icon, _alert.Heading));
        }

        public MvcHtmlString BuildErrorList()
        {
            WriteLine("<p>");

            if (_alert.MessageList.Any())
            {
                WriteLine("<ul>");

                foreach (string m in _alert.MessageList)
                {
                    WriteLine(String.Format("<li>{0}</li>", m));
                }

                WriteLine("</ul>");
            }
            else
            {
                WriteLine("No errors!");
            }

            WriteLine("</p>");

            return new MvcHtmlString(String.Empty);
        }

        public void Dispose()
        {
            WriteLine("</div>");
        }
    }
}