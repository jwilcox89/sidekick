﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for an Ajax action link element.
    /// </summary>
    public class AjaxActionLinkBuilder : ActionLinkBase<AjaxActionLinkBuilder>, IHtmlString
    {
        private AjaxHelper _helper;
        private AjaxOptions _options;

        public AjaxActionLinkBuilder(AjaxHelper helper, string controller, string action)
        {
            _helper = helper;
            _controller = controller;
            _action = action;
        }

        public AjaxActionLinkBuilder(AjaxHelper helper, string controller, string action, string text)
        {
            _helper = helper;
            _controller = controller;
            _action = action;
            _text = text;
        }

        /// <summary>
        ///     Sets the ajax options for the link
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public AjaxActionLinkBuilder AjaxOptions(AjaxOptions options)
        {
            _options = options;
            return this;
        }

        public string ToHtmlString()
        {
            return _helper.ActionLink(REPLACEMENT_TEXT, _action, _controller, _routeValues, _options, _htmlAttributes)
                .ToString()
                .Replace(REPLACEMENT_TEXT, $"{new IconBuilder(_icon).ToHtmlString()} {_text}");
        }
    }
}