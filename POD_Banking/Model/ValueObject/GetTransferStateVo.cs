using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;

namespace POD_Banking.Model.ValueObject
{
    public class GetTransferStateVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Date { get; }
        public string PaymentId { get; }
        public string UserName { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetTransferStateVo(Builder builder)
        {
            Date = builder.GetDate();
            PaymentId = builder.GetPaymentId();
            UserName = builder.GetUserName();
            Timestamp = builder.GetTimestamp();
            Signature = builder.GetSignature();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string date;

            [Required]
            private string paymentId;

            [Required]
            private string userName;
            private string signature;

            [Required]
            private string privateKey;
            private string timestamp;

            [Required]
            private InternalServiceCallVo serviceCallParameters;


            public string GetDate()
            {
                return date;
            }

            /// <param name="date">تاریخ انتقال میلادی</param>
            public Builder SetDate(DateTime date)
            {
                this.date = date.ToString("yyyy/MM/dd");
                return this;
            }

            /// <param name="paymentId">شناسه پرداخت درج شده در درخواست انتقال وجه</param>
            public Builder SetPaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }
            public string GetPaymentId()
            {
                return paymentId;
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

            public GetTransferStateVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                string dataToSign = "{" + $"\"UserName\":\"{userName}\",\"Date\":\"{date}\",\"PaymentId\":\"{paymentId}\"" +
                                $",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" + "}";

                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new GetTransferStateVo(this);
            }
        }
    }
}

