﻿using System;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a Bootstrap 'Panel' element.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class PanelBuilder<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public PanelBuilder(HtmlHelper<TModel> helper, Panel panel)
        {
            _helper = helper;
            _helper.WriteLine(String.Format("<div class='panel panel-{0} {1}'>", panel._color.GetAttribute<HtmlBuilderAttribute>().Class, panel._class));
            if (!String.IsNullOrEmpty(panel._title) || panel._icon != null)
            {
                _helper.WriteLine("<div class='panel-heading'>");
                _helper.WriteLine(String.Format("<{0} class='panel-title'>{1} {2}</{0}>",
                    panel._headingSize.GetAttribute<HtmlBuilderAttribute>().Tag,
                    new IconBuilder(panel._icon).ToHtmlString(),
                    panel._title));
                _helper.WriteLine("</div>");
            }
        }

        /// <summary>
        ///     Body of the panel
        /// </summary>
        /// <returns></returns>
        public PanelBody<TModel> BeginBody()
        {
            return new PanelBody<TModel>(_helper);
        }

        /// <summary>
        ///     Footer of the panel
        /// </summary>
        /// <returns></returns>
        public PanelFooter<TModel> BeginFooter()
        {
            return new PanelFooter<TModel>(_helper);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }

    public class PanelBody<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public PanelBody(HtmlHelper<TModel> helper)
        {
            _helper = helper;
            _helper.WriteLine("<div class='panel-body'>");
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }

    public class PanelFooter<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public PanelFooter(HtmlHelper<TModel> helper)
        {
            _helper = helper;
            _helper.WriteLine("<div class='panel-footer'>");
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }
}