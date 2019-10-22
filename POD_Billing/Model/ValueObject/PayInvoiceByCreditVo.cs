using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject
{
    public class PayInvoiceByCreditVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? InvoiceId { get; }
        public long[] DelegatorId { get; }
        public string[] DelegationHash { get; }
        public bool? ForceDelegation { get; }
        public string Wallet { get; }
        public string Ott { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public PayInvoiceByCreditVo(Builder builder)
        {
            InvoiceId = builder.GetInvoiceId();
            DelegatorId = builder.GetDelegatorId();
            DelegationHash = builder.GetDelegationHash();
            ForceDelegation = builder.GetForceDelegation();
            Wallet = builder.GetWallet();
            Ott = builder.GetOtt();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long? invoiceId;
            private long[] delegatorId;
            private string[] delegationHash;
            private bool? forceDelegation;
            private string wallet;

            [Required]
            private string ott;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetInvoiceId()
            {
                return invoiceId;
            }

            /// <param name="invoiceId">شناسه فاکتور که لازم است از صادر کننده ی فاکتور دریافت گردد</param>
            public Builder SetInvoiceId(long invoiceId)
            {
                this.invoiceId = invoiceId;
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
            public string GetWallet()
            {
                return wallet;
            }

            /// <param name="wallet">کد کیف پول</param>
            public Builder SetWallet(string wallet)
            {
                this.wallet = wallet;
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

            public PayInvoiceByCreditVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PayInvoiceByCreditVo(this);
            }
        }
    }
}
