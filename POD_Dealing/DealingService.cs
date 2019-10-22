using System;
using System.Collections.Generic;
using POD_Base_Service;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Result;
using POD_Dealing.Base;
using POD_Dealing.Model.ServiceOutput;
using POD_Dealing.Model.ValueObject;
using RestSharp;

namespace POD_Dealing
{
    public static class DealingService
    {
        public static void AddUserAndBusiness(AddUserAndBusinessVo addUserAndBusinessVo,
            Action<IRestResponse<ResultSrv<BusinessSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.AddUserAndBusiness, addUserAndBusinessVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<BusinessSrv>>(request));
        }

        public static void ListUserCreatedBusiness(ListUserCreatedBusinessVo listUserCreatedBusinessVo,
            Action<IRestResponse<ResultSrv<List<BusinessSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ListUserCreatedBusiness, listUserCreatedBusinessVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<BusinessSrv>>>(request));
        }

        /// <summary>
        /// توجه داشته باشید، بجز مقداردهی پارامترهای اجباری کلاس ورودی ,که عدم ثبت آنها منجر به خطا خواهد شد، عدم مقداردهی سایر موارد منجر به پاک شدن مقدار قبلی می گردد
        /// </summary>
        public static void UpdateBusiness(UpdateBusinessVo updateBusinessVo,
            Action<IRestResponse<ResultSrv<BusinessSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.UpdateBusiness, updateBusinessVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<BusinessSrv>>(request));
        }

        public static void GetApiTokenForCreatedBusiness(
            GetApiTokenForCreatedBusinessVo getApiTokenForCreatedBusinessVo,
            Action<IRestResponse<ResultSrv<BusinessApiTokenSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetApiTokenForCreatedBusiness,
                getApiTokenForCreatedBusinessVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<BusinessApiTokenSrv>>(request));
        }

        public static void RateBusiness(RateBusinessVo rateBusinessVo,
            Action<IRestResponse<ResultSrv<RateSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.RateBusiness, rateBusinessVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<RateSrv>>(request));
        }

        public static void CommentBusiness(CommentBusinessVo commentBusinessVo,
            Action<IRestResponse<ResultSrv<long>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.CommentBusiness, commentBusinessVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<long>>(request));
        }

        public static void BusinessFavorite(BusinessFavoriteVo businessFavoriteVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.BusinessFavorite, businessFavoriteVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public static void UserBusinessInfos(UserBusinessInfosVo userBusinessInfosVo,
            Action<IRestResponse<ResultSrv<List<UserBusinessInfoSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.UserBusinessInfos, userBusinessInfosVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<UserBusinessInfoSrv>>>(request));
        }

        public static void CommentBusinessList(CommentBusinessListVo commentBusinessListVo,
            Action<IRestResponse<ResultSrv<List<CommentSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.CommentBusinessList, commentBusinessListVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<CommentSrv>>>(request));
        }

        public static void ConfirmComment(CommentVo commentVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ConfirmComment, commentVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }
        public static void UnConfirmComment(CommentVo commentVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.UnConfirmComment, commentVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }
        public static void AddDealer(AddDealerVo addDealerVo,
            Action<IRestResponse<ResultSrv<BusinessDealerSrv>>> callback)

        {
            BaseService.PrepareRestClient(ServiceCallProducts.AddDealer, addDealerVo, PodParameterName.ParametersName,
                out var client,
                out var request);
            callback(client.Execute<ResultSrv<BusinessDealerSrv>>(request));
        }

        public static void DealerList(DealerListVo dealerListVo,
            Action<IRestResponse<ResultSrv<List<BusinessDealerSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DealerList, dealerListVo, PodParameterName.ParametersName,
                out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<BusinessDealerSrv>>>(request));
        }

        public static void EnableDealer(EnableDealerVo enableDealerVo,
            Action<IRestResponse<ResultSrv<BusinessDealerSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.EnableDealer, enableDealerVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<BusinessDealerSrv>>(request));
        }

        public static void DisableDealer(DisableDealerVo disableDealerVo,
            Action<IRestResponse<ResultSrv<BusinessDealerSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DisableDealer, disableDealerVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<BusinessDealerSrv>>(request));
        }

        public static void BusinessDealingList(BusinessDealingListVo businessDealingListVo,
            Action<IRestResponse<ResultSrv<List<BusinessDealerSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.BusinessDealingList, businessDealingListVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<BusinessDealerSrv>>>(request));
        }

        public static void AddDealerProductPermission(AddDealerProductPermissionVo addDealerProductPermissionVo,
            Action<IRestResponse<ResultSrv<DealerProductPermissionSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.AddDealerProductPermission, addDealerProductPermissionVo,
                PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<DealerProductPermissionSrv>>(request));
        }

        public static void DealerProductPermissionList(DealerProductPermissionListVo dealerProductPermissionListVo,
            Action<IRestResponse<ResultSrv<List<DealerProductPermissionSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DealerProductPermissionList,
                dealerProductPermissionListVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<List<DealerProductPermissionSrv>>>(request));
        }

        public static void DealingProductPermissionList(DealingProductPermissionListVo dealingProductPermissionListVo,
            Action<IRestResponse<ResultSrv<List<DealerProductPermissionSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DealingProductPermissionList,
                dealingProductPermissionListVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<List<DealerProductPermissionSrv>>>(request));
        }

        public static void DisableDealerProductPermission(
            DisableDealerProductPermissionVo disableDealerProductPermissionVo,
            Action<IRestResponse<ResultSrv<DealerProductPermissionSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DisableDealerProductPermission,
                disableDealerProductPermissionVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<DealerProductPermissionSrv>>(request));
        }

        public static void EnableDealerProductPermission(
            EnableDealerProductPermissionVo enableDealerProductPermissionVo,
            Action<IRestResponse<ResultSrv<DealerProductPermissionSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.EnableDealerProductPermission,
                enableDealerProductPermissionVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<DealerProductPermissionSrv>>(request));
        }
    }
}
