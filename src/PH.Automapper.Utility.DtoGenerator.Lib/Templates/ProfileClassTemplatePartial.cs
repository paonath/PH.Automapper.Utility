using System.Reflection;

namespace PH.Automapper.Utility.DtoGenerator.Lib.Templates
{
    public partial class ProfileClassTemplate
    {
        public string ProfileNameSpaceName { get; set; }
        public string EntityNameSpace { get; set; }
        public string EntityName { get; set; }

        public string DtoNameSpace { get; set; }
        public string DtoName { get; set; }

        public CustomModifier Modifier { get; set; }

        public string GetModifier => Modifier.ToString().ToLowerInvariant();

        public PropertyInfo[] Properties { get; set; }
    }
}