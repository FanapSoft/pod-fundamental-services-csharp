using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class AddAutoSettlementVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string FirstName { get; }
        public string LastName { get; }
        public string Sheba { get; }
        public string GuildCode { get; }
        public string CurrencyCode { get; }
        public bool? Instant { get; }
        public string Ott { get; }

        public AddAutoSettlementVo(Builder builder)
        {
            FirstName = builder.GetFirstName();
            LastName = builder.GetLastName();
            Sheba = builder.GetSheba();
            GuildCode = builder.GetGuildCode();
            CurrencyCode = builder.GetCurrencyCode();
            Instant = builder.GetInstant();
            Ott = builder.GetOtt();
        }

        public class Builder
        {
            private string firstName;
            private string lastName;

            [RegularExpression(RegexFormat.Sheba)]
            private string sheba;

            [Required]
            private string guildCode;
            private string currencyCode;
            private bool? instant;

            [Required]
            private string ott;

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

            /// <param name="sheba">شماره شبا حسابی که تسویه به آن واریز می گردد</param>
            public Builder SetSheba(string sheba)
            {
                this.sheba = sheba;
                return this;
            }
            public string GetGuildCode()
            {
                return guildCode;
            }

            /// <param name="guildCode">کد صنف</param>
            public Builder SetGuildCode(string guildCode)
            {
                this.guildCode = guildCode;
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
            public bool? GetInstant()
            {
                return instant;
            }
            
            /// <param name="instant">
            /// بودن تسویه خودکار فعال می شود false در صورت
            /// بودن تسویه خودکار فوری  فعال می شود true در صورت
            ///</param>
            public Builder SetInstant(bool instant)
            {
                this.instant = instant;
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

            public AddAutoSettlementVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AddAutoSettlementVo(this);
            }
        }
    }
}
