using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Base_Service.Model.ValueObject
{
    public class AddTagTreeCategoryVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Name { get; }
        public string Desc { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public AddTagTreeCategoryVo(Builder builder)
        {
            Name = builder.GetName();
            Desc = builder.GetDesc();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private string name;
            private string desc;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetName()
            {
                return name;
            }

            /// <param name="name">نام دسته بندی</param>
            public Builder SetName(string name)
            {
                this.name =name;
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
            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public AddTagTreeCategoryVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AddTagTreeCategoryVo(this);
            }
        }
    }
}
