using POD_Base_Service.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Billing.Base.Enum;

namespace POD_Billing.Model.ValueObject.Voucher
{
    public class DefineDiscountPercentageVoucherVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string GuildCode { get; }
        public List<DiscountVoucherContentVo> VouchersContent { get; }
        public string ExpireDate { get; }
        public long? LimitedConsumerId { get; }
        public string CurrencyCode { get; }
        public long[] EntityId { get; }
        public long[] DealerBusinessId { get; }
        public int? Type { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public DefineDiscountPercentageVoucherVo(Builder builder)
        {
            GuildCode = builder.GetGuildCode();
            VouchersContent = builder.GetVouchersContent();
            ExpireDate = builder.GetExpireDate();
            LimitedConsumerId = builder.GetLimitedConsumerId();
            CurrencyCode = builder.GetCurrencyCode();
            EntityId = builder.GetEntityId();
            DealerBusinessId = builder.GetDealerBusinessId();
            Type = builder.GetType();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string guildCode;

            [Required]
            private List<DiscountVoucherContentVo> vouchersContent;

            [RegularExpression(RegexFormat.ShamsiDate)]
            [Required]
            private string expireDate;
            private long? limitedConsumerId;
            private string currencyCode;
            private long[] entityId;
            private long[] dealerBusinessId;

            [Required]
            private int? type;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetGuildCode()
            {
                return guildCode;
            }

            /// <param name="guildCode">نام صنف مطابق با صنف موجود در پنل</param>
            public Builder SetGuildCode(string guildCode)
            {
                this.guildCode = guildCode;
                return this;
            }
            public string GetExpireDate()
            {
                return expireDate;
            }

            /// <param name="expireDate">yyyy/mm/dd تاریخ انقضای شمسی</param>
            public Builder SetExpireDate(string expireDate)
            {
                this.expireDate = expireDate;
                return this;
            }

            /// <param name="expireDate">تاریخ انقضای میلادی</param>
            public Builder SetExpireDate(DateTime expireDate)
            {
                this.expireDate = expireDate.ToShamsiDate();
                return this;
            }
            public List<DiscountVoucherContentVo> GetVouchersContent()
            {
                return vouchersContent;
            }
            public Builder SetVouchersContent(List<DiscountVoucherContentVo> vouchersContent)
            {
                this.vouchersContent = vouchersContent;
                return this;
            }
            public long? GetLimitedConsumerId()
            {
                return limitedConsumerId;
            }

            /// <param name="limitedConsumerId">در صورت ورود شناسه کاربری، بن تخفیف فقط برای کاربر داده شده قابل استفاده خواهد بود.</param>
            public Builder SetLimitedConsumerId(long limitedConsumerId)
            {
                this.limitedConsumerId = limitedConsumerId;
                return this;
            }
            public string GetCurrencyCode()
            {
                return currencyCode;
            }

            /// <param name="currencyCode">کد ارز</param>
            public Builder SetCurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode;
                return this;
            }

            public long[] GetEntityId()
            {
                return entityId;
            }

            /// <param name="entityId">لیست محصولات</param>
            public Builder SetEntityId(long[] entityId)
            {
                this.entityId = entityId;
                return this;
            }
            public long[] GetDealerBusinessId()
            {
                return dealerBusinessId;
            }

            /// <param name="dealerBusinessId">لیست شناسه کسب و کارهای واسط کسب و کار اصلی که می توانند از این بن تخفیف هنگام صدور فاکتور استفاده کنند</param>
            public Builder SetDealerBusinessId(long[] dealerBusinessId)
            {
                this.dealerBusinessId = dealerBusinessId;
                return this;
            }

            public new int? GetType()
            {
                return type;
            }

            public Builder SetType(VoucherType type)
            {
                this.type = (int)type;
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

            public DefineDiscountPercentageVoucherVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                var hashCodeError = DiscountVoucherContentVo.ValidateHashCodeCount(vouchersContent);
                if (hashCodeError.Key != null) hasErrorFields.Add(hashCodeError);

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new DefineDiscountPercentageVoucherVo(this);
            }
        }
    }
}
