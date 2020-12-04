using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Banking.Model.ValueObject
{
    public class GetDepositInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string UserName { get; }
        public string DepositNumber { get; }
        public string StartDate { get; }
        public string EndDate { get; }
        public string Sheba { get; }
        public long? FirstIndex { get; }
        public int? Count { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetDepositInvoiceVo(Builder builder)
        {
            UserName = builder.GetUserName();
            DepositNumber = builder.GetDepositNumber();
            StartDate = builder.GetStartDate();
            EndDate = builder.GetEndDate();
            Sheba = builder.GetSheba();
            FirstIndex = builder.GetFirstIndex();
            Count = builder.GetCount();
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

            [Required]
            private string startDate;

            [Required]
            private string endDate;
            private string sheba;
            private long? firstIndex;
            private int? count;
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
            public Builder SetDepositNumber(string depositNumber)
            {
                this.depositNumber = depositNumber;
                return this;
            }


            public string GetStartDate()
            {
                return startDate;
            }

            /// <param name="startDate">تاریخ از</param>
            public Builder SetStartDate(DateTime startDate)
            {
                this.startDate = startDate.ToString("yyyy/MM/dd")+ " 00:00:00:000";
                return this;
            }
            public string GetEndDate()
            {
                return endDate;
            }

            /// <param name="endDate">تاریخ تا</param>
            public Builder SetEndDate(DateTime endDate)
            {
                this.endDate = endDate.ToString("yyyy/MM/dd")+ " 23:59:59:999";
                return this;
            }
            public string GetSheba()
            {
                return sheba;
            }

            public Builder SetSheba(string sheba)
            {
                if (sheba.StartsWith("IR", StringComparison.OrdinalIgnoreCase))
                    this.sheba = sheba;
                else this.sheba = "IR" + sheba;
                return this;
            }
            public long? GetFirstIndex()
            {
                return firstIndex;
            }

            public Builder SetFirstIndex(long firstIndex)
            {
                this.firstIndex = firstIndex;
                return this;
            }
            public int? GetCount()
            {
                return count;
            }

            public Builder SetCount(int count)
            {
                this.count = count;
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

            public GetDepositInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                var dataToSign = "{" + 
                                 $"\"UserName\":\"{userName}\",\"DepositNumber\":\"{depositNumber}\",\"Sheba\":\"{sheba}\"" +
                                 $",\"StartDate\":\"{startDate}\",\"EndDate\":\"{endDate}\",\"FirstIndex\":\"{firstIndex}\",\"Count\":\"{count}\"" +
                                 $",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" + 
                                 "}";

                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new GetDepositInvoiceVo(this);
            }
        }
    }
}

