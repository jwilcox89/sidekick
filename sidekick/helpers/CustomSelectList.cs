using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace sidekick
{
    public class CustomSelectList<T>
    {
        public Expression<Func<T,object>> Value         { get; set; }
        public Expression<Func<T,object>> Display       { get; set; }
        public object                     SelectedValue { get; set; }
        public IEnumerable<T>             ItemList      { get; set; }
    }
}
