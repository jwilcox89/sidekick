using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace sidekick
{
    public static class ErrorHandler
    {
        /// <summary>
        ///     Get a list of the errors in the ModelState
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static List<string> GetModelErrors(this ModelStateDictionary modelState) {

            List<string> errorList = new List<string>();

            foreach (var e in modelState.Values.SelectMany(m => m.Errors)) {
                errorList.Add(e.ErrorMessage);
            }

            return errorList;
        }
    }
}
