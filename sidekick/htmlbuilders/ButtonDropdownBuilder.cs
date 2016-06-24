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
            _helper.WriteLine(String.Format("<button type='button' class='btn btn-{0} dropdown-toggle' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>", button._color.GetAttribute<HtmlBuilderAttribute>().Class));

            if (button._icon == null)
            {
                _helper.WriteLine(button._title);
            }
            else
            {
                _helper.WriteLine(String.Format("{0} {1}", new IconBuilder(button._icon).ToHtmlString(), button._title));
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
