using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject.Settlement
{
    public class RequestWalletSettlementVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Wallet { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Sheba { get; }
        public double? Amount { get; }
        public string CurrencyCode { get; }
        public string UniqueId { get; }
        public string Description { get; }
        public string Ott { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public RequestWalletSettlementVo(Builder builder)
        {
            Wallet = builder.Getwallet();
            FirstName = builder.GetFirstName();
            LastName = builder.GetLastName();
            Sheba = builder.GetSheba();
            Amount = builder.GetAmount();
            CurrencyCode = builder.GetCurrencyCode();
            UniqueId = builder.GetUniqueId();
            Description = builder.GetDescription();
            Ott = builder.GetOtt();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string wallet;
            private string firstName;
            private string lastName;

            [RegularExpression(RegexFormat.Sheba)]
            private string sheba;

            [Required]
            private double? amount;
            private string currencyCode;
            private string uniqueId;
            private string description;

            [Required]
            private string ott;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string Getwallet()
            {
                return wallet;
            }

            /// <param name="wallet">کد کیف پول</param>
            public Builder SetWallet(string wallet)
            {
                this.wallet = wallet;
                return this;
            }
            public string GetFirstName()
            {
                return firstName;
            }

            /// <param name="firstName">نام صاحب حسابی که تسویه به آن واریز می گردد</param>
            public Builder SetFirstName(string firstName)
            {
                this.firstName = firstName;
                return this;
            }
            public string GetLastName()
            {
                return lastName;
            }

            /// <param name="lastName">نام خانوادگی صاحب حسابی که تسویه به آن واریز می گردد</param>
            public Builder SetLastName(string lastName)
            {
                this.lastName = lastName;
                return this;
            }
            public string GetSheba()
            {
                return sheba;
            }

            /// <param name="sheba">
            /// شماره شبا حسابی که تسویه به آن واریز می گردد
            /// اگر این مقدار داده نشود همان مقدار ثبت شده در کسب و کار استفاده میشود
            /// </param>
            public Builder SetSheba(string sheba)
            {
                this.sheba = sheba;
                return this;
            }
            public double? GetAmount()
            {
                return amount;
            }

            /// <param name="amount">مبلغ برداشت</param>
            public Builder SetAmount(double amount)
            {
                this.amount = amount;
                return this;
            }
            public string GetCurrencyCode()
            {
                return currencyCode;
            }
            public Builder SetCurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode;
                return this;
            }
            public string GetUniqueId()
            {
                return uniqueId;
            }

            /// <param name="uniqueId">ارسال شناسه یکتا و دلخواه به منظور جستجو در لیست</param>
            public Builder SetUniqueId(string uniqueId)
            {
                this.uniqueId = uniqueId;
                return this;
            }
            public string GetDescription()
            {
                return description;
            }

            /// <param name="description">شرح دلخواه</param>
            public Builder SetDescription(string description)
            {
                this.description = description;
                return this;
            }
            public string GetOtt()
            {
                return ott;
            }
            public Builder SetOtt(string ott)
            {
                this.ott = ott;
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

            public RequestWalletSettlementVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new RequestWalletSettlementVo(this);
            }
        }
    }
}
