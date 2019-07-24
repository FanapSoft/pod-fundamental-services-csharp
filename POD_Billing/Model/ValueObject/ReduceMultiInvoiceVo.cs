using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class ReduceMultiInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Data { get; }

        public ReduceMultiInvoiceVo(Builder builder)
        {
            Data = builder.GetData();
        }

        public class Builder
        {
            [Required]
            private string data;

            public string GetData()
            {
                return data;
            }

            /// <param name="data">اطلاعات فاکتورها</param>
            public Builder SetData(ReduceMultiInvoiceDataVo data)
            {
                this.data = JsonConvert.SerializeObject(data);
                return this;
            }

            public ReduceMultiInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ReduceMultiInvoiceVo(this);
            }
        }
    }
}
