using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Codenation.Challenge
{
    public class FieldCalculatorTest
    {
        const string CLASS_FULL_NAME = "Codenation.Challenge.FieldCalculator";
        const string INTERFACE_FULL_NAME = "Codenation.Challenge.ICalculateField";
        const string ASSEMBLY_NAME = "Source";
        const string ADDITION_METHOD = "Addition";
        const string SUBTRACTION_METHOD = "Subtraction";
        const string TOTAL_METHOD = "Total";

        /// When a class C implements an interface I, to find the method MC on class that 
        /// correspond the method MI of that interface, you must use the GetInterfaceMap
        private MethodInfo GetImplementationMethod(Type sourceInterface, Type sourceClass, string methodName)
        {
            var map = sourceClass.GetInterfaceMap(sourceInterface);
            var methodIndex = map.InterfaceMethods.ToList().FindIndex(x => x.Name == methodName);
            return map.TargetMethods[methodIndex];
        }

        [Fact]
        public void Should_Exists_The_Class()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var expected = assembly.GetType(CLASS_FULL_NAME);
            Assert.NotNull(expected);
        }

        [Fact]
        public void Should_Implements_ICalculateField_Interface()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var actual = assembly.GetType(CLASS_FULL_NAME);
            Assert.NotNull(actual);
            var interfaces = actual.GetInterfaces().Select(x => x.FullName).ToList();
            Assert.Contains(INTERFACE_FULL_NAME, interfaces);
        }

        [Fact]
        public void Should_Addition()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var interfaceCalculate = assembly.GetType(INTERFACE_FULL_NAME);
            var classCalculate = assembly.GetType(CLASS_FULL_NAME);
            var method = GetImplementationMethod(interfaceCalculate, classCalculate, ADDITION_METHOD);
            var obj = Activator.CreateInstance(classCalculate);

            AddAttribute add = new AddAttribute();

            Assert.Equal(10.0M, method.Invoke(obj, new object[] { add }));

        }

        [Fact]
        public void Should_Subtraction()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var interfaceCalculate = assembly.GetType(INTERFACE_FULL_NAME);
            var classCalculate = assembly.GetType(CLASS_FULL_NAME);
            var method = GetImplementationMethod(interfaceCalculate, classCalculate, SUBTRACTION_METHOD);
            var obj = Activator.CreateInstance(classCalculate);

            SubtractAttribute sub = new SubtractAttribute();

            Assert.Equal(-30.0M, method.Invoke(obj, new object[] { sub }));

        }

        [Fact]
        public void Should_Total()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var interfaceCalculate = assembly.GetType(INTERFACE_FULL_NAME);
            var classCalculate = assembly.GetType(CLASS_FULL_NAME);
            var method = GetImplementationMethod(interfaceCalculate, classCalculate, TOTAL_METHOD);
            var obj = Activator.CreateInstance(classCalculate);

            Total total = new Total();

            Assert.Equal(0M, method.Invoke(obj, new object[] { total }));

        }
    }
}