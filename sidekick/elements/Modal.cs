namespace sidekick
{
    public class Modal : IModal
    {
        /// <summary>
        ///     View name that will be generated with Alert details
        /// </summary>
        public string ViewName { get; set; }

        /// <summary>
        ///     Specify the size of the modal
        /// </summary>
        public ModalSize ModalSize { get; set; }

        /// <summary>
        ///     Document ID of the modal
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Heading for the modal
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Html ID of the error div. Used for display errors via Ajax/Json
        /// </summary>
        public string ErrorAreaID { get; set; }

        /// <summary>
        ///     Body of the modal
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     Text for the close modal button
        /// </summary>
        public string CloseText { get; set; }

        /// <summary>
        ///     Text for the submit button
        /// </summary>
        public string SubmitText { get; set; }

        /// <summary>
        ///     True if the modal is dismissible. Defaults to true.
        /// </summary>
        public bool Dismissable { get; set; }

        /// <summary>
        ///     Sets the color of the submit button
        /// </summary>
        public ButtonColor SubmitColor { get; set; }

        public Modal() {
            Dismissable = true;
            ModalSize = ModalSize.Regular;
            SubmitColor = ButtonColor.Primary;
        }
    }
}
