namespace sidekick
{
    public class Modal : IView
    {
        public string ViewName { get; set; }
        internal ModalSize _modalSize;
        internal string _id;
        internal string _title;
        internal string _errorAreaID;
        internal string _body;
        internal string _closeText;
        internal string _closeIcon;
        internal string _submitText;
        internal string _submitIcon;
        internal bool _dismissable;
        internal Colors _submitColor;
        internal Colors _closeColor;
        internal bool _showSubmitButton;

        /// <summary>
        ///     DEFAULTS:
        ///     Dismissable: true,
        ///     Show Submit Button: true,
        ///     Close Text: 'Close',
        ///     Submit Text: 'Submit',
        ///     Size: Regular,
        ///     Submit Color: Primary,
        ///     Close Color: Default
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
        ///     Set the text in the cancel button
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Modal CloseText(string text)
        {
            _closeText = text;
            return this;
        }

        /// <summary>
        ///     Set the text and the icon for the cancel button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Modal CloseText(string text, string icon)
        {
            _closeText = text;
            _closeIcon = icon;
            return this;
        }

        /// <summary>
        ///     Set the text in the submit button
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Modal SubmitText(string text)
        {
            _submitText = text;
            return this;
        }

        /// <summary>
        ///     Set the text and the icon for the submit button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public Modal SubmitText(string text, string icon)
        {
            _submitText = text;
            _submitIcon = icon;
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
        ///     Set the color of the submit button
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Modal SubmitColor(Colors color)
        {
            _submitColor = color;
            return this;
        }

        /// <summary>
        ///     Set the color of the cancel button
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Modal CloseColor(Colors color)
        {
            _closeColor = color;
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