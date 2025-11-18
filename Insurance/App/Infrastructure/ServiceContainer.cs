using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Infrastructure
{
    public interface IServiceRegistry
    {
        void RegisterSingleton<TService>(Func<object> factory);
        void RegisterTransient<TService>(Func<object> factory);
        TService Resolve<TService>();
    }

    public class ServiceContainer : IServiceRegistry
    {
        private readonly ConcurrentDictionary<Type, Func<object>> _singletons = new ConcurrentDictionary<Type, Func<object>>();
        private readonly ConcurrentDictionary<Type, Func<object>> _transients = new ConcurrentDictionary<Type, Func<object>>();
        private readonly ConcurrentDictionary<Type, object> _singletonsInstances = new ConcurrentDictionary<Type, object>();

        public void RegisterSingleton<TService>(Func<object> factory)
        {
            _singletons[typeof(TService)] = factory;
        }

        public void RegisterTransient<TService>(Func<object> factory)
        {
            _transients[typeof(TService)] = factory;
        }

        public TService Resolve<TService>()
        {
            var t = typeof(TService);
            if (_singletonsInstances.TryGetValue(t, out var instance)) return (TService)instance;
            if (_singletons.TryGetValue(t, out var factory))
            {
                var created = factory();
                _singletonsInstances[t] = created;
                return (TService)created;
            }
            if (_transients.TryGetValue(t, out var tf)) return (TService)tf();
            throw new InvalidOperationException($"Service of type {t.FullName} not registered");
        }
    }
}