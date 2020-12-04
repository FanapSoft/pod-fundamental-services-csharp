using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Banking.Base.Enum;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Banking.Model.ValueObject
{
    public class GetSubmissionChequeVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Deposit { get; }
        public string ChequeNumber { get; }
        public decimal? MinAmount { get; }
        public decimal? MaxAmount { get; }
        public string StartDate { get; }
        public string EndDate { get; }
        public int? BankCode { get; }
        public int? ChequeStatus { get; }
        public string StartSubmissionDate { get; }
        public string EndSubmissionDate { get; }
        public int? RowCount { get; }
        public string UserName { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetSubmissionChequeVo(Builder builder)
        {
            Deposit = builder.GetDeposit();
            ChequeNumber = builder.GetChequeNumber();
            MinAmount = builder.GetMinAmount();
            MaxAmount = builder.GetMaxAmount();
            StartDate = builder.GetStartDate();
            EndDate = builder.GetEndDate();
            BankCode = builder.GetBankCode();
            ChequeStatus = builder.GetChequeStatus();
            StartSubmissionDate = builder.GetStartSubmisionDate();
            EndSubmissionDate = builder.GetEndSubmitionDate();
            RowCount = builder.GetRowCount();
            UserName = builder.GetUserName();
            Timestamp = builder.GetTimestamp();
            Signature = builder.GetSignature();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string deposit;
            private string chequeNumber;
            private decimal? minAmount;
            private decimal? maxAmount;
            private string startDate;
            private string endDate;
            private int? bankCode;
            private int? chequeStatus;
            private string startSubmisionDate;
            private string endSubmitionDate;
            private int? rowCount;

            [Required]
            private string userName;
            private string timestamp;
            private string signature;

            [Required]
            private string privateKey;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetChequeNumber()
            {
                return chequeNumber;
            }

            /// <param name="chequeNumber">شماره چک</param>
            public Builder SetChequeNumber(string chequeNumber)
            {
                this.chequeNumber = chequeNumber;
                return this;
            }
            public int? GetBankCode()
            {
                return bankCode;
            }

            /// <param name="bankCode">کد بانک</param>
            public Builder SetBankCode(BankCode bankCode)
            {
                this.bankCode = (int)bankCode;
                return this;
            }
            public int? GetChequeStatus()
            {
                return chequeStatus;
            }

            /// <param name="chequeStatus">کد وضعیت چک</param>
            public Builder SetChequeStatus(ChequeStatus chequeStatus)
            {
                this.chequeStatus = (int)chequeStatus;
                return this;
            }
            public string GetDeposit()
            {
                return deposit;
            }

            /// <param name="deposit">شماره سپرده مبدا</param>
            public Builder SetDeposit(string deposit)
            {
                this.deposit = deposit;
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
            public string GetStartSubmisionDate()
            {
                return startSubmisionDate;
            }

            /// <param name="startSubmisionDate">تاریخ واگذاری از</param>
            public Builder SetStartSubmisionDate(DateTime startSubmisionDate)
            {
                this.startSubmisionDate = startSubmisionDate.ToString("yyyy/MM/dd");
                return this;
            }
            public string GetEndSubmitionDate()
            {
                return endSubmitionDate;
            }

            /// <param name="endSubmitionDate">تاریخ واگذاری تا</param>
            public Builder SetEndSubmitionDate(DateTime endSubmitionDate)
            {
                this.endSubmitionDate = endSubmitionDate.ToString("yyyy/MM/dd");
                return this;
            }
            public int? GetRowCount()
            {
                return rowCount;
            }

            public Builder SetRowCount(int rowCount)
            {
                this.rowCount = rowCount;
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
            public string GetTimestamp()
            {
                return timestamp;
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

            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public GetSubmissionChequeVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                var dataToSign =
                    "{" +
                    $"\"UserName\":\"{userName}\",\"Deposit\":\"{deposit}\",\"ChequeNumber\":\"{chequeNumber}\",\"MinAmount\":\"{minAmount}\",\"MaxAmount\":\"{maxAmount}\"" +
                    $",\"StartDate\":\"{startDate}\",\"EndDate\":\"{endDate}\",\"BankCode\":\"{bankCode}\",\"ChequeStatus\":\"{chequeStatus}\"" +
                    $",\"StartSubmisionDate\":\"{startSubmisionDate}\",\"EndSubmissionDate\":\"{endSubmitionDate}\",\"RowCount\":\"{rowCount}\"" +
                    $",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" +
                    "}";

                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new GetSubmissionChequeVo(this);
            }
        }
    }
}
