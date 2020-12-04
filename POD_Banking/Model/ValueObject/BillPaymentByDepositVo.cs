using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;

namespace POD_Banking.Model.ValueObject
{
    public class BillPaymentByDepositVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string DepositNumber { get; }
        public string PaymentId { get; }
        public string BillNumber { get; }
        public string UserName { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public BillPaymentByDepositVo(Builder builder)
        {
            DepositNumber = builder.GetDepositNumber();
            PaymentId = builder.GetPaymentId();
            BillNumber = builder.GetBillNumber();
            UserName = builder.GetUserName();
            Timestamp = builder.GetTimestamp();
            Signature = builder.GetSignature();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string depositNumber;

            [Required]
            private string paymentId;

            [Required]
            private string billNumber;

            [Required]
            private string userName;
            private string signature;

            [Required]
            private string privateKey;
            private string timestamp;

            [Required]
            private InternalServiceCallVo serviceCallParameters;


            public string GetDepositNumber()
            {
                return depositNumber ;
            }

            /// <param name="depositNumber ">شماره سپرده</param>
            public Builder SetDepositNumber (string depositNumber )
            {
                this.depositNumber = depositNumber;
                return this;
            }
            public string GetPaymentId()
            {
                return paymentId;
            }

            /// <param name="paymentId">شناسه پرداخت</param>
            public Builder SetPaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }
            public string GetBillNumber()
            {
                return billNumber;
            }

            /// <param name="billNumber">شناسه قبض</param>
            public Builder SetBillNumber(string billNumber)
            {
                this.billNumber = billNumber;
                return this;
            }
            public string GetUserName()
            {
                return userName;
            }

            /// <param name="userName">نام کاربری</param>
            public Builder SetUserName(string userName)
            {
                this.userName = userName;
                return this;
            }
            public string GetSignature()
            {
                return signature;
            }
            public Builder SetPrivateKey(string privateKey)
            {
                this.privateKey = privateKey;
                return this;
            }
            public string GetTimestamp()
            {
                return timestamp;
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

            public BillPaymentByDepositVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                string dataToSign = "{" +
                                          $"\"UserName\":\"{userName}\",\"PaymentId\":\"{paymentId}\",\"DepositNumber\":\"{depositNumber}\"" +
                                          $",\"BillNumber\":\"{billNumber}\",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" + 
                                    "}";

                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new BillPaymentByDepositVo(this);
            }
        }
    }
}
