using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace POD_Billing.Model.ValueObject
{
    public class GetInvoiceListAsFileVo
    {
        public static Builder ConcreteBuilder => new Builder();

        public long? Id { get; }
        public string BillNumber { get; }
        public string UniqueNumber { get; }
        public long? TrackerId { get; }
        public string FromDate { get; }
        public string ToDate { get; }
        public bool? IsCanceled { get; }
        public bool? IsPayed { get; }
        public bool? IsClosed { get; }
        public bool? IsWaiting { get; }
        public string GuildCode { get; }
        public string ReferenceNumber { get; }
        public long? UserId { get; }
        public string Query { get; }
        public long[] ProductIdList { get; }
        public int? LastNRows { get; }
        public string CallbackUrl { get; }

        public GetInvoiceListAsFileVo(Builder builder)
        {

            Id = builder.GetId();
            BillNumber = builder.GetBillNumber();
            UniqueNumber = builder.GetUniqueNumber();
            TrackerId = builder.GetTrackerId();
            FromDate = builder.GetFromDate();
            ToDate = builder.GetToDate();
            IsCanceled = builder.GetIsCanceled();
            IsPayed = builder.GetIsPayed();
            IsClosed = builder.GetIsClosed();
            IsWaiting = builder.GetIsWaiting();
            GuildCode = builder.GetGuildCode();
            ReferenceNumber = builder.GetReferenceNumber();
            UserId = builder.GetUserId();
            Query = builder.GetQuery();
            ProductIdList = builder.GetProductIdList();
            LastNRows = builder.GetLastNRows();
            CallbackUrl = builder.GetCallbackUrl();
        }

        public class Builder
        {
            private long? id;
            private string billNumber;
            private string uniqueNumber;
            private long? trackerId;

            [RegularExpression(RegexFormat.ShamsiDateTime)]
            private string fromDate;

            [RegularExpression(RegexFormat.ShamsiDateTime)]
            private string toDate;
            private bool? isCanceled;
            private bool? isPayed;
            private bool? isClosed;
            private bool? isWaiting;
            private string guildCode;
            private string referenceNumber;
            private long? userId;
            private string query;
            private long[] productIdList;
            private int? lastNRows;
            [Url] private string callbackUrl;

            public long? GetId()
            {
                return id;
            }

            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }

            public string GetBillNumber()
            {
                return billNumber;
            }

            /// <param name="billNumber">شماره قبض که به تنهایی با آن می توان جستجو نمود</param>
            public Builder SetBillNumber(string billNumber)
            {
                this.billNumber = billNumber.Trim();
                return this;
            }
            public string GetUniqueNumber()
            {
                return uniqueNumber;
            }

            /// <param name="uniqueNumber">شماره کد شده ی قبض که به تنهایی با آن می توان جستجو نمود</param>
            public Builder SetUniqueNumber(string uniqueNumber)
            {
                this.uniqueNumber = uniqueNumber;
                return this;
            }
            public long? GetTrackerId()
            {
                return trackerId;
            }

            public Builder SetTrackerId(long trackerId)
            {
                this.trackerId = trackerId;
                return this;
            }

            public string GetFromDate()
            {
                return fromDate;
            }


            /// <param name="fromDate">بازه تاریخ شمسی ابتدای صدور فاکتور</param>
            public Builder SetFromDate(string fromDate)
            {
                this.fromDate = fromDate.Trim();
                return this;
            }
            /// <param name="fromDate">بازه تاریخ میلادی ابتدای صدور فاکتور</param>
            public Builder SetFromDate(DateTime fromDate)
            {
                this.fromDate = fromDate.ToShamsiDateTime();
                return this;
            }
            public string GetToDate()
            {
                return toDate;
            }

            /// <param name="toDate">بازه تاریخ شمسی انتهای صدور فاکتور</param>
            public Builder SetToDate(string toDate)
            {
                this.toDate = toDate.Trim();
                return this;
            }
            /// <param name="toDate">بازه تاریخ میلادی انتهای صدور فاکتور</param>
            public Builder SetToDate(DateTime toDate)
            {
                this.toDate = toDate.ToShamsiDateTime();
                return this;
            }
            public bool? GetIsCanceled()
            {
                return isCanceled;
            }

            public Builder SetIsCanceled(bool isCanceled)
            {
                this.isCanceled = isCanceled;
                return this;
            }

            public bool? GetIsPayed()
            {
                return isPayed;
            }

            /// <param name="isPayed">وضعیت پرداختی فاکتور</param>
            public Builder SetIsPayed(bool isPayed)
            {
                this.isPayed = isPayed;
                return this;
            }

            public bool? GetIsClosed()
            {
                return isClosed;
            }

            public Builder SetIsClosed(bool isClosed)
            {
                this.isClosed = isClosed;
                return this;
            }

            public bool? GetIsWaiting()
            {
                return isWaiting;
            }

            /// <param name="isWaiting">وضعیت در انتظار پرداخت بودن فاکتور</param>
            public Builder SetIsWaiting(bool isWaiting)
            {
                this.isWaiting = isWaiting;
                return this;
            }

            public string GetGuildCode()
            {
                return guildCode;
            }

            public Builder SetGuildCode(string guildCode)
            {
                this.guildCode = guildCode.Trim();
                return this;
            }

            public string GetReferenceNumber()
            {
                return referenceNumber;
            }

            /// <param name="referenceNumber">شماره ارجاع ثبت شده در فاکتور</param>
            public Builder SetReferenceNumber(string referenceNumber)
            {
                this.referenceNumber = referenceNumber.Trim();
                return this;
            }

            public long? GetUserId()
            {
                return userId;
            }

            /// <param name="userId">شناسه کاربری مشتری فاکتور</param>
            public Builder SetUserId(long userId)
            {
                this.userId = userId;
                return this;
            }

            public string GetQuery()
            {
                return query;
            }


            /// <param name="query">عبارت دلخواه مورد جستجو</param>
            public Builder SetQuery(string query)
            {
                this.query = query;
                return this;
            }

            public long[] GetProductIdList()
            {
                return productIdList;
            }

            public Builder SetProductIdList(long[] productIdList)
            {
                this.productIdList = productIdList;
                return this;
            }

            public int? GetLastNRows()
            {
                return lastNRows;
            }


            /// <param name="lastNRows">تعداد ردیف های مورد نظر در خروجی فایل</param>
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
                this.callbackUrl = callbackUrl.Trim();
                return this;
            }

            public GetInvoiceListAsFileVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();
                if (lastNRows == null && string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
                {
                    hasErrorFields.Add(new KeyValuePair<string, string>("lastNRows,fromDate,toDate", "One of this Builder fields is required."));
                }

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetInvoiceListAsFileVo(this);
            }
        }
    }
}
