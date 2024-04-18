using System;

namespace Attribute_pract
{
    public class BrainValidateAttribute : Attribute
    {
        public int Brain { get; }

        public BrainValidateAttribute(int brain)
        {
            this.Brain = brain;
        }
    }
}