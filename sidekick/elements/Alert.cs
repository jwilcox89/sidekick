using System;
using System.Linq;
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
        internal AlertType _type;

        /// <summary>
        ///     If true the alert box will be dismissible. Default value false.
        /// </summary>
        internal bool _dismissible;

        /// <summary>
        ///     The heading (ex. Error or Add User)
        /// </summary>
        internal string _heading;

        /// <summary>
        ///     Used for multiple errors or success messages that are generally generated from a list of ModelState errors or AspIdentity IdentityErrors 
        /// </summary>
        internal IEnumerable<string> _messageList;

        /// <summary>
        ///     Body of the alert
        /// </summary>
        internal string _body;

        /// <summary>
        ///     Sets the alert class here. Ex. "alert alert-success"
        /// </summary>
        internal string _alertClass
        {
            get
            {
                string className = _type.GetAttribute<AlertType, HtmlBuilderAttribute>().Class;
                if (_dismissible)
                    className = String.Format("{0} alert-dismissable", className);

                return className;
            }
        }

        public Alert Body(string text)
        {
            _body = text;
            return this;
        }

        public Alert Type(AlertType type)
        {
            _type = type;
            return this;
        }

        public Alert Dismissible()
        {
            _dismissible = true;
            return this;
        }

        public Alert Heading(string heading)
        {
            _heading = heading;
            return this;
        }

        public Alert MessageList(IEnumerable<string> messages)
        {
            _messageList = messages;
            return this;
        }

        public Alert()
        {
            _type = AlertType.Info;
            _messageList = Enumerable.Empty<string>();
        }

        public Alert(AlertType type)
        {
            _type = type;
            _messageList = Enumerable.Empty<string>();
        }
    }
}

