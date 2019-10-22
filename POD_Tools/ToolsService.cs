using System;
using System.Collections.Generic;
using POD_Base_Service;
using POD_Base_Service.Result;
using POD_Tools.Base;
using POD_Tools.Model.ServiceOutput;
using POD_Tools.Model.ValueObject;
using RestSharp;

namespace POD_Tools
{
    public static class ToolsService
    {
        public static void PayBill(PayBillVo payBillVo,
            Action<IRestResponse<ResultSrv<ServiceBillSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.PayBill, payBillVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceBillSrv>>(request));
        }
        public static void GetPayedBillList(PayedBillListVo payedBillListVo,
            Action<IRestResponse<ResultSrv<List<ServiceBillSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.PayedBillList, payedBillListVo, PodParameterName.ParametersName, out var client,out var request);
            callback(client.Execute<ResultSrv<List<ServiceBillSrv>>>(request));
        }
    }
}
