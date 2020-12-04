using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Banking.Model.ValueObject
{
    public class GetShebaByCardNumberVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string UserName { get; }
        public string CardNumber { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetShebaByCardNumberVo(Builder builder)
        {
            UserName = builder.GetUserName();
            CardNumber = builder.GetCardNumber();
            Timestamp = builder.GetTimestamp();
            Signature = builder.GetSignature();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string userName;

            [Required]
            [StringLength(16, MinimumLength = 16)]
            private string cardNumber;
            private string signature;

            [Required]
            private string privateKey;
            private string timestamp;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

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

            public string GetCardNumber()
            {
                return cardNumber;
            }

            /// <param name="cardNumber">شماره 16 رقمی کارت</param>
            public Builder SetCardNumber(string cardNumber)
            {
                this.cardNumber = cardNumber.Replace("-","").Replace("_","").Trim();
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

            public GetShebaByCardNumberVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                var dataToSign = "{" + $"\"UserName\":\"{userName}\",\"CardNumber\":\"{cardNumber}\",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" + "}";
                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new GetShebaByCardNumberVo(this);
            }
        }
    }
}
