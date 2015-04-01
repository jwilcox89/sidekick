using System.Collections.Generic;

namespace sidekick
{
    public class Alert : IAlert
    {
        /// <summary>
        ///     View name that will be generated with Alert details
        /// </summary>
        public string ViewName { get; set; }

        /// <summary>
        ///     Success, Failure, Warning etc
        /// </summary>
        public MessageTypes MessageType { get; set; }

        /// <summary>
        ///     If true the alert box will be dismissible
        /// </summary>
        public bool Dismissible { get; set; }

        /// <summary>
        ///     The heading (ex. Error or Add User)
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        ///     The body of the message (ex. User was added successfully)
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     Used for multiple errors or success messages that are generally generated from a list of ModelState errors or AspIdentity IdentityErrors 
        /// </summary>
        public List<string> MessageList { get; set; }

        /// <summary>
        ///     Sets the alert class here. Ex. "alert alert-success"
        /// </summary>
        public virtual string AlertClass {
            get {
                string className = HtmlConverters.MessageTypeConverter(MessageType);
                if (Dismissible)
                    className = string.Format("{0} alert-dismissable", className);

                return className;
            }
        }

        public virtual string Icon {
            get {
                return HtmlConverters.IconConverter(MessageType);
            }
        }

        public Alert() {
            MessageList = new List<string>();
        }
    }
}

