using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class ValidationSmsContentVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Receptor { get; }
        public string Token1 { get; }
        public string Token2 { get; }
        public string Token3 { get; }
        public string Template { get; }
        public string Type { get; }

        public ValidationSmsContentVo(Builder builder)
        {
            Receptor = builder.GetReceptor();
            Token1 = builder.GetToken1();
            Token2 = builder.GetToken2();
            Token3 = builder.GetToken3();
            Template = builder.GetTemplate();
            Type = builder.GetType();
        }

        public class Builder
        {
            [Required]
            private string receptor;

            [Required]
            private string token1;
            private string token2;
            private string token3;

            [Required]
            private string template;
            private string type;

            public string GetReceptor()
            {
                return receptor;
            }

            /// <param name="receptor">شماره تلفن دریافت کننده</param>
            public Builder SetReceptor(string receptor)
            {
                this.receptor =receptor;
                return this;
            }
            public string GetToken1()
            {
                return token1;
            }

            /// <param name="token1">این رشته فقط میتواند حاوی کاراکتر های انگلیسی و عدد باشد</param>
            public Builder SetToken1(string token1)
            {
                this.token1 = token1;
                return this;
            }
            public string GetToken2()
            {
                return token2;
            }

            /// <param name="token2">این رشته فقط میتواند حاوی کاراکتر های انگلیسی و عدد باشد</param>
            public Builder SetToken2(string token2)
            {
                this.token2 = token2;
                return this;
            }
            public string GetToken3()
            {
                return token3;
            }

            /// <param name="token3">این رشته فقط میتواند حاوی کاراکتر های انگلیسی و عدد باشد</param>
            public Builder SetToken3(string token3)
            {
                this.token3 = token3;
                return this;
            }
            public string GetTemplate()
            {
                return template;
            }

            public Builder SetTemplate(string template)
            {
                this.template = template;
                return this;
            }
            public string GetType()
            {
                return type;
            }

            public Builder SetType(string type)
            {
                this.type = type;
                return this;
            }

            public ValidationSmsContentVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ValidationSmsContentVo(this);
            }
        }
    }
}
