using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject.Voucher
{
    public class DefineCreditVoucherVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string GuildCode { get; }
        public List<VoucherContentVo> VouchersContent { get; }
        public string ExpireDate { get; }
        public long? LimitedConsumerId { get; }
        public string CurrencyCode { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public DefineCreditVoucherVo(Builder builder)
        {
            GuildCode = builder.GetGuildCode();
            VouchersContent = builder.GetVouchersContent();
            ExpireDate = builder.GetExpireDate();
            LimitedConsumerId = builder.GetLimitedConsumerId();
            CurrencyCode = builder.GetCurrencyCode();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string guildCode;

            [Required]
            private List<VoucherContentVo> vouchersContent;

            [RegularExpression(RegexFormat.ShamsiDate)]
            [Required]
            private string expireDate;
            private long? limitedConsumerId;
            private string currencyCode;

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
            public List<VoucherContentVo> GetVouchersContent()
            {
                return vouchersContent;
            }
            public Builder SetVouchersContent(List<VoucherContentVo> vouchersContent)
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
            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public DefineCreditVoucherVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();
                var hashCodeError = VoucherContentVo.ValidateHashCodeCount(vouchersContent);
                if (hashCodeError.Key != null) hasErrorFields.Add(hashCodeError);

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new DefineCreditVoucherVo(this);
            }
        }
    }
}
