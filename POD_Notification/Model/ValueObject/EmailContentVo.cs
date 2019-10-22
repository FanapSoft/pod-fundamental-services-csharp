using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class EmailContentVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string[] To { get; }
        public string ReplyAddress { get; }
        public string Body { get; }
        public string Subject { get; }
        public string[] Cc { get; }
        public string[] Bcc { get; }
        public string[] FileHashes { get; }
        public string Scheduler { get; }


        public EmailContentVo(Builder builder)
        {
            To = builder.GetTo();
            ReplyAddress = builder.GetReplyAddress();
            Body = builder.GetBody();
            Subject = builder.GetSubject();
            Cc = builder.GetCc();
            Bcc = builder.GetBcc();
            FileHashes = builder.GetFileHashes();
            Scheduler = builder.GetScheduler();
        }

        public class Builder
        {
            [Required] private string[] to;
            private string replyAddress;
            private string body;
            private string subject;
            private string[] cc;
            private string[] bcc;
            private string[] fileHashes;
            private string scheduler;

            public string[] GetTo()
            {
                return to;
            }

            /// <param name="to">آدرس ایمیل افراد دریافت ­کننده</param>
            public Builder SetTo(string[] to)
            {
                this.to = to;
                return this;
            }
            public string GetReplyAddress()
            {
                return replyAddress;
            }

            /// <param name="replyAddress">آدرس جواب</param>
            public Builder SetReplyAddress(string replyAddress)
            {
                this.replyAddress = replyAddress;
                return this;
            }
            public string GetBody()
            {
                return body;
            }

            /// <param name="body"> بدنه ایمیل </param>
            public Builder SetBody(string body)
            {
                this.body = body;
                return this;
            }
            public string GetSubject()
            {
                return subject;
            }

            /// <param name="subject">موضوع ایمیل</param>
            public Builder SetSubject(string subject)
            {
                this.subject = subject;
                return this;
            }
            public string[] GetCc()
            {
                return cc;
            }

            /// <param name="cc">cc آدرس های</param>
            public Builder SetCc(string[] cc)
            {
                this.cc = cc;
                return this;
            }
            public string[] GetBcc()
            {
                return bcc;
            }

            /// <param name="bcc">bcc آدرس های</param>
            public Builder SetBcc(string[] bcc)
            {
                this.bcc = bcc;
                return this;
            }
            public string[] GetFileHashes()
            {
                return fileHashes;
            }

            /// <param name="fileHashes">Pod Space های مربوط به فایل­ های ذخیره شده در Hash</param>
            public Builder SetFileHashes(string[] fileHashes)
            {
                this.fileHashes = fileHashes;
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

            public EmailContentVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new EmailContentVo(this);
            }
        }
    }
}
