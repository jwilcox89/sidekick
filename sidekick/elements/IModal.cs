namespace sidekick
{
    /// <summary>
    ///     Base elements for generating a modal
    /// </summary>
    public interface IModal : IElement
    {
        /// <summary>
        ///     Document ID of the modal
        /// </summary>
        string ID { get; set; }

        /// <summary>
        ///     Heading for the modal
        /// </summary>
        string Title { get; set; }

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
        ///     Sets the color of the submit button
        /// </summary>
        ButtonColor SubmitColor { get; set; }
    }
}
