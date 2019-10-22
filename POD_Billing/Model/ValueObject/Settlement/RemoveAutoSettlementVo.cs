using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject.Settlement
{
    public class RemoveAutoSettlementVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string GuildCode { get; }
        public string CurrencyCode { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public RemoveAutoSettlementVo(Builder builder)
        {
            GuildCode = builder.GetGuildCode();
            CurrencyCode = builder.GetCurrencyCode();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string guildCode;
            private string currencyCode;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetGuildCode()
            {
                return guildCode;
            }

            /// <param name="guildCode">کد صنف</param>
            public Builder SetGuildCode(string guildCode)
            {
                this.guildCode = guildCode;
                return this;
            }
            public string GetCurrencyCode()
            {
                return currencyCode;
            }

            /// <param name="currencyCode">کد ارز</param>
            public Builder SetCurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode;
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

            public RemoveAutoSettlementVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new RemoveAutoSettlementVo(this);
            }
        }
    }
}
