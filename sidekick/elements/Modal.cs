namespace sidekick
{
    public class Modal : IView
    {
        /// <summary>
        ///     View name that will be generated with Alert details
        /// </summary>
        public virtual string ViewName { get; set; }

        /// <summary>
        ///     Specify the size of the modal
        /// </summary>
        public virtual ModalSize ModalSize { get; set; }

        /// <summary>
        ///     Document ID of the modal
        /// </summary>
        public virtual string ID { get; set; }

        /// <summary>
        ///     Heading for the modal
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     Html ID of the error div. Used for display errors via Ajax/Json
        /// </summary>
        public virtual string ErrorAreaID { get; set; }

        /// <summary>
        ///     Body of the modal
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        ///     Text for the close modal button. Default value "Close"
        /// </summary>
        public virtual string CloseText { get; set; }

        /// <summary>
        ///     Text for the submit button. Default value "Submit"
        /// </summary>
        public virtual string SubmitText { get; set; }

        /// <summary>
        ///     True if the modal is dismissible. Defaults to true.
        /// </summary>
        public virtual bool Dismissable { get; set; }

        /// <summary>
        ///     True if the footer section will be hidden. Defaults to false.
        /// </summary>
        public virtual bool HideFooter { get; set; }

        /// <summary>
        ///     Sets the color of the submit button
        /// </summary>
        public virtual Colors SubmitColor { get; set; }

        /// <summary>
        ///     Sets the color of the close button
        /// </summary>
        public virtual Colors CloseColor { get; set; }

        /// <summary>
        ///     Submit button will show if true. Default value "True"
        /// </summary>
        public virtual bool ShowSubmitButton { get; set; }

        public Modal() {
            Dismissable = true;
            ShowSubmitButton = true;
            CloseText = "Close";
            SubmitText = "Submit";
            ModalSize = ModalSize.Regular;
            SubmitColor = Colors.Primary;
            CloseColor = Colors.Default;
        }
    }
}