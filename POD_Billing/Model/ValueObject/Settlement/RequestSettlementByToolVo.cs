using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Billing.Base.Enum;

namespace POD_Billing.Model.ValueObject.Settlement
{
    public class RequestSettlementByToolVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string FirstName { get; }
        public string LastName { get; }
        public ToolCode? ToolCode { get; }
        public string ToolId { get; }
        public double? Amount { get; }
        public string GuildCode { get; }
        public string CurrencyCode { get; }
        public string UniqueId { get; }
        public string Description { get; }
        public string Ott { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public RequestSettlementByToolVo(Builder builder)
        {
            FirstName = builder.GetFirstName();
            LastName = builder.GetLastName();
            ToolCode = builder.GetToolCode();
            ToolId = builder.GetToolId();
            Amount = builder.GetAmount();
            GuildCode = builder.GetGuildCode();
            CurrencyCode = builder.GetCurrencyCode();
            UniqueId = builder.GetUniqueId();
            Description = builder.GetDescription();
            Ott = builder.GetOtt();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string firstName;
            private string lastName;

            [Required]
            private ToolCode? toolCode;

            [Required]
            private string toolId;

            [Required]
            private double? amount;

            [Required]
            private string guildCode;
            private string currencyCode;
            private string uniqueId;
            private string description;

            [Required]
            private string ott;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

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
            public ToolCode? GetToolCode()
            {
                return toolCode;
            }

            public Builder SetToolCode(ToolCode toolCode)
            {
                this.toolCode = toolCode;
                return this;
            }
            public string GetToolId()
            {
                return toolId;
            }

            /// <param name="toolId">  در صورتی که انتقال از طریق کارت را انتخاب نموده اید،شماره کارت مقصد را وارد نمایید, در غیر این صورت شماره شبا را وارد نمایید.</param>
            public Builder SetToolId(string toolId)
            {
                this.toolId = toolId;
                return this;
            }
            public double? GetAmount()
            {
                return amount;
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

            public RequestSettlementByToolVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new RequestSettlementByToolVo(this);
            }
        }
    }
}
