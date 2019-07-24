using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Dealing.Model.ValueObject
{
    public class UserBusinessInfosVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long[] Id { get; }
        public string Token { get; }

        public UserBusinessInfosVo(Builder builder)
        {
            Id = builder.GetId();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private long[] id;

            [Required]
            private string token;

            public long[] GetId()
            {
                return id;
            }

            /// <param name="id">لیست شناسه های کسب و کار</param>
            public Builder SetId(long[] id)
            {
                this.id = id;
                return this;
            }
            public string GetToken()
            {
                return token;
            }

            /// <param name="token">AccessToken Or ApiToken         
            /// توکنی که بعد از ورود به سیستم یا از پنل کسب و کار دریافت شده است
            /// </param>
            public Builder SetToken(string token)
            {
                this.token = token;
                return this;
            }

            public UserBusinessInfosVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UserBusinessInfosVo(this);
            }
        }
    }
}
