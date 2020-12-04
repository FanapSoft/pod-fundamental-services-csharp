using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class TransferFromOwnAccountsVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public List<GuildAmount> GuildAmount { get; }
        public decimal? CustomerAmount { get; }
        public string CurrencyCode { get; }
        public string Description { get; }
        public string Wallet { get; }
        public string UniqueId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public TransferFromOwnAccountsVo(Builder builder)
        {
            GuildAmount = builder.GetGuildAmount();
            CurrencyCode = builder.GetCurrencyCode();
            Description = builder.GetDescription();
            Wallet = builder.GetWallet();
            UniqueId = builder.GetUniqueId();
            ServiceCallParameters = builder.GetServiceCallParameters();
            CustomerAmount = builder.GetCustomerAmount();
        }

        public class Builder
        {
            [Required]
            private List<GuildAmount> guildAmount;

            [Required]
            private decimal? customerAmount;
            private string currencyCode;
            private string description;
            private string wallet;
            private string uniqueId;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public List<GuildAmount> GetGuildAmount()
            {
                return guildAmount;
            }

            /// <param name="guildAmount">لیست کد های صنف و مبالغ هر بند سند که حساب های مربوطه درگیر میشوند</param>
            public Builder SetGuildAmount(List<GuildAmount> guildAmount)
            {
                this.guildAmount = guildAmount;
                return this;
            }
            public decimal? GetCustomerAmount()
            {
                return customerAmount;
            }

            /// <param name="customerAmount">مبلغ مربوط به بند سند حساب نقش مشتری</param>
            public Builder SetCustomerAmount(decimal customerAmount)
            {
                this.customerAmount = customerAmount;
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

            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public TransferFromOwnAccountsVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new TransferFromOwnAccountsVo(this);
            }
        }
    }
}
