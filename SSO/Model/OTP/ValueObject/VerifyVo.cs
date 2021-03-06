﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_SSO.Model.OTP.ValueObject
{
    public class VerifyVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Otp { get; }
        public string Authorization { get; }
        public string Identity { get; }

        public VerifyVo(Builder builder)
        {
            Otp = builder.GetOtp();
            Authorization = builder.GetAuthorization();
            Identity = builder.GetIdentity();
        }

        public class Builder
        {
            [Required] private string identity;

            [Required] private string authorization;

            [Required] private string otp;

            public string GetIdentity()
            {
                return identity;
            }

            ///<param name="identity">شماره تلفن و یا ایمیل کاربر</param>
            public Builder SetIdentity(string identity)
            {
                this.identity = identity;
                return this;
            }

            public string GetAuthorization()
            {
                return authorization;
            }

            public Builder SetAuthorization(string keyId, string privateKey)
            {
                var header = "host";
                var dataToSign = "host: accounts.pod.ir";
                //if (signType == SignType.HostDate)
                //{
                //    header += " date";
                //    dataToSign += Environment.NewLine + "date: Sat July 24 2019 11:25:37 GMT+0430";
                //}

                var signature = dataToSign.GetSignature(privateKey, HashAlgorithmName.SHA256);
                this.authorization =
                    $"Signature keyId = \"{keyId}\", signature = \"{signature}\", headers = \"{header}\"";
                return this;
            }

            public string GetOtp()
            {
                return otp;
            }

            public Builder SetOtp(string otp)
            {
                this.otp = otp;
                return this;
            }

            public VerifyVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new VerifyVo(this);
            }
        }
    }
}
