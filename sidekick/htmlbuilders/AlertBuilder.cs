using System;
using System.Linq;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a Bootstrap 'Alert' element.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class AlertBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;
        private Alert _model;

        public AlertBuilder(HtmlHelper<TModel> helper, Alert alert)
        {
            _helper = helper;
            _model = alert;
            _helper.WriteLine($"<div class='alert {_model._alertClass}'>");

            if (_model._dismissible)
                _helper.WriteLine("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>");

            _helper.WriteLine($"<strong><i class='{_model._type.GetAttribute<HtmlBuilderAttribute>().Icon}'></i>&nbsp;{_model._heading}</strong>");
        }

        public MvcHtmlString WriteBody()
        {
            _helper.WriteLine("<p>");

            if (_model._messageList.Any())
            {
                _helper.WriteLine("<ul>");

                foreach (string message in _model._messageList)
                {
                    _helper.WriteLine($"<li>{message}</li>");
                }

                _helper.WriteLine("</ul>");
            }
            else
            {
                if (String.IsNullOrEmpty(_model._body))
                {
                    _helper.WriteLine("No errors!");
                }
                else
                {
                    _helper.WriteLine(_model._body);
                }
            }

            _helper.WriteLine("</p>");

            return new MvcHtmlString(String.Empty);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }
}