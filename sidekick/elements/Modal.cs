namespace sidekick
{
    public class Modal : IView
    {
        /// <summary>
        ///     View name that will be generated with Alert details
        /// </summary>
        public string ViewName { get; set; }

        /// <summary>
        ///     Specify the size of the modal
        /// </summary>
        internal ModalSize _modalSize;

        /// <summary>
        ///     Document ID of the modal
        /// </summary>
        internal string _id;

        /// <summary>
        ///     Heading for the modal
        /// </summary>
        internal string _title;

        /// <summary>
        ///     Html ID of the error div. Used for display errors via Ajax/Json
        /// </summary>
        internal string _errorAreaID;

        /// <summary>
        ///     Body of the modal
        /// </summary>
        internal string _body;

        /// <summary>
        ///     Text for the close modal button. Default value "Close"
        /// </summary>
        internal string _closeText;

        /// <summary>
        ///     Icon for the cancel button.
        /// </summary>
        internal string _closeIcon;

        /// <summary>
        ///     Text for the submit button. Default value "Submit"
        /// </summary>
        internal string _submitText;

        /// <summary>
        ///     Icon for the submit button.
        /// </summary>
        internal string _submitIcon;

        /// <summary>
        ///     True if the modal is dismissible. Defaults to true.
        /// </summary>
        internal bool _dismissable;

        /// <summary>
        ///     Sets the color of the submit button
        /// </summary>
        internal Colors _submitColor;

        /// <summary>
        ///     Sets the color of the close button
        /// </summary>
        internal Colors _closeColor;

        /// <summary>
        ///     Submit button will show if true. Default value "True"
        /// </summary>
        internal bool _showSubmitButton;

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
    }
}