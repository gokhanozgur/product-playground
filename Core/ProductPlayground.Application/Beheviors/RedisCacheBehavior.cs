﻿using MediatR;
using ProductPlayground.Application.Interfaces.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application.Beheviors
{
    public class RedisCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehavior(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is ICacheableQuery query)
            {
                var cacheKey = query.CacheKey;
                var cacheTime = query.CacheTime;

                var cachedData = await redisCacheService.GetAsync<TResponse>(cacheKey);
                if (cachedData is not null)
                {
                    return cachedData;
                }
                else
                {
                    var response = await next();
                    if (response is not null)
                    {
                        await redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));
                    }
                    return response;
                }
            }
            return await next();
        }
    }
}
