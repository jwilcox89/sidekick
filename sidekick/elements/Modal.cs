namespace sidekick
{
    public class Modal : IModal
    {
        /// <summary>
        ///     Document ID of the modal
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Heading for the modal
        /// </summary>
        public string Title { get; set; }

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
        ///     Sets the color of the submit button
        /// </summary>
        public ButtonColor SubmitColor { get; set; }
    }
}
