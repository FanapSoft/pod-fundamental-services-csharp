using System;
using POD_Base_Service;
using POD_Base_Service.Result;
using POD_Neshan.Base;
using POD_Neshan.Model.ServiceOutput;
using POD_Neshan.Model.ValueObject;
using RestSharp;

namespace POD_Neshan
{
    public static class NeshanService
    {
        public static void Search(SearchVo serviceCallVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<SearchSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallConsts.Search, serviceCallVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<SearchSrv>>>(request));
        }

        public static void ReverseGeo(ReverseGeoVo reverseGeoVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ReverseSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallConsts.ReverseGeo, reverseGeoVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ReverseSrv>>>(request));
        }

        public static void Direction(DirectionVo directionVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<DirectionSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallConsts.Direction, directionVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<DirectionSrv>>>(request));
        }

        public static void NoTrafficDirection(DirectionVo directionVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<DirectionSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallConsts.NoTrafficDirection, directionVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<DirectionSrv>>>(request));
        }

        public static void DistanceMatrix(DistanceMatrixVo distanceMatrixVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<DistanceMatrixSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallConsts.DistanceMatrix, distanceMatrixVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<DistanceMatrixSrv>>>(request));
        }

        public static void NoTrafficDistanceMatrix(DistanceMatrixVo distanceMatrixVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<DistanceMatrixSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallConsts.NoTrafficDistanceMatrix, distanceMatrixVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<DistanceMatrixSrv>>>(request));
        }

        public static void MapMatching(MapMatchingVo mapMatchingVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<MapMatchingSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallConsts.MapMatching, mapMatchingVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<MapMatchingSrv>>>(request));
        }
    }
}
