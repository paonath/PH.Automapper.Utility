using System;
using NUnit.Framework;
using PH.Automapper.Utility.DtoGenerator.Lib;

namespace PH.Automapper.Utility.DtoGenerator.Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var utlity = new DtoGenerator.Lib.DtoGeneratorUtility();
            var fooDto = utlity.GenerateDto(typeof(Foo), "Sample.Dto", CustomModifier.Public);
            
            
            
            Assert.NotNull(fooDto);
            
            Assert.Pass();
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
    }
}