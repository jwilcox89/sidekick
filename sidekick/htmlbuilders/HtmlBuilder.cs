using System;
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
        public static ModalBuilder BeginModal(this HtmlHelper helper, Modal modal) {
            return new ModalBuilder(helper, modal);
        }

        /// <summary>
        ///     Builds a Bootstrap alert
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="alert"></param>
        /// <returns></returns>
        public static AlertBuilder BeginAlert(this HtmlHelper helper, Alert alert) {
            return new AlertBuilder(helper, alert, true);
        }

        /// <summary>
        ///     Builds a Bootstrap alert
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="alert"></param>
        /// <returns></returns>
        public static MvcHtmlString BuildAlert(this HtmlHelper helper, Alert alert) {
            new AlertBuilder(helper, alert, false);
            return new MvcHtmlString(string.Empty);
        }

        /// <summary>
        ///     Builds a Bootstrap tab panel
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static TabBuilder BeginTabs(this HtmlHelper helper) {
            return new TabBuilder(helper);
        }

        /// <summary>
        ///     Builds a Bootstrap panel
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="panel"></param>
        /// <returns></returns>
        public static PanelBuilder BeginPanel(this HtmlHelper helper, Panel panel) {
            return new PanelBuilder(helper, panel);
        }

        /// <summary>
        ///     Begins a custom workflow process. Must include the 'bootstrap-progress.css' file in your project.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="totalSteps"></param>
        /// <returns></returns>
        public static StepsBuilder BeginSteps(this HtmlHelper helper, int totalSteps) {
            return new StepsBuilder(helper, totalSteps);
        }

        /// <summary>
        ///     Builds a Bootstrap breadcrumb
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static BreadcrumbBuilder BeginBreadcrumbs(this HtmlHelper helper) {
            return new BreadcrumbBuilder(helper);
        }

        /// <summary>
        ///     Builds a Bootstrap textbox with an input group
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
        ///     Builds a Bootstrap label.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="color"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static MvcHtmlString BuildLabel(this HtmlHelper helper, Colors color, string text) {
            return LabelBuilder.Build(color, text);
        }
    }
}
