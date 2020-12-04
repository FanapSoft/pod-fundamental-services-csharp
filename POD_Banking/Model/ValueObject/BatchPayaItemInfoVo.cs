using System;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace POD_Banking.Model.ValueObject
{
    public class BatchPayaItemInfoVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public decimal? Amount { get; }
        public string BeneficiaryFullName { get; }
        public string Description { get; }
        public string DestShebaNumber { get; }
        public string BillNumber { get; }

        public BatchPayaItemInfoVo(Builder builder)
        {
            Amount = builder.GetAmount();
            BeneficiaryFullName = builder.GetBeneficiaryFullName();
            Description = builder.GetDescription();
            DestShebaNumber = builder.GetDestShebaNumber();
            BillNumber = builder.GetBillNumber();
        }

        public class Builder
        {
            [Required]
            private decimal? amount;

            [Required]
            private string beneficiaryFullName;

            [Required]
            private string billNumber;

            [Required]
            private string destShebaNumber;

            [Required]
            private string description;

            public decimal? GetAmount()
            {
                return amount;
            }

            ///<param name="amount ">مبلغ تراکنش</param>
            public Builder SetAmount(decimal amount)
            {
                this.amount = amount;
                return this;
            }
            public string GetBeneficiaryFullName()
            {
                return beneficiaryFullName;
            }

            ///<param name="beneficiaryFullName"> نام و نام خانوادگی ذینفع</param>
            public Builder SetBeneficiaryFullName(string beneficiaryFullName)
            {
                this.beneficiaryFullName = beneficiaryFullName;
                return this;
            }
            public string GetDescription()
            {
                return description;
            }

            /// <param name="description">شرح تراکنش</param>
            public Builder SetDescription(string description)
            {
                this.description = description;
                return this;
            }
            public string GetDestShebaNumber()
            {
                return destShebaNumber;
            }

            /// <param name="destShebaNumber">شماره شبای مقصد</param>
            public Builder SetDestShebaNumber(string destShebaNumber)
            {
                if (destShebaNumber.StartsWith("IR", StringComparison.OrdinalIgnoreCase))
                    this.destShebaNumber = destShebaNumber;
                else this.destShebaNumber = "IR" + destShebaNumber;
                this.destShebaNumber = destShebaNumber;
                return this;
            }

            public string GetBillNumber()
            {
                return billNumber;
            }

            /// <param name="billNumber">شناسه واریز</param>
            public Builder SetBillNumber(string billNumber)
            {
                this.billNumber = billNumber;
                return this;
            }

            public BatchPayaItemInfoVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new BatchPayaItemInfoVo(this);
            }
        }
    }
}
