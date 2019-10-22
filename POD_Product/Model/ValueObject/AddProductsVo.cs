using Newtonsoft.Json;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Model.ValueObject;
using POD_Product.Base;

namespace POD_Product.Model.ValueObject
{
    public class AddProductsVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BizId { get; }
        public string Data { get; }
        public string PreviewImage { get; }
        public string CurrencyCode { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public AddProductsVo(Builder builder)
        {
            BizId = builder.GetBizId();
            Data = builder.GetData();
            PreviewImage = builder.GetPreviewImage();
            CurrencyCode = builder.GetCurrencyCode();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private long? bizId;

            [Required]
            private string data;
            private string previewImage;
            private string currencyCode;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetBizId()
            {
                return bizId;
            }

            /// <param name="bizId">شناسه کسب و کار - دسترسی ادمین می خواهد </param>
            public Builder SetBizId(long bizId)
            {
                this.bizId = bizId;
                return this;
            }
            public string GetPreviewImage()
            {
                return previewImage;
            }

            /// <param name="previewImage">آدرس تصویر محصول</param>
            public Builder SetPreviewImage(string previewImage)
            {
                this.previewImage = previewImage;
                return this;
            }
            public string GetData()
            {
                return data;
            }

            /// <param name="data">اطلاعات محصول جهت ثبت</param>
            public Builder SetData(List<MultiProductVo> data)
            {
                var productDic = new List<Dictionary<string, object>>();
                foreach (var item in data)
                {
                    productDic.Add(item.ToDictionary(PodParameterName.ParametersName));
                }

                var jsonString = JsonConvert.SerializeObject(productDic, Formatting.Indented).Replace("[]","");

                if (!string.IsNullOrEmpty(this.data))
                {
                    this.data = this.data.TrimEnd(']') + " , " + jsonString.TrimStart('[').TrimEnd(']') + " ] ";
                }
                else this.data = jsonString;
                return this;
            }

            /// <param name="data">اطلاعات زیر محصول جهت ثبت</param>
            public Builder SetData(List<SubProductVo> data)
            {
                var productDic = new List<Dictionary<string, object>>();
                foreach (var item in data)
                {
                    productDic.Add(item.ToDictionary(PodParameterName.ParametersName));
                }
                var jsonString = JsonConvert.SerializeObject(productDic, Formatting.Indented).Replace("[]", "");

                if (!string.IsNullOrEmpty(this.data))
                {
                    this.data = this.data.TrimEnd(']') + " , " + jsonString.TrimStart('[').TrimEnd(']') + " ] ";
                }
                else this.data = jsonString;
                return this;
            }

            public string GetCurrencyCode()
            {
                return currencyCode;
            }

            /// <param name="currencyCode">کد ارز</param>
            public Builder SetCurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode;
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

            public AddProductsVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AddProductsVo(this);
            }
        }
    }
}
