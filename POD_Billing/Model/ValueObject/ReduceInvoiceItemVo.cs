using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class ReduceInvoiceItemVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public List<ReduceInvoiceSubItemVo> ReduceInvoiceItemVOs { get; }

        public ReduceInvoiceItemVo(Builder builder)
        {
            Id = builder.GetId();
            ReduceInvoiceItemVOs = builder.GetReduceInvoiceItemVOs();
        }

        public class Builder
        {
            [Required]
            private long? id;

            [Required]
            private List<ReduceInvoiceSubItemVo> reduceInvoiceItemVOs;
            public long? GetId()
            {
                return id;
            }
            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }
            public List<ReduceInvoiceSubItemVo> GetReduceInvoiceItemVOs()
            {
                return reduceInvoiceItemVOs;
            }
            public Builder SetReduceInvoiceItemVOs(List<ReduceInvoiceSubItemVo> reduceInvoiceItemVOs)
            {
                this.reduceInvoiceItemVOs = reduceInvoiceItemVOs;
                return this;
            }

            public ReduceInvoiceItemVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ReduceInvoiceItemVo(this);
            }
        }
    }
}
