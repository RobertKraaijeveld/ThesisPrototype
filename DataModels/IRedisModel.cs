using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisPrototype.DataModels
{
    public interface IRedisModel
    {
        string ToRedisKey();
    }
}
