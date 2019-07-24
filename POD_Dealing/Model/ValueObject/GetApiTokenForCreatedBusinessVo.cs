using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Dealing.Model.ValueObject
{
    public class GetApiTokenForCreatedBusinessVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BusinessId { get; }
        public string Token { get; }

        public GetApiTokenForCreatedBusinessVo(Builder builder)
        {
            BusinessId = builder.GetBusinessId();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private long? businessId;

            [Required]
            private string token;

            public long? GetBusinessId()
            {
                return businessId;
            }

            /// <param name="businessId">شناسه کسب و کار </param>
            public Builder SetBusinessId(long businessId)
            {
                this.businessId = businessId;
                return this;
            }
            public string GetToken()
            {
                return token;
            }

            /// <param name="token">توکنی که از پنل کسب و کار دریافت شده است - ApiToken</param>
            public Builder SetToken(string token)
            {
                this.token = token;
                return this;
            }

            public GetApiTokenForCreatedBusinessVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetApiTokenForCreatedBusinessVo(this);
            }
        }
    }
}
