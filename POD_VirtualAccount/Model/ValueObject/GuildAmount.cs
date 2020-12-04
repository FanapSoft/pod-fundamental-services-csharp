using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class GuildAmount
    {
        public static Builder ConcreteBuilder => new Builder();
        public string GuildCode { get; }
        public decimal? Amount { get; }

        public GuildAmount(Builder builder)
        {
            GuildCode = builder.GetGuildCode();
            Amount = builder.GetAmount();
        }

        public class Builder
        {
            [Required]
            private string guildCode;

            [Required]
            private decimal? amount;

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

            public GuildAmount Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GuildAmount(this);
            }
        }
    }
}
