using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace POD_Banking.Model.ValueObject
{
    public class PayaServiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string SourceDepositNumber { get; }
        public string TransferMoneyBillNumber { get; }
        public string FileUniqueIdentifier { get; }
        public string BatchPayaItemInfos { get; }
        public string UserName { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public PayaServiceVo(Builder builder)
        {
            SourceDepositNumber = builder.GetSourceDepositNumber();
            TransferMoneyBillNumber = builder.GetTransferMoneyBillNumber();
            FileUniqueIdentifier = builder.GetFileUniqueIdentifier();
            BatchPayaItemInfos = builder.GetBatchPayaItemInfos();
            UserName = builder.GetUserName();
            Timestamp = builder.GetTimestamp();
            Signature = builder.GetSignature();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string sourceDepositNumber;
            private string transferMoneyBillNumber;

            [Required]
            private string fileUniqueIdentifier;

            [Required]
            private string batchPayaItemInfosJson;

            [Required]
            private string userName;
            private string signature;

            [Required]
            private string privateKey;
            private string timestamp;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetSourceDepositNumber()
            {
                return sourceDepositNumber;
            }

            /// <param name="sourceDepositNumber">شماره سپرده جهت برداشت وجه</param>
            public Builder SetSourceDepositNumber(string sourceDepositNumber)
            {
                this.sourceDepositNumber = sourceDepositNumber;
                return this;
            }

            public string GetTransferMoneyBillNumber()
            {
                return transferMoneyBillNumber;
            }

            /// <summary>
            /// در صورتیکه سپرده مبدا دارای شناسه قبض است باید این فیلد ارسال شود.
            /// </summary>
            public Builder SetTransferMoneyBillNumber(string transferMoneyBillNumber)
            {
                this.transferMoneyBillNumber = transferMoneyBillNumber;
                return this;
            }
            public string GetFileUniqueIdentifier()
            {
                return fileUniqueIdentifier;
            }

            /// <param name="fileUniqueIdentifier">شروع شود و از کاراکترهای حرفی و عددی تشکیل شده است ACHشناسه یکتای فایل که حتما باید با</param>
            public Builder SetFileUniqueIdentifier(string fileUniqueIdentifier)
            {
                if (fileUniqueIdentifier.StartsWith("ACH", StringComparison.OrdinalIgnoreCase))
                    this.fileUniqueIdentifier = fileUniqueIdentifier;
                else this.fileUniqueIdentifier = "ACH" + fileUniqueIdentifier;
                this.fileUniqueIdentifier = fileUniqueIdentifier;
                return this;
            }
            public string GetBatchPayaItemInfos()
            {
                return batchPayaItemInfosJson;
            }

            /// <param name="batchPayaItemInfos">لیست پایاها</param>
            public Builder SetBatchPayaItemInfos(List<BatchPayaItemInfoVo> batchPayaItemInfos)
            {
                batchPayaItemInfosJson = JsonConvert.SerializeObject(batchPayaItemInfos);
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

            public PayaServiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                var dataToSign = "{" + 
                                       $"\"UserName\":\"{userName}\",\"SourceDepositNumber\":\"{sourceDepositNumber}\",\"FileUniqueIdentifier\":\"{fileUniqueIdentifier}\"" +
                                       $",\"TransferMoneyBillNumber\":\"{transferMoneyBillNumber}\",\"BatchPayaItemInfos\":{batchPayaItemInfosJson}" +
                                       $",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" + 
                                 "}";

                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new PayaServiceVo(this);
            }
        }
    }
}
