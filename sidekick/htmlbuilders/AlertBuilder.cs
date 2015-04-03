using System;
using System.Linq;
using System.Web.Mvc;

namespace sidekick
{
    public class AlertBuilder : IDisposable
    {
        private HtmlHelper _helper;
        private IAlert _alert;

        public AlertBuilder(HtmlHelper helper, IAlert alert, bool customBody) {
            _helper = helper;
            _alert = alert;

            if (customBody) {
                BuildAlertShell();
            } else {
                BuildAlert();
            }
        }

        private void BuildAlert() {
            _helper.ViewContext.Writer.Write(string.Format("<div class='{0}'>", _alert.AlertClass));

            if (_alert.Dismissible)
                _helper.ViewContext.Writer.Write("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>");

            _helper.ViewContext.Writer.Write(string.Format("<strong><i class='{0}'></i>&nbsp;{1}</strong>", _alert.Icon, _alert.Heading));
            _helper.ViewContext.Writer.Write("<p>");

            if (_alert.MessageList.Count() > 0) {
                 _helper.ViewContext.Writer.Write("<ul>");

                foreach (string m in _alert.MessageList) {
                     _helper.ViewContext.Writer.Write(string.Format("<li>{0}</li>", m));
                }

                 _helper.ViewContext.Writer.Write("</ul>");
            } else {
                 _helper.ViewContext.Writer.Write(_alert.Body);
            }

            _helper.ViewContext.Writer.Write("</p>");

            Dispose();
        }

        private void BuildAlertShell() {
            _helper.ViewContext.Writer.Write(string.Format("<div class='{0}'>", _alert.AlertClass));

            if (_alert.Dismissible)
                _helper.ViewContext.Writer.Write("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>");

            _helper.ViewContext.Writer.Write(string.Format("<strong><i class='{0}'></i>&nbsp;{1}</strong>", _alert.Icon, _alert.Heading));
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div>");
        }
    }
}
