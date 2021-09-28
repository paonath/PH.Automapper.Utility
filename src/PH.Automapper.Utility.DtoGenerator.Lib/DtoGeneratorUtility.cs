using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PH.Automapper.Utility.DtoGenerator.Lib.Templates;

namespace PH.Automapper.Utility.DtoGenerator.Lib
{
    public class DtoGeneratorUtility : IDtoGeneratorUtility
    {
        public string GenerateDto(Type sourceType, string dtoNameSpace, CustomModifier modifier = CustomModifier.Public)
        {
            
            throw new NotImplementedException();
        }

        internal DtoClassTemplateFile InitFromType(Type sourceType, string dtoNameSpace,
                                                   CustomModifier modifier = CustomModifier.Public)
        {
            var c = new DtoClassTemplateFile();
            c.Modifier         = modifier;
            c.NewNameSpaceName = dtoNameSpace;
            c.OriginalTypeName = sourceType.Name;
            c.NewTypeName      = $"{sourceType.Name}Dto";
            c.Properties       = GetPropertiesFromType(sourceType);

            return c;
        }

        private PropertyInfo[] GetPropertiesFromType(Type sourceType)
        {
            var l     = new List<PropertyInfo>();
            var infos = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in infos)
            {
                //check
            }


            return l.OrderBy(x => x.Name).ToArray();
        }
    }
}