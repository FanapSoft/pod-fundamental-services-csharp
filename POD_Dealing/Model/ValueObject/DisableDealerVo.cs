using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Dealing.Model.ValueObject
{
    public class DisableDealerVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? DealerBizId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public DisableDealerVo(Builder builder)
        {
            DealerBizId = builder.GetDealerBizId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? dealerBizId;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetDealerBizId()
            {
                return dealerBizId;
            }

            /// <param name="dealerBizId ">شناسه کسب و کار واسط </param>
            public Builder SetDealerBizId(long dealerBizId)
            {
                this.dealerBizId = dealerBizId;
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

            public DisableDealerVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new DisableDealerVo(this);
            }
        }
    }
}
