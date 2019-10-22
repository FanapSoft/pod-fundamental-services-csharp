using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using POD_Dealing;
using POD_Dealing.Model.ServiceOutput;
using POD_Dealing.Model.ValueObject;

namespace Demo
{
    public class DealingMethodInvoke
    {
        private InternalServiceCallVo internalServiceCallVo;
        public DealingMethodInvoke()
        {
            internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("")
                //.SetScVoucherHash({Put your VoucherHash})
                //.SetScApiKey("")
                .Build();
        }
        public ResultSrv<BusinessSrv> AddUserAndBusiness()
        {
            try
            {
                var output = new ResultSrv<BusinessSrv>();
                var addUserAndBusinessVo = AddUserAndBusinessVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUsername("")
                    .SetBusinessName("")
                    .SetGuildCode(new[]{ "TOILETRIES_GUILD", "HEALTH_GUILD" })
                    .SetCountry("ایران")
                    .SetState("رضوی")
                    .SetCity("مشهد")
                    .SetAddress("")
                    .SetDescription("تست 11")
                    .SetAgentFirstName("")
                    .SetAgentLastName("")
                    .SetEmail("")
                    //.SetFirstName("")
                    //.SetLastName("")
                    //.SetSheba("")
                    //.SetNationalCode("")
                    //.SetEconomicCode("")
                    //.SetRegistrationNumber("")
                    //.SetCellphone("09057604247")
                    //.SetPhone("")
                    //.SetFax("")
                    //.SetPostalCode("")
                    //.SetNewsReader(false)
                    //.SetLogoImage("")
                    //.SetCoverImage("")
                    //.SetTags(new []{"tst1","tst2"})
                    //.SetTagTrees(new string[]{})
                    //.SetTagTreeCategoryName("")
                    //.SetLink("")
                    //.SetLat(0)
                    //.SetLng(0)
                    //.SetAgentNationalCode("")
                    .Build();
                DealingService.AddUserAndBusiness(addUserAndBusinessVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<BusinessSrv>> ListUserCreatedBusiness()
        {
            try
            {
                var output = new ResultSrv<List<BusinessSrv>>();
                var listUserCreatedBusinessVo = ListUserCreatedBusinessVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBizId(new long[]{0})
                    //.SetGuildCode(new string[]{ "CLOTHING_GUILD"})
                    //.SetOffset(0)
                    //.SetSize(0)
                    //.SetQuery("")
                    //.SetTags(new []{"tst1","tst2","tst3"})
                    //.SetTagTrees(new string[]{})
                    //.SetActive(false)
                    //.SetCountry("")
                    //.SetState("")
                    //.SetCity("")
                    //.SetSsoId(0)
                    //.SetUsername("")
                    //.SetBusinessName("")
                    //.SetSheba("")
                    //.SetNationalCode("")
                    //.SetEconomicCode("")
                    //.SetEmail("")
                    //.SetCellphone("")
                    .Build();
                DealingService.ListUserCreatedBusiness(listUserCreatedBusinessVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<BusinessSrv> UpdateBusiness()
        {
            try
            {
                var output = new ResultSrv<BusinessSrv>();
                var updateBusinessVo = UpdateBusinessVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBizId(0)
                    .SetBusinessName("")
                    .SetGuildCode(new string[] { })
                    .SetCountry("ایران")
                    .SetState("خراسان رضوی")
                    .SetCity("مشهد")
                    .SetAddress("")
                    .SetDescription("ی")
                    //.SetCompanyName("")
                    //.SetShopName("")
                    //.SetShopNameEn("")
                    //.SetWebsite("")
                    //.SetDateEstablishing("")
                    //.SetFirstName("")
                    //.SetLastName("")
                    //.SetSheba("")
                    //.SetNationalCode("")
                    //.SetEconomicCode("")
                    //.SetRegistrationNumber("")
                    //.SetEmail("")
                    //.SetCellphone("")
                    //.SetPhone("")
                    //.SetFax("")
                    //.SetPostalCode("")
                    //.SetChangeLogo(false)
                    //.SetChangeCover(false)
                    //.SetLogoImage("")
                    //.SetCoverImage("")
                    //.SetTags(new string[]{})
                    //.SetTagTrees(new string[]{})
                    //.SetTagTreeCategoryName("")
                    //.SetLink("")
                    //.SetLat(0)
                    //.SetLng(0)
                    //.SetAgentFirstName("")
                    //.SetAgentLastName("")
                    //.SetAgentCellphoneNumber("")
                    //.SetAgentNationalCode("")
                    //.SetChangeAgent(false)
                    .Build();
                DealingService.UpdateBusiness(updateBusinessVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<BusinessApiTokenSrv> GetApiTokenForCreatedBusiness()
        {
            try
            {
                var output = new ResultSrv<BusinessApiTokenSrv>();
                var getApiTokenForCreatedBusinessVo = GetApiTokenForCreatedBusinessVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBusinessId(0)
                    .Build();
                DealingService.GetApiTokenForCreatedBusiness(getApiTokenForCreatedBusinessVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<RateSrv> RateBusiness()
        {
            try
            {
                var output = new ResultSrv<RateSrv>();
                var rateBusinessVo = RateBusinessVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBusinessId(0)
                    .SetRate(4)
                    .Build();
                DealingService.RateBusiness(rateBusinessVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<long> CommentBusiness()
        {
            try
            {
                var output = new ResultSrv<long>();
                var commentBusinessVo = CommentBusinessVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBusinessId(0)
                    .SetText("jsj")
                    .Build();
                DealingService.CommentBusiness(commentBusinessVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<bool> BusinessFavorite()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var businessFavoriteVo = BusinessFavoriteVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBusinessId(0)
                    .SetDisFavorite(false)
                    .Build();
                DealingService.BusinessFavorite(businessFavoriteVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<UserBusinessInfoSrv>> UserBusinessInfos()
        {
            try
            {
                var output = new ResultSrv<List<UserBusinessInfoSrv>>();
                var userBusinessInfosVo = UserBusinessInfosVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(new long[]{0})
                    .Build();
                DealingService.UserBusinessInfos(userBusinessInfosVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<CommentSrv>> CommentBusinessList()
        {
            try
            {
                var output = new ResultSrv<List<CommentSrv>>();
                var commentBusinessListVo = CommentBusinessListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBusinessId(0)
                    .SetSize(10)
                    .SetOffset(0)
                    //.SetFirstId(0)
                    //.SetLastId(0)
                    .Build();
                DealingService.CommentBusinessList(commentBusinessListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<bool> ConfirmComment()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var commentVo = CommentVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetCommentId(0)
                    .Build();
                DealingService.ConfirmComment(commentVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<bool> UnConfirmComment()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var commentVo = CommentVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetCommentId(0)
                    .Build();
                DealingService.UnConfirmComment(commentVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<BusinessDealerSrv> AddDealer()
        {
            try
            {
                var output = new ResultSrv<BusinessDealerSrv>();
                var addDealerVo = AddDealerVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetDealerBizId(0)
                    //.SetAllProductAllow(true)
                    .Build();
                DealingService.AddDealer(addDealerVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<BusinessDealerSrv>> DealerList()
        {
            try
            {
                var output = new ResultSrv<List<BusinessDealerSrv>>();
                var dealerListVo = DealerListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    //.SetDealerBizId(0)
                    //.SetEnable(false)
                    //.SetOffset(0)
                    //.SetSize(0)
                    .Build();
                DealingService.DealerList(dealerListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<BusinessDealerSrv> EnableDealer()
        {
            try
            {
                var output = new ResultSrv<BusinessDealerSrv>();
                var enableDealerVo = EnableDealerVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetDealerBizId(0)
                    .Build();
                DealingService.EnableDealer(enableDealerVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<BusinessDealerSrv> DisableDealer()
        {
            try
            {
                var output = new ResultSrv<BusinessDealerSrv>();
                var disableDealerVo = DisableDealerVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetDealerBizId(0)
                    .Build();
                DealingService.DisableDealer(disableDealerVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<BusinessDealerSrv>> BusinessDealingList()
        {
            try
            {
                var output = new ResultSrv<List<BusinessDealerSrv>>();
                var businessDealingListVo = BusinessDealingListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetDealerBizId(0)
                    //.SetEnable(false)
                    //.SetOffset(0)
                    //.SetSize(0)
                    .Build();
                DealingService.BusinessDealingList(businessDealingListVo,
                    response => Listener.GetResult(response, out output));
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
        public ResultSrv<DealerProductPermissionSrv> AddDealerProductPermission()
        {
            try
            {
                var output = new ResultSrv<DealerProductPermissionSrv>();
                var registerUserVo = AddDealerProductPermissionVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetEntityId(0)
                    .SetDealerBizId(0)
                    .Build();
                DealingService.AddDealerProductPermission(registerUserVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<DealerProductPermissionSrv>> DealerProductPermissionList()
        {
            try
            {
                var output = new ResultSrv<List<DealerProductPermissionSrv>>();
                var registerUserVo = DealerProductPermissionListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    //.SetSize(0)
                    //.SetDealingBusinessId(0)
                    //.SetEnable(false)
                    //.SetOffset(0)
                    .SetEntityId(19482)
                    .Build();
                DealingService.DealerProductPermissionList(registerUserVo,
                    response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<DealerProductPermissionSrv>> DealingProductPermissionList()
        {
            try
            {
                var output = new ResultSrv<List<DealerProductPermissionSrv>>();
                var registerUserVo = DealingProductPermissionListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    //.SetSize(0)
                    //.SetDealingBusinessId(0)
                    //.SetEnable(false)
                    //.SetOffset(0)
                    //.SetEntityId(0)
                    .Build();
                DealingService.DealingProductPermissionList(registerUserVo,
                    response => Listener.GetResult(response, out output));
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
        public ResultSrv<DealerProductPermissionSrv> DisableDealerProductPermission()
        {
            try
            {
                var output = new ResultSrv<DealerProductPermissionSrv>();
                var registerUserVo = DisableDealerProductPermissionVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetEntityId(0)
                    .SetDealerBizId(0)
                    .Build();
                DealingService.DisableDealerProductPermission(registerUserVo,
                    response => Listener.GetResult(response, out output));
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
        public ResultSrv<DealerProductPermissionSrv> EnableDealerProductPermission()
        {
            try
            {
                var output = new ResultSrv<DealerProductPermissionSrv>();
                var registerUserVo = EnableDealerProductPermissionVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetEntityId(0)
                    .SetDealerBizId(0)
                    .Build();
                DealingService.EnableDealerProductPermission(registerUserVo,
                    response => Listener.GetResult(response, out output));
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
