using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Subscription.Base.Enum;

namespace POD_Subscription.Model.ValueObject
{
    public class UpdateSubscriptionPlanVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public PeriodType? PeriodTypeCode { get; }
        public int? PeriodTypeCount { get; }
        public long? UsageCountLimit { get; }
        public string Name { get; }
        public decimal? Price { get; }
        public bool? Enable { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public UpdateSubscriptionPlanVo(Builder builder)
        {
            Id = builder.GetId();
            PeriodTypeCode = builder.GetPeriodTypeCode();
            PeriodTypeCount = builder.GetPeriodTypeCount();
            UsageCountLimit = builder.GetUsageCountLimit();
            Name = builder.GetName();
            Price = builder.GetPrice();
            Enable = builder.GetEnable();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? id;
            private PeriodType? periodTypeCode;
            private int? periodTypeCount;
            private long? usageCountLimit;
            private string name;
            private decimal? price;
            private bool? enable;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه طرح</param>
            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }
            public PeriodType? GetPeriodTypeCode()
            {
                return periodTypeCode;
            }

            /// <param name="periodTypeCode">کد نوع بازه زمانی</param>
            public Builder SetPeriodTypeCode(PeriodType periodTypeCode)
            {
                this.periodTypeCode = periodTypeCode;
                return this;
            }
            public int? GetPeriodTypeCount()
            {
                return periodTypeCount;
            }

            /// <param name="periodTypeCount">تعداد مورد نظر از بازه زمانی</param>
            public Builder SetPeriodTypeCount(int periodTypeCount)
            {
                this.periodTypeCount = periodTypeCount;
                return this;
            }
            public long? GetUsageCountLimit()
            {
                return usageCountLimit;
            }

            /// <param name="usageCountLimit">محدودیت تعداد دفعات استفاده</param>
            public Builder SetUsageCountLimit(long usageCountLimit)
            {
                this.usageCountLimit = usageCountLimit;
                return this;
            }
            public string GetName()
            {
                return name;
            }

            /// <param name="name">نام طرح</param>
            public Builder SetName(string name)
            {
                this.name = name;
                return this;
            }
            public decimal? GetPrice()
            {
                return price;
            }

            /// <param name="price">قیمت طرح</param>
            public Builder SetPrice(decimal price)
            {
                this.price = price;
                return this;
            }
            public bool? GetEnable()
            {
                return enable;
            }

            /// <param name="enable">فعال/غیرفعالسازی طرح</param>
            public Builder SetEnable(bool enable)
            {
                this.enable = enable;
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

            public UpdateSubscriptionPlanVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UpdateSubscriptionPlanVo(this);
            }
        }
    }
}
