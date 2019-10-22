using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Base_Service.Model.ValueObject
{
    public class UpdateTagTreeVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public string Name { get; }
        public long? ParentId { get; }
        public bool? Enable { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public UpdateTagTreeVo(Builder builder)
        {
            Name = builder.GetName();
            Id = builder.GetId();
            ParentId = builder.GetParentId();
            Enable = builder.GetEnable();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? id;
            private string name;
            private long? parentId;
            private bool? enable;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetName()
            {
                return name;
            }

            /// <param name="name">نام برچسب</param>
            public Builder SetName(string name)
            {
                this.name = name;
                return this;
            }
            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه برچسب</param>
            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }
            public long? GetParentId()
            {
                return parentId;
            }

            /// <param name="categoryId">شناسه والد برچسب</param>
            public Builder SetParentId(long parentId)
            {
                this.parentId = parentId;
                return this;
            }
            public bool? GetEnable()
            {
                return enable;
            }

            /// <param name="enable">فعال/غیرفعال کردن برچسب</param>
            public Builder SetEnable(bool enable)
            {
                this.enable = enable;
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

            public UpdateTagTreeVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UpdateTagTreeVo(this);
            }
        }
    }
}
