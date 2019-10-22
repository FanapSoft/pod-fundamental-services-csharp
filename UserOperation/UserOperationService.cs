using System;
using System.Collections.Generic;
using POD_Base_Service;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Result;
using POD_UserOperation.Base;
using POD_UserOperation.Model.ServiceOutput;
using POD_UserOperation.Model.ValueObject;
using RestSharp;

namespace POD_UserOperation
{
    public static class UserOperationService
    {
        public static void GetUserProfile(UserProfileVo userProfileVo,
            Action<IRestResponse<ResultSrv<CustomerProfileSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetUserProfile, userProfileVo,PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<CustomerProfileSrv>>(request));
        }

        /// <summary>
        /// در صورتی که هر یک از فیلدهای کلاس ورودی که اسکوپ خواندن آن را داشته اید ارسال نشود و یا خالی ارسال شود، مقدار آن در پروفایل کاربر خالی می شود
        /// </summary>      
        public static void EditProfileWithConfirmation(EditProfileWithConfirmationVo editProfileWithConfirmationVo,
            Action<IRestResponse<ResultSrv<CustomerProfileSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.EditProfileWithConfirmation, editProfileWithConfirmationVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<CustomerProfileSrv>>(request));
        }
        public static void GetListAddress(ListAddressVo listAddressVo,
            Action<IRestResponse<ResultSrv<List<AddressSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetListAddress, listAddressVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<AddressSrv>>>(request));
        }
        public static void ConfirmEditProfile(ConfirmEditProfileVo confirmEditProfileVo,
            Action<IRestResponse<ResultSrv<CustomerProfileSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ConfirmEditProfile, confirmEditProfileVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<CustomerProfileSrv>>(request));
        }
    }
}
