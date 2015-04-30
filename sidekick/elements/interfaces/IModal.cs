namespace sidekick
{
    /// <summary>
    ///     Base elements for generating a modal
    /// </summary>
    public interface IModal : IElement
    {
        /// <summary>
        ///     Specify the size of the modal
        /// </summary>
        ModalSize ModalSize { get; set; }

        /// <summary>
        ///     Document ID of the modal
        /// </summary>
        string ID { get; set; }

        /// <summary>
        ///     Heading for the modal
        /// </summary>
        string Title { get; set; }

        /// <summary>
        ///     Html ID of the error div. Used for display errors via Ajax/Json
        /// </summary>
        string ErrorAreaID { get; set; }

        /// <summary>
        ///     Body of the modal
        /// </summary>
        string Body { get; set; }

        /// <summary>
        ///     Text for the close modal button
        /// </summary>
        string CloseText { get; set; }

        /// <summary>
        ///     Text for the submit button
        /// </summary>
        string SubmitText { get; set; }

        /// <summary>
        ///     True if the modal is dismissible. Defaults to true.
        /// </summary>
        bool Dismissable { get; set; }

        /// <summary>
        ///     Sets the color of the submit button
        /// </summary>
        Colors SubmitColor { get; set; }

        /// <summary>
        ///     Sets the color of the close button
        /// </summary>
        Colors CloseColor { get; set; }
    }
}
