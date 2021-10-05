using System;
using NUnit.Framework;
using PH.Automapper.Utility.DtoGenerator.Lib;
using AutoMapper;

namespace PH.Automapper.Utility.DtoGenerator.Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var utility = new DtoGenerator.Lib.DtoGeneratorUtility();
            var fooDto = utility.GenerateDto(typeof(Foo), "Sample.Dto", CustomModifier.Public);
            
            
            
            Assert.NotNull(fooDto);
            
            Assert.Pass();
        }

        [Test]
        public void GenerateFooDtoAndProfile()
        {
            var utility = new ProfileGeneratorUtility(new DtoGeneratorUtility());
            var data    = utility.GenerateDtoAndProfile(typeof(Foo), "Profile.Dto", "Sample.Dto");

            Assert.NotNull(data.Dto);
            Assert.NotNull(data.Profile);
        }

        
        
        internal class Foo
        {
            public int Id { get; set; }
            public virtual DateTime DateTime { get; set; }
            private double _dbl;

            public Guid BarId { get; set; }
            public Bar Bar { get; set; }

            public Foo()
            {
                _dbl = double.Epsilon;
            }
            
            
        }
        
        internal class Bar
        {
            public Guid BarId { get; set; }
            public string Name { get; set; }
            public string FullName => $"{BarId} - {Name}";
        }

        internal class FooWritingDto
        {
            public int Id { get; set; }
            public DateTime DateTime { get; set; }
            public Guid BarId { get; set; }

            
        }

        /// <summary>
        /// AutoMapper Profile class for <see cref="Foo"/> and <see cref="FooWritingDto"/> mapping
        /// </summary>
        /// <seealso cref="AutoMapper.Profile" />
        internal class ProfileExample : AutoMapper.Profile
        {
            public ProfileExample()
            {
                CreateMap<Foo, FooWritingDto>()

                #region Entity to Dto

                .ForMember(x => x.BarId, o => o.MapFrom(src => src.BarId))
                .AfterMap((foo, dto, context) =>
                {
                    //
                })
                #endregion
                   
                    .ReverseMap()

                #region Dto to Entity

                .ForMember(x => x.BarId, o => o.MapFrom(src => src.BarId))
                .AfterMap((dto, foo, context) =>
                {
                    //
                });
                
                #endregion
                   
            }
        }
    }
}