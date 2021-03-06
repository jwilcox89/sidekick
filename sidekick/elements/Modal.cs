﻿using System;

namespace sidekick
{
    /// <summary>
    ///     Bootstrap 'Modal' element
    /// </summary>
    public class Modal
    {
        internal string _id;
        internal string _title;
        internal string _errorAreaID;
        internal string _body;
        internal string _closeText;
        internal string _submitText;
        internal bool _dismissable;
        internal bool _showSubmitButton;
        internal bool _hasFooter;
        internal Icon _closeIcon;
        internal Icon _submitIcon;
        internal Icon _icon;
        internal Colors _submitColor;
        internal Colors _closeColor;
        internal ModalSize _modalSize;

        /// <summary>
        ///     <para>No HTML ID</para>
        ///     DEFAULTS:
        ///     <para>Dismissable: true</para>
        ///     <para>Show Submit Button: true</para>
        ///     <para>Close Text: 'Close'</para>
        ///     <para>Submit Text: 'Submit'</para>
        ///     <para>Size: Regular</para>
        ///     <para>Submit Color: Primary</para>
        ///     <para>Close Color: Default</para>
        /// </summary>
        public Modal()
        {
            _id = String.Empty;
            _dismissable = true;
            _showSubmitButton = true;
            _closeText = "Close";
            _submitText = "Submit";
            _modalSize = ModalSize.Regular;
            _submitColor = Colors.Primary;
            _closeColor = Colors.Default;
        }

        /// <summary>
        ///     DEFAULTS:
        ///     <para>Dismissable: true</para>
        ///     <para>Show Submit Button: true</para>
        ///     <para>Close Text: 'Close'</para>
        ///     <para>Submit Text: 'Submit'</para>
        ///     <para>Size: Regular</para>
        ///     <para>Submit Color: Primary</para>
        ///     <para>Close Color: Default</para>
        /// </summary>
        /// <param name="modalID">HTML id of the modal element. Used for opening and closing the modal.</param>
        public Modal(string modalID)
        {
            _id = modalID;
            _dismissable = true;
            _showSubmitButton = true;
            _closeText = "Close";
            _submitText = "Submit";
            _modalSize = ModalSize.Regular;
            _submitColor = Colors.Primary;
            _closeColor = Colors.Default;
        }

        /// <summary>
        ///     Set the title of the modal
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public Modal Title(string title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        ///     Set the title of the modal and include an icon
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Modal Title(string title, Icon icon)
        {
            _title = title;
            _icon = icon;
            return this;
        }

        /// <summary>
        ///     Set the title of the modal and include an icon
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Modal Title(string title, string icon)
        {
            _title = title;
            _icon = new Icon(icon);
            return this;
        }

        /// <summary>
        ///     Set the size of the modal element
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Modal Size(ModalSize size)
        {
            _modalSize = size;
            return this;
        }

        /// <summary>
        ///     Set the html id for the error area element
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Modal ErrorAreaID(string id)
        {
            _errorAreaID = id;
            return this;
        }

        /// <summary>
        ///     Set the body of the modal
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public Modal Body(string body)
        {
            _body = body;
            return this;
        }

        /// <summary>
        ///     Set attributes of submit button
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Modal SubmitButton(string text)
        {
            _submitText = text;
            return this;
        }

        /// <summary>
        ///     Set attributes of submit button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Modal SubmitButton(string text, Icon icon)
        {
            _submitText = text;
            _submitIcon = icon;
            return this;
        }

        /// <summary>
        ///     Set attributes of submit button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Modal SubmitButton(string text, string icon)
        {
            _submitText = text;
            _submitIcon = new Icon(icon);
            return this;
        }

        /// <summary>
        ///     Set attributes of submit button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public Modal SubmitButton(string text, Icon icon, Colors color)
        {
            _submitText = text;
            _submitIcon = icon;
            _submitColor = color;
            return this;
        }

        /// <summary>
        ///     Set attributes of submit button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public Modal SubmitButton(string text, string icon, Colors color)
        {
            _submitText = text;
            _submitIcon = new Icon(icon);
            _submitColor = color;
            return this;
        }

        /// <summary>
        ///     Set attributes of close button
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Modal CloseButton(string text)
        {
            _closeText = text;
            return this;
        }

        /// <summary>
        ///     Set attributes of close button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Modal CloseButton(string text, string icon)
        {
            _closeText = text;
            _closeIcon = new Icon(icon);
            return this;
        }

        /// <summary>
        ///     Set attributes of close button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Modal CloseButton(string text, Icon icon)
        {
            _closeText = text;
            _closeIcon = icon;
            return this;
        }

        /// <summary>
        ///     Set attributes of close button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public Modal CloseButton(string text, Icon icon, Colors color)
        {
            _closeText = text;
            _closeIcon = icon;
            _closeColor = color;
            return this;
        }

        /// <summary>
        ///     Set attributes of close button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public Modal CloseButton(string text, string icon, Colors color)
        {
            _closeText = text;
            _closeIcon = new Icon(icon);
            _closeColor = color;
            return this;
        }

        /// <summary>
        ///     Ensures that you cannot close the modal
        /// </summary>
        /// <returns></returns>
        public Modal NotDismissable()
        {
            _dismissable = false;
            return this;
        }

        /// <summary>
        ///     Submit button will be hidden
        /// </summary>
        /// <returns></returns>
        public Modal HideSubmitButton()
        {
            _showSubmitButton = false;
            return this;
        }
    }
}