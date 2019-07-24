using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class DisableDealerVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? DealerBizId { get; }

        public DisableDealerVo(Builder builder)
        {
            DealerBizId = builder.GetDealerBizId();
        }

        public class Builder
        {
            [Required]
            private long? dealerBizId;

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
