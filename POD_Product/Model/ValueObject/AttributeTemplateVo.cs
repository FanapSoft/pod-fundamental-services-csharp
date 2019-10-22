using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Product.Model.ValueObject
{
    public class AttributeTemplateVo
    {
        public static Builder ConcreteBuilder => new Builder();

        public string AttCode { get; }
        public string AttValue { get; }
        public bool? AttGroup { get; }

        public AttributeTemplateVo(Builder builder)
        {
            AttCode = builder.GetAttCode();
            AttValue = builder.GetAttValue();
            AttGroup = builder.GetAttGroup();
        }

        public class Builder
        {
            [Required] private string attCode;
            [Required] private string attValue;
            [Required] private bool? attGroup;

            public string GetAttCode()
            {
                return attCode;
            }

            public Builder SetAttCode(string attCode)
            {
                this.attCode = attCode;
                return this;
            }

            public string GetAttValue()
            {
                return attValue;
            }

            public Builder SetAttValue(string attValue)
            {
                this.attValue = attValue;
                return this;
            }

            public bool? GetAttGroup()
            {
                return attGroup;
            }

            public Builder SetAttGroup(bool attGroup)
            {
                this.attGroup = attGroup;
                return this;
            }

            public AttributeTemplateVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AttributeTemplateVo(this);
            }
        }
    }
}

