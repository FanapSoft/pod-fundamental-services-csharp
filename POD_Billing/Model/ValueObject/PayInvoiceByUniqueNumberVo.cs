using POD_Base_Service.Base;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject
{
    public class PayInvoiceByUniqueNumberVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string UniqueNumber { get; }
        public string RedirectUri { get; }
        public string CallUri { get; }
        public string Gateway { get; }

        public PayInvoiceByUniqueNumberVo(Builder builder)
        {
            UniqueNumber = builder.GetUniqueNumber();
            RedirectUri = builder.GetRedirectUri();
            CallUri = builder.GetCallUri();
            Gateway = builder.GetGateway();
        }

        public class Builder
        {
            [Required] private string uniqueNumber;

            [Url] private string redirectUri;

            [Url] private string callUri;

            private string gateway;

            public string GetUniqueNumber()
            {
                return uniqueNumber;
            }

            public Builder SetUniqueNumber(string uniqueNumber)
            {
                this.uniqueNumber = uniqueNumber;
                return this;
            }

            public string GetRedirectUri()
            {
                return redirectUri;
            }

            /// <param name="redirectUri">آدرسی است که بعد از پرداخت کاربر به آن هدایت می گردد</param>
            public Builder SetRedirectUri(string redirectUri)
            {
                this.redirectUri = redirectUri;
                return this;
            }

            public string GetCallUri()
            {
                return callUri;
            }

            /// <param name="callUri">آدرسی در سرور شما میتواند باشد که در صورت موفق بودن پرداخت فراخوانی می گردد</param>
            public Builder SetCallUri(string callUri)
            {
                this.callUri = callUri;
                return this;
            }
            public string GetGateway()
            {
                return gateway;
            }

            /// <param name="gateway"> وارد کنید , کاربر مستقیما به صفحه درگاه پرداخت بانک پاسارگاد هدایت خواهد شد PEP در صورتی که مقدار </param>
            public Builder SetGateway(string gateway)
            {
                this.gateway = gateway;
                return this;
            }
            public PayInvoiceByUniqueNumberVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PayInvoiceByUniqueNumberVo(this);
            }
        }

        public string GetLink()
        {
            return $@"{BaseUrl.PrivateCallAddress}/v1/pbc/payInvoiceByUniqueNumber/?uniqueNumber={UniqueNumber}&gateway={Gateway}&redirectUri={RedirectUri}&callUri={CallUri}";
        }
    }
}
