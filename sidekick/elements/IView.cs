﻿namespace sidekick
{
    public interface IView
    {
        /// <summary>
        ///     View name that will be used to create the html string
        /// </summary>
        string ViewName { get; set; }
    }
}