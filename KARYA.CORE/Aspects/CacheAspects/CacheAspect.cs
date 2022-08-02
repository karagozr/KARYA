using AspectInjector.Broker;
using KARYA.CORE.CrossCuttingConcerns.Caching.Microsoft;
using KARYA.CORE.CrossCuttingConcerns.Cashhing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KARYA.CORE.Aspects.CacheAspects
{
    [Serializable]
    [Aspect(Scope.Global)]
    [Injection(typeof(MicrosoftCacheAspectAttribute))]
    public sealed class MicrosoftCacheAspectAttribute : Attribute
    {
        //private readonly Type _cacheType;
        private readonly int _cacheMinute;
        private ICacheManager _cacheManager;

        public MicrosoftCacheAspectAttribute()
        {
            _cacheManager = new MemoryCacheManager(); //(ICacheManager)Activator.CreateInstance(_cacheType);
            _cacheMinute = 15;
        }

        [Advice(Kind.Around, Targets = Target.Method)]
        public object Trace(
            [Argument(Source.Type)] Type type,
            [Argument(Source.Name)] string name,
            [Argument(Source.Target)] Func<object[], object> methodDelegate,
            [Argument(Source.Arguments)] object[] args)
        {


            string argStr = JsonSerializer.Serialize(args).ToString();
            var key = string.Format("{0}.{1}({2})", type.FullName, name, argStr);
           

            if (_cacheManager.IsAdd(key))
            {
                return _cacheManager.Get<object>(key);
            }
            else
            {

                var result = methodDelegate(args);
                _cacheManager.Add(key, result, _cacheMinute);

                return result;

            }

        }



    }
}
