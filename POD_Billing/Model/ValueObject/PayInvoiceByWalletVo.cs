using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class PayInvoiceByWalletVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? InvoiceId { get; }
        public string RedirectUri { get; }
        public string CallUri { get; }

        public PayInvoiceByWalletVo(Builder builder)
        {
            InvoiceId = builder.GetInvoiceId();
            RedirectUri = builder.GetRedirectUri();
            CallUri = builder.GetCallUri();
        }

        public class Builder
        {
            [Required] private long? invoiceId;
            [Url] private string redirectUri;
            [Url] private string callUri;

            public long? GetInvoiceId()
            {
                return invoiceId;
            }

            public Builder SetInvoiceId(long invoiceId)
            {
                this.invoiceId = invoiceId;
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

            public string GetCallUri()
            {
                return callUri;
            }

            public Builder SetCallUri(string callUri)
            {
                this.callUri = callUri;
                return this;
            }

            public PayInvoiceByWalletVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PayInvoiceByWalletVo(this);
            }
        }

        public string GetLink()
        {
            return  $@"{BaseUrl.PrivateCallAddress}/v1/pbc/payinvoice/?invoiceId={InvoiceId}&redirectUri={RedirectUri}&callUri={CallUri}";
        }
    }
}
