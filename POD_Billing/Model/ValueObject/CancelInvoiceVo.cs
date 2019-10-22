using POD_Base_Service.Exception;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject
{
    public class CancelInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public CancelInvoiceVo(Builder builder)
        {
            Id = builder.GetId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long? id;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetId()
            {
                return id;
            }

            /// <param name="id"> شناسه فاکتو</param>
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

            public CancelInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new CancelInvoiceVo(this);
            }
        }
    }
}
