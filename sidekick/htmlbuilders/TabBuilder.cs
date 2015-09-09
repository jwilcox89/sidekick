using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sidekick
{
    public class TabBuilder : IDisposable
    {
        private HtmlHelper _helper;
        private Queue<Tab> _tabList;

        public TabBuilder(HtmlHelper helper) {
            _helper = helper;
            _helper.ViewContext.Writer.Write("<div role='tabpanel'>");
        }

        public TabNav BeginNavSection() {
            TabNav nav = new TabNav(_helper);
            _tabList = nav.TabList;
            return nav;
        }

        public TabContent BeginContentSection() {
            return new TabContent(_helper, _tabList);
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div>");
        }
    }

    public class TabNav : IDisposable
    {
        public Queue<Tab> TabList;
        private HtmlHelper _helper;

        public TabNav(HtmlHelper helper) {
            TabList = new Queue<Tab>();
            _helper = helper;
            _helper.ViewContext.Writer.Write("<ul role='tablist' class='nav nav-tabs'>");
        }

        public MvcHtmlString BuildTab(Tab tab, string displayText) {
            TabList.Enqueue(tab);
            TabNavBuilder.Build(_helper, tab, displayText);
            return new MvcHtmlString(String.Empty);
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</ul>");
        }
    }

    public class TabContent : IDisposable
    {
        private HtmlHelper _helper;
        private Queue<Tab> _tabList;

        public TabContent(HtmlHelper helper, Queue<Tab> tabList) {
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

    public static class TabNavBuilder
    {
        public static void Build(HtmlHelper helper, Tab tab, string displayText) {
            string active = (tab.Active) ? "class='active'" : null;
            helper.ViewContext.Writer.Write(String.Format("<li role='presentation' {0}>", active));

            helper.ViewContext.Writer.Write(String.Format("<a href='#{0}' aria-controls='{0}' role='tab' data-toggle='tab'>", tab.Name));

            if (!String.IsNullOrEmpty(tab.Icon))
                helper.ViewContext.Writer.Write(String.Format("<i class='{0}'></i>&nbsp;", tab.Icon));

            helper.ViewContext.Writer.Write(displayText);
            helper.ViewContext.Writer.Write("</a></li>");
        }
    }

    public class TabContentBuilder : IDisposable
    {
        private HtmlHelper _helper;

        public TabContentBuilder(HtmlHelper helper, Tab tab) {
            _helper = helper;

            string active = (tab.Active) ? "active" : null;
            _helper.ViewContext.Writer.Write(String.Format("<div role='tabpanel' class='tab-pane {0}' id='{1}'>", active, tab.Name));
        }

        public void Dispose() {
            _helper.ViewContext.Writer.Write("</div>");
        }
    }
}
