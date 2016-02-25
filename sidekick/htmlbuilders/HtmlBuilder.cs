using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace sidekick
{
    public static class HtmlBuilder
    {
        /// <summary>
        ///     Builds a Bootstrap modal
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="modal"></param>
        /// <returns></returns>
        public static ModalBuilder<TModel> BeginModal<TModel>(this HtmlHelper<TModel> helper, Modal modal)
        {
            return new ModalBuilder<TModel>(helper, modal);
        }

        /// <summary>
        ///     Builds a Bootstrap alert
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="alert"></param>
        /// <returns></returns>
        public static AlertBuilder<TModel> BeginAlert<TModel>(this HtmlHelper<TModel> helper, Alert alert)
        {
            return new AlertBuilder<TModel>(helper, alert);
        }

        /// <summary>
        ///     Builds a Bootstrap tab panel
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="helper"></param>
        /// <param name="tabType">Specify which style of tabs you would like</param>
        /// <returns></returns>
        public static TabsBuilder<TModel> BeginTabs<TModel>(this HtmlHelper<TModel> helper, TabTypes tabType)
        {
            return new TabsBuilder<TModel>(helper, tabType);
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
        public static TabsBuilder<TModel> BeginTabs<TModel>(this HtmlHelper<TModel> helper, TabTypes tabType, bool stacked, bool justified)
        {
            return new TabsBuilder<TModel>(helper, tabType, stacked, justified);
        }

        /// <summary>
        ///     Builds a Bootstrap panel
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="panel"></param>
        /// <returns></returns>
        public static PanelBuilder<TModel> BeginPanel<TModel>(this HtmlHelper<TModel> helper, Panel panel)
        {
            return new PanelBuilder<TModel>(helper, panel);
        }

        /// <summary>
        ///     Begins a custom workflow process. Must include the 'bootstrap-progress.css' file in your project.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="totalSteps"></param>
        /// <returns></returns>
        public static StepsBuilder<TModel> BeginSteps<TModel>(this HtmlHelper<TModel> helper)
        {
            return new StepsBuilder<TModel>(helper);
        }

        /// <summary>
        ///     Builds a Bootstrap breadcrumb
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static BreadcrumbBuilder<TModel> BeginBreadcrumbs<TModel>(this HtmlHelper<TModel> helper)
        {
            return new BreadcrumbBuilder<TModel>(helper);
        }

        /// <summary>
        ///     Builds a Bootstrap textbox with an input group. No label.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static InputGroupBuilder<TModel, TProperty> InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return new InputGroupBuilder<TModel, TProperty>(helper, expression, htmlAttributes);
        }

        /// <summary>
        ///     Builds a Bootstrap input group. Includes a label, dropdown list and validation if nessecary
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="itemList"></param>
        /// <param name="optionLabel"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static InputGroupBuilder<TModel, TProperty> InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> itemList, string optionLabel, object htmlAttributes = null)
        {
            return new InputGroupBuilder<TModel, TProperty>(helper, expression, itemList, optionLabel, htmlAttributes);
        }

        /// <summary>
        ///     Builds a Bootstrap input group. Includes a label, dropdown list and validation if nessecary. Default OptionLabel is "--Select--".
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="itemList"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static InputGroupBuilder<TModel, TProperty> InputGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> itemList, object htmlAttributes = null)
        {
            return new InputGroupBuilder<TModel, TProperty>(helper, expression, itemList, "--Select--", htmlAttributes);
        }

        /// <summary>
        ///     Builds a Bootstrap form group. Includes a label, textbox and validation if nessecary
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="textboxHtmlAttributes"></param>
        /// <returns></returns>
        public static FormGroupBuilder<TModel, TProperty> FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object textboxHtmlAttributes = null)
        {
            return new FormGroupBuilder<TModel, TProperty>(helper, expression, textboxHtmlAttributes);
        }

        /// <summary>
        ///     Builds a Bootstrap form group. Includes a label, dropdown list and validation if nessecary
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="itemList"></param>
        /// <param name="optionLabel"></param>
        /// <param name="textboxHtmlAttributes"></param>
        /// <returns></returns>
        public static FormGroupBuilder<TModel, TProperty> FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> itemList, string optionLabel, object textboxHtmlAttributes = null)
        {
            return new FormGroupBuilder<TModel, TProperty>(helper, expression, itemList, optionLabel, textboxHtmlAttributes);
        }

        /// <summary>
        ///     Builds a Bootstrap form group. Includes a label, dropdown list and validation if nessecary. Default OptionLabel is "--Select--".
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="itemList"></param>
        /// <param name="textboxHtmlAttributes"></param>
        /// <returns></returns>
        public static FormGroupBuilder<TModel, TProperty> FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> itemList, object textboxHtmlAttributes = null)
        {
            return new FormGroupBuilder<TModel, TProperty>(helper, expression, itemList, "--Select--", textboxHtmlAttributes);
        }

        /// <summary>
        ///     Builds a textarea
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="textboxHtmlAttributes"></param>
        /// <returns></returns>
        public static TextAreaBuilder<TModel, TProperty> FormGroupTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object textboxHtmlAttributes = null)
        {
            return new TextAreaBuilder<TModel, TProperty>(helper, expression, textboxHtmlAttributes);
        }

        /// <summary>
        ///     Builds an action link
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static HtmlActionLinkBuilder BeginActionLink(this HtmlHelper helper, string controller, string action)
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
        public static HtmlActionLinkBuilder BeginActionLink(this HtmlHelper helper, string controller, string action, string text)
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
        public static AjaxActionLinkBuilder BeginActionLink(this AjaxHelper helper, string controller, string action)
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
        public static AjaxActionLinkBuilder BeginActionLink(this AjaxHelper helper, string controller, string action, string text)
        {
            return new AjaxActionLinkBuilder(helper, controller, action, text);
        }
    }
}
