using POD_Base_Service.Model.ValueObject;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using System.ComponentModel.DataAnnotations;

namespace POD_AI.Model.ValueObject
{
    public class LicensePlateReaderVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Image { get; }
        public bool? IsCrop { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public LicensePlateReaderVo(Builder builder)
        {
            Image = builder.GetImage();
            IsCrop = builder.GetIsCrop();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required][Url]
            private string image;
            private bool? isCrop;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetImage()
            {
                return image;
            }

            public Builder SetImage(string image)
            {
                this.image = image;
                return this;
            }
            public bool? GetIsCrop()
            {
                return isCrop;
            }

            public Builder SetIsCrop(bool isCrop)
            {
                this.isCrop = isCrop;
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

            public LicensePlateReaderVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new LicensePlateReaderVo(this);
            }
        }
    }
}
