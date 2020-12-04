using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace Booking_Service.Model.ValueObject
{
    public class AuthorizeVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Authorization { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public AuthorizeVo(Builder builder)
        {
            Authorization = builder.GetAuthorization();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private string authorization;
            [Required] private InternalServiceCallVo serviceCallParameters;

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

            public AuthorizeVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AuthorizeVo(this);
            }
        }
    }
}
