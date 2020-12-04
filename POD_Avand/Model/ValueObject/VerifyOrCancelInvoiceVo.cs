using POD_Base_Service.Model.ValueObject;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using System.ComponentModel.DataAnnotations;

namespace POD_Avand.Model.ValueObject
{
    public class VerifyOrCancelInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? InvoiceId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public VerifyOrCancelInvoiceVo(Builder builder)
        {
            InvoiceId = builder.GetInvoiceId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long? invoiceId;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetInvoiceId()
            {
                return invoiceId;
            }

            /// <param name="invoiceId">شناسه فاکتور</param>
            public Builder SetInvoiceId(long invoiceId)
            {
                this.invoiceId = invoiceId;
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

            public VerifyOrCancelInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new VerifyOrCancelInvoiceVo(this);
            }
        }
    }
}
