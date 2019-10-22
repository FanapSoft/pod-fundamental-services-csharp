using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Billing.Base.Enum;

namespace POD_Billing.Model.ValueObject.Voucher
{
    public class GetVoucherListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? ConsumerId { get; }
        public string HashCode { get; }
        public string VoucherName { get; }
        public int? Type { get; }
        public string[] GuildCodes { get; }
        public string CurrencyCode { get; }
        public decimal? AmountFrom { get; }
        public decimal? AmountTo { get; }
        public decimal? DiscountPercentageFrom { get; }
        public decimal? DiscountPercentageTo { get; }
        public string ExpireDateFrom { get; }
        public string ExpireDateTo { get; }
        public long[] EntityId { get; }
        public string ConsumeDateFrom { get; }
        public string ConsumeDateTo { get; }
        public decimal? UsedAmountFrom { get; }
        public decimal? UsedAmountTo { get; }
        public bool? Active { get; }
        public bool? Used { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetVoucherListVo(Builder builder)
        {
            ConsumerId = builder.GetConsumerId();
            HashCode = builder.GetHashCode();
            VoucherName = builder.GetVoucherName();
            Type = builder.GetType();
            GuildCodes = builder.GetGuildCodes();
            CurrencyCode = builder.GetCurrencyCode();
            AmountFrom = builder.GetAmountFrom();
            AmountTo = builder.GetAmountTo();
            DiscountPercentageFrom = builder.GetDiscountPercentageFrom();
            DiscountPercentageTo = builder.GetDiscountPercentageTo();
            ExpireDateFrom = builder.GetExpireDateFrom();
            ExpireDateTo = builder.GetExpireDateTo();
            EntityId = builder.GetEntityId();
            ConsumeDateFrom = builder.GetConsumeDateFrom();
            ConsumeDateTo = builder.GetConsumeDateTo();
            UsedAmountFrom = builder.GetUsedAmountFrom();
            UsedAmountTo = builder.GetUsedAmountTo();
            Active = builder.GetActive();
            Used = builder.GetUsed();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private long? consumerId;
            private string hashCode;
            private string voucherName;
            private int? type;
            private string[] guildCodes;
            private string currencyCode;
            private decimal? amountFrom;
            private decimal? amountTo;
            private decimal? discountPercentageFrom;
            private decimal? discountPercentageTo;

            [RegularExpression(RegexFormat.ShamsiDate)]
            private string expireDateFrom;

            [RegularExpression(RegexFormat.ShamsiDate)]
            private string expireDateTo;

            private long[] entityId;

            [RegularExpression(RegexFormat.ShamsiDate)]
            private string consumeDateFrom;

            [RegularExpression(RegexFormat.ShamsiDate)]
            private string consumeDateTo;
            private decimal? usedAmountFrom;
            private decimal? usedAmountTo;
            private bool? active;
            private bool? used;
            private int? offset;
            private int? size;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetConsumerId()
            {
                return consumerId;
            }

            /// <param name="consumerId ">شناسه کاربر مربوط به مشتری مصرف کننده</param>
            public Builder SetConsumerId(long consumerId)
            {
                this.consumerId = consumerId;
                return this;
            }
            public new string GetHashCode()
            {
                return hashCode;
            }

            /// <param name="hashCode ">کد بن</param>
            public Builder SetHashCode(string hashCode)
            {
                this.hashCode = hashCode;
                return this;
            }
            public string GetVoucherName()
            {
                return voucherName;
            }

            /// <param name="voucherName ">چک می شود like نام بن که به صورت</param>
            public Builder SetVoucherName(string voucherName)
            {
                this.voucherName = voucherName;
                return this;
            }
            public new int? GetType()
            {
                return type;
            }

            /// <param name="type ">نوع بن</param>
            public Builder SetType(VoucherType type)
            {
                this.type = (int)type;
                return this;
            }
            public string[] GetGuildCodes()
            {
                return guildCodes;
            }

            /// <param name="guildCodes">کدهای صنف</param>
            public Builder SetGuildCodes(string[] guildCodes)
            {
                this.guildCodes = guildCodes;
                return this;
            }
            public string GetCurrencyCode()
            {
                return currencyCode;
            }

            /// <param name="currencyCode ">کد صنف</param>
            public Builder SetCurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode;
                return this;
            }
            public decimal? GetAmountFrom()
            {
                return amountFrom;
            }

            /// <param name="amountFrom ">حد پایین مبلغ بن</param>
            public Builder SetAmountFrom(decimal amountFrom)
            {
                this.amountFrom = amountFrom;
                return this;
            }
            public decimal? GetAmountTo()
            {
                return amountTo;
            }

            /// <param name="amountTo ">حد بالای مبلغ بن</param>
            public Builder SetAmountTo(decimal amountTo)
            {
                this.amountTo = amountTo;
                return this;
            }

            public decimal? GetDiscountPercentageFrom()
            {
                return discountPercentageFrom;
            }

            /// <param name="discountPercentageFrom ">حد پایین درصد تخفیف بن</param>
            public Builder SetDiscountPercentageFrom(decimal discountPercentageFrom)
            {
                this.discountPercentageFrom = discountPercentageFrom;
                return this;
            }
            public decimal? GetDiscountPercentageTo()
            {
                return discountPercentageTo;
            }

            /// <param name="discountPercentageTo ">حد بالای درصد تخفیف بن</param>
            public Builder SetDiscountPercentageTo(decimal discountPercentageTo)
            {
                this.discountPercentageTo = discountPercentageTo;
                return this;
            }
            public string GetExpireDateFrom()
            {
                return expireDateFrom;
            }

            /// <param name="expireDateFrom ">yyyy/mm/dd حد پایین تاریخ انقضا شمسی</param>
            public Builder SetExpireDateFrom(string expireDateFrom)
            {
                this.expireDateFrom = expireDateFrom;
                return this;
            }

            /// <param name="expireDateFrom">حد پایین تاریخ انقضا میلادی</param>
            public Builder SetExpireDateFrom(DateTime expireDateFrom)
            {
                this.expireDateFrom = expireDateFrom.ToShamsiDate();
                return this;
            }

            public string GetExpireDateTo()
            {
                return expireDateTo;
            }

            /// <param name="expireDateTo">yyyy/mm/dd حد بالای تاریخ انقضا شمسی</param>
            public Builder SetExpireDateTo(string expireDateTo)
            {
                this.expireDateTo = expireDateTo;
                return this;
            }

            /// <param name="expireDateTo">حد بالای تاریخ انقضا میلادی</param>
            public Builder SetExpireDateTo(DateTime expireDateTo)
            {
                this.expireDateTo = expireDateTo.ToShamsiDate();
                return this;
            }

            public long[] GetEntityId()
            {
                return entityId;
            }

            /// <param name="entityId">شناسه محصولات معتبر برای بن</param>
            public Builder SetEntityId(long[] entityId)
            {
                this.entityId = entityId;
                return this;
            }
            public string GetConsumeDateFrom()
            {
                return consumeDateFrom;
            }

            /// <param name="consumeDateFrom">yyyy/mm/dd حد پایین تاریخ مصرف شمسی</param>
            public Builder SetConsumeDateFrom(string consumeDateFrom)
            {
                this.consumeDateFrom = consumeDateFrom;
                return this;
            }

            /// <param name="consumeDateFrom">حد پایین تاریخ مصرف بن میلادی</param>
            public Builder SetConsumeDateFrom(DateTime consumeDateFrom)
            {
                this.consumeDateFrom = consumeDateFrom.ToShamsiDate();
                return this;
            }
            public string GetConsumeDateTo()
            {
                return consumeDateTo;
            }

            /// <param name="consumeDateTo">yyyy/mm/dd حد بالای تاریخ مصرف بن شمسی</param>
            public Builder SetConsumeDateTo(string consumeDateTo)
            {
                this.consumeDateTo = consumeDateTo;
                return this;
            }

            /// <param name="consumeDateTo">حد بالای تاریخ مصرف بن میلادی</param>
            public Builder SetConsumeDateTo(DateTime consumeDateTo)
            {
                this.consumeDateTo = consumeDateTo.ToShamsiDate();
                return this;
            }
            public decimal? GetUsedAmountFrom()
            {
                return usedAmountFrom;
            }
            /// <param name="usedAmountFrom">حد پایین مبلغ اعتبار یا تخفیف داده شده بوسیله بن</param>
            public Builder SetUsedAmountFrom(decimal usedAmountFrom)
            {
                this.usedAmountFrom = usedAmountFrom;
                return this;
            }
            public decimal? GetUsedAmountTo()
            {
                return usedAmountTo;
            }

            /// <param name="usedAmountTo">حد بالای مبلغ اعتبار یا تخفیف داده شده بوسیله بن</param>
            public Builder SetUsedAmountTo(decimal usedAmountTo)
            {
                this.usedAmountTo = usedAmountTo;
                return this;
            }
            public bool? GetActive()
            {
                return active;
            }

            /// <param name="active">فعال بودن بن</param>
            public Builder SetActive(bool active)
            {
                this.active = active;
                return this;
            }
            public bool? GetUsed()
            {
                return used;
            }

            /// <param name="used">بن های استفاده شده</param>
            public Builder SetUsed(bool used)
            {
                this.used = used;
                return this;
            }
            public int? GetOffset()
            {
                return offset;
            }

            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }
            public int? GetSize()
            {
                return size;
            }
            /// <param name="size">اندازه خروجی</param>
            public Builder SetSize(int size)
            {
                this.size = size;
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

            public GetVoucherListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetVoucherListVo(this);
            }
        }
    }
}
