using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class PushNotificationByPeerIdContentVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long[] PeerId { get; }
        public string Title { get; }
        public string Text { get; }
        public string ExtraData { get; }
        public string Scheduler { get; }

        public PushNotificationByPeerIdContentVo(Builder builder)
        {
            PeerId = builder.GetPeerId();
            Title = builder.GetTitle();
            Text = builder.GetText();
            ExtraData = builder.GetExtraData();
            Scheduler = builder.GetScheduler();
        }

        public class Builder
        {
            [Required]
            private long[] peerId;
            private string title;
            private string text;
            private string extraData;
            private string scheduler;

            public long[] GetPeerId()
            {
                return peerId;
            }

            /// <param name="peerId">دریافت کنندگان</param>
            public Builder SetPeerId(long[] peerId)
            {
                this.peerId = peerId;
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
            public string GetExtraData()
            {
                return extraData;
            }

            /// <param name="extraData">محتویات اضافی در صورت نیاز</param>
            public Builder SetExtraData(string extraData)
            {
                this.extraData = extraData;
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

            public PushNotificationByPeerIdContentVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PushNotificationByPeerIdContentVo(this);
            }
        }
    }
}
