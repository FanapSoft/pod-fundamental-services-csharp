using System;
using System.Collections.Generic;
using POD_Avand;
using POD_Avand.Model.ServiceOutput;
using POD_Avand.Model.ValueObject;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;

namespace POD_Demo
{
    public class AvandMethodInvoke
    {
        private const string GuildCode = "";
        private InternalServiceCallVo internalServiceCallVo;
        public AvandMethodInvoke()
        {
            try
            {
                internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    //.SetScVoucherHash({Put your VoucherHash})
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
        public ResultSrv<ServiceCallResultSrv<Output<IssueInvoiceContentSrv>>> IssueInvoice()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<Output<IssueInvoiceContentSrv>>>();
                var invoiceSrv = IssueInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBusinessId(0)
                    .SetPrice(100)
                    .SetRedirectUri("")
                    .SetUserId(0)
                    .Build();
                AvandService.IssueInvoice(invoiceSrv, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<Output<object>>> VerifyInvoice()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<Output<object>>>();
                var verifyInvoiceVo = VerifyOrCancelInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetInvoiceId(0)
                    .Build();
                AvandService.VerifyInvoice(verifyInvoiceVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<Output<object>>> CancelInvoice()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<Output<object>>>();
                var cancelInvoiceVo = VerifyOrCancelInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetInvoiceId(0)
                    .Build();
                AvandService.CancelInvoice(cancelInvoiceVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<List<InvoiceSrv>> GetInvoiceList()
        {
            try
            {
                var output = new ResultSrv<List<InvoiceSrv>>();
                var getInvoiceListVo = GetInvoiceListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    //.SetSize(1)
                    //.SetUserId(0)
                    //.SetBillNumber("")
                    //.SetEntityIdList(new string[]{})
                    //.SetFirstId(0)
                    //.SetLastId(0)
                    //.SetGuildCode("")
                    //.SetId(0)
                    //.SetIsCanceled(false)
                    //.SetIsPayed(false)
                    //.SetIsClosed(false)
                    //.SetQuery("")
                    //.SetReferenceNumber("")
                    //.SetUniqueNumber("")
                    //.SetTrackerId(0)
                    //.SetFromDate("")
                    //.SetToDate("")
                    //.SetIsWaiting(false)
                    //.SetIssuerId(new long[]{0})
                    .Build();

                AvandService.GetInvoiceList(getInvoiceListVo, response => Listener.GetResult(response, out output));
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
