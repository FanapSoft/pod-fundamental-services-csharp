using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Subscription.Model.ValueObject
{
    public class ConsumeSubscriptionVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public decimal? UsedAmount { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public ConsumeSubscriptionVo(Builder builder)
        {
            Id = builder.GetId();
            UsedAmount = builder.GetUsedAmount();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? id;
            private decimal? usedAmount;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه طرح</param>
            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }
            public decimal? GetUsedAmount()
            {
                return usedAmount;
            }

            /// <param name="usedAmount">میزان استفاده از اشتراک</param>
            public Builder SetUsedAmount(decimal usedAmount)
            {
                this.usedAmount = usedAmount;
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

            public ConsumeSubscriptionVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ConsumeSubscriptionVo(this);
            }
        }
    }
}
