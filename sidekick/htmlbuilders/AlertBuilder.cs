using System;
using System.Linq;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a Bootstrap 'Alert' element.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class AlertBuilder : IDisposable
    {
        private HtmlHelper _helper;
        private Alert _alert;

        public AlertBuilder(HtmlHelper helper, Alert alert)
        {
            _helper = helper;
            _alert = alert;
            _helper.WriteLine($"<div class='alert {_alert._alertClass}'>");

            if (_alert._dismissible)
            {
                _helper.WriteLine("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>");
            }

            _helper.WriteLine($"<strong><i class='{_alert._type.GetAttribute<HtmlBuilderAttribute>().Icon}'></i>&nbsp;{_alert._heading}</strong>");
        }

        /// <summary>
        ///     Write the list of messages
        /// </summary>
        /// <returns></returns>
        public MvcHtmlString WriteMessageList()
        {
            if (_alert._messageList.Any())
            {
                _helper.WriteLine("<ul>");

                foreach (string message in _alert._messageList)
                {
                    _helper.WriteLine($"<li>{message}</li>");
                }

                _helper.WriteLine("</ul>");
            }

            return new MvcHtmlString(String.Empty);
        }

        /// <summary>
        ///     Write the predefined body
        /// </summary>
        /// <returns></returns>
        public MvcHtmlString WriteBody()
        {
            if (!String.IsNullOrEmpty(_alert._body))
            {
                _helper.WriteLine(_alert._body);
            }

            return new MvcHtmlString(String.Empty);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }
}