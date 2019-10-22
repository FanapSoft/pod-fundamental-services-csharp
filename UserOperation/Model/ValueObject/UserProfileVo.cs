using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_UserOperation.Model.ValueObject
{
    public class UserProfileVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string ClientId { get; }
        public string ClientSecret { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public UserProfileVo(Builder builder)
        {
            ClientId = builder.GetClientId();
            ClientSecret = builder.GetClientSecret();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string clientId;
            private string clientSecret;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetClientId()
            {
                return clientId;
            }
            public Builder SetClientId(string clientId)
            {
                this.clientId = clientId;
                return this;
            }
            public string GetClientSecret()
            {
                return clientSecret;
            }
            public Builder SetClientSecret(string clientSecret)
            {
                this.clientSecret = clientSecret;
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

            public UserProfileVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UserProfileVo(this);
            }
        }
    }
}
