namespace sidekick
{
    public class HtmlConverters
    {
        public static string ButtonColorConverter(ButtonColor color) {
            switch (color) {
                case ButtonColor.Primary:
                    return "btn btn-primary";
                case ButtonColor.Danger:
                    return "btn btn-danger";
                case ButtonColor.Default:
                    return "btn btn-default";
                case ButtonColor.Info:
                    return "btn btn-info";
                case ButtonColor.Success:
                    return "btn btn-success";
                case ButtonColor.Warning:
                    return "btn btn-warning";
                default:
                    return "btn btn-default";
            }
        }

        public static string MessageTypeConverter(MessageTypes message) {
            switch (message) {
                case MessageTypes.Danger:
                    return "alert alert-danger";
                case MessageTypes.Info:
                    return "alert alert-info";
                case MessageTypes.Success:
                    return "alert alert-success";
                case MessageTypes.Warning:
                    return "alert alert-warning";
                default:
                    return string.Empty;
            }
        }

        public static string IconConverter(MessageTypes message) {
            switch (message) {
                case MessageTypes.Danger:
                    return "fa fa-fire";
                case MessageTypes.Info:
                    return "fa fa-info";
                case MessageTypes.Success:
                    return "fa fa-check";
                case MessageTypes.Warning:
                    return "fa fa-exclamation-triangle";
                default:
                    return string.Empty;
            }
        }
    }
}
