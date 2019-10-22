using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.CustomAttribute;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject
{
    public class VerifyInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public string BillNumber { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public VerifyInvoiceVo(Builder builder)
        {
            Id = builder.GetId();
            BillNumber = builder.GetBillNumber();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [RequiredIf(nameof(billNumber))]
            private long? id;
            private string billNumber;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetId()
            {
                return id;
            }

            // <summary> شناسه فاکتور </summary>
            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }

            public string GetBillNumber()
            {
                return billNumber;
            }

            // <summary> شماره قبض </summary>
            public Builder SetBillNumber(string billNumber)
            {
                this.billNumber = billNumber;
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

            public VerifyInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new VerifyInvoiceVo(this);
            }
        }
    }
}
