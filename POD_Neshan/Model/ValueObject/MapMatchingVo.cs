using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Neshan.Model.ValueObject
{
    public class MapMatchingVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Path { get; }
        public ExternalServiceCallVo ServiceCallParameters { get; }

        public MapMatchingVo(Builder builder)
        {
            Path = builder.GetPath();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string path;

            [Required]
            private ExternalServiceCallVo serviceCallParameters;

            public string GetPath()
            {
                return path;
            }

            /// <param name="path">نقاطی که باید به یک مسیر نگاشت شوند</param>
            public Builder SetPath(PointD[] path)
            {
                for (var i = 0; i < path.Length; i++)
                {
                    this.path += $"{path[i].X.ToString(CultureInfo.InvariantCulture)},{path[i].Y.ToString(CultureInfo.InvariantCulture)}|";
                }

                this.path = this.path.TrimEnd('|');
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

            public MapMatchingVo Build()
            {
                var hasErrorFields = this.ValidateFieldAndPropertyByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new MapMatchingVo(this);
            }
        }
    }
}
