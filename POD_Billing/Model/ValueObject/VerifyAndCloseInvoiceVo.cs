using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class VerifyAndCloseInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
       
        public VerifyAndCloseInvoiceVo(Builder builder)
        {
            Id = builder.GetId();
        }

        public class Builder
        {
            [Required] private long? id;
         
            public long? GetId()
            {
                return id;
            }

            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }

            public VerifyAndCloseInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new VerifyAndCloseInvoiceVo(this);
            }
        }
    }
}
