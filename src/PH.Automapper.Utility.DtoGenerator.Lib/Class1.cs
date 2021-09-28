using System;

namespace PH.Automapper.Utility.DtoGenerator.Lib
{
    public enum CustomModifier
    {
        Public = 0,
        Internal = 1,
        Protected = 2
    }

    public interface IDtoGeneratorUtility
    {
        string GenerateDto(Type sourceType, string dtoNameSpace, CustomModifier modifier = CustomModifier.Public);
    }

    public class DtoGeneratorUtility : IDtoGeneratorUtility
    {
        public string GenerateDto(Type sourceType, string dtoNameSpace, CustomModifier modifier = CustomModifier.Public)
        {
            
            throw new NotImplementedException();
        }
    }

}