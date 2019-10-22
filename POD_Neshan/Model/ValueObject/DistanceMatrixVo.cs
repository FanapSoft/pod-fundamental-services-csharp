using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Neshan.Model.ValueObject
{
    public class DistanceMatrixVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Origins { get; }
        public string Destinations { get; }
        public ExternalServiceCallVo ServiceCallParameters { get; }

        public DistanceMatrixVo(Builder builder)
        {
            Origins = builder.GetOrigins();
            Destinations = builder.GetDestinations();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string origins;

            [Required]
            private string destinations;

            [Required]
            private ExternalServiceCallVo serviceCallParameters;

            public string GetOrigins()
            {
                return origins;
            }

            /// <param name="origins">نقطه شروع مسیریابی</param>
            public Builder SetOrigins(PointD[] origins)
            {
                for (var i = 0; i < origins.Length; i++)
                {
                    this.origins += $"{origins[i].X.ToString(CultureInfo.InvariantCulture)},{origins[i].Y.ToString(CultureInfo.InvariantCulture)}|";
                }

                this.origins = this.origins.TrimEnd('|');
                return this;
            }
            public string GetDestinations()
            {
                return destinations;
            }

            /// <param name="destinations">نقطه پایان مسیر</param>
            public Builder SetDestinations(PointD[] destinations)
            {
                for (var i = 0; i < destinations.Length; i++)
                {
                    this.destinations += $"{destinations[i].X.ToString(CultureInfo.InvariantCulture)},{destinations[i].Y.ToString(CultureInfo.InvariantCulture)}|";
                }

                this.destinations = this.destinations.TrimEnd('|');
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

            public DistanceMatrixVo Build()
            {
                var hasErrorFields = this.ValidateFieldAndPropertyByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new DistanceMatrixVo(this);
            }
        }
    }
}
