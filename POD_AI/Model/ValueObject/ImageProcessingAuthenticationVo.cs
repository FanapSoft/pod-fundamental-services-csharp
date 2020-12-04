using POD_AI.Base.Enum;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace POD_AI.Model.ValueObject
{
    public class ImageProcessingAuthenticationVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Image1 { get; }
        public string Image2 { get; }
        public ImageComparisonMode? Mode { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public ImageProcessingAuthenticationVo(Builder builder)
        {
            Image1 = builder.GetImage1();
            Image2 = builder.GetImage2();
            Mode = builder.GetMode();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string image1;

            [Required]
            private string image2;

            [Required]
            private ImageComparisonMode? mode;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetImage1()
            {
                return image1;
            }

            /// <param name="image1">آدرس تصویر اصلی</param>
            public Builder SetImage1(string image1)
            {
                this.image1 = image1;
                return this;
            }

            public string GetImage2()
            {
                return image2;
            }

            /// <param name="image2">آدرس تصاویری که جستجو بین آنها قرار است صورت بگیرد</param>
            public Builder SetImage2(string image2)
            {
                this.image2 = image2;
                return this;
            }

            public ImageComparisonMode? GetMode()
            {
                return mode;
            }

            public Builder SetMode(ImageComparisonMode mode)
            {
                this.mode = mode;
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

            public ImageProcessingAuthenticationVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ImageProcessingAuthenticationVo(this);
            }
        }
    }
}