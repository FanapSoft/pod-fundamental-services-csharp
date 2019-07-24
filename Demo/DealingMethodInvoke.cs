using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Dealing;
using POD_Dealing.Model.ServiceOutput;
using POD_Dealing.Model.ValueObject;

namespace Demo
{
    public class DealingMethodInvoke
    {
        private readonly DealingService dealingService=new DealingService();
        public ResultSrv<BusinessSrv> AddUserAndBusiness()
        {
            try
            {
                var output = new ResultSrv<BusinessSrv>();
                var addUserAndBusinessVo = AddUserAndBusinessVo.ConcreteBuilder
                    .SetToken("") //{Put your ApiToken}
                    .SetUsername("") //{Put your Username}
                    .SetBusinessName("") //{Put your BusinessName}
                    .SetGuildCode(new string[]{}) //{Put your GuildCode}
                    .SetCountry("") //{Put your Country}
                    .SetState("") //{Put your State}
                    .SetCity("") //{Put your City}
                    .SetAddress("") //{Put your Address}
                    .SetDescription("") //{Put your Description}
                    .SetAgentFirstName("") //{Put your AgentFirstName}
                    .SetAgentLastName("") //{Put your AgentLastName}
                    .SetEmail("") //{Put your Email}
                    //.SetFirstName("") //{Put your FirstName}
                    //.SetLastName("") //{Put your LastName}
                    //.SetSheba("") //{Put your Sheba}
                    //.SetNationalCode("") //{Put your NationalCode}
                    //.SetEconomicCode("") //{Put your EconomicCode}
                    //.SetRegistrationNumber("") //{Put your RegistrationNumber}
                    //.SetCellphone("") //{Put your Cellphone}
                    //.SetPhone("") //{Put your Phone}
                    //.SetFax("") //{Put your Fax}
                    //.SetPostalCode("") //{Put your PostalCode}
                    //.SetNewsReader(false) //{Put your NewsReader}
                    //.SetLogoImage("") //{Put your LogoImage}
                    //.SetCoverImage("") //{Put your CoverImage}
                    //.SetTags(new string[]{}) //{Put your Tags}
                    //.SetTagTrees(new string[]{}) //{Put your TagTrees}
                    //.SetTagTreeCategoryName("") //{Put your TagTreeCategoryName}
                    //.SetLink("") //{Put your Link}
                    //.SetLat(0) //{Put your Lat}
                    //.SetLng(0) //{Put your Lng}
                    //.SetAgentNationalCode("") //{Put your AgentNationalCode}
                    .Build();
                dealingService.AddUserAndBusiness(addUserAndBusinessVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<GuildSrv>> GuildList()
        {
            try
            {
                var output = new ResultSrv<List<GuildSrv>>();
                var guildListVo = GuildListVo.ConcreteBuilder
                    .SetToken("") //{Put your Token}
                    .SetOffset(0) //{Put your Offset}
                    .SetSize(0) //{Put your Size}
                    //.SetName("") //{Put your Name}
                    .Build();
                dealingService.GuildList(guildListVo, response => Listener.GetResult(response, out output));
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
                    .SetToken("") //{Put your Token}
                    //.SetBizId(new long[]{}) //{Put your BizId}
                    //.SetGuildCode(new string[] {}) //{Put your GuildCode}
                    //.SetOffset(0) //{Put your Offset}
                    //.SetSize(0) //{Put your Size}
                    //.SetQuery("") //{Put your Query}
                    //.SetTags(new string[] {}) //{Put your Tags}
                    //.SetTagTrees(new string[] {}) //{Put your TagTrees}
                    //.SetActive(false) //{Put your Active}
                    //.SetCountry("") //{Put your Country}
                    //.SetState("") //{Put your State}
                    //.SetCity("") //{Put your City}
                    //.SetSsoId(0) //{Put your SsoId}
                    //.SetUsername("") //{Put your Username}
                    //.SetBusinessName("") //{Put your BusinessName}
                    //.SetSheba("") //{Put your Sheba}
                    //.SetNationalCode("") //{Put your NationalCode}
                    //.SetEconomicCode("") //{Put your EconomicCode}
                    //.SetEmail("") //{Put your Email}
                    //.SetCellphone("") //{Put your Cellphone}
                    .Build();
                dealingService.ListUserCreatedBusiness(listUserCreatedBusinessVo, response => Listener.GetResult(response, out output));
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
                    .SetToken("") //{Put your Token}
                    .SetBizId(0) //{Put your BizId}
                    .SetBusinessName("") //{Put your BusinessName}
                    .SetGuildCode(new string[] { }) //{Put your GuildCode}
                    .SetCountry("") //{Put your Country}
                    .SetState("") //{Put your State}
                    .SetCity("") //{Put your City}
                    .SetAddress("") //{Put your Address}
                    .SetDescription("") //{Put your Description}
                    //.SetCompanyName("") //{Put your CompanyName}
                    //.SetShopName("") //{Put your ShopName}
                    //.SetShopNameEn("") //{Put your ShopNameEn}
                    //.SetWebsite("") //{Put your Website}
                    //.SetDateEstablishing("") //{Put your DateEstablishing}
                    //.SetFirstName("") //{Put your FirstName}
                    //.SetLastName("") //{Put your LastName}
                    //.SetSheba("") //{Put your Sheba}
                    //.SetNationalCode("") //{Put your NationalCode}
                    //.SetEconomicCode("") //{Put your EconomicCode}
                    //.SetRegistrationNumber("") //{Put your RegistrationNumber}
                    //.SetEmail("") //{Put your Email}
                    //.SetCellphone("") //{Put your Cellphone}
                    //.SetPhone("") //{Put your Phone}
                    //.SetFax("") //{Put your Fax}
                    //.SetPostalCode("") //{Put your PostalCode}
                    //.SetChangeLogo(false) //{Put your ChangeLogo}
                    //.SetChangeCover(false) //{Put your ChangeCover}
                    //.SetLogoImage("") //{Put your LogoImage}
                    //.SetCoverImage("") //{Put your CoverImage}
                    //.SetTags(new string[] { }) //{Put your Tags}
                    //.SetTagTrees(new string[] { }) //{Put your TagTrees}
                    //.SetTagTreeCategoryName("") //{Put your TagTreeCategoryName}
                    //.SetLink("") //{Put your Link}
                    //.SetLat(0) //{Put your Lat}
                    //.SetLng(0) //{Put your Lng}
                    //.SetAgentFirstName("") //{Put your AgentFirstName}
                    //.SetAgentLastName("") //{Put your AgentLastName}
                    //.SetAgentCellphoneNumber("") //{Put your AgentCellphoneNumber}
                    //.SetAgentNationalCode("") //{Put your AgentNationalCode}
                    //.SetChangeAgent(false) //{Put your ChangeAgent}
                    .Build();
                dealingService.UpdateBusiness(updateBusinessVo, response => Listener.GetResult(response, out output));
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
                    .SetToken("") //{Put your Token}
                    .SetBusinessId(0) //{Put your BusinessId}
                    .Build();
                dealingService.GetApiTokenForCreatedBusiness(getApiTokenForCreatedBusinessVo, response => Listener.GetResult(response, out output));
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
                    .SetToken("") //{Put your Token}
                    .SetBusinessId(0) //{Put your BusinessId}
                    .SetRate(0) //{Put your Rate}
                    .Build();
                dealingService.RateBusiness(rateBusinessVo, response => Listener.GetResult(response, out output));
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
                    .SetToken("") //{Put your Token}
                    .SetBusinessId(0) //{Put your BusinessId}
                    .SetText("") //{Put your Text}
                    .Build();
                dealingService.CommentBusiness(commentBusinessVo, response => Listener.GetResult(response, out output));
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
                    .SetToken("") //{Put your Token}
                    .SetBusinessId(0) //{Put your BusinessId}
                    .SetDisFavorite(false) //{Put your DisFavorite}
                    .Build();
                dealingService.BusinessFavorite(businessFavoriteVo, response => Listener.GetResult(response, out output));
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
                    .SetToken("") //{Put your Token}
                    .SetId(new long[]{}) //{Put your Id}
                    .Build();
                dealingService.UserBusinessInfos(userBusinessInfosVo, response => Listener.GetResult(response, out output));
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
                    .SetToken("") //{Put your Token}
                    .SetBusinessId(0) //{Put your BusinessId}
                    .SetSize(0) //{Put your Size}
                    .SetOffset(0) //{Put your Offset}
                    //.SetFirstId(0) //{Put your FirstId}
                    //.SetLastId(0) //{Put your LastId}
                    .Build();
                dealingService.CommentBusinessList(commentBusinessListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<CommentSrv> ConfirmComment()
        {
            try
            {
                var output = new ResultSrv<CommentSrv>();
                var confirmCommentVo = ConfirmCommentVo.ConcreteBuilder
                    .SetToken("") //{Put your Token}
                    .SetCommentId(0) //{Put your CommentId}
                    .Build();
                dealingService.ConfirmComment(confirmCommentVo, response => Listener.GetResult(response, out output));
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
