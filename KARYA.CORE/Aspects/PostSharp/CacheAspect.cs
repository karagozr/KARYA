using KARYA.CORE.CrossCuttingConcerns.Cashhing;
using PostSharp.Aspects;
using System;
using System.Reflection;
using System.Text.Json;

namespace KARYA.CORE.Aspects.PostSharp
{
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect
    {
        private Type _cacheType;
        private ICacheManager _cacheManager;
        private readonly int _cacheMinute;
        public CacheAspect(Type cacheType, int cacheMinute = 15)
        {
            _cacheType = cacheType;
            _cacheMinute = cacheMinute;
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

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            string argStr = JsonSerializer.Serialize(args.Arguments).ToString();
            var key = string.Format("{0}.{1}.{2}({3})", args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name, args.Method.Name, argStr);


            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            else
            {
                base.OnInvoke(args);

                _cacheManager.Add(key, args.ReturnValue, _cacheMinute);
            }

            

        }
    }

    //[Serializable]
    //public class CacheAspect : MethodInterceptionAspect
    //{


    //    public override void RuntimeInitialize(MethodBase method)
    //    {
    //        base.RuntimeInitialize(method);
    //    }

    //    public override void OnInvoke(MethodInterceptionArgs args)
    //    {
    //        Console.WriteLine("-----------before-------------");

    //        base.OnInvoke(args);

    //        Console.WriteLine("-----------after-------------");

    //    }
    //}
}
