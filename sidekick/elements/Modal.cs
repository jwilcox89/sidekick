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
        ///     Text for the submit button. Default value "Submit"
        /// </summary>
        internal string _submitText;

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

        public Modal Title(string title)
        {
            _title = title;
            return this;
        }

        public Modal ErrorAreaID(string id)
        {
            _errorAreaID = id;
            return this;
        }

        public Modal Body(string body)
        {
            _body = body;
            return this;
        }

        public Modal CloseText(string text)
        {
            _closeText = text;
            return this;
        }

        public Modal SubmitText(string text)
        {
            _submitText = text;
            return this;
        }

        public Modal NotDismissable()
        {
            _dismissable = false;
            return this;
        }

        public Modal SubmitColor(Colors color)
        {
            _submitColor = color;
            return this;
        }

        public Modal CloseColor(Colors color)
        {
            _closeColor = color;
            return this;
        }

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