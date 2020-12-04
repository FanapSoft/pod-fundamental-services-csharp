using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Notification.Base.Enum;

namespace POD_Notification.Model.ValueObject
{
    public class PushNotificationListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Offset { get; }
        public int? Size { get; }
        public NotificationOrderField? OrderBy { get; }
        public OrderType? Order { get; }
        public NotificationFilterField? Filter { get; }
        public string FilterValue { get; }
        public string ApiToken { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public PushNotificationListVo(Builder builder)
        {
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            OrderBy = builder.GetOrderBy();
            Order = builder.GetOrder();
            Filter = builder.GetFilter();
            FilterValue = builder.GetFilterValue();
            ApiToken = builder.GetApiToken();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private int? offset;
            private int? size;
            private NotificationOrderField? orderBy;
            private OrderType? order;
            private NotificationFilterField? filter;
            private string filterValue;
            [Required] private string apiToken;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public int? GetOffset()
            {
                return offset;
            }
            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }
            public int? GetSize()
            {
                return size;
            }
            public Builder SetSize(int size)
            {
                this.size = size;
                return this;
            }
            public NotificationOrderField? GetOrderBy()
            {
                return orderBy;
            }

            public Builder SetOrderBy(NotificationOrderField orderBy)
            {
                this.orderBy = orderBy;
                return this;
            }
            public OrderType? GetOrder()
            {
                return order;
            }

            public Builder SetOrder(OrderType order)
            {
                this.order = order;
                return this;
            }
            public NotificationFilterField? GetFilter()
            {
                return filter;
            }

            public Builder SetFilter(NotificationFilterField filter)
            {
                this.filter = filter;
                return this;
            }
            public string GetFilterValue()
            {
                return filterValue;
            }

            public Builder SetFilterValue(string filterValue)
            {
                this.filterValue = filterValue;
                return this;
            }
            public string GetApiToken()
            {
                return apiToken;
            }

            /// <param name="apiToken">AccessApiToken Or ApiApiToken         
            /// توکنی که بعد از ورود به سیستم یا از پنل کسب و کار دریافت شده است
            /// </param>
            public Builder SetApiToken(string apiToken)
            {
                this.apiToken = apiToken;
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

            public PushNotificationListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PushNotificationListVo(this);
            }
        }
    }
}
