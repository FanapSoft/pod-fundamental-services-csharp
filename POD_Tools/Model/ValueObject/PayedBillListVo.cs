using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Model.ValueObject;

namespace POD_Tools.Model.ValueObject
{
    public class PayedBillListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string BillId { get; }
        public string PaymentId { get; }
        public long? Id { get; }
        public string FromDate { get; }
        public string ToDate { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public PayedBillListVo(Builder builder)
        {
            BillId = builder.GetBillId();
            PaymentId = builder.GetPaymentId();
            Id = builder.GetId();
            FromDate = builder.GetFromDate();
            ToDate = builder.GetToDate();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [RegularExpression(RegexFormat.BillId)]
            private string billId;

            [RegularExpression(RegexFormat.PaymentId)]
            private string paymentId;
            private long? id;
            private string fromDate;
            private string toDate;

            [Required]
            private int? offset;

            [Required]
            private int? size;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetBillId()
            {
                return billId;
            }

            /// <param name="billId">شماره قبض</param>
            public Builder SetBillId(string billId)
            {
                this.billId = billId;
                return this;
            }

            public string GetPaymentId()
            {
                return paymentId;
            }

            /// <param name="paymentId">شناسه پرداخت</param>
            public Builder SetPaymentId(string paymentId)
            {
                this.paymentId = paymentId;
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
                this.fromDate = fromDate.ToShamsiDate();
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
                this.toDate = toDate.ToShamsiDate();
                return this;
            }

            public int? GetOffset()
            {
                return offset;
            }


            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }

            public int? GetSize()
            {
                return size;
            }

            public Builder SetSize(int size)
            {
                this.size = size;
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

            public PayedBillListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PayedBillListVo(this);
            }
        }
    }
}
