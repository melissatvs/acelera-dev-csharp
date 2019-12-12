using System;
using System.Linq;
using System.Reflection;

namespace Codenation.Challenge
{
    public class FieldCalculator : ICalculateField
    {
        public decimal Addition(object obj)
        {
            decimal result = 0;
            var fields = obj.GetType()
                .GetRuntimeFields()
                .Where(x => x.FieldType == typeof(decimal))
                .ToList();

            foreach (var field in fields)
            {
                object[] attributes = field.GetCustomAttributes(false);

                foreach (AddAttribute attribute in attributes.OfType<AddAttribute>())
                {
                    result += (decimal)field.GetValue(obj);
                }
            }

            return result;            
        }

        public decimal Subtraction(object obj)
        {
            decimal result = 0;
            var fields = obj.GetType()
                .GetRuntimeFields()
                .Where(x => x.FieldType == typeof(decimal))
                .ToList();

            foreach (var field in fields)
            {
                object[] attributes = field.GetCustomAttributes(false);

                foreach (SubtractAttribute attribute in attributes.OfType<SubtractAttribute>())
                {
                    result -= (decimal)field.GetValue(obj);
                }
            }

            return result;
        }

        public decimal Total(object obj)
        {
            decimal result = 0;
            var fields = obj.GetType()
                .GetRuntimeFields()
                .Where(x => x.FieldType == typeof(decimal))
                .ToList();

            foreach (var field in fields)
            {
                object[] attributes = field.GetCustomAttributes(false);

                foreach (SubtractAttribute attribute in attributes.OfType<SubtractAttribute>())
                {
                    result -= (decimal)field.GetValue(obj);
                }

                foreach (AddAttribute attribute in attributes.OfType<AddAttribute>())
                {
                    result += (decimal)field.GetValue(obj);
                }
            }

            return result;
        }
    }
}
