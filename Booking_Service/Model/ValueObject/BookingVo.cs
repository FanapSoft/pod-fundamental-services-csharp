using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace Booking_Service.Model.ValueObject
{
    public class BookingVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string ApiVersion { get; }
        public string HotelId { get; }
        public string ReferenceId { get; }
        public string Authorization { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public BookingVo(Builder builder)
        {
            ApiVersion = builder.GetApiVersion();
            HotelId = builder.GetHotelId();
            ReferenceId = builder.GetReferenceId();
            Authorization = builder.GetAuthorization();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string apiVersion;
            private string hotelId;
            private string referenceId;
            [Required] private string authorization;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetApiVersion()
            {
                return apiVersion;
            }

            public Builder SetApiVersion(string apiVersion)
            {
                this.apiVersion = apiVersion;
                return this;
            }
            public string GetHotelId()
            {
                return hotelId;
            }

            public Builder SetHotelId(string hotelId)
            {
                this.hotelId = hotelId;
                return this;
            }

            public string GetReferenceId()
            {
                return referenceId;
            }

            public Builder SetReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
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

            public BookingVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new BookingVo(this);
            }
        }
    }
}
