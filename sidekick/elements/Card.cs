namespace sidekick
{
    public class Card
    {
        internal string _title;
        internal HeadingSize _titleSize;
        internal string _subtitle;
        internal string _header;
        internal HeadingSize? _headerSize;
        internal string _footer;

        public Card Title(string title, HeadingSize titleSize)
        {
            _title = title;
            _titleSize = titleSize;
            return this;
        }

        public Card Subtitle(string subtitle)
        {
            _subtitle = subtitle;
            return this;
        }

        public Card Header(string heading)
        {
            _header = heading;
            return this;
        }

        public Card Header(string heading, HeadingSize size)
        {
            _header = heading;
            _headerSize = size;
            return this;
        }

        public Card Footer(string footer)
        {
            _footer = footer;
            return this;
        }
    }
}
