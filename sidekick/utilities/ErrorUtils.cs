using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace sidekick
{
    /// <summary>
    ///     ModelState extensions
    /// </summary>
    public static class ErrorUtils
    {
        /// <summary>
        ///     Get a list of the errors in the ModelState
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetModelErrors(this ModelStateDictionary modelState) 
        {
            return modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
        }

        /// <summary>
        ///     Gets a list of the errors in the identity result and places them in the model state.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="result"></param>
        public static void AddIdentityErrors(this ModelStateDictionary state, IdentityResult result) 
        {
            foreach (string error in result.Errors)
            {
                state.AddModelError("", error);
            }
        }
    }
}
