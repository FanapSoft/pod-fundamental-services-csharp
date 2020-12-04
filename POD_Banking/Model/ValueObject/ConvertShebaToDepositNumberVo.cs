using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Banking.Model.ValueObject
{
    public class ConvertShebaToDepositNumberVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string UserName { get; }
        public string Sheba { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public ConvertShebaToDepositNumberVo(Builder builder)
        {
            UserName = builder.GetUserName();
            Sheba = builder.GetSheba();
            Timestamp = builder.GetTimestamp();
            Signature = builder.GetSignature();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string userName;

            [Required]
            private string sheba;
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

            public string GetSheba()
            {
                return sheba;
            }

            /// <param name="sheba">شماره شبا</param>
            public Builder SetSheba(string sheba)
            {
                if (sheba.StartsWith("IR", StringComparison.OrdinalIgnoreCase))
                    this.sheba = sheba;
                else this.sheba = "IR" + sheba;
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

            public ConvertShebaToDepositNumberVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                var dataToSign = "{" + $"\"UserName\":\"{userName}\",\"Sheba\":\"{sheba}\"" +
                                 $",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" + "}";

                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new ConvertShebaToDepositNumberVo(this);
            }
        }
    }
}
