using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject
{
    public class SendInvoicePaymentSmsVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? InvoiceId { get; }
        public string Wallet { get; }
        public string CallbackUri { get; }
        public string RedirectUri { get; }
        public long[] DelegationId { get; }
        public bool? ForceDelegation { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public SendInvoicePaymentSmsVo(Builder builder)
        {
            InvoiceId  = builder.GetInvoiceId();
            Wallet = builder.GetWallet();
            CallbackUri = builder.GetCallbackUri();
            RedirectUri = builder.GetRedirectUri();
            DelegationId = builder.GetDelegationId();
            ForceDelegation = builder.GetForceDelegation();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? invoiceId;

            private string wallet;
            [Url] private string callbackUri;
            [Url] private string redirectUri;
            private long[] delegationId;
            private bool? forceDelegation;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetInvoiceId()
            {
                return invoiceId;
            }

            public Builder SetInvoiceId(long invoiceId)
            {
                this.invoiceId = invoiceId;
                return this;
            }

            public string GetWallet()
            {
                return wallet;
            }

            public Builder SetWallet(string wallet)
            {
                this.wallet = wallet;
                return this;
            }

            public string GetCallbackUri()
            {
                return callbackUri;
            }

            public Builder SetCallbackUri(string callbackUri)
            {
                this.callbackUri = callbackUri;
                return this;
            }
            public string GetRedirectUri()
            {
                return redirectUri;
            }

            public Builder SetRedirectUri(string redirectUri)
            {
                this.redirectUri = redirectUri;
                return this;
            }
            public long[] GetDelegationId()
            {
                return delegationId;
            }

            public Builder SetDelegationId(long[] delegationId)
            {
                this.delegationId = delegationId;
                return this;
            }

            public bool? GetForceDelegation()
            {
                return forceDelegation;
            }

            public Builder SetForceDelegation(bool forceDelegation)
            {
                this.forceDelegation = forceDelegation;
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

            public SendInvoicePaymentSmsVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new SendInvoicePaymentSmsVo(this);
            }
        }
    }
}
