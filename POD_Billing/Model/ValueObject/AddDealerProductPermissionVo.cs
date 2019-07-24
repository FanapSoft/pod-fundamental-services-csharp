using POD_Base_Service.Base;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class AddDealerProductPermissionVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? EntityId { get; }
        public long? DealerBizId { get; }

        public AddDealerProductPermissionVo(Builder builder)
        {
            EntityId = builder.GetEntityId();
            DealerBizId = builder.GetDealerBizId();
        }

        public class Builder
        {
            [Required]
            private long? entityId;

            [Required]
            private long? dealerBizId;

            public long? GetEntityId()
            {
                return entityId;
            }

            /// <param name="entityId">شناسه محصول </param>
            public Builder SetEntityId(long entityId)
            {
                this.entityId = entityId;
                return this;
            }
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

            public AddDealerProductPermissionVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AddDealerProductPermissionVo(this);
            }
        }
    }
}
