using System;
using System.Web.Mvc;

namespace sidekick
{
    public class CardBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public CardBuilder(HtmlHelper<TModel> helper, bool block, bool inverse)
        {
            _helper = helper;
            _helper.WriteLine(String.Format("<div class='card {0} {1}'>", block ? "card-block" : String.Empty, inverse ? "card-inverse" : String.Empty));
        }

        public CardBuilder(HtmlHelper<TModel> helper, bool block, Colors color)
        {
            _helper = helper;
            _helper.WriteLine(String.Format("<div class='card {0} card-{1}'>", block ? "card-block" : String.Empty, color.GetAttribute<HtmlBuilderAttribute>().Class));
        }

        public MvcHtmlString Image(CardImageLocation location, string source, string alt)
        {
            _helper.WriteLine(String.Format("<img class='{0}' data-src='{1}' alt='{2}' />", location.GetAttribute<HtmlBuilderAttribute>().Class, source, alt));
            return new MvcHtmlString(String.Empty);
        }

        public CardSection<TModel> BeginBlock()
        {
            return new CardSection<TModel>(_helper, "card-block");
        }

        public CardSection<TModel> BeginBlock(string @class)
        {
            return new CardSection<TModel>(_helper, "card-block", @class);
        }

        public CardSection<TModel> BeginHeader()
        {
            return new CardSection<TModel>(_helper, "card-header");
        }

        public CardSection<TModel> BeginHeader(string @class)
        {
            return new CardSection<TModel>(_helper, "card-header", @class);
        }

        public CardSection<TModel> BeginFooter()
        {
            return new CardSection<TModel>(_helper, "card-footer");
        }

        public CardSection<TModel> BeginFooter(string @class)
        {
            return new CardSection<TModel>(_helper, "card-footer", @class);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }

    public class CardSection<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public CardSection(HtmlHelper<TModel> helper, string @class)
        {
            _helper = helper;
            _helper.WriteLine(String.Format("<div class='{0}'>", @class));
        }

        public CardSection(HtmlHelper<TModel> helper, string @class, string additionalClass)
        {
            _helper = helper;
            _helper.WriteLine(String.Format("<div class='{0} {1}'>", @class, additionalClass));
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }
}
