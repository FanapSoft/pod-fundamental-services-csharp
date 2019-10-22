using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject.Voucher
{
    public class DiscountVoucherContentVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Count { get; }
        public decimal? Amount { get; }
        public string Name { get; }
        public string Description { get; }
        public string[] HashCodes { get; }
        public int? DiscountPercentage { get; }

        public DiscountVoucherContentVo(Builder builder)
        {
            Count = builder.GetCount();
            Amount = builder.GetAmount();
            Name = builder.GetName();
            Description = builder.GetDescription();
            HashCodes = builder.GetHashCodes();
            DiscountPercentage = builder.GetDiscountPercentage();
        }

        public class Builder
        {
            [Required]
            private int? count;

            [Required]
            private decimal? amount;

            [Required]
            private string name;

            [Required]
            private string description;
            private string[] hashCodes;

            [Required]
            private int? discountPercentage;

            public int? GetCount()
            {
                return count;
            }

            /// <param name="count">لیست تعداد بن تخفیف</param>
            public Builder SetCount(int? count)
            {
                this.count = count;
                return this;
            }
            public decimal? GetAmount()
            {
                return amount;
            }

            /// <param name="amount">لیست مبالغ بن تخفیف</param>
            public Builder SetAmount(decimal? amount)
            {
                this.amount = amount;
                return this;
            }
            public string GetName()
            {
                return name;
            }

            /// <param name="name">لیست نام ها</param>
            public Builder SetName(string name)
            {
                this.name = name;
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
            public string[] GetHashCodes()
            {
                return hashCodes;
            }

            /// <param name="hashCodes">کد هش دلخواه خود را تنظیم نمایید.</param>
            public Builder SetHashCodes(string[] hashCodes)
            {
                this.hashCodes = hashCodes;
                return this;
            }
            public int? GetDiscountPercentage()
            {
                return discountPercentage;
            }

            public Builder SetDiscountPercentage(int discountPercentage)
            {
                this.discountPercentage = discountPercentage;
                return this;
            }

            public DiscountVoucherContentVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new DiscountVoucherContentVo(this);
            }
        }
        public static KeyValuePair<string, string> ValidateHashCodeCount(List<DiscountVoucherContentVo> vouchersContent)
        {
            if (vouchersContent != null && vouchersContent.Any(_ => _.HashCodes != null))
            {
                int? voucherCount = 0;
                var hashCount = 0;
                foreach (var voucherContentVo in vouchersContent)
                {
                    voucherCount += voucherContentVo.Count;
                    if (voucherContentVo.HashCodes != null)
                        hashCount += voucherContentVo.HashCodes.Length;
                }

                if (voucherCount != hashCount)
                    return new KeyValuePair<string, string>($"count : {voucherCount},hash : {hashCount}", "-مطابقت ندارد hash تعداد کل بن ها با تعداد کل کدهای ");
            }

            return new KeyValuePair<string, string>();
        }
    }
}
