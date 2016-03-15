using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace sidekick
{
    public class CheckboxBuilder<TModel> : Checkbox, IHtmlString
    {
        private HtmlHelper<TModel> _helper;
        private Expression<Func<TModel, bool>> _expression;

        public CheckboxBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, CheckboxType type)
        {
            _helper = helper;
            _expression = expression;
            _type = type;
        }

        public string ToHtmlString()
        {
            _helper.WriteLine("<div class='form-group'>");

            switch (_type)
            {
                case CheckboxType.Checkbox:
                    _helper.WriteLine(_helper.CheckBoxFor(_expression, _htmlAttributes));
                    break;
                case CheckboxType.RadioButton:
                    _helper.WriteLine(_helper.RadioButtonFor(_expression, "", _htmlAttributes));
                    break;
            }

            if (_label || _labelWithColon)
            {
                _helper.WriteLine("&nbsp;");
                if (_label)
                    _helper.WriteLine(_helper.LabelForNoColon(_expression, _isRequired));

                if (_labelWithColon)
                    _helper.WriteLine(_helper.LabelForWithColon(_expression, _isRequired));
            }

            _helper.WriteLine("</div>");
            return String.Empty;
        }
    }
}
