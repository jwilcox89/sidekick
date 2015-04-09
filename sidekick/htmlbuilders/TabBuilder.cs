using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public class TabBuilder : IDisposable
    {
        private HtmlHelper _helper;
        private Queue<ITab> _tabList;

        public TabBuilder(HtmlHelper helper) {
            _helper = helper;
            _helper.ViewContext.Writer.Write("<div role='tabpanel'>");
        }

        public TabNav BeginNav() {
            TabNav nav = new TabNav(_helper);
            _tabList = nav.TabList;
            return nav;
        }

        public TabContent BeginContent() {
            return new TabContent(_helper, _tabList);
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div>");
        }
    }

    public class TabNav : IDisposable
    {
        public Queue<ITab> TabList;
        private HtmlHelper _helper;

        public TabNav(HtmlHelper helper) {
            TabList = new Queue<ITab>();
            _helper = helper;
            _helper.ViewContext.Writer.Write("<ul role='tablist' class='nav nav-tabs'>");
        }

        public MvcHtmlString BeginTabNav(ITab tab, string displayText) {
            TabList.Enqueue(tab);
            new TabNavBuilder(_helper, tab, displayText);
            return new MvcHtmlString(string.Empty);
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</ul>");
        }
    }

    public class TabContent : IDisposable
    {
        private HtmlHelper _helper;
        private Queue<ITab> _tabList;

        public TabContent(HtmlHelper helper, Queue<ITab> tabList) {
            _helper = helper;
            _tabList = tabList;
            _helper.ViewContext.Writer.Write("<div class='tab-content'>");
        }

        public TabContentBuilder BeginTabContent() {
            return new TabContentBuilder(_helper, _tabList.Dequeue());
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div>");
        }
    }

    public class TabNavBuilder
    {
        private HtmlHelper _helper;

        public TabNavBuilder(HtmlHelper helper, ITab tab, string displayText) {
            _helper = helper;

            string active = (tab.Active) ? "class='active'" : null;
            _helper.ViewContext.Writer.Write(string.Format("<li role='presentation' {0}>", active));
            _helper.ViewContext.Writer.Write(string.Format("<a href='#{0}' aria-controls='{0}' role='tab' data-toggle='tab'>", tab.Name));
            _helper.ViewContext.Writer.Write(displayText);
            _helper.ViewContext.Writer.Write("</a></li>");
        }
    }

    public class TabContentBuilder : IDisposable
    {
        private HtmlHelper _helper;

        public TabContentBuilder(HtmlHelper helper, ITab tab) {
            _helper = helper;

            string active = (tab.Active) ? "active" : null;
            _helper.ViewContext.Writer.Write(string.Format("<div role='tabpanel' class='tab-pane {0}' id='{1}'>", active, tab.Name));
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div>");
        }
    }
}
