using System;
using System.Collections.Generic;
using POD_Base_Service;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;

namespace Demo
{
    public class BaseMethodInvoke
    {
        private InternalServiceCallVo internalServiceCallVo;
        public BaseMethodInvoke()
        {
            internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("")
                //.SetScVoucherHash({Put your VoucherHash})
                //.SetScApiKey("")
                .Build();
        }
        public ResultSrv<List<GuildSrv>> GetGuildList()
        {
            try
            {

                var output = new ResultSrv<List<GuildSrv>>();
                var guildListVo = GuildListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    //.SetName("")
                    .Build();
                BaseService.GetGuildList(guildListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<GuildSrv>> GetCurrencyList()
        {
            try
            {
                var output = new ResultSrv<List<GuildSrv>>();
                BaseService.GetCurrencyList(internalServiceCallVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<string> GetOtt()
        {
            try
            {
                var output = new ResultSrv<string>();
                BaseService.GetOtt(internalServiceCallVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<TagTreeCategorySrv> AddTagTreeCategory()
        {
            try
            {
                var output = new ResultSrv<TagTreeCategorySrv>();
                var addTagTreeCategoryVo = AddTagTreeCategoryVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetName("nvsdfaw")
                    .SetDesc("test")
                    .Build();
                BaseService.AddTagTreeCategory(addTagTreeCategoryVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<List<TagTreeCategorySrv>> GetTagTreeCategoryList()
        {
            try
            {
                var output = new ResultSrv<List<TagTreeCategorySrv>>();
                var getTagTreeCategoryListVo = GetTagTreeCategoryListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(0)
                    //.SetId(0)
                    //.SetName("")
                    //.SetQuery("")
                    .Build();
                BaseService.GetTagTreeCategoryList(getTagTreeCategoryListVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<TagTreeCategorySrv> UpdateTagTreeCategory()
        {
            try
            {
                var output = new ResultSrv<TagTreeCategorySrv>();
                var updateTagTreeCategoryVo = UpdateTagTreeCategoryVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(301)
                    .SetName("naavahg")
                    //.SetDesc("")
                    //.SetEnable(false)
                    .Build();
                BaseService.UpdateTagTreeCategory(updateTagTreeCategoryVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<TagTreeSrv> AddTagTree()
        {
            try
            {
                var output = new ResultSrv<TagTreeSrv>();
                var addTagTreeCategoryVo = AddTagTreeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetName("tstna18")
                    .SetCategoryId(301)
                    .SetParentId(601)
                    .Build();
                BaseService.AddTagTree(addTagTreeCategoryVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<TagTreeSrv>> GetTagTreeList()
        {
            try
            {
                var output = new ResultSrv<List<TagTreeSrv>>();
                var getTagTreeListVo = GetTagTreeListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetCategoryId(301)
                    .SetLevelCount(2)
                    .SetFromLevel(1)
                    //.SetParentId(601)
                    //.SetId(0)
                    .Build();
                BaseService.GetTagTreeList(getTagTreeListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<TagTreeSrv> UpdateTagTree()
        {
            try
            {
                var output = new ResultSrv<TagTreeSrv>();
                var updateTagTreeVo = UpdateTagTreeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(602)
                    .SetName("naava")
                    .SetParentId(601)
                    //.SetEnable(false)
                    .Build();
                BaseService.UpdateTagTree(updateTagTreeVo, response => Listener.GetResult(response, out output));
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
