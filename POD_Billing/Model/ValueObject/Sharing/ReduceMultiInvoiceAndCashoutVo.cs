using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Billing.Base.Enum;

namespace POD_Billing.Model.ValueObject.Sharing
{
    public class ReduceMultiInvoiceAndCashoutVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Data { get; }
        public ToolCode? ToolCode { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public ReduceMultiInvoiceAndCashoutVo(Builder builder)
        {
            Data = builder.GetData();
            ToolCode = builder.GetToolCode();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private string data;

            private ToolCode? toolCode;

            [Required] private InternalServiceCallVo serviceCallParameters;
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

            public ToolCode? GetToolCode()
            {
                return toolCode;
            }

            /// <param name="toolCode">کد ابزار تسویه </param>
            public Builder SetToolCode(ToolCode toolCode)
            {
                this.toolCode = toolCode;
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

            public ReduceMultiInvoiceAndCashoutVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ReduceMultiInvoiceAndCashoutVo(this);
            }
        }
    }
}
