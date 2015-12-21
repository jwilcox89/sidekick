using System;
using System.Linq;
using System.Web.Mvc;

namespace sidekick
{
    public class AlertBuilder<TModel> : BuilderBase<TModel>, IDisposable
    {
        private Alert _alert;

        public AlertBuilder(HtmlHelper<TModel> helper, Alert alert, bool customBody) : base(helper) 
        {
            _alert = alert;

            if (!customBody) 
            {
                BuildAlert();
            } 
            else 
            {
                BuildAlertShell();
            }
        }

        private void BuildAlert() 
        {
            WriteLine(String.Format("<div class='alert alert-{0}' role='alert'>", _alert.AlertClass));

            if (_alert.Dismissible)
                WriteLine("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>");

            WriteLine(String.Format("<strong><i class='{0}'></i>&nbsp;{1}</strong>", _alert.Type.GetHtmlAttributes<AlertType>().Icon, _alert.Heading));
            WriteLine("<p>");

            if (_alert.MessageList.Count() > 0) 
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
                 WriteLine(_alert.Body);
            }

            WriteLine("</p>");

            Dispose();
        }

        private void BuildAlertShell() 
        {
            WriteLine(String.Format("<div class='alert alert-{0}'>", _alert.AlertClass));

            if (_alert.Dismissible)
                WriteLine("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>");

            WriteLine(String.Format("<strong><i class='{0}'></i>&nbsp;{1}</strong>", _alert.Type.GetHtmlAttributes<AlertType>().Icon, _alert.Heading));
        }

        public void Dispose() 
        {
            WriteLine("</div>");
        }
    }
}