using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class PayInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? InvoiceId { get; }

        public PayInvoiceVo(Builder builder)
        {
            InvoiceId = builder.GetInvoiceId();
        }

        public class Builder
        {
            [Required] private long? invoiceId;

            public long? GetInvoiceId()
            {
                return invoiceId;
            }

            public Builder SetInvoiceId(long invoiceId)
            {
                this.invoiceId = invoiceId;
                return this;
            }

            public PayInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PayInvoiceVo(this);
            }
        }
    }
}
