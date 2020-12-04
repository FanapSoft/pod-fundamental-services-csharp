using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace POD_AI.Model.ValueObject
{
    public class NLUVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Text { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public NLUVo(Builder builder)
        {
            Text = builder.GetText();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string text;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetText()
            {
                return text;
            }

            public Builder SetText(string text)
            {
                this.text = text;
                return this;
            }
            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public NLUVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new NLUVo(this);
            }
        }
    }
}