using System;
using PH.Automapper.Utility.DtoGenerator.Lib.Templates;

namespace PH.Automapper.Utility.DtoGenerator.Lib
{
    public class ProfileGeneratorUtility : IProfileGeneratorUtility
    {
        public ProfileGeneratorUtility(IDtoGeneratorUtility dtoGenerator)
        {
            DtoGenerator = dtoGenerator;
        }

        public IDtoGeneratorUtility DtoGenerator { get; }

        public (string Dto, string Profile, string ProfileClassName) GenerateDtoAndProfile(Type sourceType, string profileNameSpace, string dtoNameSpace,
                                                                  CustomModifier modifierProfile = CustomModifier.Internal,
                                                                  CustomModifier modifierDto = CustomModifier.Public)
        {
            var dto = DtoGenerator.GenerateDto(sourceType, dtoNameSpace, modifierDto);

            ProfileClassTemplate profileTpl = new ProfileClassTemplate();
            profileTpl.Modifier             = modifierProfile;
            profileTpl.Properties           = dto.Properties;
            profileTpl.EntityName           = sourceType.Name;
            profileTpl.EntityNameSpace      = sourceType.Namespace;
            profileTpl.DtoName              = $"{sourceType.Name}Dto";
            profileTpl.DtoNameSpace         = dtoNameSpace;
            profileTpl.ProfileNameSpaceName = profileNameSpace;

            var profileText = profileTpl.TransformText();
            var profileClassName = $"{sourceType.Name}Profile";  
            return (dto.Dto, profileText, profileClassName);

        }
    }
}