using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace Booking_Service.Model.ValueObject
{
    public class HotelInventoryVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? CityId { get; }
        public string ApiVersion { get; }
        public string Lang { get; }
        public string Authorization { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public HotelInventoryVo(Builder builder)
        {
            CityId = builder.GetCityId();
            ApiVersion = builder.GetApiVersion();
            Lang = builder.GetLang();
            Authorization = builder.GetAuthorization();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string apiVersion;
            private string lang;
            private long? cityId;
            [Required] private string authorization;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetCityId()
            {
                return cityId;
            }

            public Builder SetCityId(long? cityId)
            {
                this.cityId = cityId;
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
            public string GetApiVersion()
            {
                return apiVersion;
            }

            public Builder SetApiVersion(string apiVersion)
            {
                this.apiVersion = apiVersion;
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

            public HotelInventoryVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new HotelInventoryVo(this);
            }
        }
    }
}
