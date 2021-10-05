using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PH.Automapper.Utility.DtoGenerator.Lib.Templates
{



    public partial class DtoClassTemplateFile 
    {
        public PropertyInfo[] Properties { get; set; }
        public string NewTypeName { get; set; }
        public string NewNameSpaceName { get; set; }
        public string OriginalTypeName { get; set; }
        public CustomModifier Modifier { get; set; }

        public string GetModifier => Modifier.ToString().ToLowerInvariant();

    }
}
