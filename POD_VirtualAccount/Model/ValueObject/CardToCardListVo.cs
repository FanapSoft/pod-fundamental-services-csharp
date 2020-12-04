using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_VirtualAccount.Base.Enum;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class CardToCardListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Offset { get; }
        public int? Size { get; }
        public bool? CanEdit { get; }
        public bool? Canceled { get; }
        public CardStatusCode? StatusCode { get; }
        public CauseCode? CauseCode { get; }
        public string CauseId { get; }
        public string FromDate { get; }
        public string ToDate { get; }
        public decimal? FromAmount { get; }
        public decimal? ToAmount { get; }
        public string UniqueId { get; }
        public string ReferenceNumber { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public CardToCardListVo(Builder builder)
        {
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            CanEdit = builder.GetCanEdit();
            Canceled = builder.GetCanceled();
            StatusCode = builder.GetStatusCode();
            CauseCode = builder.GetCauseCode();
            CauseId = builder.GetCauseId();
            FromDate = builder.GetFromDate();
            ToDate = builder.GetToDate();
            FromAmount = builder.GetFromAmount();
            ToAmount = builder.GetToAmount();
            UniqueId = builder.GetUniqueId();
            ReferenceNumber = builder.GetReferenceNumber();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private int? offset;
            [Required] private int? size;
            private bool? canEdit;
            private bool? canceled;
            private CardStatusCode? statusCode;
            private CauseCode? causeCode;
            private string causeId;
            private string fromDate;
            private string toDate;
            private decimal? fromAmount;
            private decimal? toAmount;
            private string uniqueId;
            private string referenceNumber;
            [Required] private InternalServiceCallVo serviceCallParameters;

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
            public bool? GetCanEdit()
            {
                return canEdit;
            }

            /// <param name="canEdit">نمایش / عدم نمایش کارت به کارت هایی که امکان ویرایش دارند</param>
            public Builder SetCanEdit(bool canEdit)
            {
                this.canEdit = canEdit;
                return this;
            }

            public bool? GetCanceled()
            {
                return canceled;
            }

            /// <param name="canceled">نمایش / عدم نمایش کارت به کارت هایی که توسط مدیر لغو شده اند</param>
            public Builder SetCanceled(bool canceled)
            {
                this.canceled = canceled;
                return this;
            }
            public CardStatusCode? GetStatusCode()
            {
                return statusCode;
            }

            /// <param name="statusCode">کد وضعیت کارت به کارت</param>
            public Builder SetStatusCode(CardStatusCode statusCode)
            {
                this.statusCode = statusCode;
                return this;
            }
            public CauseCode? GetCauseCode()
            {
                return causeCode;
            }

            /// <param name="causeCode ">کد منشا ایجاد کننده کارت به کارت</param>
            public Builder SetCauseCode(CauseCode causeCode)
            {
                this.causeCode = causeCode;
                return this;
            }

            public string GetCauseId()
            {
                return causeId;
            }

            /// <param name="causeId ">شناسه منشا ایجاد کننده کارت به کارت</param>
            public Builder SetCauseId(string causeId)
            {
                this.causeId = causeId;
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

            public string GetReferenceNumber()
            {
                return referenceNumber;
            }

            /// <param name="referenceNumber">شماره مرجع</param>
            public Builder SetReferenceNumber(string referenceNumber)
            {
                this.referenceNumber = referenceNumber;
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

            public CardToCardListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new CardToCardListVo(this);
            }
        }
    }
}
