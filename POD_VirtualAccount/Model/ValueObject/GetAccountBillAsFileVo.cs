using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class GetAccountBillAsFileVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string DateFrom { get; }
        public string DateTo { get; }
        public string Description { get; }
        public decimal? AmountFrom { get; }
        public decimal? AmountTo { get; }
        public bool? Block { get; }
        public string GuildCode { get; }
        public string CurrencyCode { get; }
        public bool? Debtor { get; }
        public int? LastNRows { get; }
        public string CallbackUrl { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetAccountBillAsFileVo(Builder builder)
        {
            DateFrom = builder.GetDateFrom();
            DateTo = builder.GetDateTo();
            Description = builder.GetDescription();
            AmountFrom = builder.GetAmountFrom();
            AmountTo = builder.GetAmountTo();
            Block = builder.GetBlock();
            GuildCode = builder.GetGuildCode();
            CurrencyCode = builder.GetCurrencyCode();
            Debtor = builder.GetDebtor();
            LastNRows = builder.GetLastNRows();
            CallbackUrl = builder.GetCallbackUrl();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string dateFrom;
            private string dateTo;
            private string description;
            private decimal? amountFrom;
            private decimal? amountTo;
            private bool? block;
            private string guildCode;
            private string currencyCode;
            private bool? debtor;
            [Required] private int? lastNRows;
            [Required] private string callbackUrl;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetDateFrom()
            {
                return dateFrom;
            }

            /// <param name="dateFrom">حد پایین تاریخ صورتحساب</param>
            public Builder SetDateFrom(string dateFrom)
            {
                this.dateFrom = dateFrom;
                return this;
            }

            /// <param name="dateFrom">حد پایین تاریخ صورتحساب</param>
            public Builder SetDateFrom(DateTime dateFrom)
            {
                this.dateFrom = dateFrom.ToShamsiDate();
                return this;
            }

            public string GetDateTo()
            {
                return dateTo;
            }

            /// <param name="dateTo">حد بالای تاریخ صورتحساب</param>
            public Builder SetDateTo(string dateTo)
            {
                this.dateTo = dateTo;
                return this;
            }

            /// <param name="dateTo">حد بالای تاریخ صورتحساب</param>
            public Builder SetDateTo(DateTime dateTo)
            {
                this.dateTo = dateTo.ToShamsiDate();
                return this;
            }
            public string GetDescription()
            {
                return description;
            }

            /// <param name="description">Like فیلتر روی توضیحات بند سند به صورت</param>
            public Builder SetDescription(string description)
            {
                this.description = description;
                return this;
            }
            public decimal? GetAmountFrom()
            {
                return amountFrom;
            }

            /// <param name="amountFrom">حد پایین مبلغ بند</param>
            public Builder SetAmountFrom(decimal amountFrom)
            {
                this.amountFrom = amountFrom;
                return this;
            }

            public decimal? GetAmountTo()
            {
                return amountTo;
            }

            /// <param name="amountTo">حد بالای مبلغ بند</param>
            public Builder SetAmountTo(decimal amountTo)
            {
                this.amountTo = amountTo;
                return this;
            }
            public bool? GetBlock()
            {
                return block;
            }

            /// <param name="block">فیلتر روی حساب های مسدودی یا غیر مسدودی</param>
            public Builder SetBlock(bool block)
            {
                this.block = block;
                return this;
            }
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
            public bool? GetDebtor()
            {
                return debtor;
            }

            /// <param name="debtor">بدهکار / بستانکار</param>
            public Builder SetDebtor(bool debtor)
            {
                this.debtor = debtor;
                return this;
            }
            public int? GetLastNRows()
            {
                return lastNRows;
            }

            /// <param name="lastNRows">ردیف آخر صورتحساب n</param>
            public Builder SetLastNRows(int lastNRows)
            {
                this.lastNRows = lastNRows;
                return this;
            }

            public string GetCallbackUrl()
            {
                return callbackUrl;
            }

            /// <param name="callbackUrl">آدرس فراخوانی پس از اتمام تولید گزارش</param>

            public Builder SetCallbackUrl(string callbackUrl)
            {
                this.callbackUrl = callbackUrl;
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

            public GetAccountBillAsFileVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetAccountBillAsFileVo(this);
            }
        }
    }
}
