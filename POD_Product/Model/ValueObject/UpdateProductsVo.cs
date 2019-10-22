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
    public class UpdateProductsVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public bool? ChangePreview  { get; }
        public string Data { get; }
        public string PreviewImage { get; }
        public string CurrencyCode { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public UpdateProductsVo(Builder builder)
        {
            ChangePreview  = builder.GetChangePreview();
            Data = builder.GetData();
            PreviewImage = builder.GetPreviewImage();
            CurrencyCode = builder.GetCurrencyCode();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private bool? changePreview;

            [Required]
            private string data;
            private string previewImage;
            private string currencyCode;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public bool? GetChangePreview()
            {
                return changePreview;
            }

            /// <param name="changePreview">وارد شود true در صورت نیاز به ویرایش تصویر محصول </param>
            public Builder SetChangePreview(bool changePreview)
            {
                this.changePreview = changePreview;
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
            public Builder SetData(List<UpdateMultiProductVo> data)
            {
                var productDic = new List<Dictionary<string, object>>();
                foreach (var item in data)
                {
                    productDic.Add(item.ToDictionary(PodParameterName.ParametersName));
                }
                var jasonString = JsonConvert.SerializeObject(productDic, Formatting.Indented).Replace("[]", "");
                this.data = jasonString;
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

            public UpdateProductsVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UpdateProductsVo(this);
            }
        }
    }
}
