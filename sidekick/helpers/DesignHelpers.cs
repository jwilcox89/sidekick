using System;
using System.Web.Mvc;
using System.Globalization;
using System.Drawing;

namespace sidekick
{
    public static class DesignHelpers
    {
        private const string WHITE_TEXT = "#ffffff";
        private const string BLACK_TEXT = "#000000";

        /// <summary>
        ///     Sets the text color to black or white depending on the background color.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="backgroundColor"></param>
        /// <returns></returns>
        public static string SetTextColor(this HtmlHelper helper, string backgroundColor) {

            if (!backgroundColor.StartsWith("#"))
                backgroundColor = string.Format("#{0}", backgroundColor);

            Color c = ColorTranslator.FromHtml(backgroundColor);

            return (PerceivedBrightness(c) > 130 ? BLACK_TEXT : WHITE_TEXT);
            
        }

        /// <summary>
        ///     Lightens the color provided by the 'lightenBy' value.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="color"></param>
        /// <param name="lightenBy"></param>
        /// <returns></returns>
        public static string LightenColor(this HtmlHelper helper, string color, float lightenBy) {

            if (!color.StartsWith("#"))
                color = string.Format("#{0}", color);

            Color c = ColorTranslator.FromHtml(color);

            float red   = (255 - c.R) * lightenBy + c.R;
            float green = (255 - c.G) * lightenBy + c.G;
            float blue  = (255 - c.B) * lightenBy + c.B;

            return ColorTranslator.ToHtml(Color.FromArgb(c.A, (int)red, (int)green, (int)blue));
        }

        private static int PerceivedBrightness(Color c) {

            return (int)Math.Sqrt(c.R * c.R * .241 +
                                  c.G * c.G * .691 +
                                  c.B * c.B * .068);
        }
    }
}
