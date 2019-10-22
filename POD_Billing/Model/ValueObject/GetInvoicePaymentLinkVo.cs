using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject
{
    public class GetInvoicePaymentLinkVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? InvoiceId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetInvoicePaymentLinkVo(Builder builder)
        {
            InvoiceId = builder.GetInvoiceId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? invoiceId;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetInvoiceId()
            {
                return invoiceId;
            }

            /// <param name="invoiceId">شناسه فاکتور </param>
            public Builder SetInvoiceId(long invoiceId)
            {
                this.invoiceId = invoiceId;
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

            public GetInvoicePaymentLinkVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetInvoicePaymentLinkVo(this);
            }
        }


        /// <param name="link">لینک گرفته شده از سرویس</param>
        /// <param name="gateway"> وارد کنید , کاربر مستقیما به صفحه درگاه پرداخت بانک پاسارگاد هدایت خواهد شد PEP در صورتی که مقدار </param>
        /// <param name="redirectUri">در صورت ارسال این پارامتر کاربر را ملزم به تکمیل فرآیند خرید خواهد بود</param>
        /// <param name="callbackUri"></param>
        public string GetAdvanceLink(string link, string gateway = null, string redirectUri=null,string callbackUri=null)
        {
            link = link.TrimEnd('&');
            if (!string.IsNullOrEmpty(redirectUri)) link += $"&redirectUri={redirectUri}";
            if (!string.IsNullOrEmpty(callbackUri)) link += $"&callbackUri={callbackUri}";
            if (!string.IsNullOrEmpty(gateway)) link += $"&gateway={gateway}";
            return link;
        }
    }
}
