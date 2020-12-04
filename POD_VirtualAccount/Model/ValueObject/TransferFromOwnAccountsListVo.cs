using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class TransferFromOwnAccountsListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string UniqueId { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public string FromDate { get; }
        public string ToDate { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public TransferFromOwnAccountsListVo(Builder builder)
        {
            UniqueId = builder.GetUniqueId();
            FromDate = builder.GetFromDate();
            ToDate = builder.GetToDate();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }
        public class Builder
        {
            private string uniqueId;
            private string fromDate;
            private string toDate;

            [Required]
            private int? offset;

            [Required]
            private int? size;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

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

            public TransferFromOwnAccountsListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new TransferFromOwnAccountsListVo(this);
            }
        }
    }
}
