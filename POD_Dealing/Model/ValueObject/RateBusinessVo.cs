using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Dealing.Model.ValueObject
{
    public class RateBusinessVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BusinessId { get; }
        public int? Rate { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public RateBusinessVo(Builder builder)
        {
            BusinessId = builder.GetBusinessId();
            Rate = builder.GetRate();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long? businessId;

            [Range(0,5)]
            [Required]
            private int? rate;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

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
            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
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

