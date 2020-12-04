using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_VirtualAccount.Base.Enum;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class TransferToFollowerAndCashoutVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string GuildCode { get; }
        public decimal? Amount { get; }
        public long? UserId { get; }
        public string Description { get; }
        public string CurrencyCode { get; }
        public string Wallet { get; }
        public ToolCode? ToolCode { get; }
        public string UniqueId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public TransferToFollowerAndCashoutVo(Builder builder)
        {
            GuildCode = builder.GetGuildCode();
            Amount = builder.GetAmount();
            UserId = builder.GetUserId();
            CurrencyCode = builder.GetCurrencyCode();
            Description = builder.GetDescription();
            Wallet = builder.GetWallet();
            UniqueId = builder.GetUniqueId();
            ToolCode = builder.GetToolCode();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private string guildCode;

            [Required] private decimal? amount;

            [Required] private long? userId;
            private string currencyCode;

            [Required] private string description;

            [Required] private string wallet;
            private string uniqueId;
            private ToolCode? toolCode;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetGuildCode()
            {
                return guildCode;
            }

            /// <param name="guildCode">کد صنف مربوط به حساب</param>
            public Builder SetGuildCode(string guildCode)
            {
                this.guildCode = guildCode;
                return this;
            }

            public decimal? GetAmount()
            {
                return amount;
            }

            /// <param name="amount">مبلغ اعتبار</param>
            public Builder SetAmount(decimal amount)
            {
                this.amount = amount;
                return this;
            }
            public long? GetUserId()
            {
                return userId;
            }

            /// <param name="userId">شناسه کاربر که مشتری کسب و کار می باشد</param>
            public Builder SetUserId(long userId)
            {
                this.userId = userId;
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

            public string GetDescription()
            {
                return description;
            }

            /// <param name="description">توضیحات</param>
            public Builder SetDescription(string description)
            {
                this.description = description;
                return this;
            }

            public string GetWallet()
            {
                return wallet;
            }

            /// <param name="wallet">کد کیف پول</param>
            public Builder SetWallet(string wallet)
            {
                this.wallet = wallet;
                return this;
            }

            public string GetUniqueId()
            {
                return uniqueId;
            }

            /// <param name="uniqueId">شناسه یکتا برای انتقال وجه</param>
            public Builder SetUniqueId(string uniqueId)
            {
                this.uniqueId = uniqueId;
                return this;
            }
            public ToolCode? GetToolCode()
            {
                return toolCode;
            }

            /// <param name="toolCode">کد ابزار تسویه</param>
            public Builder SetToolCode(ToolCode toolCode)
            {
                this.toolCode = toolCode;
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

            public TransferToFollowerAndCashoutVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new TransferToFollowerAndCashoutVo(this);
            }
        }
    }
}
