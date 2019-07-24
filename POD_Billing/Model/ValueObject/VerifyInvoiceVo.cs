using System.Collections.Generic;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class VerifyInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public string BillNumber { get; }

        public VerifyInvoiceVo(Builder builder)
        {
            Id = builder.GetId();
            BillNumber = builder.GetBillNumber();
        }

        public class Builder
        {
             private long? id;
             private string billNumber;

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
            public VerifyInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();
                if (id == null && string.IsNullOrEmpty(billNumber))
                {
                    hasErrorFields.Add(new KeyValuePair<string, string>("id,billNumber", "One of this Builder fields is required."));
                }

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new VerifyInvoiceVo(this);
            }
        }
    }
}
