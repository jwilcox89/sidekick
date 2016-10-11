using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a Bootstrap 'Tab' element
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class TabsBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;
        private readonly Queue<Tab> _tabList;
        private bool _contentStarted;
        private bool _fade;

        public TabsBuilder(HtmlHelper<TModel> helper, TabType tabType)
        {
            _helper = helper;
            _tabList = new Queue<Tab>();
            _helper.WriteLine("<div role='tabpanel'>");
            _helper.WriteLine($"<ul role='tablist' class='nav {tabType.GetAttribute<HtmlBuilderAttribute>().Class}'>");
        }

        public TabsBuilder(HtmlHelper<TModel> helper, TabType tabType, bool fade)
        {
            _helper = helper;
            _fade = fade;
            _tabList = new Queue<Tab>();
            _helper.WriteLine("<div role='tabpanel'>");
            _helper.WriteLine($"<ul role='tablist' class='nav {tabType.GetAttribute<HtmlBuilderAttribute>().Class}'>");
        }

        public TabsBuilder(HtmlHelper<TModel> helper, TabType tabType, bool stacked, bool justified, bool fade)
        {
            _helper = helper;
            _fade = fade;
            _tabList = new Queue<Tab>();
            _helper.WriteLine("<div role='tabpanel'>");
            string isStacked = (stacked) ? "nav-stacked" : String.Empty;
            string isJustified = (justified) ? "nav-justified" : String.Empty;
            _helper.WriteLine($"<ul role='tablist' class='nav {tabType.GetAttribute<HtmlBuilderAttribute>().Class} {isStacked} {justified}'>");
        }

        /// <summary>
        ///     Builds the tab nav
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="displayText"></param>
        /// <returns></returns>
        public MvcHtmlString Tab(Tab tab)
        {
            _tabList.Enqueue(tab);
            string active = (tab.Active) ? "class='active'" : String.Empty;
            _helper.WriteLine($"<li role='presentation' {active}>");
            _helper.WriteLine($"<a href='#{tab.Name}' aria-controls='{tab.Name}' role='tab' data-toggle='tab'>");

            if (tab.Icon != null)
                _helper.WriteLine($"{new IconBuilder(tab.Icon).ToHtmlString()} ");

            _helper.WriteLine(tab.DisplayText);
            _helper.WriteLine("</a></li>");

            return new MvcHtmlString(String.Empty);
        }

        /// <summary>
        ///     Build a tab dropdown.
        ///     <para>*Note: tabs must be managed manually</para>
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public TabDropdown<TModel> BeginTabDropdown(Tab tab)
        {
            return new TabDropdown<TModel>(_helper, tab);
        }

        /// <summary>
        ///     Builds the tab content area
        /// </summary>
        /// <returns></returns>
        public TabsContent<TModel> BeginTab()
        {
            if (!_contentStarted)
            {
                _helper.WriteLine("</ul>");
                _helper.WriteLine("<div class='tab-content'>");
                _contentStarted = true;
            }

            return new TabsContent<TModel>(_helper, _tabList.Dequeue(), _fade);
        }

        /// <summary>
        ///     Builds the tab content area
        ///     <para>*Note: must be used when using a tab dropdown</para>
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public TabsContent<TModel> BeginTab(string name)
        {
            if (!_contentStarted)
            {
                _helper.WriteLine("</ul>");
                _helper.WriteLine("<div class='tab-content'>");
                _contentStarted = true;
            }

            return new TabsContent<TModel>(_helper, new Tab("", "", name, false), _fade);
        }

        /// <summary>
        ///     Builds the tab content area
        ///     <para>*Note: must be used when using a tab dropdown</para>
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public TabsContent<TModel> BeginTab(string name, bool active)
        {
            if (!_contentStarted)
            {
                _helper.WriteLine("</ul>");
                _helper.WriteLine("<div class='tab-content'>");
                _contentStarted = true;
            }

            return new TabsContent<TModel>(_helper, new Tab("", "", name, active), _fade);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div></div>");
        }
    }

    /// <summary>
    ///     Build the content area for tab
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class TabsContent<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public TabsContent(HtmlHelper<TModel> helper, Tab tab, bool fade)
        {
            _helper = helper;
            string active = (tab.Active) ? "active" : null;
            string inValue = (tab.Active && fade) ? "in" : null;
            string fadeValue = (fade) ? "fade" : null;

            _helper.WriteLine($"<div role='tabpanel' class='tab-pane {active} {fadeValue} {inValue}' id='{tab.Name}'>");
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }

    /// <summary>
    ///     Build a tab dropdown menu
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class TabDropdown<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public TabDropdown(HtmlHelper<TModel> helper, Tab tab)
        {
            _helper = helper;
            _helper.WriteLine("<li class='dropdown' role='presentation'>");
            _helper.WriteLine("<a href='#' role='button' data-toggle='dropdown'>");

            if (tab.Icon != null)
                _helper.WriteLine($"{new IconBuilder(tab.Icon).ToHtmlString()} ");

            _helper.WriteLine($"{tab.DisplayText} <span class='caret'></span>");
            _helper.WriteLine("</a>");
            _helper.WriteLine("<ul class='dropdown-menu'>");
        }

        public MvcHtmlString Option(Tab tab)
        {
            _helper.WriteLine($"<li><a href='#{tab.Name}' data-toggle='tab'>{new IconBuilder(tab.Icon).ToHtmlString()} {tab.DisplayText}</a></li>");
            return new MvcHtmlString(String.Empty);
        }

        public void Dispose()
        {
            _helper.WriteLine("</ul></li>");
        }
    }
}
