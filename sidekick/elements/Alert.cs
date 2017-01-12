using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace sidekick
{
    /// <summary>
    ///     Bootstrap 'Alert' element
    /// </summary>
    public class Alert
    {
        internal AlertType _type;
        internal bool _dismissible;
        internal string _heading;
        internal string _body;
        internal IEnumerable<string> _messageList;

        /// <summary>
        ///     Class used with alert
        /// </summary>
        internal string _alertClass => _dismissible
            ? _type.GetAttribute<HtmlBuilderAttribute>().Class.Insert("alert-dismissable")
            : _type.GetAttribute<HtmlBuilderAttribute>().Class;

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
        ///     Create an alert populated with a list of errors from the <see cref="ModelStateDictionary"/>
        /// </summary>
        /// <param name="modelState"></param>
        public Alert(ModelStateDictionary modelState)
        {
            _type = AlertType.Danger;
            _heading = "Errors!";
            _messageList = modelState.GetModelErrors();
        }

        /// <summary>
        ///     Create an alert populated with a list of errors from the <see cref="ModelStateDictionary"/>
        /// </summary>
        /// <param name="modelState"></param>
        /// <param name="type">Custom <see cref="AlertType"/></param>
        /// <param name="heading">Custom heading</param>
        public Alert(ModelStateDictionary modelState, AlertType type, string heading)
        {
            _type = type;
            _heading = heading;
            _messageList = modelState.GetModelErrors();
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

