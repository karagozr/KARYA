using KARYA.CORE.CrossCuttingConcerns.Cashhing;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KARYA.CORE.Aspects.PostSharp
{
    [Serializable]
    public class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        private Type _cacheType;
        private ICacheManager _cacheManager;
        private readonly string _pattern;
        

        public CacheRemoveAspect(string pattern , Type cacheType) : this(cacheType)
        {
            _pattern = pattern;
        }

        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (!typeof(ICacheManager).IsAssignableFrom(_cacheType))
            {
                throw new Exception("Wrong cache manager");
            }

            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);

            base.RuntimeInitialize(method); 
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern) ?
                string.Format("{0}.{1}.*", args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name) :
                _pattern
                );
        }
    }
}
