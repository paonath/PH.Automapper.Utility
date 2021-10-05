using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PH.Automapper.Utility.DtoGenerator.Lib.Templates;

namespace PH.Automapper.Utility.DtoGenerator.Lib
{
    public class DtoGeneratorUtility : IDtoGeneratorUtility
    {
        public (string Dto, PropertyInfo[] Properties) GenerateDto(Type sourceType, string dtoNameSpace, CustomModifier modifier = CustomModifier.Public)
        {

            var templateDtoInternal = InitFromType(sourceType, dtoNameSpace, modifier);
            var textClass = templateDtoInternal.dto.TransformText();
            return (textClass, templateDtoInternal.properties);
        }

        internal (DtoClassTemplateFile dto, PropertyInfo[] properties ) InitFromType(Type sourceType, string dtoNameSpace,
                                                                          CustomModifier modifier = CustomModifier.Public)
        {
            var props = GetPropertiesFromType(sourceType);

            var c     = new DtoClassTemplateFile();
            c.Modifier         = modifier;
            c.NewNameSpaceName = dtoNameSpace;
            c.OriginalTypeName = sourceType.Name;
            c.NewTypeName      = $"{sourceType.Name}Dto";
            c.Properties       = props;

            return (c, props);
        }

        private PropertyInfo[] GetPropertiesFromType(Type sourceType)
        {
            var l     = new List<PropertyInfo>();
            var infos = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                  .Where(x => !x.PropertyType.IsAbstract && !x.PropertyType.IsClass)
                                  .ToArray();

            foreach (var propertyInfo in infos)
            {
                //check
                //todo: implenets
                l.Add(propertyInfo);
            }


            return l.OrderBy(x => x.Name).ToArray();
        }
    }
}