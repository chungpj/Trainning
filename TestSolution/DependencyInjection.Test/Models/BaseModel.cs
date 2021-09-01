// Copyright (c) ChungNA - 2020 All Rights Reserved
using DependencyInjection.Test.Services;
using System;

namespace DependencyInjection.Test.Models
{
    public class BaseModel : IMyTransientService, IMyScopedService, IMySingletonService
    {
        Guid _guid;
        public BaseModel() : this(Guid.NewGuid())
        {

        }

        public BaseModel(Guid guid)
        {
            _guid = guid;
        }

        public Guid GuidId => _guid;
    }
}