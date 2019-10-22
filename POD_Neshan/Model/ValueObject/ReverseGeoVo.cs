using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Neshan.Model.ValueObject
{
    public class ReverseGeoVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public double? Lat { get; }
        public double? Lng { get; }
        public ExternalServiceCallVo ServiceCallParameters { get; }

        public ReverseGeoVo(Builder builder)
        {
            Lat = builder.GetLat();
            Lng = builder.GetLng();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
    {
            [Required]
            private double? lat;

            [Required]
            private double? lng;

            [Required]
            private ExternalServiceCallVo serviceCallParameters;

            public double? GetLat()
            {
                return lat;
            }

            /// <param name="lat">عرض جغرافیایی مرکز جستجو </param>
            public Builder SetLat(double lat)
            {
                this.lat = lat;
                return this;
            }
            public double? GetLng()
            {
                return lng;
            }

            /// <param name="lng">طول جغرافیایی مرکز جستجو </param>
            public Builder SetLng(double lng)
            {
                this.lng = lng;
                return this;
            }
            public ExternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(ExternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public ReverseGeoVo Build()
            {
                var hasErrorFields = this.ValidateFieldAndPropertyByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ReverseGeoVo(this);
            }
        }
    }
}
