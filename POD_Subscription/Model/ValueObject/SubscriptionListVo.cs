using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Subscription.Model.ValueObject
{
    public class SubscriptionListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Offset { get; }
        public int? Size { get; }
        public long? SubscriptionPlanId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public SubscriptionListVo(Builder builder)
        {
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            SubscriptionPlanId = builder.GetSubscriptionPlanId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? subscriptionPlanId;
            [Required] private int? offset;
            [Required] private int? size;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public int? GetOffset()
            {
                return offset;
            }

            /// <param name="offset">حد پایین خروجی</param>
            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }
            public int? GetSize()
            {
                return size;
            }

            /// <param name="size">اندازه خروجی</param>
            public Builder SetSize(int size)
            {
                this.size = size;
                return this;
            }
            public long? GetSubscriptionPlanId()
            {
                return subscriptionPlanId;
            }

            /// <param name="subscriptionPlanId">شناسه طرح</param>
            public Builder SetSubscriptionPlanId(long subscriptionPlanId)
            {
                this.subscriptionPlanId = subscriptionPlanId;
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

            public SubscriptionListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new SubscriptionListVo(this);
            }
        }
    }
}
