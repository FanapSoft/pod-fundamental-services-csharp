using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using POD_Product;
using POD_Product.Base.Enum;
using POD_Product.Model.ServiceOutput;
using POD_Product.Model.ValueObject;

namespace POD_Demo
{
    public class ProductMethodInvoke
    {
        private InternalServiceCallVo internalServiceCallVo;
        public ProductMethodInvoke()
        {
            try
            {
                internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    //.SetScVoucherHash()
                    //.SetScApiKey("")
                    .Build();
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ProductSrv> AddProduct()
        {
            try
            {
                var output = new ResultSrv<ProductSrv>();
                var singleProductVo = SingleProductVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetName("newr")
                    .SetAvailableCount(1)
                    .SetPrice(10)
                    .SetDiscount(1)
                    .SetCanComment(true)
                    .SetCanLike(true)
                    .SetEnable(true)
                    .SetDescription("try")
                    //optional
                    //.SetUnlimited(false)
                    //.SetParentProductId(0)
                    //.SetUniqueId("")
                    .SetMetadata("{'test':'true'}")
                    //.SetBusinessId(0)
                    .SetGuildCode("TOILETRIES_GUILD")
                    //.SetAllowUserInvoice(false)
                    //.SetAllowUserPrice(false)
                    //.SetCurrencyCode("")
                    .SetAttTemplateCode("پیراهن مردانه")
                    .SetAttCode(new[] { "gender", "color", "size" })
                    .SetAttValue(new[] { "female", "purpel", "XL" })
                    .SetAttGroup(new[] { false, false, true })
                    .SetLat(10)
                   .SetLng(10)
                   .SetTags(new[] { "terl" })
                    //.SetContent("")
                    //.SetPreviewImage("")
                    //.SetTagTrees(new []{""})
                    //.SetTagTreeCategoryName("")
                    //.SetPreferredTaxRate(0)
                    //.SetQuantityPrecision(0)
                    .Build();
                ProductService.AddProduct(singleProductVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ProductSrv> AddSubProduct()
        {
            try
            {
                var output = new ResultSrv<ProductSrv>();
                var subProductVo = SubProductVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetGroupId(1154)
                    .SetName("")
                    .SetAvailableCount(1)
                    .SetPrice(10)
                    .SetDiscount(1)
                    .SetDescription("try")
                    .SetCanComment(true)
                    .SetCanLike(true)
                    .SetEnable(true)
                    //optional
                    .SetAttCode(new[] { "gender", "color", "size" })
                    .SetAttValue(new[] { "female", "green", "XL" })
                    .SetAttGroup(new[] { false, false, true })
                    //.SetUnlimited(false)
                    //.SetParentProductId(0)
                    //.SetUniqueId("")
                    //.SetMetadata("{'test':'true'}")
                    //.SetBusinessId(0)
                    //.SetGuildCode("TOILETRIES_GUILD")
                    //.SetAllowUserInvoice(false)
                    //.SetAllowUserPrice(false)
                    //.SetCurrencyCode("")
                    //.SetLat(0)
                    //.SetLng(0)
                    //.SetTags(new[] {"terl"})
                    //.SetContent("")
                    //.SetPreviewImage("")
                    //.SetTagTrees(new []{""})
                    //.SetTagTreeCategoryName("")
                    //.SetPreferredTaxRate(0)
                    //.SetQuantityPrecision(0)
                    .Build();
                ProductService.AddSubProduct(subProductVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<List<ProductSrv>> AddProducts()
        {
            try
            {
                var output = new ResultSrv<List<ProductSrv>>();
                var addProductsVo = AddProductsVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetData(new List<MultiProductVo>
                    {
                        MultiProductVo.ConcreteBuilder
                            .SetName("test")
                            .SetAvailableCount(1)
                            .SetPrice(10)
                            .SetDiscount(1)
                            .SetCanComment(true)
                            .SetCanLike(true)
                            .SetEnable(true)
                            .SetDescription("try")
                            //optional
                            //.SetUnlimited(false)
                            //.SetParentProductId(0)
                            //.SetUniqueId("")
                            .SetMetadata("{'test':'true'}")
                            //.SetBusinessId(0)
                            .SetGuildCode("TOILETRIES_GUILD")
                            //.SetAllowUserInvoice(false)
                            //.SetAllowUserPrice(false)
                            //.SetCurrencyCode("")
                            .SetAttTemplateCode("پیراهن مردانه")
                            .SetAttCode(new[] { "gender", "color", "size" })
                            .SetAttValue(new[] { "female", "purpel", "XL" })
                            .SetAttGroup(new[] { false, false, true })
                            .SetLat(10)
                            .SetLng(10)
                            .SetTags(new []{"terl"})
                            //.SetContent("")
                            //.SetPreviewImage("")
                            //.SetTagTrees(new []{""})
                            //.SetTagTreeCategoryName("")
                            //.SetPreferredTaxRate(0)
                            //.SetQuantityPrecision(0)
                            .Build(),

                        MultiProductVo.ConcreteBuilder
                            .SetName("")
                            .SetAvailableCount(2)
                            .SetPrice(10)
                            .SetDiscount(1)
                            .SetCanComment(true)
                            .SetCanLike(true)
                            .SetEnable(true)
                            .SetDescription("")
                            .Build(),

                        //MultiProductVo.ConcreteBuilder
                        //    .SetName("")
                        //    .SetAvailableCount(1)
                        //    .SetPrice(10)
                        //    .SetDiscount(1)
                        //    .SetCanComment(true)
                        //    .SetCanLike(true)
                        //    .SetEnable(true)
                        //    .SetDescription("")
                        //    //optional
                        //    //.SetUnlimited(false)
                        //    //.SetParentProductId(0)
                        //    //.SetUniqueId("")
                        //    .SetMetadata("{'test':'true'}")
                        //    //.SetBusinessId(0)
                        //    .SetGuildCode("TOILETRIES_GUILD")
                        //    .Build()
                    })
                    .SetData(new List<SubProductVo>
                    {
                        SubProductVo.ConcreteBuilder
                            .SetServiceCallParameters(internalServiceCallVo)
                            .SetGroupId(0)
                            .SetName("")
                            .SetAvailableCount(1)
                            .SetPrice(10)
                            .SetDiscount(1)
                            .SetDescription("try")
                            .SetCanComment(true)
                            .SetCanLike(true)
                            .SetEnable(true)
                            //optional
                            .SetAttCode(new[] { "gender", "color", "size" })
                            .SetAttValue(new[] { "female", "purpel", "XL" })
                            .SetAttGroup(new[] { false, false, true })
                            //.SetUnlimited(false)
                            //.SetParentProductId(0)
                            //.SetUniqueId("")
                            //.SetMetadata("{'test':'true'}")
                            //.SetBusinessId(0)
                            //.SetGuildCode("TOILETRIES_GUILD")
                            //.SetAllowUserInvoice(false)
                            //.SetAllowUserPrice(false)
                            //.SetCurrencyCode("")
                            //.SetLat(0)
                            //.SetLng(0)
                            //.SetTags(new[] {"terl"})
                            //.SetContent("")
                            //.SetPreviewImage("")
                            //.SetTagTrees(new []{""})
                            //.SetTagTreeCategoryName("")
                            //.SetPreferredTaxRate(0)
                            //.SetQuantityPrecision(0)
                            .Build()
                    })
                    //.SetBizId(3615)
                    //.SetCurrencyCode("")
                    //.SetPreviewImage("")
                    .Build();
                ProductService.AddProducts(addProductsVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ProductSrv> UpdateProduct()
        {
            try
            {
                var output = new ResultSrv<ProductSrv>();
                var updateProductVo = UpdateProductVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetEntityId(0)
                    .SetName("Hellloooo")
                    .SetAvailableCount(12)
                    .SetPrice(0)
                    .SetDiscount(1)
                    .SetCanComment(false)
                    .SetCanLike(false)
                    .SetEnable(false)
                    .SetDescription("")
                    .SetChangePreview(true)
                    //optional
                    //.SetVersion("")
                    //.SetParentProductId(0)
                    //.SetMetadata("{'test':'true'}")
                    //.SetBusinessId(0)
                    //.SetUnlimited(false)
                    //.SetGuildCode("")
                    //.SetAllowUserInvoice(false)
                    //.SetAllowUserPrice(false)
                    //.SetCurrencyCode("")
                    //.SetCategories(new[] { "" })
                    //.SetAttTemplateCode("پیراهن مردانه")
                    //.SetAttCode(new[] { "gender", "color", "size" })
                    //.SetAttValue(new[] { "female", "pink", "XXL" })
                    //.SetAttGroup(new[] { false, false, true })
                    //.SetGroupId(0)

                    //.SetLat(0)
                    //.SetLng(0)
                    //.SetTags(new[] { "" })
                    //.SetContent("")
                    //.SetPreviewImage("")
                    //.SetTagTrees(new[] { "" })
                    //.SetTagTreeCategoryName("")
                    //.SetPreferredTaxRate(0)
                    //.SetQuantityPrecision(0)
                    .Build();
                ProductService.UpdateProduct(updateProductVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<List<ProductSrv>> UpdateProducts()
        {
            try
            {
                var output = new ResultSrv<List<ProductSrv>>();
                var updateProductsVo = UpdateProductsVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetData(new List<UpdateMultiProductVo>
                    {
                        UpdateMultiProductVo.ConcreteBuilder
                            .SetEntityId(24398)
                            .SetName("")
                            .SetAvailableCount(12)
                            .SetPrice(0)
                            .SetDiscount(1)
                            .SetChangePreview(true)
                            .SetCanComment(false)
                            .SetCanLike(false)
                            .SetEnable(false)
                            .SetDescription("")
                            //optional
                            //.SetVersion("")
                            //.SetParentProductId(0)
                            //.SetMetadata("")
                            //.SetBusinessId(0)
                            //.SetUnlimited(false)
                            //.SetGuildCode("")
                            //.SetAllowUserInvoice(false)
                            //.SetAllowUserPrice(false)
                            //.SetCurrencyCode("")
                            //.SetCategories(new[] { "" })
                            //.SetAttTemplateCode("پیراهن مردانه")
                            //.SetAttCode(new[] { "gender", "color", "size" })
                            //.SetAttValue(new[] { "male", "red", "L" })
                            //.SetAttGroup(new[] { false, false, true })
                            //.SetGroupId(0)
                            //.SetChangePreview(false)
                            //.SetLat(0)
                            //.SetLng(0)
                            //.SetTags(new[] { "" })
                            //.SetContent("")
                            //.SetPreviewImage("")
                            //.SetTagTrees(new[] { "" })
                            //.SetTagTreeCategoryName("")
                            //.SetPreferredTaxRate(0)
                            //.SetQuantityPrecision(0)
                            .Build()

                        ,

                        UpdateMultiProductVo.ConcreteBuilder
                            .SetEntityId(24533)
                            .SetName("")
                            .SetAvailableCount(12)
                            .SetPrice(0)
                            .SetDiscount(1)
                            .SetChangePreview(true)
                            .SetCanComment(false)
                            .SetCanLike(false)
                            .SetEnable(false)
                            .SetDescription("")
                            //optional
                            //.SetVersion("")
                            //.SetParentProductId(0)
                            //.SetMetadata("")
                            //.SetBusinessId(0)
                            //.SetUnlimited(false)
                            //.SetGuildCode("")
                            //.SetAllowUserInvoice(false)
                            //.SetAllowUserPrice(false)
                            //.SetCurrencyCode("")
                            //.SetCategories(new[] { "" })
                            //.SetAttTemplateCode("پیراهن مردانه")
                            //.SetAttCode(new[] { "gender", "color", "size" })
                            //.SetAttValue(new[] { "male", "red", "L" })
                            //.SetAttGroup(new[] { false, false, true })
                            //.SetGroupId(0)
                            //.SetChangePreview(false)
                            //.SetLat(0)
                            //.SetLng(0)
                            //.SetTags(new[] { "" })
                            //.SetContent("")
                            //.SetPreviewImage("")
                            //.SetTagTrees(new[] { "" })
                            //.SetTagTreeCategoryName("")
                            //.SetPreferredTaxRate(0)
                            //.SetQuantityPrecision(0)
                            .Build()
                    })
                    .SetChangePreview(false)
                    //.SetCurrencyCode("")
                    //.SetPreviewImage("")
                    .Build();
                ProductService.UpdateProducts(updateProductsVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<List<ProductSrv>> GetProductList()
        {
            try
            {
                var output = new ResultSrv<List<ProductSrv>>();
                var productListVo = ProductListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    //.SetFirstId(0)
                    //.SetLastId(0)
                    //.SetSize(0)
                    //.SetBusinessId(0)
                    //.SetId(new long[]{0})
                    //.SetUniqueId(new []{""})
                    //.SetCategoryCode(new []{""})
                    //.SetGuildCode(new []{""})
                    //.SetCurrencyCode("")
                    .SetAttributeTemplateCode("پیراهن مردانه")
                    //.SetAttributeCode(new[] { "gender", "color", "size" })
                    //.SetAttributeValue(new[] { "male", "red", "L" })
                    //.SetOrderByLike(OrderType.asc)
                    //.SetOrderBySale(OrderType.asc)
                    //.SetOrderByPrice(OrderType.asc)
                    //.SetTags(new[] { "" })
                    //.SetTagTrees(new[] { "" })
                    .Build();
                ProductService.GetProductList(productListVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<List<ProductSrv>> GetBusinessProductList()
        {
            try
            {
                var output = new ResultSrv<List<ProductSrv>>();
                var businessProductListVo = BusinessProductListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    //.SetFirstId(0)
                    //.SetLastId(0)
                    //.SetSize(0)
                    //.SetBusinessId(0)
                    //.SetId(new long[] { 0 })
                    //.SetUniqueId(new[] { "" })
                    //.SetCategoryCode(new[] { "" })
                    //.SetGuildCode(new[] { "ENTERTAINMENT_GUILD" })
                    //.SetCurrencyCode("")
                    .SetAttributeTemplateCode("")
                    .SetAttributeCode(new[] { "" })
                    .SetAttributeValue(new[] { "" })
                    //.SetOrderByLike(OrderType.asc)
                    //.SetOrderBySale(OrderType.asc)
                    //.SetOrderByPrice(OrderType.asc)
                    //.SetTags(new[] { "uo" })
                    //.SetTagTrees(new[] { "" })
                    //.SetScope(ProductScope.BUSINESS_PRODUCT)
                    //.SetAttributeSearchQuery("")
                    //.SetScVoucherHash(new []{""})
                    //.SetScApiKey("")
                    .Build();
                ProductService.GetProductList(businessProductListVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<List<AttributeTemplateSrv>> GetAttributeTemplateList()
        {
            try
            {
                var output = new ResultSrv<List<AttributeTemplateSrv>>();
                var attributeTemplateListVo = AttributeTemplateListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    //.SetFirstId(0)
                    //.SetLastId(0)
                    //.SetSize(0)
                    //.SetGuildCode(new[] { "" })
                    .Build();
                ProductService.GetAttributeTemplateList(attributeTemplateListVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<SearchProductSrv> SearchProduct()
        {
            try
            {
                var output = new ResultSrv<SearchProductSrv>();
                var searchProductVo = SearchProductVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    //.SetSize(0)
                    //.SetBusinessId(0)
                    //.SetId(new long[] { 0 })
                    //.SetUniqueId(new[] { "" })
                    //.SetCategoryCode(new[] { "" })
                    //.SetGuildCode(new[] { "" })
                    //.SetCurrencyCode("")
                    //.SetFirstId(0)
                    //.SetLastId(0)
                    //.SetAttributeTemplateCode("")
                    //.SetAttributeCode(new[] { "" })
                    //.SetAttributeValue(new[] { "" })
                    //.SetOrderByLike(OrderType.asc)
                    //.SetOrderBySale(OrderType.asc)
                    //.SetOrderByPrice(OrderType.asc)
                    //.SetTags(new[] { "terl" })
                    //.SetTagTrees(new[] { "" })
                    //.SetQuery("")
                    .Build();
                ProductService.SearchProduct(searchProductVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<List<ProductSrv>> SearchSubProduct()
        {
            try
            {
                var output = new ResultSrv<List<ProductSrv>>();
                var searchSubProductVo = SearchSubProductVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetProductGroupId(new long[] { 1154 })
                    //.SetOffset(0)
                    //.SetSize(10)
                    .SetAttributeCode(new[] { "gender" })
                    .SetAttributeValue(new[] { "male" })
                    .SetOrderByAttributeCode("size")
                    .SetOrderByDirection(OrderType.asc)
                    //.SetTags(new[] { "terl" })
                    //.SetTagTrees(new[] { "" })
                    //.SetQuery("")
                    .Build();
                ProductService.SearchSubProduct(searchSubProductVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}
