using System;
using System.Collections.Generic;

namespace sidekick
{
    public class Alert : IView
    {
        /// <summary>
        ///     View name that will be generated with Alert details
        /// </summary>
        public virtual string ViewName { get; set; }

        /// <summary>
        ///     Success, Failure, Warning etc. Default value "Info"
        /// </summary>
        public virtual AlertType Type { get; set; }

        /// <summary>
        ///     If true the alert box will be dismissible. Default value false.
        /// </summary>
        public virtual bool Dismissible { get; set; }

        /// <summary>
        ///     The heading (ex. Error or Add User)
        /// </summary>
        public virtual string Heading { get; set; }

        /// <summary>
        ///     The body of the message (ex. User was added successfully)
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        ///     Used for multiple errors or success messages that are generally generated from a list of ModelState errors or AspIdentity IdentityErrors 
        /// </summary>
        public virtual List<string> MessageList { get; set; }

        /// <summary>
        ///     Sets the alert class here. Ex. "alert alert-success"
        /// </summary>
        public virtual string AlertClass 
        {
            get 
            {
                string className = Type.GetHtmlAttributes<AlertType>().Class;
                if (Dismissible)
                    className = String.Format("{0} alert-dismissable", className);

                return className;
            }
        }

        public Alert() 
        {
            Type = AlertType.Info;
            MessageList = new List<string>();
        }

        public Alert(AlertType type) 
        {
            Type = type;
            MessageList = new List<string>();
        }
    }
}

