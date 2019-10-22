using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;


namespace POD_Billing.Model.ValueObject
{
    public class GetInvoiceListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Size { get; }
        public int? Offset { get; }
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
        public long[] IssuerId { get; }
        public string Query { get; }
        public long? FirstId { get; }
        public long? LastId { get; }
        public string[] ProductIdList { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetInvoiceListVo(Builder builder)
        {
            Size = builder.GetSize();
            Offset = builder.GetOffset();
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
            IssuerId = builder.GetIssuerId();
            Query = builder.GetQuery();
            FirstId = builder.GetFirstId();
            LastId = builder.GetLastId();
            ProductIdList = builder.GetProductIdList();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private int? size;

            [Required]
            private int? offset;
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
            private long[] issuerId;
            private string query;
            private long? firstId;
            private long? lastId;
            private string[] productIdList;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public int? GetSize()
            {
                return size;
            }

            public Builder SetSize(int size)
            {
                this.size = size;
                return this;
            }
            public int? GetOffset()
            {
                return offset;
            }

            /// <param name="offset">حد پایین خروجی</param>
            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }
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

            public Builder SetBillNumber(string billNumber)
            {
                this.billNumber = billNumber;
                return this;
            }
            public string GetUniqueNumber()
            {
                return uniqueNumber;
            }

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

            public Builder SetFromDate(string fromDate)
            {
                this.fromDate = fromDate;
                return this;
            }
            public Builder SetFromDate(DateTime fromDate)
            {
                this.fromDate = fromDate.ToShamsiDateTime();
                return this;
            } 
            public string GetToDate()
            {
                return toDate;
            }

            public Builder SetToDate(string toDate)
            {
                this.toDate = toDate;
                return this;
            }
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
                this.guildCode = guildCode;
                return this;
            }

            public string GetReferenceNumber()
            {
                return referenceNumber;
            }

            public Builder SetReferenceNumber(string referenceNumber)
            {
                this.referenceNumber = referenceNumber;
                return this;
            }

            public long? GetUserId()
            {
                return userId;
            }

            public Builder SetUserId(long userId)
            {
                this.userId = userId;
                return this;
            }
            public long[] GetIssuerId()
            {
                return issuerId;
            }

            public Builder SetIssuerId(long[] issuerId)
            {
                this.issuerId = issuerId;
                return this;
            }
            public string GetQuery()
            {
                return query;
            }

            public Builder SetQuery(string query)
            {
                this.query = query;
                return this;
            }
            public long? GetFirstId()
            {
                return firstId;
            }

            public Builder SetFirstId(long firstId)
            {
                this.firstId = firstId;
                return this;
            }

            public long? GetLastId()
            {
                return lastId;
            }

            public Builder SetLastId(long lastId)
            {
                this.lastId = lastId;
                return this;
            }
            public string[] GetProductIdList()
            {
                return productIdList;
            }

            public Builder SetProductIdList(string[] productIdList)
            {
                this.productIdList = productIdList;
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

            public GetInvoiceListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetInvoiceListVo(this);
            }
        }
    }
}
