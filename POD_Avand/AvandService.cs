using System;
using System.Collections.Generic;
using POD_Avand.Base;
using POD_Avand.Model.ServiceOutput;
using POD_Avand.Model.ValueObject;
using POD_Base_Service;
using POD_Base_Service.Result;
using RestSharp;

namespace POD_Avand
{
    public static class AvandService
    {
        public static void IssueInvoice(IssueInvoiceVo issueInvoiceVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<Output<IssueInvoiceContentSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.IssueInvoice, issueInvoiceVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<Output<IssueInvoiceContentSrv>>>>(request));
        }

        public static void VerifyInvoice(VerifyOrCancelInvoiceVo verifyInvoiceVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<Output<object>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.VerifyInvoice, verifyInvoiceVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<Output<object>>>>(request));
        }

        public static void CancelInvoice(VerifyOrCancelInvoiceVo cancelInvoiceVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<Output<object>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.CancelInvoice, cancelInvoiceVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<Output<object>>>>(request));
        }

        public static void GetInvoiceList(GetInvoiceListVo getInvoiceListVo,
            Action<IRestResponse<ResultSrv<List<InvoiceSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetInvoiceList, getInvoiceListVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<InvoiceSrv>>>(request));
        }
    }
}
