using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject.Sharing
{
    public class ReduceMultiInvoiceDataVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public double? PreferredTaxRate { get; }
        public ReduceInvoiceItemVo MainInvoice { get; }
        public List<ReduceInvoiceItemVo> SubInvoices { get; }
        public List<ReduceInvoiceSubItemVo> CustomerInvoiceItemVOs { get; }

        public ReduceMultiInvoiceDataVo(Builder builder)
        {
            PreferredTaxRate = builder.GetPreferredTaxRate();
            MainInvoice = builder.GetMainInvoice();
            SubInvoices = builder.GetSubInvoices();
            CustomerInvoiceItemVOs = builder.GetCustomerInvoiceItemVOs();
        }

        public class Builder
        {
            [Range(0, 1)]
            private double? preferredTaxRate;

            [Required]
            private ReduceInvoiceItemVo mainInvoice;

            [Required]
            private List<ReduceInvoiceItemVo> subInvoices;

            [Required]
            private List<ReduceInvoiceSubItemVo> customerInvoiceItemVOs;

            public double? GetPreferredTaxRate()
            {
                return preferredTaxRate;
            }
            public Builder SetPreferredTaxRate(double preferredTaxRate)
            {
                this.preferredTaxRate = preferredTaxRate;
                return this;
            }
            public ReduceInvoiceItemVo GetMainInvoice()
            {
                return mainInvoice;
            }
            public Builder SetMainInvoice(ReduceInvoiceItemVo mainInvoice)
            {
                this.mainInvoice = mainInvoice;
                return this;
            }
            public List<ReduceInvoiceItemVo> GetSubInvoices()
            {
                return subInvoices;
            }
            public Builder SetSubInvoices(List<ReduceInvoiceItemVo> subInvoices)
            {
                this.subInvoices = subInvoices;
                return this;
            }
            public List<ReduceInvoiceSubItemVo> GetCustomerInvoiceItemVOs()
            {
                return customerInvoiceItemVOs;
            }
            public Builder SetCustomerInvoiceItemVOs(List<ReduceInvoiceSubItemVo> customerInvoiceItemVOs)
            {
                this.customerInvoiceItemVOs = customerInvoiceItemVOs;
                return this;
            }

            public ReduceMultiInvoiceDataVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ReduceMultiInvoiceDataVo(this);
            }
        }
    }
}
