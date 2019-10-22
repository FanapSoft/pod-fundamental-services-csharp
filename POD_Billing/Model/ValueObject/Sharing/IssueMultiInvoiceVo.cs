using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject.Sharing
{
    public class IssueMultiInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Data { get; }
        public long[] DelegatorId { get; }
        public string[] DelegationHash { get; }
        public bool? ForceDelegation { get; }
        public string Ott { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public IssueMultiInvoiceVo(Builder builder)
        {
            Data = builder.GetData();
            DelegatorId = builder.GetDelegatorId();
            DelegationHash = builder.GetDelegationHash();
            ForceDelegation = builder.GetForceDelegation();
            Ott = builder.GetOtt();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private string data;
            private long[] delegatorId;
            private string[] delegationHash;
            private bool? forceDelegation;

            [Required] private string ott;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetData()
            {
                return data;
            }

            /// <param name="data">اطلاعات فاکتورها</param>
            public Builder SetData(MultiInvoiceDataVo data)
            {
                this.data = JsonConvert.SerializeObject(data);
                return this;
            }
            public long[] GetDelegatorId()
            {
                return delegatorId;
            }

            /// <param name="delegatorId">شناسه تفویض کنندگان، ترتیب اولویت را مشخص می کند </param>
            public Builder SetDelegatorId(long[] delegatorId)
            {
                this.delegatorId = delegatorId;
                return this;
            }
            public string[] GetDelegationHash()
            {
                return delegationHash;
            }

            /// <param name="delegationHash">کد تفویض برای اشاره به یک تفویض مشخص </param>
            public Builder SetDelegationHash(string[] delegationHash)
            {
                this.delegationHash = delegationHash;
                return this;
            }
            public bool? GetForceDelegation()
            {
                return forceDelegation;
            }

            /// <param name="forceDelegation">پرداخت فقط از طریق تفویض </param>
            public Builder SetForceDelegation(bool forceDelegation)
            {
                this.forceDelegation = forceDelegation;
                return this;
            }
            public string GetOtt()
            {
                return ott;
            }
            public Builder SetOtt(string ott)
            {
                this.ott = ott;
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

            public IssueMultiInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new IssueMultiInvoiceVo(this);
            }
        }
    }
}
