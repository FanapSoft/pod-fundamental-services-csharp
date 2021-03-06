﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class TransferToContactListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Offset { get; }
        public int? Size { get; }
        public long? ContactId { get; }
        public decimal? FromAmount { get; }
        public decimal? ToAmount { get; }
        public string CurrencyCode { get; }
        public string UniqueId { get; }
        public string FromDate { get; }
        public string ToDate { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public TransferToContactListVo(Builder builder)
        {
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            ContactId = builder.GetContactId();
            FromAmount = builder.GetFromAmount();
            ToAmount = builder.GetToAmount();
            CurrencyCode = builder.GetCurrencyCode();
            UniqueId = builder.GetUniqueId();
            FromDate = builder.GetFromDate();
            ToDate = builder.GetToDate();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private int? offset;

            [Required] private int? size;
            private long? contactId;
            private decimal? fromAmount;
            private decimal? toAmount;
            private string uniqueId;
            private string currencyCode;
            private string fromDate;
            private string toDate;

            [Required] private InternalServiceCallVo serviceCallParameters;

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

            public string GetUniqueId()
            {
                return uniqueId;
            }

            /// <param name="uniqueId">شناسه واریز یکتا</param>
            public Builder SetUniqueId(string uniqueId)
            {
                this.uniqueId = uniqueId;
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

            public int? GetOffset()
            {
                return offset;
            }

            /// <param name="offset">فاصله از مبداء</param>
            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }

            public int? GetSize()
            {
                return size;
            }

            /// <param name="size">اندازه خروجی</param>

            public Builder SetSize(int size)
            {
                this.size = size;
                return this;
            }

            public decimal? GetFromAmount()
            {
                return fromAmount;
            }

            /// <param name="fromAmount">از مبلغ</param>
            public Builder SetFromAmount(decimal fromAmount)
            {
                this.fromAmount = fromAmount;
                return this;
            }

            public decimal? GetToAmount()
            {
                return toAmount;
            }

            /// <param name="toAmount">تا مبلغ</param>
            public Builder SetToAmount(decimal toAmount)
            {
                this.toAmount = toAmount;
                return this;
            }

            public string GetFromDate()
            {
                return fromDate;
            }

            /// <param name="fromDate">از تاریخ</param>
            public Builder SetFromDate(string fromDate)
            {
                this.fromDate = fromDate;
                return this;
            }

            /// <param name="fromDate">از تاریخ</param>
            public Builder SetFromDate(DateTime fromDate)
            {
                this.fromDate = fromDate.ToShamsiDate();
                return this;
            }

            public string GetToDate()
            {
                return toDate;
            }

            /// <param name="toDate">تا تاریخ</param>
            public Builder SetToDate(string toDate)
            {
                this.toDate = toDate;
                return this;
            }

            /// <param name="toDate">تا تاریخ</param>
            public Builder SetToDate(DateTime toDate)
            {
                this.toDate = toDate.ToShamsiDate();
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

            public TransferToContactListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new TransferToContactListVo(this);
            }
        }
    }
}
