using System;
using System.Collections.Generic;
using POD_Base_Service;
using POD_Base_Service.Result;
using POD_Product.Base;
using POD_Product.Model.ServiceOutput;
using POD_Product.Model.ValueObject;
using RestSharp;

namespace POD_Product
{
    public static class ProductService
    {
        public static void AddProduct(SingleProductVo addProductVo, Action<IRestResponse<ResultSrv<ProductSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.AddProduct, addProductVo,PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ProductSrv>>(request));
        }
        public static void AddSubProduct(SubProductVo addSubProductVo, Action<IRestResponse<ResultSrv<ProductSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.AddProduct, addSubProductVo,PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ProductSrv>>(request));
        }
        public static void AddProducts(AddProductsVo addProductsVo, Action<IRestResponse<ResultSrv<List<ProductSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.AddProducts, addProductsVo,PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<ProductSrv>>>(request));
        }
        public static void UpdateProduct(UpdateProductVo updateProductVo, Action<IRestResponse<ResultSrv<ProductSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.UpdateProduct, updateProductVo,PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ProductSrv>>(request));
        }
        public static void UpdateProducts(UpdateProductsVo updateProductsVo, Action<IRestResponse<ResultSrv<List<ProductSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.UpdateProducts, updateProductsVo,PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<ProductSrv>>>(request));
        }
        public static void GetProductList(ProductListVo productListVo, Action<IRestResponse<ResultSrv<List<ProductSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ProductList, productListVo,PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<ProductSrv>>>(request));
        }
        public static void GetProductList(BusinessProductListVo businessProductListVo, Action<IRestResponse<ResultSrv<List<ProductSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.BusinessProductList, businessProductListVo,PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<ProductSrv>>>(request));
        }
        public static void GetAttributeTemplateList(AttributeTemplateListVo attributeTemplateListVo, Action<IRestResponse<ResultSrv<List<AttributeTemplateSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.AttributeTemplateList, attributeTemplateListVo,PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<AttributeTemplateSrv>>>(request));
        }
        public static void SearchProduct(SearchProductVo searchProductVo, Action<IRestResponse<ResultSrv<SearchProductSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.SearchProduct, searchProductVo,PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<SearchProductSrv>>(request));
        }
        public static void SearchSubProduct(SearchSubProductVo searchSubProductVo, Action<IRestResponse<ResultSrv<List<ProductSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.SearchSubProduct, searchSubProductVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<ProductSrv>>>(request));
        }
    }
}
