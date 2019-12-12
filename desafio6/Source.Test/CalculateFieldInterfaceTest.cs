using System.Linq;
using System.Reflection;
using Xunit;

namespace Codenation.Challenge
{
    public class CalculateFieldInterfaceTest
    {
        const string INTERFACE_FULL_NAME = "Codenation.Challenge.ICalculateField";
        const string ASSEMBLY_NAME = "Source";    
        const string ADDITION_METHOD = "Addition";
        const string SUBTRACTION_METHOD = "Subtraction";
        const string TOTAL_METHOD = "Total";

        [Fact]
        public void Should_Exists_The_Interface()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var expected = assembly.GetType(INTERFACE_FULL_NAME);
            Assert.NotNull(expected);
            Assert.True(expected.IsInterface);
        }

    }
}