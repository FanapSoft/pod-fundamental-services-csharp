using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_SSO.Model.OTP.ValueObject
{
    public class AccessTokenByOtpVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string GrantType { get; }
        public string Code { get; }

        public AccessTokenByOtpVo(Builder builder)
        {
            GrantType = builder.GetGrantType();
            Code = builder.GetCode();
        }
        public class Builder
        {
            [Required]
            private string grantType;

            [Required]
            private string code;

            public string GetGrantType()
            {
                return grantType;
            }
            public Builder SetGrantType(string grantType)
            {
                this.grantType = grantType;
                return this;
            }
            public string GetCode()
            {
                return code;
            }
            public Builder SetCode(string code)
            {
                this.code = code;
                return this;
            }
            public AccessTokenByOtpVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AccessTokenByOtpVo(this);
            }
        }
    }
}
