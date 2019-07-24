using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using RestSharp;
using POD_Billing.Model.ServiceOutput;
using POD_Billing.Model.ValueObject;
using POD_Base_Service.Exception;
using POD_Billing.Base;

namespace POD_Billing
{
    public class BillingService
    {
        private readonly string apiToken;

        /// <param name="apiToken">توکنی که از پنل کسب و کار دریافت شده است</param>
        public BillingService(string apiToken)
        {
            if (string.IsNullOrEmpty(apiToken))
            {
                throw PodException.BuildException(new InvalidParameter(new KeyValuePair<string, string>("ApiToken", "The field is required.")));
            }

            this.apiToken = apiToken;
        }

        public void IssueInvoice(IssueInvoiceVo issueInvoiceVo, Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/issueInvoice";
            PrepareRestClient(url, issueInvoiceVo, out var client, out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public void GetListAddress(ListAddressVo listAddressVo, Action<IRestResponse<ResultSrv<AddressSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/listAddress";
            PrepareRestClient(url, listAddressVo, out var client, out var request);
            callback(client.Execute<ResultSrv<AddressSrv>>(request));
        }

        public void GetOtt(Action<IRestResponse<ResultSrv<string>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/ott";
            PrepareRestClient(url, out var client, out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }

        public void VerifyInvoice(VerifyInvoiceVo verifyInvoiceVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/verifyInvoice";
            PrepareRestClient(url, verifyInvoiceVo, out var client, out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public void CloseInvoice(CloseInvoiceVo closeInvoiceVo, Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/closeInvoice";
            PrepareRestClient(url, closeInvoiceVo, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public void VerifyAndCloseInvoice(VerifyAndCloseInvoiceVo verifyAndCloseInvoiceVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/verifyAndCloseInvoice";
            PrepareRestClient(url, verifyAndCloseInvoiceVo, out var client, out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public void CancelInvoice(CancelInvoiceVo cancelInvoiceVo, Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/cancelInvoice";
            PrepareRestClient(url, cancelInvoiceVo, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public void GetInvoiceList(GetInvoiceListVo getInvoiceListVo,
            Action<IRestResponse<ResultSrv<List<InvoiceSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/getInvoiceList";
            PrepareRestClient(url, getInvoiceListVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<InvoiceSrv>>>(request));
        }

        public void GetInvoiceListByMetadata(GetInvoiceListByMetadataVo getInvoiceListByMetadataVo,
            Action<IRestResponse<ResultSrv<List<InvoiceSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/getInvoiceListByMetadata";
            PrepareRestClient(url, getInvoiceListByMetadataVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<InvoiceSrv>>>(request));
        }

        public void GetInvoiceListAsFile(GetInvoiceListAsFileVo getInvoiceListAsFileVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/getInvoiceListAsFile";
            PrepareRestClient(url, getInvoiceListAsFileVo, out var client, out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public void ReduceInvoice(ReduceInvoiceVo reduceInvoiceVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/reduceInvoice";
            PrepareRestClient(url, reduceInvoiceVo, out var client, out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public void GetExportList(GetExportListVo getExportListVo,
            Action<IRestResponse<ResultSrv<List<ExportServiceSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/getExportList";
            PrepareRestClient(url, getExportListVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<ExportServiceSrv>>>(request));
        }

        public void PayInvoice(PayInvoiceVo payInvoiceVo, Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/payInvoice";
            PrepareRestClient(url, payInvoiceVo, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public void SendInvoicePaymentSms(SendInvoicePaymentSmsVo sendInvoicePaymentSmsVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/sendInvoicePaymentSMS";
            PrepareRestClient(url, sendInvoicePaymentSmsVo, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public void PayInvoiceInFuture(PayInvoiceInFutureVo payInvoiceInFutureVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/payInvoiceInFuture";
            PrepareRestClient(url, payInvoiceInFutureVo, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public void PayInvoiceByInvoice(PayInvoiceByInvoiceVo payInvoiceByInvoiceVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/payInvoiceByInvoice";
            PrepareRestClient(url, payInvoiceByInvoiceVo, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public void RegisterUser(RegisterUserVo registerUserVo,
            Action<IRestResponse<ResultSrv<CustomerProfileSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/umanage/registerUser";
            PrepareRestClient(url, registerUserVo, out var client, out var request);
            callback(client.Execute<ResultSrv<CustomerProfileSrv>>(request));
        }

        public void CreatePreInvoice(CreatePreInvoiceVo createPreInvoiceVo,
            Action<IRestResponse<ResultSrv<string>>> callback)
        {
            var url = $"{BaseUrl.PrivateCallAddress}/service/createPreInvoice";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            PrepareParameters(createPreInvoiceVo, request);
            callback(client.Execute<ResultSrv<string>>(request));
        }

        public void GetInvoicePaymentLink(GetInvoicePaymentLinkVo getInvoicePaymentLinkVo,
            Action<IRestResponse<ResultSrv<string>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/getInvoicePaymentLink";
            PrepareRestClient(url, getInvoicePaymentLinkVo, out var client, out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }

        public void RequestSettlement(RequestWalletSettlementVo requestWalletSettlementVo,
            Action<IRestResponse<ResultSrv<SettlementRequestSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/requestSettlement";
            PrepareRestClient(url, requestWalletSettlementVo, out var client, out var request);
            callback(client.Execute<ResultSrv<SettlementRequestSrv>>(request));
        }

        public void RequestSettlement(RequestGuildSettlementVo requestGuildSettlementVo,
            Action<IRestResponse<ResultSrv<SettlementRequestSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/requestSettlement";
            PrepareRestClient(url, requestGuildSettlementVo, out var client, out var request);
            callback(client.Execute<ResultSrv<SettlementRequestSrv>>(request));
        }

        public void RequestSettlement(RequestSettlementByToolVo requestSettlementByToolVo,
            Action<IRestResponse<ResultSrv<SettlementRequestSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/requestSettlementByTool";
            PrepareRestClient(url, requestSettlementByToolVo, out var client, out var request);
            callback(client.Execute<ResultSrv<SettlementRequestSrv>>(request));
        }

        public void ListSettlements(ListSettlementsVo listSettlementsVo,
            Action<IRestResponse<ResultSrv<List<SettlementRequestSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/listSettlements";
            PrepareRestClient(url, listSettlementsVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<SettlementRequestSrv>>>(request));
        }

        public void AddAutoSettlement(AddAutoSettlementVo addAutoSettlementVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/addAutoSettlement";
            PrepareRestClient(url, addAutoSettlementVo, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public void RemoveAutoSettlement(RemoveAutoSettlementVo removeAutoSettlementVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/removeAutoSettlement";
            PrepareRestClient(url, removeAutoSettlementVo, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public void AddDealer(AddDealerVo addDealerVo, Action<IRestResponse<ResultSrv<BusinessDealerSrv>>> callback)

        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/addDealer";
            PrepareRestClient(url, addDealerVo, out var client, out var request);
            callback(client.Execute<ResultSrv<BusinessDealerSrv>>(request));
        }

        public void DealerList(DealerListVo dealerListVo, Action<IRestResponse<ResultSrv<List<BusinessDealerSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/dealerList";
            PrepareRestClient(url, dealerListVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<BusinessDealerSrv>>>(request));
        }

        public void EnableDealer(EnableDealerVo enableDealerVo,
            Action<IRestResponse<ResultSrv<BusinessDealerSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/enableDealer";
            PrepareRestClient(url, enableDealerVo, out var client, out var request);
            callback(client.Execute<ResultSrv<BusinessDealerSrv>>(request));
        }

        public void DisableDealer(DisableDealerVo disableDealerVo,
            Action<IRestResponse<ResultSrv<BusinessDealerSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/disableDealer";
            PrepareRestClient(url, disableDealerVo, out var client, out var request);
            callback(client.Execute<ResultSrv<BusinessDealerSrv>>(request));
        }

        public void BusinessDealingList(BusinessDealingListVo businessDealingListVo,
            Action<IRestResponse<ResultSrv<List<BusinessDealerSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/businessDealingList";
            PrepareRestClient(url, businessDealingListVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<BusinessDealerSrv>>>(request));
        }

        public void IssueMultiInvoice(IssueMultiInvoiceVo issueMultiInvoiceListVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/issueMultiInvoice";
            PrepareRestClient(url, issueMultiInvoiceListVo, out var client, out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public void ReduceMultiInvoice(ReduceMultiInvoiceVo reduceMultiInvoiceVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/reduceMultiInvoice";
            PrepareRestClient(url, reduceMultiInvoiceVo, out var client, out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public void ReduceMultiInvoiceAndCashout(ReduceMultiInvoiceAndCashoutVo reduceMultiInvoiceAndCashoutVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/reduceMultiInvoiceAndCashout";
            PrepareRestClient(url, reduceMultiInvoiceAndCashoutVo, out var client, out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public void AddDealerProductPermission(AddDealerProductPermissionVo addDealerProductPermissionVo,
            Action<IRestResponse<ResultSrv<DealerProductPermissionSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/addDealerProductPermission";
            PrepareRestClient(url, addDealerProductPermissionVo, out var client, out var request);
            callback(client.Execute<ResultSrv<DealerProductPermissionSrv>>(request));
        }

        public void DealerProductPermissionList(DealerProductPermissionListVo dealerProductPermissionListVo,
            Action<IRestResponse<ResultSrv<List<DealerProductPermissionSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/dealerProductPermissionList";
            PrepareRestClient(url, dealerProductPermissionListVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<DealerProductPermissionSrv>>>(request));
        }

        public void DealingProductPermissionList(DealingProductPermissionListVo dealingProductPermissionListVo,
            Action<IRestResponse<ResultSrv<List<DealerProductPermissionSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/dealingProductPermissionList";
            PrepareRestClient(url, dealingProductPermissionListVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<DealerProductPermissionSrv>>>(request));
        }

        public void DisableDealerProductPermission(DisableDealerProductPermissionVo disableDealerProductPermissionVo,
            Action<IRestResponse<ResultSrv<DealerProductPermissionSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/disableDealerProductPermission";
            PrepareRestClient(url, disableDealerProductPermissionVo, out var client, out var request);
            callback(client.Execute<ResultSrv<DealerProductPermissionSrv>>(request));
        }

        public void EnableDealerProductPermission(EnableDealerProductPermissionVo enableDealerProductPermissionVo,
            Action<IRestResponse<ResultSrv<DealerProductPermissionSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/enableDealerProductPermission";
            PrepareRestClient(url, enableDealerProductPermissionVo, out var client, out var request);
            callback(client.Execute<ResultSrv<DealerProductPermissionSrv>>(request));
        }

        private void PrepareRestClient<T>(string url, T objectVo, out RestClient client, out RestRequest request)
        {
            client = new RestClient(url);
            request = new RestRequest(Method.GET);
            request.AddHeader("_token_", apiToken)
                   .AddHeader(nameof(Config.TokenIssuer).GetPodName(), Config.TokenIssuer.ToString());
            PrepareParameters(objectVo, request);
        }

        private void PrepareRestClient(string url, out RestClient client, out RestRequest request)
        {
            client = new RestClient(url);
            request = new RestRequest(Method.GET);
            request.AddHeader("_token_", apiToken)
                   .AddHeader(nameof(Config.TokenIssuer).GetPodName(), Config.TokenIssuer.ToString());
        }

        private static void PrepareParameters<T>(T objectVo, IRestRequest request)
        {
            var parameters = objectVo.FilterNotNull(PodParameterName.ParametersName);
            if (parameters == null) return;
            foreach (var parameter in parameters)
            {
                if (parameter.Key.Equals("_ott_"))
                {
                    request.AddHeader(parameter.Key, parameter.Value);
                }
                else request.AddParameter(parameter.Key, parameter.Value);
            }
        }
    }
}
