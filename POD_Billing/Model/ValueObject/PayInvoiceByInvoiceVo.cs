using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject
{
    public class PayInvoiceByInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? CreditorInvoiceId { get; }
        public long? DebtorInvoiceId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public PayInvoiceByInvoiceVo(Builder builder)
        {
            CreditorInvoiceId = builder.GetCreditorInvoiceId();
            DebtorInvoiceId = builder.GetDebtorInvoiceId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? creditorInvoiceId;

            [Required] private long? debtorInvoiceId;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetCreditorInvoiceId()
            {
                return creditorInvoiceId;
            }

            public Builder SetCreditorInvoiceId(long creditorInvoiceId)
            {
                this.creditorInvoiceId = creditorInvoiceId;
                return this;
            }

            public long? GetDebtorInvoiceId()
            {
                return debtorInvoiceId;
            }

            public Builder SetDebtorInvoiceId(long debtorInvoiceId)
            {
                this.debtorInvoiceId = debtorInvoiceId;
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

            public PayInvoiceByInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PayInvoiceByInvoiceVo(this);
            }
        }
    }
}
