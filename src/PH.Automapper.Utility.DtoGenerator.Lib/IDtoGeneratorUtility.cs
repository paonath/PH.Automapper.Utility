using System;
using System.Reflection;

namespace PH.Automapper.Utility.DtoGenerator.Lib
{
    public interface IDtoGeneratorUtility
    {
        (string Dto, PropertyInfo[] Properties) GenerateDto(Type sourceType, string dtoNameSpace, CustomModifier modifier = CustomModifier.Public);
    }
}