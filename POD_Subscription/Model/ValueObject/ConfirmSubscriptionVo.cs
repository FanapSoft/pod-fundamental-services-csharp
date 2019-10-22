using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Subscription.Model.ValueObject
{
    public class ConfirmSubscriptionVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Code { get; }
        public long? SubscriptionId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public ConfirmSubscriptionVo(Builder builder)
        {
            SubscriptionId = builder.GetSubscriptionId();
            Code = builder.GetCode();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private string code;
            [Required] private long? subscriptionId;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetCode()
            {
                return code;
            }

            /// <param name="code">کد پیامک شده</param>
            public Builder SetCode(string code)
            {
                this.code = code;
                return this;
            }
            public long? GetSubscriptionId()
            {
                return subscriptionId;
            }

            /// <param name="subscriptionId">شناسه درخواست جهت تایید</param>
            public Builder SetSubscriptionId(long subscriptionId)
            {
                this.subscriptionId = subscriptionId;
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

            public ConfirmSubscriptionVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ConfirmSubscriptionVo(this);
            }
        }
    }
}
