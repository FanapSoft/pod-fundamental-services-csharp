using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class AddDealerVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? DealerBizId { get; }
        public bool? AllProductAllow { get; }

        public AddDealerVo(Builder builder)
        {
            DealerBizId = builder.GetDealerBizId();
            AllProductAllow = builder.GetAllProductAllow();
        }

        public class Builder
        {
            [Required]
            private long? dealerBizId;
            private bool? allProductAllow;

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
            public bool? GetAllProductAllow()
            {
                return allProductAllow;
            }

            /// <param name="allProductAllow">دسترسی به همه محصولات </param>
            public Builder SetAllProductAllow(bool allProductAllow)
            {
                this.allProductAllow = allProductAllow;
                return this;
            }

            public AddDealerVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AddDealerVo(this);
            }
        }
    }
}
