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
        public PanelSection<TModel> BeginBody()
        {
            return new PanelSection<TModel>(_helper, "panel-body");
        }

        /// <summary>
        ///     Body of the panel
        /// </summary>
        /// <param name="class">Additional class(es) beyond the class required for the body</param>
        /// <returns></returns>
        public PanelSection<TModel> BeginBody(string @class)
        {
            return new PanelSection<TModel>(_helper, "panel-body", @class);
        }

        /// <summary>
        ///     Footer of the panel
        /// </summary>
        /// <returns></returns>
        public PanelSection<TModel> BeginFooter()
        {
            return new PanelSection<TModel>(_helper, "panel-footer");
        }

        /// <summary>
        ///     Footer of the panel
        /// </summary>
        /// <param name="class">Additional class(es) beyond the class required for the footer</param>
        /// <returns></returns>
        public PanelSection<TModel> BeginFooter(string @class)
        {
            return new PanelSection<TModel>(_helper, "panel-footer", @class);
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }

    /// <summary>
    ///     Build a section of the panel by providing the class for that section
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class PanelSection<TModel> : IDisposable
    {
        private HtmlHelper<TModel> _helper;

        public PanelSection(HtmlHelper<TModel> helper, string @class)
        {
            _helper = helper;
            _helper.WriteLine(String.Format("<div class='{0}'>", @class));
        }

        public PanelSection(HtmlHelper<TModel> helper, string @class, string additionalClass)
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