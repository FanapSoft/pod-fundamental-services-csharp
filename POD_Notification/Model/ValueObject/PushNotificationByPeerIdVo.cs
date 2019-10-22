﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class PushNotificationByPeerIdVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public PushNotificationByPeerIdContentVo Content { get; }
        public string Token { get; }

        public PushNotificationByPeerIdVo(Builder builder)
        {
            Content = builder.GetContent();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private PushNotificationByPeerIdContentVo content;

            [Required]
            private string token;

            public PushNotificationByPeerIdContentVo GetContent()
            {
                return content;
            }

            /// <param name="content">اطلاعات مورد نیاز برای ارسال پیام</param>
            public Builder SetContent(PushNotificationByPeerIdContentVo content)
            {
                this.content = content;
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
            public PushNotificationByPeerIdVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PushNotificationByPeerIdVo(this);
            }
        }
    }
}