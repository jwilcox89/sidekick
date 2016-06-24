using System.Web.Mvc;

namespace sidekick.mockup
{
    public static class MockupHtmlBuilder
    {
        public static MockupInputBuilder BuildInput(this HtmlHelper helper, string label, MockupInputType inputType)
        {
            return new MockupInputBuilder(helper, label, inputType);
        }
    }
}
