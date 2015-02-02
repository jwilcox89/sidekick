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
        ///     Makes the color lighter or darker
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="color"></param>
        /// <param name="correctionFactor">Must be between -1 and 1. Negative values produce darker colors. ex. 0.15 = 15%.</param>
        /// <returns></returns>
        public static string ChangeColor(this HtmlHelper helper, string color, float correctionFactor) {
            if (!color.StartsWith("#"))
                color = string.Format("#{0}", color);

            Color c = ColorTranslator.FromHtml(color);

            float red = (float)c.R;
            float green = (float)c.G;
            float blue = (float)c.B;

            if (correctionFactor < 0) {
                correctionFactor = 1 + correctionFactor;
                red   *= correctionFactor;
                green *= correctionFactor;
                blue  *= correctionFactor;
            } else {
                red   = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue  = (255 - blue) * correctionFactor + blue;
            }

            return ColorTranslator.ToHtml(Color.FromArgb(c.A, (int)red, (int)green, (int)blue));
        }

        private static int PerceivedBrightness(Color c) {
            return (int)Math.Sqrt(c.R * c.R * .241 +
                                  c.G * c.G * .691 +
                                  c.B * c.B * .068);
        }
    }
}
