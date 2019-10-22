using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject.Voucher
{
    public class ApplyVoucherVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? InvoiceId { get; }
        public string[] VoucherHash { get; }
        public bool? Preview { get; }
        public string Ott { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public ApplyVoucherVo(Builder builder)
        {
            InvoiceId = builder.GetInvoiceId();
            VoucherHash = builder.GetVoucherHash();
            Preview = builder.GetPreview();
            Ott = builder.GetOtt();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? invoiceId;
            [Required] private string[] voucherHash;
            private bool? preview;
            [Required] private string ott;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetInvoiceId()
            {
                return invoiceId;
            }

            /// <param name="invoiceId ">شناسه فاکتور </param>
            public Builder SetInvoiceId(long invoiceId)
            {
                this.invoiceId = invoiceId;
                return this;
            }
            public string[] GetVoucherHash()
            {
                return voucherHash;
            }

            /// <param name="voucherHash ">لیست کد بن تخفیف</param>
            public Builder SetVoucherHash(string[] voucherHash)
            {
                this.voucherHash = voucherHash;
                return this;
            }
            public bool? GetPreview()
            {
                return preview;
            }

            /// <param name="preview">پیش نمایش اعمال ووچر روی فاکتور- در سیستم ثبت نمی گردد</param>
            public Builder SetPreview(bool preview)
            {
                this.preview = preview;
                return this;
            }
            public string GetOtt()
            {
                return ott;
            }
            public Builder SetOtt(string ott)
            {
                this.ott = ott;
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

            public ApplyVoucherVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ApplyVoucherVo(this);
            }
        }
    }
}
