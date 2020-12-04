using POD_Base_Service.Model.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class BuyCreditByAmountVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string RedirectUri { get; }
        public string CallUri { get; }
        public decimal? Amount { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public BuyCreditByAmountVo(Builder builder)
        {
            RedirectUri = builder.GetRedirectUri();
            CallUri = builder.GetCallUri();
            Amount = builder.GetAmount();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Url]
            private string redirectUri;

            [Url]
            private string callUri;

            [Required]
            private decimal? amount;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetRedirectUri()
            {
                return redirectUri;
            }

            public Builder SetRedirectUri(string redirectUri)
            {
                this.redirectUri = redirectUri;
                return this;
            }

            public string GetCallUri()
            {
                return callUri;
            }

            public Builder SetCallUri(string callUri)
            {
                this.callUri = callUri;
                return this;
            }

            public decimal? GetAmount()
            {
                return amount;
            }

            /// <param name="amount">مبلغ جهت شارژ کیف پول</param>
            public Builder SetAmount(decimal amount)
            {
                this.amount = amount;
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

            public BuyCreditByAmountVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new BuyCreditByAmountVo(this);
            }
        }

        public string GetLink()
        {
            var link = $"{BaseUrl.PrivateCallAddress}/v1/pbc/BuyCredit/?amount= {Amount} &" +
                       $"redirectUri={RedirectUri} & callUri ={CallUri}";
            return link;
        }
    }
}
