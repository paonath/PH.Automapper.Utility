using System;
using System.Collections.Generic;

namespace PH.Automapper.Utility.DtoGenerator.Lib
{
    public interface IInitMapperGeneratorUtility
    {
        IProfileGeneratorUtility ProfileGenerator { get; }


        (string MapperProvider, string MapperProviderClassName, string[] Dto, string[] Profile) GenerateFullMapping(
            IEnumerable<Type> sourceTypes, string profileNameSpace, string dtoNameSpace,
            CustomModifier modifierProfile = CustomModifier.Internal,
            CustomModifier modifierDto = CustomModifier.Public);

    }
}