using System;

namespace PH.Automapper.Utility.DtoGenerator.Lib
{
    public interface IDtoGeneratorUtility
    {
        string GenerateDto(Type sourceType, string dtoNameSpace, CustomModifier modifier = CustomModifier.Public);
    }

    public interface IProfileGeneratorUtility
    {
        string GenerateProfile(Type sourceType, Type dtoType, string profileNameSpace,
                               CustomModifier modifier = CustomModifier.Internal);
    }
}