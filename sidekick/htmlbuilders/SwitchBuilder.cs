using System;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.IO;

namespace sidekick
{
    /// <summary>
    ///     HTML builder for a Bootstrap 'switch' element (http://www.bootstrap-switch.org/).
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class SwitchBuilder<TModel> : Switch, IHtmlString
    {
        private HtmlHelper<TModel> _helper;

        public SwitchBuilder(HtmlHelper<TModel> helper, string elementName, bool switchState)
        {
            _helper = helper;
            _elementName = elementName;
            _state = switchState;
        }

        public string ToHtmlString()
        {
            using (HtmlTextWriter writer = new HtmlTextWriter(new StringWriter()))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Name, _elementName);
                writer.AddAttribute(HtmlTextWriterAttribute.Type, "checkbox");
                writer.AddAttribute("data-state", _state.ToString().ToLower());

                if (_size.HasValue)
                    writer.AddAttribute("data-size", _size.Value.GetAttribute<HtmlBuilderAttribute>().Class);

                if (!_animate)
                    writer.AddAttribute("data-animate", _animate.ToString().ToLower());

                if (_disabled)
                    writer.AddAttribute(HtmlTextWriterAttribute.Disabled, _disabled.ToString().ToLower());

                if (_readOnly)
                    writer.AddAttribute(HtmlTextWriterAttribute.ReadOnly, _readOnly.ToString().ToLower());

                if (_indeterminate)
                    writer.AddAttribute("data-indeterminate", _indeterminate.ToString().ToLower());

                if (_inverse)
                    writer.AddAttribute("data-inverse", _inverse.ToString().ToLower());

                if (_radioAllOff)
                    writer.AddAttribute("data-radio-all-off", _radioAllOff.ToString().ToLower());

                if (_onColor.HasValue)
                    writer.AddAttribute("data-on-color", _onColor.Value.GetAttribute<HtmlBuilderAttribute>().Class);

                if (_offColor.HasValue)
                    writer.AddAttribute("data-off-color", _offColor.Value.GetAttribute<HtmlBuilderAttribute>().Class);

                if (!String.IsNullOrEmpty(_onText))
                    writer.AddAttribute("data-on-text", _onText);

                if (!String.IsNullOrEmpty(_offText))
                    writer.AddAttribute("data-off-text", _offText);

                if (!String.IsNullOrEmpty(_labelText))
                    writer.AddAttribute("data-label-text", _labelText);

                if (!String.IsNullOrEmpty(_handleWidth))
                    writer.AddAttribute("data-handle-width", _handleWidth);

                if (!String.IsNullOrEmpty(_labelWidth))
                    writer.AddAttribute("data-label-width", _labelWidth);

                if (!String.IsNullOrEmpty(_baseClass))
                    writer.AddAttribute("data-base-class", _baseClass);

                if (!String.IsNullOrEmpty(_wrapperClass))
                    writer.AddAttribute("data-wrapper-class", _wrapperClass);

                writer.RenderBeginTag(HtmlTextWriterTag.Input);
                writer.RenderEndTag();

                return new MvcHtmlString(writer.InnerWriter.ToString()).ToString();
            }
        }
    }
}
