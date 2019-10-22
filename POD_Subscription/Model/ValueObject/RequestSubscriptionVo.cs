using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Subscription.Model.ValueObject
{
    public class RequestSubscriptionVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? SubscriptionPlanId { get; }
        public long? UserId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public RequestSubscriptionVo(Builder builder)
        {
            SubscriptionPlanId = builder.GetSubscriptionPlanId();
            UserId = builder.GetUserId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? subscriptionPlanId;
            [Required] private long? userId;
            [Required] private InternalServiceCallVo serviceCallParameters;

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
            public long? GetUserId()
            {
                return userId;
            }

            /// <param name="userId">شناسه کاربر</param>
            public Builder SetUserId(long userId)
            {
                this.userId = userId;
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

            public RequestSubscriptionVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new RequestSubscriptionVo(this);
            }
        }
    }
}
