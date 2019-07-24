using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Dealing.Model.ValueObject
{
    public class RateBusinessVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BusinessId { get; }
        public int? Rate { get; }
        public string Token { get; }

        public RateBusinessVo(Builder builder)
        {
            BusinessId = builder.GetBusinessId();
            Rate = builder.GetRate();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private long? businessId;

            [Range(0,10)]
            [Required]
            private int? rate;

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
            public int? GetRate()
            {
                return rate;
            }

            /// <param name="rate">امتیازی که کاربر به کسب و کار می دهد </param>
            public Builder SetRate(int rate)
            {
                this.rate = rate;
                return this;
            }
            public string GetToken()
            {
                return token;
            }

            /// <param name="token">توکنی که بعد از ورود به سیستم دریافت کرده اید - AccessToken</param>
            public Builder SetToken(string token)
            {
                this.token = token;
                return this;
            }

            public RateBusinessVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new RateBusinessVo(this);
            }
        }
    }
}

