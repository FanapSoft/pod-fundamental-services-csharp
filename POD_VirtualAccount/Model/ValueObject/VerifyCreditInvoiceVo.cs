using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class VerifyCreditInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string BillNumber { get; }
        public long? Id { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }
        public VerifyCreditInvoiceVo(Builder builder)
        {
            BillNumber = builder.GetBillNumber();
            Id = builder.GetId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }
        public class Builder
        {
            [Required]
            private string billNumber;
            private long? id;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetBillNumber()
            {
                return billNumber;
            }

            /// <param name="billNumber">شماره قبض فاکتور خرید شارژ</param>
            public Builder SetBillNumber(string billNumber)
            {
                this.billNumber = billNumber;
                return this;
            }

            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه فاکتور خرید شارژ</param>
            public Builder SetId(long id)
            {
                this.id = id;
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

            public VerifyCreditInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new VerifyCreditInvoiceVo(this);
            }
        }
    }
}
