using System;
using System.Web.Mvc;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a Bootstrap 'Panel' element.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class PanelBuilder : IDisposable
    {
        private HtmlHelper _helper;

        public PanelBuilder(HtmlHelper helper, Panel panel)
        {
            _helper = helper;
            _helper.WriteLine($"<div class='panel panel-{panel._color.GetAttribute<HtmlBuilderAttribute>().Class} {panel._class}'>");
        }

        /// <summary>
        ///     Heading of the panel. Title element class 'panel-title'.
        /// </summary>
        /// <returns></returns>
        public PanelSection BeginHeading()
        {
            return new PanelSection(_helper, "panel-heading");
        }

        /// <summary>
        ///     Heading of the panel. Title element class 'panel-title'.
        /// </summary>
        /// <param name="class">Additional class(es) beyond the class required for the heading</param>
        /// <returns></returns>
        public PanelSection BeginHeading(string @class)
        {
            return new PanelSection(_helper, "panel-heading", @class);
        }

        /// <summary>
        ///     Body of the panel
        /// </summary>
        /// <returns></returns>
        public PanelSection BeginBody()
        {
            return new PanelSection(_helper, "panel-body");
        }

        /// <summary>
        ///     Body of the panel
        /// </summary>
        /// <param name="class">Additional class(es) beyond the class required for the body</param>
        /// <returns></returns>
        public PanelSection BeginBody(string @class)
        {
            return new PanelSection(_helper, "panel-body", @class);
        }

        /// <summary>
        ///     Footer of the panel
        /// </summary>
        /// <returns></returns>
        public PanelSection BeginFooter()
        {
            return new PanelSection(_helper, "panel-footer");
        }

        /// <summary>
        ///     Footer of the panel
        /// </summary>
        /// <param name="class">Additional class(es) beyond the class required for the footer</param>
        /// <returns></returns>
        public PanelSection BeginFooter(string @class)
        {
            return new PanelSection(_helper, "panel-footer", @class);
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
    public class PanelSection : IDisposable
    {
        private HtmlHelper _helper;

        public PanelSection(HtmlHelper helper, string @class)
        {
            _helper = helper;
            _helper.WriteLine($"<div class='{@class}'>");
        }

        public PanelSection(HtmlHelper helper, string @class, string additionalClass)
        {
            _helper = helper;
            _helper.WriteLine($"<div class='{@class} {additionalClass}'>");
        }

        public void Dispose()
        {
            _helper.WriteLine("</div>");
        }
    }
}