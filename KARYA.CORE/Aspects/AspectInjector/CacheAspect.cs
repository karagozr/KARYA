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
  

    [Injection(typeof(TraceAspect))]
    public sealed class MicrosoftCacheAspectAttribute : Attribute
    {
        public int CacheMinute { get; set; }

        public MicrosoftCacheAspectAttribute()
        {

        }
    }

    [Aspect(Scope.Global, Factory = typeof(AspectFactory))]
    public sealed class TraceAspect
    {
        private ICacheManager _cacheManager;
        private readonly int _cacheMinute;
        public TraceAspect(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
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

    public class AspectFactory
    {
        public static object GetInstance(Type aspectType)
        {
           
            if (aspectType == typeof(TraceAspect))
            {
                var cacheManager = new MemoryCacheManager();
                return new TraceAspect(cacheManager);
            }
            throw new ArgumentException($"Unknown aspect type '{aspectType.FullName}'");
        }
    }

}
