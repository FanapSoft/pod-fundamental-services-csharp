using POD_Base_Service.Model.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_AI.Model.ValueObject
{
    public class SpeechToTextVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string LinkFile { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public SpeechToTextVo(Builder builder)
        {
            LinkFile = builder.GetLinkFile();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string linkFile;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetLinkFile()
            {
                return linkFile;
            }

            /// <param name="linkFile">آدرس فایل صوتی</param>
            public Builder SetLinkFile(string linkFile)
            {
                this.linkFile = linkFile;
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

            public SpeechToTextVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new SpeechToTextVo(this);
            }
        }
    }
}