// Copyright (c) ChungNA - 2020 All Rights Reserved
namespace DependencyInjection.Test.Services
{
    public class BaseService
    {
        public IMyTransientService TransientService { get; }
        public IMyScopedService ScopedService { get; }
        public IMySingletonService SingletonService { get; }

        public BaseService(IMyTransientService transientService,
            IMyScopedService scopedService,
            IMySingletonService singletonService)
        {
            TransientService = transientService;
            ScopedService = scopedService;
            SingletonService = singletonService;
        }
    }
}