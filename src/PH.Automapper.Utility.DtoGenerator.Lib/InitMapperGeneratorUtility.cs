using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using PH.Automapper.Utility.DtoGenerator.Lib.Templates;

namespace PH.Automapper.Utility.DtoGenerator.Lib
{
    public class InitMapperGeneratorUtility : IInitMapperGeneratorUtility
    {
        public InitMapperGeneratorUtility(IProfileGeneratorUtility profileGenerator)
        {
            ProfileGenerator = profileGenerator;
        }

        public IProfileGeneratorUtility ProfileGenerator { get; }

        public (string MapperProvider, string MapperProviderClassName, string[] Dto, string[] Profile) GenerateFullMapping(
            IEnumerable<Type> sourceTypes, string profileNameSpace, string dtoNameSpace,
            CustomModifier modifierProfile = CustomModifier.Internal, CustomModifier modifierDto = CustomModifier.Public)
        {
            var profiles = new List<(string Dto, string Profile, string ProfileClassName)>();
            foreach (var sourceType in sourceTypes.OrderBy(x => x.Name).ToArray())
            {
                profiles.Add(ProfileGenerator.GenerateDtoAndProfile(sourceType, profileNameSpace, dtoNameSpace,
                                                                    modifierProfile, modifierDto));
            }

            var profilesFullNames =
                profiles.Select(x => $"{dtoNameSpace}.{x.ProfileClassName}").OrderBy(x => x).ToArray();
            InitMapperTemplate tpl = new InitMapperTemplate();
            tpl.ProfileClassFullNames = profilesFullNames;
            tpl.NewNameSpaceName      = profileNameSpace;
            tpl.DtoNameSpace          = dtoNameSpace;
            tpl.EntityNameSpace       = sourceTypes.First().Namespace;

            string mapperClass = tpl.TransformText();

            return (mapperClass, "InitMapper", profiles.Select(x => x.Dto).ToArray(),
                    profiles.Select(x => x.Profile).ToArray());
        }
    }
}