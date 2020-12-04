using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace Booking_Service.Model.ValueObject
{
    public class HotelAvailabilityVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long[] HotelIds { get; }
        public string StartDate { get; }
        public string EndDate { get; }
        public string Lang { get; }
        public string Currency { get; }
        public string UserCountry { get; }
        public long? CityId { get; }
        public string ApiVersion { get; }
        public string QueryKey { get; }
        public string DeviceType { get; }
        public string Authorization { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public HotelAvailabilityVo(Builder builder)
        {
            HotelIds = builder.GetHotelIds();
            StartDate = builder.GetStartDate();
            EndDate = builder.GetEndDate();
            Lang = builder.GetLang();
            Currency = builder.GetCurrency();
            UserCountry = builder.GetUserCountry();
            CityId = builder.GetCityId();
            ApiVersion = builder.GetApiVersion();
            QueryKey = builder.GetQueryKey();
            DeviceType = builder.GetDeviceType();
            Authorization = builder.GetAuthorization();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private long[] hotelIds;
            private string startDate;
            private string endDate;
            private string lang;
            private string currency;
            private string userCountry;
            private long? cityId;
            private string apiVersion;
            private string queryKey;
            private string deviceType;
            [Required] private string authorization;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long[] GetHotelIds()
            {
                return hotelIds;
            }

            public Builder SetHotelIds(long[] hotelIds)
            {
                this.hotelIds = hotelIds;
                return this;
            }

            public string GetLang()
            {
                return lang;
            }

            public Builder SetLang(string lang)
            {
                this.lang = lang;
                return this;
            }

            public string GetStartDate()
            {
                return startDate;
            }

            /// <param name="startDate">از تاریخ</param>
            public Builder SetStartDate(string startDate)
            {
                this.startDate = startDate;
                return this;
            }

            /// <param name="startDate">از تاریخ</param>
            public Builder SetStartDate(DateTime startDate)
            {
                this.startDate = startDate.ToShamsiDate();
                return this;
            }

            public string GetEndDate()
            {
                return endDate;
            }

            /// <param name="endDate">تا تاریخ</param>
            public Builder SetEndDate(string endDate)
            {
                this.endDate = endDate;
                return this;
            }

            /// <param name="endDate">تا تاریخ</param>
            public Builder SetEndDate(DateTime endDate)
            {
                this.endDate = endDate.ToShamsiDate();
                return this;
            }
            public string GetCurrency()
            {
                return currency;
            }

            public Builder SetCurrency(string currency)
            {
                this.currency = currency;
                return this;
            }
            public string GetUserCountry()
            {
                return userCountry;
            }

            public Builder SetUserCountry(string userCountry)
            {
                this.userCountry = userCountry;
                return this;
            }

            public long? GetCityId()
            {
                return cityId;
            }

            public Builder SetCityId(long? cityId)
            {
                this.cityId = cityId;
                return this;
            }
            public string GetApiVersion()
            {
                return apiVersion;
            }

            public Builder SetApiVersion(string apiVersion)
            {
                this.apiVersion = apiVersion;
                return this;
            }
            public string GetQueryKey()
            {
                return queryKey;
            }

            public Builder SetQueryKey(string queryKey)
            {
                this.queryKey = queryKey;
                return this;
            }
            public string GetDeviceType()
            {
                return deviceType;
            }

            public Builder SetDeviceType(string deviceType)
            {
                this.deviceType = deviceType;
                return this;
            }
            public string GetAuthorization()
            {
                return authorization;
            }

            public Builder SetAuthorization(string authorization)
            {
                this.authorization = authorization;
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

            public HotelAvailabilityVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new HotelAvailabilityVo(this);
            }
        }
    }
}
