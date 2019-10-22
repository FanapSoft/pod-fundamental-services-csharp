using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class SmsContentVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Body { get; }
        public string[] MobileNumbers { get; }
        public string Scheduler { get; }

        public SmsContentVo(Builder builder)
        {
            Body = builder.GetBody();
            MobileNumbers = builder.GetMobileNumbers();
            Scheduler = builder.GetScheduler();
        }

        public class Builder
        {
            [Required]
            private string body;

            [Required]
            private string[] mobileNumbers;

            private string scheduler;

            public string GetBody()
            {
                return body;
            }

            /// <param name="body">محتویات پیام ارسالی</param>
            public Builder SetBody(string body)
            {
                this.body = body;
                return this;
            }
            public string[] GetMobileNumbers()
            {
                return mobileNumbers;
            }

            /// <param name="mobileNumbers">شماره­ تلفن­های افراد دریافت کننده پیام</param>
            public Builder SetMobileNumbers(string[] mobileNumbers)
            {
                this.mobileNumbers = mobileNumbers;
                return this;
            }
            public string GetScheduler()
            {
                return scheduler;
            }

            /// <param name="scheduler">اگر پیامک لازم است در روز و ساعت خاصی ارسال شود این فیلد را مقداردهی نمایید</param>
            public Builder SetScheduler(DateTime scheduler)
            {
                this.scheduler = scheduler.ToString("yyyy-MM-dd HH:mm");
                return this;
            }
            public SmsContentVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new SmsContentVo(this);
            }
        }
    }
}
