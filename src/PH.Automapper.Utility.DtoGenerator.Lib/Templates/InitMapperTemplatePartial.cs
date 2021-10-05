using System.Collections.Generic;

namespace PH.Automapper.Utility.DtoGenerator.Lib.Templates
{
    public partial class InitMapperTemplate
    {
        public string[] ProfileClassFullNames { get; set; }
        public string NewNameSpaceName { get; set; }

        public string EntityNameSpace { get; set; }

        public string DtoNameSpace { get; set; }
    }
}