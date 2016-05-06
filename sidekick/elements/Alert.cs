using System;
using System.Linq;
using System.Collections.Generic;

namespace sidekick
{
    public class Alert : IView
    {
        public virtual string ViewName { get; set; }
        internal AlertType _type;
        internal bool _dismissible;
        internal string _heading;
        internal IEnumerable<string> _messageList;
        internal string _body;

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

        /// <summary>
        ///     DEFAULTS: 
        ///     <para>AlertType = Info</para>
        /// </summary>
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

        /// <summary>
        ///     Set body of alert
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Alert Body(string text)
        {
            _body = text;
            return this;
        }

        /// <summary>
        ///     Set the type of alert
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Alert Type(AlertType type)
        {
            _type = type;
            return this;
        }

        /// <summary>
        ///     Makes the alert dismissible
        /// </summary>
        /// <returns></returns>
        public Alert Dismissible()
        {
            _dismissible = true;
            return this;
        }

        /// <summary>
        ///     Sets the heading for the alert
        /// </summary>
        /// <param name="heading"></param>
        /// <returns></returns>
        public Alert Heading(string heading)
        {
            _heading = heading;
            return this;
        }

        /// <summary>
        ///     Adds a list of messages to the alert
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public Alert MessageList(IEnumerable<string> messages)
        {
            _messageList = messages;
            return this;
        }
    }
}

