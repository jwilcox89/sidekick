using System.Collections.Generic;

namespace sidekick
{
    public interface IAlert : IElement
    {
        /// <summary>
        ///     Success, Failure, Warning etc
        /// </summary>
        AlertType Type { get; set; }

        /// <summary>
        ///     If true the alert box will be dismissible
        /// </summary>
        bool Dismissible { get; set; }

        /// <summary>
        ///     The heading (ex. Error or Add User)
        /// </summary>
        string Heading { get; set; }

        /// <summary>
        ///     The body of the message (ex. User was added successfully)
        /// </summary>
        string Body { get; set; }

        /// <summary>
        ///     Used for multiple errors or success messages that are generally generated from a list of ModelState errors or AspIdentity IdentityErrors 
        /// </summary>
        List<string> MessageList { get; set; }

        /// <summary>
        ///     Sets the alert class here. Ex. "alert alert-success"
        /// </summary>
        string AlertClass { get; }
    }
}
