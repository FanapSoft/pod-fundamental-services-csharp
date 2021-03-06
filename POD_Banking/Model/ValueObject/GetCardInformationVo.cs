﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Banking.Model.ValueObject
{
    public class GetCardInformationVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string UserName { get; }
        public string SrcCardNumber { get; }
        public string DestCardNumber { get; }
        public string Email { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetCardInformationVo(Builder builder)
        {
            UserName = builder.GetUserName();
            SrcCardNumber = builder.GetSrcCardNumber();
            DestCardNumber = builder.GetDestCardNumber();
            Email = builder.GetEmail();
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
            private string srcCardNumber;

            [Required]
            [StringLength(16, MinimumLength = 16)]
            private string destCardNumber;

            [EmailAddress]
            private string email;
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

            public string GetSrcCardNumber()
            {
                return srcCardNumber;
            }

            /// <param name="srcCardNumber">شماره 16 رقمی کارت مبدا</param>
            public Builder SetSrcCardNumber(string srcCardNumber)
            {
                this.srcCardNumber = srcCardNumber.Replace("-", "").Replace("_", "").Trim();
                return this;
            }
            public string GetDestCardNumber()
            {
                return destCardNumber;
            }

            /// <param name="destCardNumber">شماره 16 رقمی کارت مقصد</param>
            public Builder SetDestCardNumber(string destCardNumber)
            {
                this.destCardNumber = destCardNumber.Replace("-", "").Replace("_", "").Trim();
                return this;
            }
            public string GetEmail()
            {
                return email;
            }

            public Builder SetEmail(string email)
            {
                this.email = email;
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

            public GetCardInformationVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                var dataToSign = "{" + $"\"UserName\":\"{userName}\",\"SrcCardNumber\":\"{srcCardNumber}\",\"DestCardNumber\":\"{destCardNumber}\"" +
                                 $",\"Email\":\"{email}\",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" + "}";
                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new GetCardInformationVo(this);
            }
        }
    }
}
