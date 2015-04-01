namespace sidekick
{
    public class Modal : IModal
    {
        /// <summary>
        ///     View name that will be generated with Alert details
        /// </summary>
        public string ViewName { get; set; }

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

        /// <summary>
        ///     Sets the button class here. Ex. "btn btn-success"
        /// </summary>
        public virtual string SubmitClass {
            get {
                return HtmlConverters.ButtonColorConverter(SubmitColor);
            }
        }
    }
}
