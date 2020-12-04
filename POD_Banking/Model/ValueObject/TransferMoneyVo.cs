using System;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Base_Service.CustomAttribute;

namespace POD_Banking.Model.ValueObject
{
    public class TransferMoneyVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string SourceDepositNumber { get; }
        public string DestDepositNumber { get; }
        public string SourceSheba { get; }
        public string DestSheba { get; }
        public string DestFirstName { get; }
        public string DestLastName { get; }
        public decimal? Amount { get; }
        public string SourceComment { get; }
        public string DestComment { get; }
        public string PaymentId { get; }
        public string UserName { get; }
        public string Timestamp { get; }
        public string Signature { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public TransferMoneyVo(Builder builder)
        {
            SourceDepositNumber = builder.GetSourceDepositNumber();
            DestDepositNumber = builder.GetDestDepositNumber();
            SourceSheba = builder.GetSourceSheba();
            DestSheba = builder.GetDestSheba();
            DestFirstName = builder.GetDestFirstName();
            DestLastName = builder.GetDestLastName();
            Amount = builder.GetAmount();
            SourceComment = builder.GetSourceComment();
            DestComment = builder.GetDestComment();
            PaymentId = builder.GetPaymentId();
            UserName = builder.GetUserName();
            Timestamp = builder.GetTimestamp();
            Signature = builder.GetSignature();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [RequiredIf(nameof(sourceSheba))] private string sourceDepositNumber;

            [RequiredIf(nameof(destSheba))] private string destDepositNumber;

            private string sourceSheba;
            private string destSheba;
            private string destFirstName;
            private string destLastName;

            [Required] private decimal? amount;

            [StringLength(50)] private string sourceComment;

            [StringLength(50)] private string destComment;

            [Required] private string paymentId;

            [Required] private string userName;
            private string signature;

            [Required] private string privateKey;
            private string timestamp;

            [Required] private InternalServiceCallVo serviceCallParameters;

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

            public string GetDestDepositNumber()
            {
                return destDepositNumber;
            }

            /// <param name="destDepositNumber ">شماره سپرده مقصد</param>
            public Builder SetDestDepositNumber(string destDepositNumber)
            {
                this.destDepositNumber = destDepositNumber;
                return this;
            }

            public string GetSourceSheba()
            {
                return sourceSheba;
            }

            /// <param name="sourceSheba">IR شماره شبا مبدا به همراه</param>
            public Builder SetSourceSheba(string sourceSheba)
            {
                if (sourceSheba.StartsWith("IR", StringComparison.OrdinalIgnoreCase))
                    this.sourceSheba = sourceSheba;
                else this.sourceSheba = "IR" + sourceSheba;
                return this;
            }
            public string GetDestSheba()
            {
                return destSheba;
            }

            /// <param name="destSheba">IR شماره شبا مقصد به همراه</param>
            public Builder SetDestSheba(string destSheba)
            {
                if (destSheba.StartsWith("IR", StringComparison.OrdinalIgnoreCase))
                    this.destSheba = destSheba;
                else this.destSheba = "IR" + destSheba;
                return this;
            }

            public string GetDestFirstName()
            {
                return destFirstName;
            }

            /// <param name="destFirstName">نام گیرنده انتقال وجه</param>
            public Builder SetDestFirstName(string destFirstName)
            {
                this.destFirstName = destFirstName;
                return this;
            }

            public string GetDestLastName()
            {
                return destLastName;
            }

            /// <param name="destLastName">نام خانوادگی گیرنده وجه</param>
            public Builder SetDestLastName(string destLastName)
            {
                this.destLastName = destLastName;
                return this;
            }
            public decimal? GetAmount()
            {
                return amount;
            }

            /// <param name="amount">مبلغ انتقال به ریال </param>
            public Builder SetAmount(decimal amount)
            {
                this.amount = amount;
                return this;
            }

            public string GetSourceComment()
            {
                return sourceComment;
            }

            public Builder SetSourceComment(string sourceComment)
            {
                this.sourceComment = sourceComment;
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
            public string GetPaymentId()
            {
                return paymentId;
            }

            /// <summary>
            /// این شناسه باید برای هر کاربر در هر روز و هر درخواست یکتا باشد تا اجازه انتقال وجه داده شود. شناسه پرداخت تنها باید از حروف انگلیسی و اعداد تشکیل شده باشد.
            /// </summary>
            /// <param name="paymentId">شناسه پرداخت</param>
            public Builder SetPaymentId(string paymentId)
            {
                this.paymentId = paymentId;
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

            public TransferMoneyVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                string dataToSign =
                    "{" +
                    $"\"UserName\":\"{userName}\",\"SourceDepositNumber\":\"{sourceDepositNumber}\",\"SourceSheba\":\"{sourceSheba}\"" +
                    $",\"DestDepositNumber\":\"{destDepositNumber}\",\"DestSheba\":\"{destSheba}\",\"DestFirstName\":\"{destFirstName}\"" +
                    $",\"DestLastName\":\"{destLastName}\",\"Amount\":\"{amount}\",\"SourceComment\":\"{sourceComment}\",\"DestComment\":\"{destComment}\",\"PaymentId\":\"{paymentId}\"" +
                    $",\"Timestamp\":\"{timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")}\"" +
                    "}";

                signature = dataToSign.GetBankingSignature(privateKey, HashAlgorithmName.SHA1);

                return new TransferMoneyVo(this);
            }
        }
    }
}
