using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace sidekick
{
    public static class ErrorExtensions
    {
        /// <summary>
        ///     Get a list of the errors in the ModelState
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static List<string> GetModelErrors(this ModelStateDictionary modelState) {
            List<string> errorList = new List<string>();

            foreach (ModelError e in modelState.Values.SelectMany(m => m.Errors)) {
                errorList.Add(e.ErrorMessage);
            }

            return errorList;
        }

        /// <summary>
        ///     Gets a list of the errors in the identity result and places them in the model state.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="result"></param>
        public static void AddIdentityErrors(this ModelStateDictionary state, IdentityResult result) {
            foreach (string error in result.Errors) {
                state.AddModelError("", error);
            }
        }
    }
}
