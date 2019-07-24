using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Dealing.Model.ValueObject
{
    public class ConfirmCommentVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? CommentId { get; }
        public string Token { get; }

        public ConfirmCommentVo(Builder builder)
        {
            CommentId = builder.GetCommentId();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private long? commentId;

            [Required]
            private string token;

            public long? GetCommentId()
            {
                return commentId;
            }

            public Builder SetCommentId(long commentId)
            {
                this.commentId = commentId;
                return this;
            }
            public string GetToken()
            {
                return token;
            }

            /// <param name="token">توکنی که از پنل کسب و کار دریافت شده است - ApiToken</param>
            public Builder SetToken(string token)
            {
                this.token = token;
                return this;
            }

            public ConfirmCommentVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ConfirmCommentVo(this);
            }
        }
    }
}
