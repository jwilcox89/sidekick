using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sidekick
{
    public class TextArea<TModel,TProperty> : FormControl<TModel,TProperty>
    {
        public int Rows { get; set; }
        
        public int Columns { get; set; }
    }
}
