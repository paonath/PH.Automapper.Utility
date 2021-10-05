using System;
using System.Collections.Generic;
using NUnit.Framework;
using PH.Automapper.Utility.DtoGenerator.Lib;
using AutoMapper;
using AutoMapper.Configuration;

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

        [Test]
        public void GenerateFullMapping()
        {
            var utility = new InitMapperGeneratorUtility(new ProfileGeneratorUtility(new DtoGeneratorUtility()));
            var data    = utility.GenerateFullMapping(new List<Type>() { typeof(Foo) }, "Profile.Dto", "Sample.Dto");

            Assert.NotNull(data.MapperProvider);
            Assert.NotNull(data.MapperProviderClassName);
            Assert.IsNotEmpty(data.Dto);
            Assert.IsNotEmpty(data.Profile);
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
                .AfterMap(AfterMapEntityToDto)
                #endregion
                   
                    .ReverseMap()

                #region Dto to Entity

                .ForMember(x => x.BarId, o => o.MapFrom(src => src.BarId))
                .AfterMap(AfterMapDtoToEntity);
                
                #endregion
                   
            }


            /// <summary>Afters the map entity to dto.</summary>
            /// <param name="entity">The entity.</param>
            /// <param name="dto">The dto.</param>
            /// <param name="context">The context.</param>
            private void AfterMapEntityToDto(Foo entity, FooWritingDto dto, ResolutionContext context)
            {
                //
            }

            /// <summary>Afters the map dto to entity.</summary>
            /// <param name="dto">The dto.</param>
            /// <param name="entity">The entity.</param>
            /// <param name="context">The context.</param>
            private void AfterMapDtoToEntity(FooWritingDto dto, Foo entity, ResolutionContext context)
            {
                //
            }
        }

        /// <summary>
        /// Static <see cref="IMapper"/> provider
        /// </summary>
        internal static class InitMapper 
        {
            /// <summary>Initializes a new instance of <see cref="Mapper"/>.</summary>
            /// <returns>configured <see cref="IMapper"/></returns>
            public static AutoMapper.IMapper Init()
            {
                var cfg = new MapperConfigurationExpression();

                cfg.AddProfile<ProfileExample>();

                var mapperConfig = new MapperConfiguration(cfg);
                var m            = new Mapper(mapperConfig);
                return m;
            }

        }
    }
}