namespace sidekick
{
    public class BuilderBase
    {
        private static ViewBuilder _builder;

        protected static ViewBuilder MyBuilder {
            get {
                if (_builder == null)
                    _builder = new ViewBuilder();

                return _builder;
            }
        }
    }
}
