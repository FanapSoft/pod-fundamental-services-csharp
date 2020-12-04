using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Banking.Model.ValueObject
{
    public class CardToCardListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string SourceCardNumber { get; }
        public string SourceDepositNumber { get; }
        public string DestinationCardNumber { get; }
        public decimal? MinAmount { get; }
        public decimal? MaxAmount { get; }
        public string StartDate { get; }
        public string EndDate { get; }
        public string RefrenceNumber { get; }
        public string SequenceNumber { get; }
        public string SourceNote { get; }
        public string DestinationNote { get; }
        public string UserName { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public CardToCardListVo(Builder builder)
        {
            SourceCardNumber = builder.GetSourceCardNumber();
            SourceDepositNumber = builder.GetSourceDepositNumber();
            DestinationCardNumber = builder.GetDestinationCardNumber();
            StartDate = builder.GetStartDate();
            EndDate = builder.GetEndDate();
            MinAmount = builder.GetMinAmount();
            MaxAmount = builder.GetMaxAmount();
            RefrenceNumber = builder.GetRefrenceNumber();
            SequenceNumber = builder.GetSequenceNumber();
            DestinationNote = builder.GetDestinationNote();
            SourceNote = builder.GetSourceNote();
            UserName = builder.GetUserName();
            Timestamp = builder.GetTimestamp();
            Signature = builder.GetSignature();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            [StringLength(16,MinimumLength = 16)]
            private string sourceCardNumber;

            [StringLength(16, MinimumLength = 16)]
            private string destinationCardNumber;
            private string sourceDepositNumber;

            [Required]
            private decimal? minAmount;

            [Required]
            private decimal? maxAmount;

            [Required]
            private string startDate;

            [Required]
            private string endDate;
            private string refrenceNumber;
            private string sequenceNumber;
            private string sourceNote;
            private string destinationNote;

            [Required] private string userName;
            private string signature;

            [Required] private string privateKey;
            private string timestamp;


            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetSourceCardNumber()
            {
                return sourceCardNumber;
            }

            /// <param name="sourceCardNumber">شماره 16 رقمی کارت مبدا</param>
            public Builder SetSourceCardNumber(string sourceCardNumber)
            {
                this.sourceCardNumber = sourceCardNumber.Replace("-", "").Replace("_", "").Trim();
                return this;
            }

            public string GetDestinationCardNumber()
            {
                return destinationCardNumber;
            }

            /// <param name="destinationCardNumber">شماره 16 رقمی کارت مقصد</param>
            public Builder SetDestinationCardNumber(string destinationCardNumber)
            {
                this.destinationCardNumber = destinationCardNumber.Replace("-", "").Replace("_", "").Trim();
                return this;
            }

            public string GetSourceDepositNumber()
            {
                return sourceDepositNumber;
            }

            /// <param name="sourceDepositNumber">شماره سپرده مبدا</param>
            public Builder SetSourceDepositNumber(string sourceDepositNumber)
            {
                this.sourceDepositNumber = sourceDepositNumber;
                return this;
            }

            public decimal? GetMinAmount()
            {
                return minAmount;
            }

            /// <param name="minAmount ">مبلغ از</param>
            public Builder SetMinAmount(decimal minAmount)
            {
                this.minAmount = minAmount;
                return this;
            }

            public decimal? GetMaxAmount()
            {
                return maxAmount;
            }

            /// <param name="maxAmount ">مبلغ تا</param>
            public Builder SetMaxAmount(decimal maxAmount)
            {
                this.maxAmount = maxAmount;
                return this;
            }

            public string GetRefrenceNumber()
            {
                return refrenceNumber;
            }

            /// <param name="refrenceNumber">شماره پیگیری</param>
            public Builder SetRefrenceNumber(string refrenceNumber)
            {
                this.refrenceNumber = refrenceNumber;
                return this;
            }

            public string GetStartDate()
            {
                return startDate;
            }

            /// <param name="startDate">تاریخ از</param>
            public Builder SetStartDate(DateTime startDate)
            {
                this.startDate = startDate.ToString("yyyy/MM/dd");
                return this;
            }

            public string GetEndDate()
            {
                return endDate;
            }

            /// <param name="endDate">تاریخ تا</param>
            public Builder SetEndDate(DateTime endDate)
            {
                this.endDate = endDate.ToString("yyyy/MM/dd");
                return this;
            }

            public string GetSourceNote()
            {
                return sourceNote;
            }

            /// <param name="sourceNote">توضیحات مبدا</param>
            public Builder SetSourceNote(string sourceNote)
            {
                this.sourceNote = sourceNote;
                return this;
            }

            public string GetDestinationNote()
            {
                return destinationNote;
            }

            /// <param name="destinationNote">توضیحات مقصد</param
            public Builder SetDestinationNote(string destinationNote)
            {
                this.destinationNote = destinationNote;
                return this;
            }

            public string GetSequenceNumber()
            {
                return sequenceNumber;
            }

            /// <param name="sequenceNumber">عنوان کارت</param>
            public Builder SetSequenceNumber(string sequenceNumber)
            {
                this.sequenceNumber = sequenceNumber;
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

            public CardToCardListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                var dataToSign =
                    "{" +
                    $"\"UserName\":\"{userName}\",\"SourceCardNumber\":\"{sourceCardNumber}\",\"SourceDepositNumber\":\"{sourceDepositNumber}\",\"DestinationCardNumber\":\"{destinationCardNumber}\"" +
                    $",\"MinAmount\":\"{minAmount}\",\"MaxAmount\":\"{maxAmount}\",\"StartDate\":\"{startDate}\",\"EndDate\":\"{endDate}\"" +
                    $",\"RefrenceNumber\":\"{refrenceNumber}\",\"SequenceNumber\":\"{sequenceNumber}\",\"SourceNote\":\"{sourceNote}\",\"DestinationNote\":\"{destinationNote}\"" +
                    $",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" +
                    "}";

                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new CardToCardListVo(this);
            }
        }
    }
}
