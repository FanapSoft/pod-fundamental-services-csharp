using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Dealing.Model.ValueObject
{
    public class BusinessFavoriteVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BusinessId { get; }
        public bool? DisFavorite { get; }
        public string Token { get; }

        public BusinessFavoriteVo(Builder builder)
        {
            BusinessId = builder.GetBusinessId();
            DisFavorite = builder.GetDisFavorite();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private long? businessId;

            [Required]
            private bool? disFavorite;

            [Required]
            private string token;

            public long? GetBusinessId()
            {
                return businessId;
            }

            /// <param name="businessId">شناسه کسب و کار </param>
            public Builder SetBusinessId(long businessId)
            {
                this.businessId = businessId;
                return this;
            }
            public bool? GetDisFavorite()
            {
                return disFavorite;
            }

            /// <param name="disfavorite">
            ///باشد به علاقه مندی ها اضافه می شود false اگر مقداردهی نشود یا مقدار
            ///باشد از علاقه مندی ها حذف می شود true اگر
            /// </param>
            public Builder SetDisFavorite(bool disFavorite)
            {
                this.disFavorite = disFavorite;
                return this;
            }
            public string GetToken()
            {
                return token;
            }

            /// <param name="token">توکنی که بعد از ورود به سیستم دریافت کرده اید - AccessToken</param>
            public Builder SetToken(string token)
            {
                this.token = token;
                return this;
            }

            public BusinessFavoriteVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new BusinessFavoriteVo(this);
            }
        }
    }
}
