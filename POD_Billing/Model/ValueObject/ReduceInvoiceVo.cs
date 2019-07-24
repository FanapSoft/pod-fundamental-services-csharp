﻿using POD_Base_Service.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class ReduceInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public List<InvoiceItemInfoVo> InvoiceItemsInfo { get; }
        public double? PreferredTaxRate { get; }

        public ReduceInvoiceVo(Builder builder)
        {
            Id = builder.GetId();
            InvoiceItemsInfo = builder.GetInvoiceItemsInfo();
            PreferredTaxRate = builder.GetPreferredTaxRate();
        }

        public class Builder
        {
            [Required] private long? id;
            [Required] private List<InvoiceItemInfoVo> invoiceItemsInfo;
            [Range(0, 1)] private double? preferredTaxRate;

            public long? GetId()
            {
                return id;
            }

            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }
            public List<InvoiceItemInfoVo> GetInvoiceItemsInfo()
            {
                return invoiceItemsInfo;
            }

            public Builder SetInvoiceItemsInfo(List<InvoiceItemInfoVo> invoiceItemsInfo)
            {
                this.invoiceItemsInfo = invoiceItemsInfo;
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

            public ReduceInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ReduceInvoiceVo(this);
            }
        }
    }
}
