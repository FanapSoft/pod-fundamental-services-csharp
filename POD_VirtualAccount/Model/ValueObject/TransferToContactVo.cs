using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class TransferToContactVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? ContactId { get; }
        public decimal? Amount { get; }
        public string Wallet { get; }
        public string CurrencyCode { get; }
        public string Description { get; }
        public string UniqueId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public TransferToContactVo(Builder builder)
        {
            ContactId = builder.GetContactId();
            Amount = builder.GetAmount();
            CurrencyCode = builder.GetCurrencyCode();
            Description = builder.GetDescription();
            Wallet = builder.GetWallet();
            UniqueId = builder.GetUniqueId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }
        public class Builder
        {
            [Required]
            private long? contactId;

            [Required]
            private decimal? amount;
            private string wallet;
            private string currencyCode;
            private string description;
            private string uniqueId;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetContactId()
            {
                return contactId;
            }

            /// <param name="contactId">شناسه مخاطب مقصد</param>
            public Builder SetContactId(long contactId)
            {
                this.contactId = contactId;
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

            public TransferToContactVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new TransferToContactVo(this);
            }
        }
    }
}
