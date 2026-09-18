using System;
using System.Collections.Generic;
using System.Text;

namespace A3_TPLReflectionAttributes.Attributes
{

    [AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
    public class MaxLengthNoAttribute : Attribute
    {
        public int MaxLength { get; }

        public MaxLengthNoAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }
    }
}
