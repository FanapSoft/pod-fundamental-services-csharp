using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class TransferByInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string GuildCode { get; }
        public decimal? Amount { get; }
        public long? InvoiceId  { get; }
        public string Description { get; }
        public string CurrencyCode { get; }
        public string Wallet { get; }
        public string UniqueId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public TransferByInvoiceVo(Builder builder)
        {

            GuildCode = builder.GetGuildCode();
            Amount = builder.GetAmount();
            InvoiceId = builder.GetInvoiceId();
            CurrencyCode = builder.GetCurrencyCode();
            Description = builder.GetDescription();
            Wallet = builder.GetWallet();
            UniqueId = builder.GetUniqueId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private string guildCode;

            [Required] private decimal? amount;

            [Required] private long? invoiceId;
            private string currencyCode;

            [Required] private string description;

            [Required] private string wallet;
            private string uniqueId;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetGuildCode()
            {
                return guildCode;
            }

            /// <param name="guildCode">لیست کد های صنف هر بند سند که حساب های مربوطه درگیر میشوند</param>
            public Builder SetGuildCode(string guildCode)
            {
                this.guildCode = guildCode;
                return this;
            }

            public decimal? GetAmount()
            {
                return amount;
            }

            /// <param name="amount">لیست مبالغ بند های سند</param>
            public Builder SetAmount(decimal amount)
            {
                this.amount = amount;
                return this;
            }
            public long? GetInvoiceId ()
            {
                return invoiceId;
            }

            /// <param name="invoiceId">شناسه کاربر فاکتور</param>
            public Builder SetInvoiceId (long invoiceId)
            {
                this.invoiceId = invoiceId;
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

            public TransferByInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new TransferByInvoiceVo(this);
            }
        }
    }
}
