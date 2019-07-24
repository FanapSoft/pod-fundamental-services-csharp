using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class MultiInvoiceDataVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string RedirectURL { get; }
        public long? UserId { get; }
        public string CurrencyCode { get; }
        public string[] VoucherHashs { get; }
        public double? PreferredTaxRate { get; }
        public bool? VerificationNeeded { get; }
        public bool? Preview { get; }
        public MainInvoiceVo MainInvoice { get; }
        public List<SubInvoiceVo> SubInvoices { get; }
        public string CustomerDescription { get; }
        public string CustomerMetadata { get; }
        public List<InvoiceItemVo> CustomerInvoiceItemVOs { get; }

        public MultiInvoiceDataVo(Builder builder)
        {
            RedirectURL = builder.GetRedirectUrl();
            UserId = builder.GetUserId();
            CurrencyCode = builder.GetCurrencyCode();
            VoucherHashs = builder.GetVoucherHashs();
            PreferredTaxRate = builder.GetPreferredTaxRate();
            VerificationNeeded = builder.GetVerificationNeeded();
            Preview = builder.GetPreview();
            MainInvoice = builder.GetMainInvoice();
            SubInvoices = builder.GetSubInvoices();
            CustomerDescription = builder.GetCustomerDescription();
            CustomerMetadata = builder.GetCustomerMetadata();
            CustomerInvoiceItemVOs = builder.GetCustomerInvoiceItemVOs();
        }
        public class Builder
        {
            private string redirectUrl;
            private long? userId;
            private string currencyCode;
            private string[] voucherHashs;

            [Range(0, 1)]
            private double? preferredTaxRate;
            private bool? verificationNeeded;
            private bool? preview;

            [Required]
            private MainInvoiceVo mainInvoice;

            [Required]
            private List<SubInvoiceVo> subInvoices;
            private string customerDescription;
            private string customerMetadata;

            [Required]
            private List<InvoiceItemVo> customerInvoiceItemVOs;

            public string GetRedirectUrl()
            {
                return redirectUrl;
            }
            public Builder SetRedirectUrl(string redirectUrl)
            {
                this.redirectUrl = redirectUrl.Trim();
                return this;
            }
            public long? GetUserId()
            {
                return userId;
            }
            public Builder SetUserId(long userId)
            {
                this.userId = userId;
                return this;
            }
            public string GetCurrencyCode()
            {
                return currencyCode;
            }
            public Builder SetCurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode.Trim();
                return this;
            }
            public string[] GetVoucherHashs()
            {
                return voucherHashs;
            }
            public Builder SetVoucherHashs(string[] voucherHashs)
            {
                this.voucherHashs = voucherHashs;
                return this;
            }
            public double? GetPreferredTaxRate()
            {
                return preferredTaxRate;
            }
            public Builder SetPreferredTaxRate(double preferredTaxRate)
            {
                this.preferredTaxRate = preferredTaxRate;
                return this;
            }
            public bool? GetVerificationNeeded()
            {
                return verificationNeeded;
            }
            public Builder SetVerificationNeeded(bool verificationNeeded)
            {
                this.verificationNeeded = verificationNeeded;
                return this;
            }
            public bool? GetPreview()
            {
                return preview;
            }
            public Builder SetPreview(bool preview)
            {
                this.preview = preview;
                return this;
            }
            public MainInvoiceVo GetMainInvoice()
            {
                return mainInvoice;
            }
            public Builder SetMainInvoice(MainInvoiceVo mainInvoice)
            {
                this.mainInvoice = mainInvoice;
                return this;
            }
            public List<SubInvoiceVo> GetSubInvoices()
            {
                return subInvoices;
            }
            public Builder SetSubInvoices(List<SubInvoiceVo> subInvoices)
            {
                this.subInvoices = subInvoices;
                return this;
            }
            public string GetCustomerDescription()
            {
                return customerDescription;
            }
            public Builder SetCustomerDescription(string customerDescription)
            {
                this.customerDescription = customerDescription;
                return this;
            }
            public string GetCustomerMetadata()
            {
                return customerMetadata;
            }
            public Builder SetCustomerMetadata(string customerMetadata)
            {
                this.customerMetadata = customerMetadata;
                return this;
            }
            public List<InvoiceItemVo> GetCustomerInvoiceItemVOs()
            {
                return customerInvoiceItemVOs;
            }
            public Builder SetCustomerInvoiceItemVOs(List<InvoiceItemVo> customerInvoiceItemVOs)
            {
                this.customerInvoiceItemVOs = customerInvoiceItemVOs;
                return this;
            }
            public MultiInvoiceDataVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new MultiInvoiceDataVo(this);
            }
        }
    }
}
