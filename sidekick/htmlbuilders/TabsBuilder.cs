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
        private Queue<Tab> _tabList;
        private bool _contentStarted;

        public TabsBuilder(HtmlHelper<TModel> helper, TabType tabType)
        {
            _helper = helper;
            _tabList = new Queue<Tab>();
            _helper.WriteLine("<div role='tabpanel'>");
            _helper.WriteLine(String.Format("<ul role='tablist' class='nav {0}'>", tabType.GetAttribute<HtmlBuilderAttribute>().Class));
        }

        public TabsBuilder(HtmlHelper<TModel> helper, TabType tabType, bool stacked, bool justified)
        {
            _helper = helper;
            _tabList = new Queue<Tab>();
            _helper.WriteLine("<div role='tabpanel'>");
            _helper.WriteLine(String.Format("<ul role='tablist' class='nav {0} {1} {2}'>", tabType.GetAttribute<HtmlBuilderAttribute>().Class, (stacked) ? "nav-stacked" : String.Empty, (justified) ? "nav-justified" : String.Empty));
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
            _helper.WriteLine(String.Format("<li role='presentation' {0}>", active));
            _helper.WriteLine(String.Format("<a href='#{0}' aria-controls='{0}' role='tab' data-toggle='tab'>", tab.Name));

            if (!String.IsNullOrEmpty(tab.Icon))
                _helper.WriteLine(String.Format("<i class='{0}'></i>&nbsp;", tab.Icon));

            _helper.WriteLine(tab.DisplayText);
            _helper.WriteLine("</a></li>");

            return new MvcHtmlString(String.Empty);
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

            return new TabsContent<TModel>(_helper, _tabList.Dequeue());
        }

        public void Dispose()
        {
            _helper.WriteLine("</div></div>");
        }
    }

    public class TabsContent<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public TabsContent(HtmlHelper<TModel> helper, Tab tab)
        {
            _helper = helper;
            string active = (tab.Active) ? "active" : null;
            _helper.WriteLine(String.Format("<div role='tabpanel' class='tab-pane {0}' id='{1}'>", active, tab.Name));
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }
}
