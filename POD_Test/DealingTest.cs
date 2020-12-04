using System;
using System.Collections.Generic;
using NUnit.Framework;
using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using POD_Dealing;
using POD_Dealing.Model.ServiceOutput;
using POD_Dealing.Model.ValueObject;
using POD_SSO;
using POD_SSO.Base;
using POD_SSO.Model.OAuth2.ServiceOutput;
using POD_SSO.Model.OAuth2.ValueObject;

namespace POD_Test
{
    [TestFixture]
    class DealingTest
    {
        public DealingTest()
        {
            Config.ServerType = ServerType.SandBox;
        }

        #region RequiredParameters

        [Test]
        public void AddUserAndBusiness_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<BusinessSrv>();
            var num = new Random().Next(10000);
            var addUserAndBusinessVo = AddUserAndBusinessVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetUsername($"Username{num}")
                .SetBusinessName($"BusinessName{num}")
                .SetGuildCode(new[] {"TOILETRIES_GUILD", "HEALTH_GUILD"})
                .SetCountry("ایران")
                .SetState("رضوی")
                .SetCity("مشهد")
                .SetAddress("تست")
                .SetDescription("تست 11")
                .SetAgentFirstName("test")
                .SetAgentLastName("test")
                .SetEmail("test@test.com")
                .Build();
            DealingService.AddUserAndBusiness(addUserAndBusinessVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void ListUserCreatedBusiness_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<BusinessSrv>>();
            var listUserCreatedBusinessVo = ListUserCreatedBusinessVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .Build();
            DealingService.ListUserCreatedBusiness(listUserCreatedBusinessVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void UpdateBusiness_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<BusinessSrv>();
            var num = new Random().Next(10000);
            var updateBusinessVo = UpdateBusinessVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetBizId(13059)
                .SetBusinessName($"BusinessName{num}")
                .SetGuildCode(new [] { "HEALTH_GUILD" })
                .SetCountry("ایران")
                .SetState("خراسان رضوی")
                .SetCity("مشهد")
                .SetAddress("تست")
                .SetDescription("تست ۱۲")
                .Build();
            DealingService.UpdateBusiness(updateBusinessVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void GetApiTokenForCreatedBusiness_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<BusinessApiTokenSrv>();
            var getApiTokenForCreatedBusinessVo = GetApiTokenForCreatedBusinessVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetBusinessId(13059)
                .Build();
            DealingService.GetApiTokenForCreatedBusiness(getApiTokenForCreatedBusinessVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void RateBusiness_RequiredParameters()
        {
            var clientInfo = new ClientInfo
            {
                ClientId = "6305557f7fcb4988abae4e404d3e6e1d",
                ClientSecret = "a8ba06d0"
            };

            var ssoService = new SsoService(clientInfo);

            var outputToken = new OAuthResponseSrv();
            var refreshTokenVo = RefreshAccessTokenVo.ConcreteBuilder
                .SetGrantType("refresh_token")
                .SetRefreshToken("077372c5cbc9429086ec37f50e2f898c")
                .Build();
            ssoService.RefreshAccessToken(refreshTokenVo, response => Listener.GetResult(response, out outputToken));

            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken(outputToken.Access_Token)
                .Build();

            var output = new ResultSrv<RateSrv>();
            var rateBusinessVo = RateBusinessVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetBusinessId(13059)
                .SetRate(4)
                .Build();
            DealingService.RateBusiness(rateBusinessVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void CommentBusiness_RequiredParameters()
        {
            var clientInfo = new ClientInfo
            {
                ClientId = "6305557f7fcb4988abae4e404d3e6e1d",
                ClientSecret = "a8ba06d0"
            };

            var ssoService = new SsoService(clientInfo);

            var outputToken = new OAuthResponseSrv();
            var refreshTokenVo = RefreshAccessTokenVo.ConcreteBuilder
                .SetGrantType("refresh_token")
                .SetRefreshToken("077372c5cbc9429086ec37f50e2f898c")
                .Build();
            ssoService.RefreshAccessToken(refreshTokenVo, response => Listener.GetResult(response, out outputToken));

            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken(outputToken.Access_Token)
                .Build();

            var output = new ResultSrv<long>();
            var commentBusinessVo = CommentBusinessVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetBusinessId(13059)
                .SetText("test Comment")
                .Build();
            DealingService.CommentBusiness(commentBusinessVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void BusinessFavorite_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<bool>();
            var businessFavoriteVo = BusinessFavoriteVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetBusinessId(13059)
                .SetDisFavorite(false)
                .Build();
            DealingService.BusinessFavorite(businessFavoriteVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void UserBusinessInfos_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<UserBusinessInfoSrv>>();
            var userBusinessInfosVo = UserBusinessInfosVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetId(new long[] { 13059 })
                .Build();
            DealingService.UserBusinessInfos(userBusinessInfosVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void CommentBusinessList_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<CommentSrv>>();
            var commentBusinessListVo = CommentBusinessListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetBusinessId(13059)
                .SetSize(10)
                .SetOffset(0)
                .Build();
            DealingService.CommentBusinessList(commentBusinessListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void ConfirmComment_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("19bd0a016563402aa39f9800ff7a9f93 ")
                .Build();

            var output = new ResultSrv<bool>();
            var commentVo = CommentVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetCommentId(7281)
                .Build();
            DealingService.ConfirmComment(commentVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void UnConfirmComment_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("19bd0a016563402aa39f9800ff7a9f93")
                .Build();

            var output = new ResultSrv<bool>();
            var commentVo = CommentVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetCommentId(7281)
                .Build();
            DealingService.UnConfirmComment(commentVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void AddDealer_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<BusinessDealerSrv>();
            var addDealerVo = AddDealerVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetDealerBizId(13059)
                .Build();
            DealingService.AddDealer(addDealerVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void DealerList_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<BusinessDealerSrv>>();
            var dealerListVo = DealerListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .Build();
            DealingService.DealerList(dealerListVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void EnableDealer_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<BusinessDealerSrv>();
            var enableDealerVo = EnableDealerVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetDealerBizId(13059)
                .Build();
            DealingService.EnableDealer(enableDealerVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void DisableDealer_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<BusinessDealerSrv>();
            var disableDealerVo = DisableDealerVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetDealerBizId(13059)
                .Build();
            DealingService.DisableDealer(disableDealerVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void BusinessDealingList_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<BusinessDealerSrv>>();
            var businessDealingListVo = BusinessDealingListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetDealerBizId(13059)
                .Build();
            DealingService.BusinessDealingList(businessDealingListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void AddDealerProductPermission_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<DealerProductPermissionSrv>();
            var registerUserVo = AddDealerProductPermissionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetEntityId(42234)
                .SetDealerBizId(13059)
                .Build();
            DealingService.AddDealerProductPermission(registerUserVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void DealerProductPermissionList_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<DealerProductPermissionSrv>>();
            var registerUserVo = DealerProductPermissionListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .Build();
            DealingService.DealerProductPermissionList(registerUserVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void DealingProductPermissionList_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<DealerProductPermissionSrv>>();
            var registerUserVo = DealingProductPermissionListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .Build();
            DealingService.DealingProductPermissionList(registerUserVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void DisableDealerProductPermission_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<DealerProductPermissionSrv>();
            var registerUserVo = DisableDealerProductPermissionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetEntityId(42234)
                .SetDealerBizId(13059)
                .Build();
            DealingService.DisableDealerProductPermission(registerUserVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void EnableDealerProductPermission_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<DealerProductPermissionSrv>();
            var registerUserVo = EnableDealerProductPermissionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetEntityId(42234)
                .SetDealerBizId(13059)
                .Build();
            DealingService.EnableDealerProductPermission(registerUserVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        #endregion RequiredParameters

        #region AllParameters

        [Test]
        public void AddUserAndBusiness_AllParameters()
        {

            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<BusinessSrv>();
            var num = new Random().Next(10000);
            var addUserAndBusinessVo = AddUserAndBusinessVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetUsername($"Username{num}")
                .SetBusinessName($"BusinessName{num}")
                .SetGuildCode(new[] { "TOILETRIES_GUILD", "HEALTH_GUILD" })
                .SetCountry("ایران")
                .SetState("رضوی")
                .SetCity("مشهد")
                .SetAddress("تست")
                .SetDescription("تست 11")
                .SetAgentFirstName("test")
                .SetAgentLastName("test")
                .SetEmail("test@test.com")
                .SetFirstName("test")
                .SetLastName("test")
                .SetSheba("980570100680013557234101")
                .SetNationalCode("1111441111")
                .SetEconomicCode("1234")
                .SetRegistrationNumber("1234fa")
                .SetCellphone("09057604247")
                .SetPhone("05132222222")
                .SetFax("05133333333")
                .SetPostalCode("9185175673")
                .SetNewsReader(false)
                .SetLogoImage("https://core.pod.ir:443/nzh/image/?imageId=110531&width=909&height=909&hashCode=16b11e5cf3c-0.42178732891944504")
                .SetCoverImage("https://core.pod.ir:443/nzh/image/?imageId=110531&width=909&height=909&hashCode=16b11e5cf3c-0.42178732891944504")
                .SetTags(new[] {"tst1", "tst2"})
                .SetTagTrees(new [] {"tstchild" })
                .SetTagTreeCategoryName("testcode")
                .SetLink("https://core.pod.ir:443/nzh/image/?imageId=110531&width=909&height=909&hashCode=16b11e5cf3c-0.42178732891944504")
                .SetLat(35.12345)
                .SetLng(35.12345)
                .SetAgentNationalCode("1111221111")
                .Build();
            DealingService.AddUserAndBusiness(addUserAndBusinessVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void ListUserCreatedBusiness_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<BusinessSrv>>();
            var listUserCreatedBusinessVo = ListUserCreatedBusinessVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetBizId(new long[] { 13059 })
                .SetGuildCode(new [] {"CLOTHING_GUILD"})
                .SetOffset(0)
                .SetSize(0)
                .SetQuery("")
                .SetTags(new[] {"tst1", "tst2", "tst3"})
                .SetTagTrees(new string[] { })
                .SetActive(false)
                .SetCountry("")
                .SetState("")
                .SetCity("")
                .SetSsoId(0)
                .SetUsername("")
                .SetBusinessName("")
                .SetSheba("")
                .SetNationalCode("")
                .SetEconomicCode("")
                .SetEmail("")
                .SetCellphone("")
                .Build();
            DealingService.ListUserCreatedBusiness(listUserCreatedBusinessVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void UpdateBusiness_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

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
                .SetCompanyName("")
                .SetShopName("")
                .SetShopNameEn("")
                .SetWebsite("")
                .SetDateEstablishing("")
                .SetFirstName("")
                .SetLastName("")
                .SetSheba("")
                .SetNationalCode("")
                .SetEconomicCode("")
                .SetRegistrationNumber("")
                .SetEmail("")
                .SetCellphone("")
                .SetPhone("")
                .SetFax("")
                .SetPostalCode("")
                .SetChangeLogo(false)
                .SetChangeCover(false)
                .SetLogoImage("")
                .SetCoverImage("")
                .SetTags(new string[] { })
                .SetTagTrees(new string[] { })
                .SetTagTreeCategoryName("")
                .SetLink("")
                .SetLat(0)
                .SetLng(0)
                .SetAgentFirstName("")
                .SetAgentLastName("")
                .SetAgentCellphoneNumber("")
                .SetAgentNationalCode("")
                .SetChangeAgent(false)
                .Build();
            DealingService.UpdateBusiness(updateBusinessVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void CommentBusinessList_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<CommentSrv>>();
            var commentBusinessListVo = CommentBusinessListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetBusinessId(13059)
                .SetSize(10)
                .SetOffset(0)
                .SetFirstId(0)
                .SetLastId(0)
                .Build();
            DealingService.CommentBusinessList(commentBusinessListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void AddDealer_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<BusinessDealerSrv>();
            var addDealerVo = AddDealerVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetDealerBizId(13059)
                .SetAllProductAllow(true)
                .Build();
            DealingService.AddDealer(addDealerVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void DealerList_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<BusinessDealerSrv>>();
            var dealerListVo = DealerListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetDealerBizId(13059)
                .SetEnable(true)
                .SetOffset(0)
                .SetSize(10)
                .Build();
            DealingService.DealerList(dealerListVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void BusinessDealingList_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<BusinessDealerSrv>>();
            var businessDealingListVo = BusinessDealingListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetDealerBizId(13059)
                .SetEnable(false)
                .SetOffset(0)
                .SetSize(0)
                .Build();
            DealingService.BusinessDealingList(businessDealingListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void DealerProductPermissionList_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<DealerProductPermissionSrv>>();
            var registerUserVo = DealerProductPermissionListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetSize(0)
                .SetDealingBusinessId(0)
                .SetEnable(false)
                .SetOffset(0)
                .SetEntityId(19482)
                .Build();
            DealingService.DealerProductPermissionList(registerUserVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void DealingProductPermissionList_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<DealerProductPermissionSrv>>();
            var dealingProductPermissionListVo = DealingProductPermissionListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetSize(0)
                .SetDealingBusinessId(0)
                .SetEnable(false)
                .SetOffset(0)
                .SetEntityId(0)
                .Build();
            DealingService.DealingProductPermissionList(dealingProductPermissionListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void DisableDealerProductPermission_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<DealerProductPermissionSrv>();
            var disableDealerProductPermissionVo = DisableDealerProductPermissionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetEntityId(0)
                .SetDealerBizId(0)
                .Build();
            DealingService.DisableDealerProductPermission(disableDealerProductPermissionVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void EnableDealerProductPermission_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<DealerProductPermissionSrv>();
            var enableDealerProductPermissionVo = EnableDealerProductPermissionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetEntityId(0)
                .SetDealerBizId(0)
                .Build();
            DealingService.EnableDealerProductPermission(enableDealerProductPermissionVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        #endregion AllParameters

        #region NoParameters

        [Test]
        public void AddUserAndBusiness_NoParameters()
        {
            try
            {
                AddUserAndBusinessVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void ListUserCreatedBusiness_NoParameters()
        {
            try
            {
                ListUserCreatedBusinessVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void UpdateBusiness_NoParameters()
        {
            try
            {
                UpdateBusinessVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetApiTokenForCreatedBusiness_NoParameters()
        {
            try
            {
                GetApiTokenForCreatedBusinessVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void RateBusiness_NoParameters()
        {
            try
            {
                RateBusinessVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void CommentBusiness_NoParameters()
        {
            try
            {
                CommentBusinessVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void BusinessFavorite_NoParameters()
        {
            try
            {
                BusinessFavoriteVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void UserBusinessInfos_NoParameters()
        {
            try
            {
                UserBusinessInfosVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void CommentBusinessList_NoParameters()
        {
            try
            {
                CommentBusinessListVo.ConcreteBuilder.Build();

            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void ConfirmComment_NoParameters()
        {
            try
            {
                CommentVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void UnConfirmComment_NoParameters()
        {
            try
            {
                CommentVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void AddDealer_NoParameters()
        {
            try
            {
                AddDealerVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void DealerList_NoParameters()
        {
            try
            {
                DealerListVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void EnableDealer_NoParameters()
        {
            try
            {
                EnableDealerVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void DisableDealer_NoParameters()
        {
            try
            {
                DisableDealerVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void BusinessDealingList_NoParameters()
        {
            try
            {
                BusinessDealingListVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void AddDealerProductPermission_NoParameters()
        {
            try
            {
                AddDealerProductPermissionVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void DealerProductPermissionList_NoParameters()
        {
            try
            {
                DealerProductPermissionListVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void DealingProductPermissionList_NoParameters()
        {
            try
            {
                DealingProductPermissionListVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void DisableDealerProductPermission_NoParameters()
        {
            try
            {
                DisableDealerProductPermissionVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void EnableDealerProductPermission_NoParameters()
        {
            try
            {
                EnableDealerProductPermissionVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        #endregion NoParameters
    }
}
