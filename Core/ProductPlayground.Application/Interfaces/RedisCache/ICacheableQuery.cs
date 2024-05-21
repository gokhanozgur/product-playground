﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application.Interfaces.RedisCache
{
    public interface ICacheableQuery
    {
        public string CacheKey { get; }
        public double CacheTime { get; }
    }
}
