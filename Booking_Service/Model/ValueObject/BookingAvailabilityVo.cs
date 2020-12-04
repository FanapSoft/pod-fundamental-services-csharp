using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace Booking_Service.Model.ValueObject
{
    public class BookingAvailabilityVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string ApiVersion { get; }
        public string HotelId { get; }
        public string StartDate { get; }
        public string EndDate { get; }
        public string Lang { get; }
        public string Currency { get; }
        public string UserCountry { get; }
        public string QueryKey { get; }
        public string DeviceType { get; }
        public  List<RequestedRoomVo> Rooms { get; }
        public string Authorization { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public BookingAvailabilityVo(Builder builder)
        {
            HotelId = builder.GetHotelId();
            StartDate = builder.GetStartDate();
            EndDate = builder.GetEndDate();
            Lang = builder.GetLang();
            Currency = builder.GetCurrency();
            UserCountry = builder.GetUserCountry();
            ApiVersion = builder.GetApiVersion();
            QueryKey = builder.GetQueryKey();
            DeviceType = builder.GetDeviceType();
            Rooms = builder.GetRooms();
            Authorization = builder.GetAuthorization();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string hotelId;
            private string startDate;
            private string endDate;
            private string lang;
            private string currency;
            private string userCountry;
            private string apiVersion;
            private string queryKey;
            private string deviceType;
            private List<RequestedRoomVo> rooms;
            [Required] private string authorization;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetHotelId()
            {
                return hotelId;
            }

            public Builder SetHotelId(string hotelId)
            {
                this.hotelId = hotelId;
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
            public List<RequestedRoomVo> GetRooms()
            {
                return rooms;
            }

            public Builder SetRooms(List<RequestedRoomVo> rooms)
            {
                this.rooms = rooms;
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

            public BookingAvailabilityVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new BookingAvailabilityVo(this);
            }
        }
    }
}
