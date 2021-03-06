﻿using System;
using NHibernate;

namespace ChinookMediaManager.Infrastructure.Persistence
{
    //http://ayende.com/blog/4106/nhibernate-inotifypropertychanged
    public class DataBindingIntercepter : EmptyInterceptor
    {
        public DataBindingIntercepter(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        private readonly ISessionFactory _sessionFactory;

        public override object Instantiate(string clazz, EntityMode entityMode, object id)
        {
            if (entityMode == EntityMode.Poco)
            {
                Type type = Type.GetType(clazz);
                if (type != null)
                {
                    var instance = DataBindingFactory.Create(type);
                    _sessionFactory.GetClassMetadata(clazz).SetIdentifier(instance, id, entityMode);
                    return instance;
                }
            }
            return base.Instantiate(clazz, entityMode, id);
        }

        public override string GetEntityName(object entity)
        {
            var markerInterface = entity as DataBindingFactory.IMarkerInterface;
            if (markerInterface != null)
                return markerInterface.TypeName;
            return base.GetEntityName(entity);
        }
    }
}