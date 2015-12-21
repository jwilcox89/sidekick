using System.Web;

namespace sidekick
{
    public class SessionManagerBase
    {
        protected static T GetOrSetSessionVariable<T>(string variableName, T variableValue) 
        {
            if (HttpContext.Current.Session[variableName] == null) 
            {
                HttpContext.Current.Session.Add(variableName, variableValue);
                return variableValue;
            }
            
            return (T)HttpContext.Current.Session[variableName];
        }

        protected static void UpdateOrSetSessionVariable<T>(string variableName, T variableValue) 
        {
            if (HttpContext.Current.Session[variableName] == null) 
            {
                HttpContext.Current.Session.Add(variableName, variableValue);
            } 
            else 
            {
                HttpContext.Current.Session[variableName] = variableValue;
            }   
        }
    }
}
