using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class PushNotificationByAppIdContentVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Title { get; }
        public string Text { get; }
        public string AppId { get; }
        public string Scheduler { get; }

        public PushNotificationByAppIdContentVo(Builder builder)
        {
            Title = builder.GetTitle();
            Text = builder.GetText();
            AppId = builder.GetAppId();
            Scheduler = builder.GetScheduler();
        }

        public class Builder
        {
            [Required] private string appId;
            private string title;
            private string text;
            private string scheduler;

            public string GetAppId()
            {
                return appId;
            }

            /// <param name="appId">شناسه اپلیکیشن مورد نظر</param>
            public Builder SetAppId(string appId)
            {
                this.appId = appId;
                return this;
            }
            public string GetTitle()
            {
                return title;
            }

            /// <param name="title">عنوان پیام</param>
            public Builder SetTitle(string title)
            {
                this.title = title;
                return this;
            }

            public string GetText()
            {
                return text;
            }

            /// <param name="text">محتوای پیام</param>
            public Builder SetText(string text)
            {
                this.text = text;
                return this;
            }

            public string GetScheduler()
            {
                return scheduler;
            }

            /// <param name="scheduler">اگر نوتیفیکیشن لازم است در روز و ساعت خاصی ارسال شود این فیلد را مقداردهی نمایید</param>
            public Builder SetScheduler(DateTime scheduler)
            {
                this.scheduler = scheduler.ToString("yyyy-MM-dd HH:mm");
                return this;
            }

            public PushNotificationByAppIdContentVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PushNotificationByAppIdContentVo(this);
            }
        }
    }
}
