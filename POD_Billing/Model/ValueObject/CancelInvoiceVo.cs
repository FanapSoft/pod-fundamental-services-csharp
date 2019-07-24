using POD_Base_Service.Exception;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;

namespace POD_Billing.Model.ValueObject
{
    public class CancelInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }

        public CancelInvoiceVo(Builder builder)
        {
            Id = builder.GetId();
        }

        public class Builder
        {
            [Required]
            private long? id;
           
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
