using System;

namespace PH.Automapper.Utility.DtoGenerator.Lib
{
    public interface IProfileGeneratorUtility
    {
        IDtoGeneratorUtility DtoGenerator { get; }

        (string Dto, string Profile) GenerateDtoAndProfile(Type sourceType, string profileNameSpace
                                                           , string dtoNameSpace, CustomModifier modifierProfile =
                                                               CustomModifier.Internal,
                               CustomModifier modifierDto = CustomModifier.Public);
    }
}