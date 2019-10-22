using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Base_Service.Model.ValueObject
{
    public class UpdateTagTreeCategoryVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public string Name { get; }
        public string Desc { get; }
        public bool? Enable { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public UpdateTagTreeCategoryVo(Builder builder)
        {
            Id = builder.GetId();
            Name = builder.GetName();
            Desc = builder.GetDesc();
            Enable = builder.GetEnable();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? id;
            private string name;
            private string desc;
            private bool? enable;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه دسته بندی</param>
            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }
            public string GetName()
            {
                return name;
            }

            /// <param name="name">نام دسته بندی</param>
            public Builder SetName(string name)
            {
                this.name = name;
                return this;
            }
            public string GetDesc()
            {
                return desc;
            }

            /// <param name="desc">توضیحات دسته بندی</param>
            public Builder SetDesc(string desc)
            {
                this.desc = desc;
                return this;
            }
            public bool? GetEnable()
            {
                return enable;
            }

            /// <param name="enable">فعال یا غیر فعال کردن دسته بندی</param>
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

            public UpdateTagTreeCategoryVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UpdateTagTreeCategoryVo(this);
            }
        }
    }
}
