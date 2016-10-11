using System;
using System.Web.Mvc;

namespace sidekick
{
    public class ButtonDropdownBuilder : IDisposable
    {
        private HtmlHelper _helper;

        public ButtonDropdownBuilder(HtmlHelper helper, ButtonDropdown button)
        {
            _helper = helper;
            _helper.WriteLine("<div class='form-group'>");
            _helper.WriteLine("<div class='btn-group'>");
            _helper.WriteLine($"<button type='button' class='btn btn-{button._color.GetAttribute<HtmlBuilderAttribute>().Class} dropdown-toggle' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>");

            if (button._icon == null)
            {
                _helper.WriteLine(button._title);
            }
            else
            {
                _helper.WriteLine($"{new IconBuilder(button._icon).ToHtmlString()} {button._title}");
            }

            _helper.WriteLine(" <span class='caret'></span>");
            _helper.WriteLine("</button>");

            _helper.WriteLine("<ul class='dropdown-menu'>");
        }

        public void Dispose()
        {
            _helper.WriteLine("</ul></div></div>");
        }
    }
}
