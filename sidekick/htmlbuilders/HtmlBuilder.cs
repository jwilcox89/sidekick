using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace sidekick
{
    /// <summary>
    ///     HTML builders
    /// </summary>
    public static class HtmlBuilder
    {
        /// <summary>
        ///     Builds a button dropdown
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public static ButtonDropdownBuilder Begin(this HtmlHelper helper, ButtonDropdown button)
        {
            return new ButtonDropdownBuilder(helper, button);
        }

        /// <summary>
        ///     Builds an Icon object
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static IconBuilder Begin(this HtmlHelper helper, Icon icon)
        {
            return new IconBuilder(icon);
        }

        /// <summary>
        ///     Builds a Bootstrap modal
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="modal"></param>
        /// <returns></returns>
        public static ModalBuilder Begin(this HtmlHelper helper, Modal modal)
        {
            return new ModalBuilder(helper, modal);
        }

        /// <summary>
        ///     Builds a Bootstrap alert
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="alert"></param>
        /// <returns></returns>
        public static AlertBuilder Begin(this HtmlHelper helper, Alert alert)
        {
            return new AlertBuilder(helper, alert);
        }

        /// <summary>
        ///     Builds a Bootstrap tab panel
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="helper"></param>
        /// <param name="tabType">Specify which style of tabs you would like</param>
        /// <returns></returns>
        public static TabsBuilder Begin(this HtmlHelper helper, TabType tabType)
        {
            return new TabsBuilder(helper, tabType);
        }

        /// <summary>
        ///     Builds a Bootstrap tab panel
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="helper"></param>
        /// <param name="tabType">Specify which style of tabs you would like</param>
        /// <param name="fade">True will enable the javascript fade in/out when toggling tabs</param>
        /// <returns></returns>
        public static TabsBuilder Begin(this HtmlHelper helper, TabType tabType, bool fade)
        {
            return new TabsBuilder(helper, tabType, fade);
        }

        /// <summary>
        ///     Builds a Bootstrap tab panel
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="helper"></param>
        /// <param name="tabType">Specify which style of tabs you would like</param>
        /// <param name="stacked">True if you want the tabs stacked on top of one another</param>
        /// <param name="justified">True if you want the tabs equal widths of their parent</param>
        /// <returns></returns>
        public static TabsBuilder Begin(this HtmlHelper helper, TabType tabType, bool stacked, bool justified, bool fade)
        {
            return new TabsBuilder(helper, tabType, stacked, justified, fade);
        }

        /// <summary>
        ///     Builds a Bootstrap panel
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="panel"></param>
        /// <returns></returns>
        public static PanelBuilder Begin(this HtmlHelper helper, Panel panel)
        {
            return new PanelBuilder(helper, panel);
        }

        /// <summary>
        ///     Builds a Bootstrap accordion
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="helper"></param>
        /// <param name="accordion"></param>
        /// <returns></returns>
        public static AccordionBuilder Begin(this HtmlHelper helper, Accordion accordion)
        {
            return new AccordionBuilder(helper, accordion);
        }

        /// <summary>
        ///     Builds a Bootstrap breadcrumb
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static BreadcrumbBuilder BeginBreadcrumbs(this HtmlHelper helper)
        {
            return new BreadcrumbBuilder(helper);
        }

        /// <summary>
        ///     Builds a Bootstrap breadcrumb
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="helper"></param>
        /// <param name="additionalClass"></param>
        /// <returns></returns>
        public static BreadcrumbBuilder BeginBreadcrumbs(this HtmlHelper helper, string additionalClass)
        {
            return new BreadcrumbBuilder(helper, additionalClass);
        }

        /// <summary>
        ///     Builds a form control
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static FormGroupBuilder<TModel, TProperty> FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, ControlType type)
        {
            return new FormGroupBuilder<TModel, TProperty>(helper, expression, type);
        }

        /// <summary>
        ///     Builds a form control
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="type"></param>
        /// <param name="itemList"></param>
        /// <param name="optionLabel"></param>
        /// <returns></returns>
        public static FormGroupBuilder<TModel, TProperty> FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> itemList, string optionLabel)
        {
            return new FormGroupBuilder<TModel, TProperty>(helper, expression, ControlType.Textbox, itemList, optionLabel);
        }

        /// <summary>
        ///     Builds a form control
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static InputGroupBuilder<TModel, TProperty> InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return new InputGroupBuilder<TModel, TProperty>(helper, expression);
        }

        /// <summary>
        ///     Builds a form control
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="type"></param>
        /// <param name="itemList"></param>
        /// <param name="optionLabel"></param>
        /// <returns></returns>
        public static InputGroupBuilder<TModel, TProperty> InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> itemList, string optionLabel)
        {
            return new InputGroupBuilder<TModel, TProperty>(helper, expression, itemList, optionLabel);
        }

        /// <summary>
        ///     Builds a bootstrap progress bar
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="bar"></param>
        /// <returns></returns>
        public static ProgressBarBuilder BuildProgressBar(this HtmlHelper helper, ProgressBar bar)
        {
            return new ProgressBarBuilder(helper, bar);
        }

        /// <summary>
        ///     Builds an action link
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static HtmlActionLinkBuilder BuildActionLink(this HtmlHelper helper, string controller, string action)
        {
            return new HtmlActionLinkBuilder(helper, controller, action);
        }

        /// <summary>
        ///     Builds an action link
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static HtmlActionLinkBuilder BuildActionLink(this HtmlHelper helper, string controller, string action, string text)
        {
            return new HtmlActionLinkBuilder(helper, controller, action, text);
        }

        /// <summary>
        ///     Builds an action link
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static AjaxActionLinkBuilder BuildActionLink(this AjaxHelper helper, string controller, string action)
        {
            return new AjaxActionLinkBuilder(helper, controller, action);
        }

        /// <summary>
        ///     Builds an action link
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static AjaxActionLinkBuilder BuildActionLink(this AjaxHelper helper, string controller, string action, string text)
        {
            return new AjaxActionLinkBuilder(helper, controller, action, text);
        }

        /// <summary>
        ///     Builds a bootstrap toggle element (http://www.bootstraptoggle.com/)
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="helper"></param>
        /// <param name="elementName">Unique identifier for element</param>
        /// <param name="toggleState">Default to On or Off?</param>
        /// <returns></returns>
        public static ToggleBuilder BuildToggle(this HtmlHelper helper, string elementName, bool toggleState)
        {
            return new ToggleBuilder(elementName, toggleState);
        }
    }
}
