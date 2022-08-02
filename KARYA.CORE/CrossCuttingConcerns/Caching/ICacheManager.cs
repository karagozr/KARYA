using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.CrossCuttingConcerns.Cashhing
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        void Add(string key, object data, int cacheTime);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        void Clear(string key);

    }
}
