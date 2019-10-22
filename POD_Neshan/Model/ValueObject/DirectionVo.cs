using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Neshan.Model.ValueObject
{
    public class DirectionVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Origin { get; }
        public string Destination { get; }
        public string WayPoints { get; }
        public bool? AvoidTrafficZone { get; }
        public bool? AvoidOddEvenZone { get; }
        public bool? Alternative { get; }
        public ExternalServiceCallVo ServiceCallParameters { get; }

        public DirectionVo(Builder builder)
        {
            Origin = builder.GetOrigin();
            Destination = builder.GetDestination();
            WayPoints = builder.GetWayPoints();
            AvoidTrafficZone = builder.GetAvoidTrafficZone();
            AvoidOddEvenZone = builder.GetAvoidOddEvenZone();
            Alternative = builder.GetAlternative();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string origin;

            [Required]
            private string destination;
            private string wayPoints;
            private bool? avoidTrafficZone;
            private bool? avoidOddEvenZone;
            private bool? alternative;

            [Required]
            private ExternalServiceCallVo serviceCallParameters;

            public string GetOrigin()
            {
                return origin;
            }

            /// <param name="origin">نقطه شروع مسیریابی</param>
            public Builder SetOrigin(PointD origin)
            {
                this.origin = $"{origin.X.ToString(CultureInfo.InvariantCulture)},{origin.Y.ToString(CultureInfo.InvariantCulture)}";
                return this;
            }
            public string GetDestination()
            {
                return destination;
            }

            /// <param name="destination">نقطه پایان مسیر</param>
            public Builder SetDestination(PointD destination)
            {
                this.destination = $"{destination.X.ToString(CultureInfo.InvariantCulture)},{destination.Y.ToString(CultureInfo.InvariantCulture)}";
                return this;
            }
            public string GetWayPoints()
            {
                return wayPoints;
            }

            /// <param name="wayPoints">نقاط میانی مسیر</param>
            public Builder SetWayPoints(PointD[] wayPoints)
            {
                for (var i = 0; i < wayPoints.Length; i++)
                {
                    this.wayPoints += $"{wayPoints[i].X.ToString(CultureInfo.InvariantCulture)},{wayPoints[i].Y.ToString(CultureInfo.InvariantCulture)}|";
                }

                this.wayPoints = this.wayPoints.TrimEnd('|');
                return this;
            }
            public bool? GetAvoidTrafficZone()
            {
                return avoidTrafficZone;
            }

            /// <param name="avoidTrafficZone">مسیر از داخل طرح ترافیک عبور نخواهد کرد. همچین در صورتی که مقصد داخل طرح ترافیک باشد هیچ مسیری پیدا نمی‌شود</param>
            public Builder SetAvoidTrafficZone(bool avoidTrafficZone)
            {
                this.avoidTrafficZone = avoidTrafficZone;
                return this;
            }
            public bool? GetAvoidOddEvenZone()
            {
                return avoidOddEvenZone;
            }

            /// <param name="avoidOddEvenZone">مسیر از داخل طرح زوج و فرد عبور نخواهد کرد. همچین در صورتی که مقصد داخل طرح ترافیک باشد هیچ مسیری پیدا نمی‌شود</param>
            public Builder SetAvoidOddEvenZone(bool avoidOddEvenZone)
            {
                this.avoidOddEvenZone = avoidOddEvenZone;
                return this;
            }
            public bool? GetAlternative()
            {
                return alternative;
            }

            /// <param name="alternative">در صورتی که مسیرهای جایگزین برای نقاط مشخص شده وجود داشته باشد این مسیرها در پاسخ ارائه خواهند شد </param>
            public Builder SetAlternative(bool alternative)
            {
                this.alternative = alternative;
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

            public DirectionVo Build()
            {
                var hasErrorFields = this.ValidateFieldAndPropertyByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new DirectionVo(this);
            }
        }
    }
}
