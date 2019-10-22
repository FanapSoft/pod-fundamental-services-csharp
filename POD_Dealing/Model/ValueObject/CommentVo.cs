using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Dealing.Model.ValueObject
{
    public class CommentVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? CommentId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public CommentVo(Builder builder)
        {
            CommentId = builder.GetCommentId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long? commentId;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetCommentId()
            {
                return commentId;
            }

            public Builder SetCommentId(long commentId)
            {
                this.commentId = commentId;
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

            public CommentVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new CommentVo(this);
            }
        }
    }
}
