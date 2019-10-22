using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject.Sharing
{
    public class SubInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BusinessId { get; }
        public string GuildCode { get; }
        public string BillNumber { get; }
        public string Metadata { get; }
        public string Description { get; }
        public List<InvoiceItemVo> InvoiceItemVOs { get; }
        public SubInvoiceVo(Builder builder)
        {
            BusinessId = builder.GetBusinessId();
            GuildCode = builder.GetGuildCode();
            BillNumber = builder.GetBillNumber();
            Metadata = builder.GetMetadata();
            Description = builder.GetDescription();
            InvoiceItemVOs = builder.GetInvoiceItemVOs();
        }
        public class Builder
        {
            [Required]
            private long? businessId;

            [Required]
            private string guildCode;
            private string billNumber;
            private string metadata;
            private string description;

            [Required]
            private List<InvoiceItemVo> invoiceItemVOs;
            public long? GetBusinessId()
            {
                return businessId;
            }
            public Builder SetBusinessId(long businessId)
            {
                this.businessId = businessId;
                return this;
            }
            public string GetGuildCode()
            {
                return guildCode;
            }
            public Builder SetGuildCode(string guildCode)
            {
                this.guildCode = guildCode.Trim();
                return this;
            }
            public string GetBillNumber()
            {
                return billNumber;
            }
            public Builder SetBillNumber(string billNumber)
            {
                this.billNumber = billNumber.Trim();
                return this;
            }
            public string GetMetadata()
            {
                return metadata;
            }
            public Builder SetMetadata(string metadata)
            {
                this.metadata = metadata;
                return this;
            }
            public string GetDescription()
            {
                return description;
            }
            public Builder SetDescription(string description)
            {
                this.description = description;
                return this;
            }
            public List<InvoiceItemVo> GetInvoiceItemVOs()
            {
                return invoiceItemVOs;
            }
            public Builder SetInvoiceItemVOs(List<InvoiceItemVo> invoiceItemVOs)
            {
                this.invoiceItemVOs = invoiceItemVOs;
                return this;
            }

            public SubInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new SubInvoiceVo(this);
            }
        }
    }
}
