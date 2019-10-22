using POD_Tools;
using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Tools.Model.ServiceOutput;
using POD_Tools.Model.ValueObject;
using POD_Base_Service.Result;

namespace Demo
{
    public class ToolsMethodInvoke
    {
        private InternalServiceCallVo internalServiceCallVo;
        public ToolsMethodInvoke()
        {
            internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("")
                //.SetScVoucherHash({Put your VoucherHash})
                //.SetScApiKey("")
                .Build();
        }

        public ResultSrv<ServiceBillSrv> PayBill()
        {
            try
            {
                var output = new ResultSrv<ServiceBillSrv>();
                var payBillVo = PayBillVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBillId("")
                    .SetPaymentId("")
                    .Build();
                ToolsService.PayBill(payBillVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<ServiceBillSrv>> GetPayedBillList()
        {
            try
            {
                var output = new ResultSrv<List<ServiceBillSrv>>();
                var payedBillListVo = PayedBillListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    //.SetBillId("")
                    //.SetPaymentId("")
                    .SetId(0)
                    //.SetFromDate("")
                    //.SetToDate("")
                    .Build();
                ToolsService.GetPayedBillList(payedBillListVo, response => Listener.GetResult(response, out output));
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
