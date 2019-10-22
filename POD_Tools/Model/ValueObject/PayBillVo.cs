using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Tools.Model.ValueObject
{
    public class PayBillVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string BillId { get; }
        public string PaymentId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public PayBillVo(Builder builder)
        {
            BillId = builder.GetBillId();
            PaymentId = builder.GetPaymentId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [RegularExpression(RegexFormat.BillId)]
            [Required]
            private string billId;

            [RegularExpression(RegexFormat.PaymentId)]
            [Required]
            private string paymentId;

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

            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public PayBillVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PayBillVo(this);
            }
        }
    }
}
