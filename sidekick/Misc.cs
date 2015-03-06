namespace sidekick
{
    /// <summary>
    ///     Months in the year
    /// </summary>
    public enum Months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    /// <summary>
    ///     Alert box style options
    /// </summary>
    public enum MessageTypes
    {
        Success,
        Danger,
        Warning,
        Info
    }

    /// <summary>
    ///     Button color options
    /// </summary>
    public enum ButtonColor
    {
        Success,
        Danger,
    }

    /// <summary>
    ///     Types of file uploads
    /// </summary>
    public enum UploadType
    {
        Multiple_Photos,
        Single_Photo,
        Audio,
        Video
    }
}
