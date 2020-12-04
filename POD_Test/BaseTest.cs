using System;
using System.Collections.Generic;
using NUnit.Framework;
using POD_Base_Service;
using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;

namespace POD_Test
{ 
    [TestFixture]
    class BaseTest
    {
        public BaseTest()
        {
            Config.ServerType = ServerType.SandBox;
        }
       

        #region RequiredParameters

        [Test]
        public void AddTagTreeCategory_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<TagTreeCategorySrv>();
            var num = new Random().Next(2000);
            var addTagTreeCategoryVo = AddTagTreeCategoryVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetName($"tst{num}")
                .Build();
            BaseService.AddTagTreeCategory(addTagTreeCategoryVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void GetTagTreeCategoryList_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<TagTreeCategorySrv>>();
            var getTagTreeCategoryListVo = GetTagTreeCategoryListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetOffset(0)
                .SetSize(0)
                .Build();
            BaseService.GetTagTreeCategoryList(getTagTreeCategoryListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void UpdateTagTreeCategory_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<TagTreeCategorySrv>();
            var num = new Random().Next(2000);
            var updateTagTreeCategoryVo = UpdateTagTreeCategoryVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetId(1507)
                .Build();
            BaseService.UpdateTagTreeCategory(updateTagTreeCategoryVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void AddTagTree_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<TagTreeSrv>();
            var num = new Random().Next(5000);
            var addTagTreeCategoryVo = AddTagTreeVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetName($"tst{num}")
                .SetCategoryId(1507)
                .Build();
            BaseService.AddTagTree(addTagTreeCategoryVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void GetTagTreeList_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<TagTreeSrv>>();
            var getTagTreeListVo = GetTagTreeListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetCategoryId(1507)
                .SetLevelCount(2)
                .SetFromLevel(0)
                .Build();
            BaseService.GetTagTreeList(getTagTreeListVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void GetTagTreeList_RequiredParameters1()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<TagTreeSrv>>();
            var getTagTreeListVo = GetTagTreeListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetCategoryId(1507)
                .SetLevelCount(2)
                .SetParentId(2601)
                .Build();
            BaseService.GetTagTreeList(getTagTreeListVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void UpdateTagTree_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<TagTreeSrv>();
            var num = new Random().Next(1000);
            var updateTagTreeVo = UpdateTagTreeVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetId(2610)
                .Build();
            BaseService.UpdateTagTree(updateTagTreeVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        #endregion RequiredParameters

        #region AllParameters


        [Test]
        public void AddTagTreeCategory_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                //.SetScVoucherHash({Put your VoucherHash})
                //.SetScApiKey("")
                .Build();

            var output = new ResultSrv<TagTreeCategorySrv>();
            var num = new Random().Next(2000);
            var addTagTreeCategoryVo = AddTagTreeCategoryVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetName($"tst{num}")
                .SetDesc("test")
                .Build();
            BaseService.AddTagTreeCategory(addTagTreeCategoryVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void GetTagTreeCategoryList_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                //.SetScVoucherHash({Put your VoucherHash})
                //.SetScApiKey("")
                .Build();

            var output = new ResultSrv<List<TagTreeCategorySrv>>();
            var getTagTreeCategoryListVo = GetTagTreeCategoryListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetOffset(0)
                .SetSize(0)
                .SetId(0)
                .SetName("")
                .SetQuery("")
                .Build();
            BaseService.GetTagTreeCategoryList(getTagTreeCategoryListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void UpdateTagTreeCategory_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                //.SetScVoucherHash({Put your VoucherHash})
                //.SetScApiKey("")
                .Build();

            var output = new ResultSrv<TagTreeCategorySrv>();
            var num = new Random().Next(2000);
            var updateTagTreeCategoryVo = UpdateTagTreeCategoryVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetId(1507)
                .SetName($"tst{num}")
                .SetDesc("test")
                .SetEnable(false)
                .Build();
            BaseService.UpdateTagTreeCategory(updateTagTreeCategoryVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void AddTagTree_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                //.SetScVoucherHash({Put your VoucherHash})
                //.SetScApiKey("")
                .Build();

            var output = new ResultSrv<TagTreeSrv>();
            var num = new Random().Next(5000);
            var addTagTreeCategoryVo = AddTagTreeVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetName($"tst{num}")
                .SetCategoryId(1507)
                .SetParentId(2601)
                .Build();
            BaseService.AddTagTree(addTagTreeCategoryVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void GetTagTreeList_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                //.SetScVoucherHash({Put your VoucherHash})
                //.SetScApiKey("")
                .Build();

            var output = new ResultSrv<List<TagTreeSrv>>();
            var getTagTreeListVo = GetTagTreeListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetCategoryId(301)
                .SetLevelCount(2)
                .SetFromLevel(1)
                .SetParentId(601)
                .SetId(0)
                .Build();
            BaseService.GetTagTreeList(getTagTreeListVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void UpdateTagTree_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                //.SetScVoucherHash({Put your VoucherHash})
                //.SetScApiKey("")
                .Build();

            var output = new ResultSrv<TagTreeSrv>();
            var num = new Random().Next(1000);
            var updateTagTreeVo = UpdateTagTreeVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetId(2610)
                .SetName($"tst{num}")
                .SetParentId(2601)
                .SetEnable(false)
                .Build();
            BaseService.UpdateTagTree(updateTagTreeVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        #endregion RequiredParameters

        #region NoHeader

        [Test]
        public void GetGuildList_NoHeader()
        {
            try
            {
                GuildListVo.ConcreteBuilder
                    .SetServiceCallParameters(null)
                    .SetOffset(0)
                    .SetSize(10)
                    //.SetName("")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetCurrencyList_NoHeader()
        {
            try
            {
                InternalServiceCallVo.ConcreteBuilder
                    .SetToken(null)
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetOtt_NoHeader()
        {
            try
            {
                InternalServiceCallVo.ConcreteBuilder
                    .SetToken(null)
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void AddTagTreeCategory_NoHeader()
        {
            try
            {
                AddTagTreeCategoryVo.ConcreteBuilder
                    .SetServiceCallParameters(null)
                    .SetName("nvsdfaw")
                    .SetDesc("test")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetTagTreeCategoryList_NoHeader()
        {
            try
            {
                GetTagTreeCategoryListVo.ConcreteBuilder
                    .SetServiceCallParameters(null)
                    .SetOffset(0)
                    .SetSize(0)
                    //.SetId(0)
                    //.SetName("")
                    //.SetQuery("")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void UpdateTagTreeCategory_NoHeader()
        {
            try
            {
                UpdateTagTreeCategoryVo.ConcreteBuilder
                    .SetServiceCallParameters(null)
                    .SetId(301)
                    .SetName("naavahg")
                    //.SetDesc("")
                    //.SetEnable(false)
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }


        [Test]
        public void AddTagTree_NoHeader()
        {
            try
            {
                AddTagTreeVo.ConcreteBuilder
                    .SetServiceCallParameters(null)
                    .SetName("tsttree1")
                    .SetCategoryId(301)
                    .SetParentId(601)
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetTagTreeList_NoHeader()
        {
            try
            {
                GetTagTreeListVo.ConcreteBuilder
                    .SetServiceCallParameters(null)
                    .SetCategoryId(301)
                    .SetLevelCount(2)
                    .SetFromLevel(1)
                    //.SetParentId(601)
                    //.SetId(0)
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void UpdateTagTree_NoHeader()
        {
            try
            {
                UpdateTagTreeVo.ConcreteBuilder
                    .SetServiceCallParameters(null)
                    .SetId(602)
                    .SetName("tst")
                    .SetParentId(601)
                    //.SetEnable(false)
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        #endregion NoHeader

        #region NoParameters

        [Test]
        public void GetGuildList_NoParameters()
        {
            try
            {
                GuildListVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetCurrencyList_NoParameters()
        {
            try
            {
                InternalServiceCallVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetOtt_NoParameters()
        {
            try
            {
                InternalServiceCallVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void AddTagTreeCategory_NoParameters()
        {
            try
            {
                AddTagTreeCategoryVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetTagTreeCategoryList_NoParameters()
        {
            try
            {
                GetTagTreeCategoryListVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void UpdateTagTreeCategory_NoParameters()
        {
            try
            {
                UpdateTagTreeCategoryVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }


        [Test]
        public void AddTagTree_NoParameters()
        {
            try
            {
                AddTagTreeVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetTagTreeList_NoParameters()
        {
            try
            {
                GetTagTreeListVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void UpdateTagTree_NoParameters()
        {
            try
            {
                UpdateTagTreeVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        #endregion NoParameters

        #region SomeRequiredParameters

        [Test]
        public void AddTagTree_SomeRequiredParameters_Name()
        {
            try
            {

                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    .Build();

                     AddTagTreeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetCategoryId(301)
                    .Build();
            }
            catch (PodException)
            { 
               Assert.True(true);
            }
        }

        [Test]
        public void AddTagTree_SomeRequiredParameters_CategoryId()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();

                AddTagTreeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetName("tst")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void AddTagTreeCategory_SomeRequiredParameters_Name()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();

                AddTagTreeCategoryVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetTagTreeCategoryList_SomeRequiredParameters_Offset()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();

                GetTagTreeCategoryListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetSize(0)
                    //.SetId(0)
                    //.SetName("")
                    //.SetQuery("")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void GetTagTreeCategoryList_SomeRequiredParameters_Size()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();

                GetTagTreeCategoryListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    //.SetId(0)
                    //.SetName("")
                    //.SetQuery("")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void UpdateTagTreeCategory_SomeRequiredParameters_Id()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();

                UpdateTagTreeCategoryVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    //.SetId(301)
                    //.SetName($"tst{num}")
                    //.SetDesc("")
                    //.SetEnable(false)
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        #endregion SomeRequiredParameters

        #region InvalidParameters

        [Test]
        public void AddTagTreeCategory_InvalidParameters_Token()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0000000jj")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();

                var output = new ResultSrv<TagTreeCategorySrv>();
                var num = new Random().Next(2000);
                var addTagTreeCategoryVo = AddTagTreeCategoryVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetName($"tst{num}")
                    //.SetDesc("test")
                    .Build();
                BaseService.AddTagTreeCategory(addTagTreeCategoryVo, response => Listener.GetResult(response, out output));
            }
            catch (PodException podException)
            {
                Assert.True(podException.OriginalResult.HasError);
            }
        }

        [Test]
        public void AddTagTreeCategory_InvalidParameters_Name()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();

                var output = new ResultSrv<TagTreeCategorySrv>();
                var addTagTreeCategoryVo = AddTagTreeCategoryVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetName("nv")
                    //.SetDesc("test")
                    .Build();
                BaseService.AddTagTreeCategory(addTagTreeCategoryVo, response => Listener.GetResult(response, out output));
            }
            catch (PodException podException)
            {
                Assert.True(podException.OriginalResult.HasError);
            }

        }

        [Test]
        public void AddTagTree_InvalidParameters_Token()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0000000jj")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();
                var output = new ResultSrv<TagTreeSrv>();
                var num = new Random().Next(2000);
                var addTagTreeCategoryVo = AddTagTreeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetName($"tst{num}")
                    .SetCategoryId(301)
                    //.SetParentId(601)
                    .Build();
                BaseService.AddTagTree(addTagTreeCategoryVo, response => Listener.GetResult(response, out output));
            }
            catch (PodException podException)
            {
               Assert.True(podException.OriginalResult.HasError);
            }
        }

        [Test]
        public void AddTagTree_InvalidParameters_CategoryId()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();
                var output = new ResultSrv<TagTreeSrv>();
                var num = new Random().Next(2000);
                var addTagTreeCategoryVo = AddTagTreeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetName($"tst{num}")
                    .SetCategoryId(0000)
                    //.SetParentId(601)
                    .Build();
                BaseService.AddTagTree(addTagTreeCategoryVo, response => Listener.GetResult(response, out output));
            }
            catch (PodException podException)
            {
                Assert.True(podException.OriginalResult.HasError);
            }
        }

        #endregion
    }
}
