using System;
using System.Web.Mvc;

namespace sidekick
{
    public class CardBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;
        private Card _card;

        public CardBuilder(HtmlHelper<TModel> helper, Card card)
        {
            _helper = helper;
            _card = card;

            _helper.WriteLine("<div class='card'>");

            if (!String.IsNullOrEmpty(_card._header))
            {
                if (_card._headerSize.HasValue)
                {
                    _helper.WriteLine(String.Format("<{0} class='card-header'>{1}</{0}>", _card._headerSize.GetAttribute<HtmlBuilderAttribute>().Tag, _card._header));
                }
                else
                {
                    _helper.WriteLine(String.Format("<div class='card-header'>{0}</div>", _card._header));
                }
            }

            _helper.WriteLine("<div class='card-block'>");
            _helper.WriteLine(String.Format("<{0} class='card-title'>{1}</{0}>", _card._titleSize.GetAttribute<HtmlBuilderAttribute>().Tag, _card._title));
            if (!String.IsNullOrEmpty(_card._subtitle))
            {
                _helper.WriteLine(String.Format("<h6 class='card-subtitle text-muted'>{0}</h6>", _card._subtitle));
            }
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");

            if (!String.IsNullOrEmpty(_card._footer))
            {
                _helper.WriteLine(String.Format("<div class='card-footer text-muted'>{0}</div>", _card._footer));
            }

            _helper.WriteLine("</div>");
        }
    }
}
