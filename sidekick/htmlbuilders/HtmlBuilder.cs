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
        public static ModalBuilder<TModel> BeginModal<TModel>(this HtmlHelper<TModel> helper, Modal modal) {
            return new ModalBuilder<TModel>(helper, modal);
        }

        /// <summary>
        ///     Builds a Bootstrap alert
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="alert"></param>
        /// <returns></returns>
        public static AlertBuilder<TModel> BeginAlert<TModel>(this HtmlHelper<TModel> helper, Alert alert) {
            return new AlertBuilder<TModel>(helper, alert, true);
        }

        /// <summary>
        ///     Builds a Bootstrap alert
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="alert"></param>
        /// <returns></returns>
        public static MvcHtmlString BuildAlert<TModel>(this HtmlHelper<TModel> helper, Alert alert) {
            new AlertBuilder<TModel>(helper, alert, false);
            return new MvcHtmlString(String.Empty);
        }

        /// <summary>
        ///     Builds a Bootstrap tab panel
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static TabsBuilder<TModel> BeginTabs<TModel>(this HtmlHelper<TModel> helper) {
            return new TabsBuilder<TModel>(helper);
        }

        /// <summary>
        ///     Builds a Bootstrap panel
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="panel"></param>
        /// <returns></returns>
        public static PanelBuilder<TModel> BeginPanel<TModel>(this HtmlHelper<TModel> helper, Panel panel) {
            return new PanelBuilder<TModel>(helper, panel);
        }

        /// <summary>
        ///     Begins a custom workflow process. Must include the 'bootstrap-progress.css' file in your project.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="totalSteps"></param>
        /// <returns></returns>
        public static StepsBuilder<TModel> BeginSteps<TModel>(this HtmlHelper<TModel> helper, int totalSteps) {
            return new StepsBuilder<TModel>(helper, totalSteps);
        }

        /// <summary>
        ///     Builds a Bootstrap breadcrumb
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static BreadcrumbBuilder<TModel> BeginBreadcrumbs<TModel>(this HtmlHelper<TModel> helper) {
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
        public static InputGroupBuilder<TModel,TProperty> InputGroupFor<TModel,TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel,TProperty>> expression, object htmlAttributes = null) {
            return new InputGroupBuilder<TModel,TProperty>(helper, expression, htmlAttributes);
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
        public static FormGroupBuilder<TModel,TProperty> FormGroupFor<TModel,TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel,TProperty>> expression, object textboxHtmlAttributes = null) {
            return new FormGroupBuilder<TModel,TProperty>(helper, expression, textboxHtmlAttributes);
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
        public static FormGroupBuilder<TModel,TProperty> FormGroupFor<TModel,TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel,TProperty>> expression, IEnumerable<SelectListItem> itemList, string optionLabel, object textboxHtmlAttributes = null) {
            return new FormGroupBuilder<TModel,TProperty>(helper, expression, itemList, textboxHtmlAttributes, optionLabel);
        }

        /// <summary>
        ///     Builds a Bootstrap label.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="color"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static MvcHtmlString BuildLabel(this HtmlHelper helper, Colors color, string text) {
            return LabelBuilder.Build(color, text);
        }

        public static TextAreaBuilder<TModel,TProperty> TextAreaBuilder<TModel,TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel,TProperty>> expression, object textboxHtmlAttributes = null) {
            return new TextAreaBuilder<TModel,TProperty>(helper, expression, textboxHtmlAttributes);
        }
    }
}
