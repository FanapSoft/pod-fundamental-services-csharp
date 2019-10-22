using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject.DirectDebit
{
    public class UpdateDirectWithdrawVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public string Username { get; }
        public string PrivateKey { get; }
        public string DepositNumber { get; }
        public bool? OnDemand { get; }
        public decimal? MinAmount { get; }
        public decimal? MaxAmount { get; }
        public string Wallet { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public UpdateDirectWithdrawVo(Builder builder)
        {
            Id = builder.GetId();
            Username = builder.GetUsername();
            PrivateKey = builder.GetPrivateKey();
            DepositNumber = builder.GetDepositNumber();
            OnDemand = builder.GetOnDemand();
            MinAmount = builder.GetMinAmount();
            MaxAmount = builder.GetMaxAmount();
            Wallet = builder.GetWallet();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? id;
            [Required] private string username;
            [Required] private string privateKey;
            [Required] private string depositNumber;
            [Required] private bool? onDemand;
            [Required] private decimal? minAmount;
            [Required] private decimal? maxAmount;
            [Required] private string wallet;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه مجوز</param>
            public Builder SetId(long? id)
            {
                this.id = id;
                return this;
            }
            public string GetUsername()
            {
                return username;
            }

            /// <param name="username">نام کاربری</param>
            public Builder SetUsername(string username)
            {
                this.username = username;
                return this;
            }

            public string GetPrivateKey()
            {
                return privateKey;
            }

            ///<summary>کلید خصوصی ایجاد شده که قبلا جفت عمومی آن به بانک ارائه شده است</summary>
            /// <param name="privateKey">XML کلید خصوصی به فرمت</param>
            public Builder SetPrivateKey(string privateKey)
            {
                this.privateKey = privateKey;
                return this;
            }

            ///<summary>کلید خصوصی ایجاد شده که قبلا جفت عمومی آن به بانک ارائه شده است</summary>
            /// <param name="pemFilePath">.pem مسیر فایل کلید خصوصی با فرمت</param>
            public Builder SetPrivateKeyFromFile(string pemFilePath)
            {
                privateKey = Util.LoadRsaFile(pemFilePath).ToXml(true);
                return this;
            }

            public string GetDepositNumber()
            {
                return depositNumber;
            }

            /// <param name="depositNumber ">شماره حساب مبدا در بانک پاسارگاد</param>
            public Builder SetDepositNumber(string depositNumber)
            {
                this.depositNumber = depositNumber;
                return this;
            }

            public bool? GetOnDemand()
            {
                return onDemand;
            }

            public Builder SetOnDemand(bool onDemand)
            {
                this.onDemand = onDemand;
                return this;
            }

            public decimal? GetMinAmount()
            {
                return minAmount;
            }

            /// <param name="minAmount ">حداقل مبلغ موجودی در حساب مجازی</param>
            public Builder SetMinAmount(decimal minAmount)
            {
                this.minAmount = minAmount;
                return this;
            }

            public decimal? GetMaxAmount()
            {
                return maxAmount;
            }

            public Builder SetMaxAmount(decimal maxAmount)
            {
                this.maxAmount = maxAmount;
                return this;
            }

            public string GetWallet()
            {
                return wallet;
            }

            /// <param name="wallet ">کد کیف پولی که باید موجودی آن تامین گردد</param>
            public Builder SetWallet(string wallet)
            {
                this.wallet = wallet;
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

            public UpdateDirectWithdrawVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UpdateDirectWithdrawVo(this);
            }
        }
    }
}
