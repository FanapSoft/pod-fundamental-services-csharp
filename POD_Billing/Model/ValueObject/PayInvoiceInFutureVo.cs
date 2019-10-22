using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.CustomAttribute;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject
{
    public class PayInvoiceInFutureVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? InvoiceId { get; }
        public string Date { get; }
        public string GuildCode { get; }
        public string Wallet { get; }
        public string Ott { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public PayInvoiceInFutureVo(Builder builder)
        {
            InvoiceId = builder.GetInvoiceId();
            Date = builder.GetDate();
            GuildCode = builder.GetGuildCode();
            Wallet = builder.GetWallet();
            Ott = builder.GetOtt();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long? invoiceId;

            [RegularExpression(RegexFormat.ShamsiDate)]
            [Required]
            private string date;

            [RequiredIf(nameof(wallet))]
            private string guildCode;
            private string wallet;

            [Required]
            private string ott;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetInvoiceId()
            {
                return invoiceId;
            }

            /// <param name="invoiceId">شناسه فاکتور</param>
            public Builder SetInvoiceId(long invoiceId)
            {
                this.invoiceId = invoiceId;
                return this;
            }

            public string GetDate()
            {
                return date;
            }

            public Builder SetDate(string date)
            {
                this.date = date;
                return this;
            }

            /// <param name="date"> yyyy/mm/dd تاریخ شمسی سررسید</param>
            public Builder SetDate(DateTime date)
            {
                this.date = date.ToShamsiDate();
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

            public PayInvoiceInFutureVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();
  
                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PayInvoiceInFutureVo(this);
            }
        }
    }
}
