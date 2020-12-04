using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Banking.Model.ValueObject
{
    public class ConvertDepositNumberToShebaVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string UserName { get; }
        public string DepositNumber  { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public ConvertDepositNumberToShebaVo(Builder builder)
        {
            UserName = builder.GetUserName();
            DepositNumber  = builder.GetDepositNumber();
            Timestamp = builder.GetTimestamp();
            Signature = builder.GetSignature();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string userName;

            [Required]
            private string depositNumber;
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

            public string GetDepositNumber()
            {
                return depositNumber;
            }

            /// <param name="depositNumber ">شماره سپرده</param>
            public Builder SetDepositNumber (string depositNumber )
            {
                this.depositNumber  = depositNumber;
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

            public ConvertDepositNumberToShebaVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                var dataToSign = "{" + $"\"UserName\":\"{userName}\",\"DepositNumber\":\"{depositNumber}\"" +
                                 $",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" + "}";

                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new ConvertDepositNumberToShebaVo(this);
            }
        }
    }
}
