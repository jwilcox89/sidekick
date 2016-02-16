using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public class TabsBuilder<TModel> : BuilderBase<TModel>, IDisposable
    {
        private Queue<Tab> _tabList;
        private bool _firstTab = true;

        public TabsBuilder(HtmlHelper<TModel> helper)
            : base(helper)
        {
            _tabList = new Queue<Tab>();
            WriteLine("<div role='tabpanel'>");
            WriteLine("<ul role='tablist' class='nav nav-tabs'>");
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
            string active = (tab.Active) ? "class='active'" : null;
            WriteLine(String.Format("<li role='presentation' {0}>", active));
            WriteLine(String.Format("<a href='#{0}' aria-controls='{0}' role='tab' data-toggle='tab'>", tab.Name));

            if (!String.IsNullOrEmpty(tab.Icon))
                WriteLine(String.Format("<i class='{0}'></i>&nbsp;", tab.Icon));

            WriteLine(tab.DisplayText);
            WriteLine("</a></li>");

            return new MvcHtmlString(String.Empty);
        }

        /// <summary>
        ///     Builds the tab content area
        /// </summary>
        /// <returns></returns>
        public TabsContent<TModel> BeginTab()
        {
            if (_firstTab)
            {
                WriteLine("</ul>");
                WriteLine("<div class='tab-content'>");
                _firstTab = false;
            }

            return new TabsContent<TModel>(Helper, _tabList.Dequeue());
        }

        public void Dispose()
        {
            WriteLine("</div></div>");
        }
    }

    public class TabsContent<TModel> : BuilderBase<TModel>, IDisposable
    {
        public TabsContent(HtmlHelper<TModel> helper, Tab tab)
            : base(helper)
        {
            string active = (tab.Active) ? "active" : null;
            WriteLine(String.Format("<div role='tabpanel' class='tab-pane {0}' id='{1}'>", active, tab.Name));
        }

        public void Dispose()
        {
            WriteLine("</div>");
        }
    }
}
