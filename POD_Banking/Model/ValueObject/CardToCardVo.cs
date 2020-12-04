using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Banking.Base.Enum;

namespace POD_Banking.Model.ValueObject
{
    public class CardToCardVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string UserName { get; }
        public decimal? Amount { get; }
        public string Cvv2 { get; }
        public string Password { get; }
        public string SrcCardNumber { get; }
        public string DestCardNumber { get; }
        public int? ExpireMonth { get; }
        public string ExpireYear { get; }
        public string Email { get; }
        public string AuthorizationCode { get; }
        public string CardName { get; }
        public string SrcComment { get; }
        public string DestComment { get; }
        public string OriginalAddress { get; }
        public bool? WithReferenceNumber { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public string ExtraData { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public CardToCardVo(Builder builder)
        {
            UserName = builder.GetUserName();
            Amount = builder.GetAmount();
            Cvv2 = builder.GetCvv2();
            Password = builder.GetPassword();
            SrcCardNumber = builder.GetSrcCardNumber();
            DestCardNumber = builder.GetDestCardNumber();
            ExpireMonth = builder.GetExpireMonth();
            ExpireYear = builder.GetExpireYear();
            Email = builder.GetEmail();
            AuthorizationCode = builder.GetAuthorizationCode();
            CardName = builder.GetCardName();
            SrcComment = builder.GetSrcComment();
            DestComment = builder.GetDestComment();
            OriginalAddress = builder.GetOriginalAddress();
            WithReferenceNumber = builder.GetWithReferenceNumber();
            Timestamp = builder.GetTimestamp();
            Signature = builder.GetSignature();
            ExtraData = builder.GetExtraData();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private decimal? amount;

            [Required]
            [StringLength(4, MinimumLength = 3)]
            private string cvv2;

            [Required]
            private string password;

            [Required]
            [StringLength(16,MinimumLength = 16)]
            private string srcCardNumber;

            [Required]
            [StringLength(16, MinimumLength = 16)]
            private string destCardNumber;

            [Required][Range(1,12)]
            private int? expireMonth;

            [Required][Range(00,99)]
            private string expireYear;

            [EmailAddress]
            private string email;

            [Required]
            private string authorizationCode;

            private string cardName;
            private string srcComment;
            private string destComment;
            private string originalAddress;

            [Required]
            private bool? withReferenceNumber;
            private string extraData;
            private string signatureExtraData;

            [Required]
            private string userName;
            private string signature;

            [Required]
            private string privateKey;
            private string timestamp;

            [Required] private InternalServiceCallVo serviceCallParameters;

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
            public decimal? GetAmount()
            {
                return amount;
            }

            /// <param name="amount">مبلغ مورد نظر</param>
            public Builder SetAmount(decimal amount)
            {
                this.amount = amount;
                return this;
            }
            public string GetCvv2()
            {
                return cvv2;
            }

            /// <param name="cvv2">کارت مبدا بدون خط تیره و فاصله cvv2 رمز</param>
            public Builder SetCvv2(string cvv2)
            {
                this.cvv2 = cvv2;
                return this;
            }
            public string GetPassword()
            {
                return password;
            }

            /// <param name="password">رمز کارت مبدا</param>
            public Builder SetPassword(string password)
            {
                this.password = password;
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
      
            public string GetExpireYear()
            {
                return expireYear;
            }
            public Builder SetExpireYear(string expireYear)
            {
                this.expireYear = expireYear;
                return this;
            }
            public int? GetExpireMonth()
            {
                return expireMonth;
            }
            public Builder SetExpireMonth(int expireMonth)
            {
                this.expireMonth = expireMonth;
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
            public string GetAuthorizationCode()
            {
                return authorizationCode;
            }

            public Builder SetAuthorizationCode(string authorizationCode)
            {
                this.authorizationCode = authorizationCode;
                return this;
            }
            public string GetCardName()
            {
                return cardName;
            }

            public Builder SetCardName(string cardName)
            {
                this.cardName = cardName;
                return this;
            }
            public string GetSrcComment()
            {
                return srcComment;
            }

            public Builder SetSrcComment(string srcComment)
            {
                this.srcComment = srcComment;
                return this;
            }
            public string GetDestComment()
            {
                return destComment;
            }

            public Builder SetDestComment(string destComment)
            {
                this.destComment = destComment;
                return this;
            }
            public string GetOriginalAddress()
            {
                return originalAddress;
            }

            public Builder SetOriginalAddress(string originalAddress)
            {
                this.originalAddress = originalAddress;
                return this;
            }
            public bool? GetWithReferenceNumber()
            {
                return withReferenceNumber;
            }

            public Builder SetWithReferenceNumber(bool withReferenceNumber)
            {
                this.withReferenceNumber = withReferenceNumber;
                return this;
            }
            public string GetExtraData()
            {
                return extraData;
            }

            public Builder SetExtraData(string deviceId, string userAgent, string ip, PlatformType platform, string os, string imei)
            {
                extraData = "{" + 
                                  $"\"DeviceId\":\"{deviceId}\",\"UserAgent\":\"{userAgent}\"" +
                                  $",\"Platform\":\"{platform.ToString()}\",\"IP\":\"{ip}\",\"OS\":\"{os}\",\"imei\":\"{imei}\"" +
                            "}";

                signatureExtraData = "{" +
                                           $"\\\"DeviceId\\\":\\\"{deviceId}\\\",\\\"UserAgent\\\":\\\"{userAgent}\\\"" +
                                           $",\\\"Platform\\\":\\\"{platform.ToString()}\\\",\\\"IP\\\":\\\"{ip}\\\",\\\"OS\\\":\\\"{os}\\\",\\\"imei\\\":\\\"{imei}\\\"" + 
                                     "}";

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

            public CardToCardVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }



                string dataToSign = "{" + $"\"UserName\":\"{userName}\",\"SrcCardNumber\":\"{srcCardNumber}\",\"DestCardNumber\":\"{destCardNumber}\",\"Password\":\"{password}\",\"Cvv2\":\"{cvv2}\"" +
                    $",\"ExpireMonth\":\"{expireMonth}\",\"ExpireYear\":\"{expireYear}\",\"Amount\":\"{amount}\",\"Email\":\"{email}\",\"AuthorizationCode\":\"{authorizationCode}\",\"WithReferenceNumber\":\"{withReferenceNumber}\"" +
                    $",\"CardName\":\"{cardName}\",\"SrcComment\":\"{srcComment}\",\"DestComment\":\"{destComment}\",\"OriginalAddress\":\"{originalAddress}\"" +
                    $",\"JsonData\":\"{signatureExtraData}\",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" + "}";

                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new CardToCardVo(this);
            }
        }
    }
}
