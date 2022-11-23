using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public interface IFooService
{
}

public class FooService : IFooService
{
}

public interface IBarService
{
    IFooService GetFoo();
}

public class BarService : IBarService
{
    private readonly IFooService _fooService;

    public BarService(IFooService fooService)
    {
        _fooService = fooService;
    }

    public IFooService GetFoo()
    {
        return _fooService;
    }
}

public class TestDiContainer : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<IFooService, FooService>(Lifetime.Singleton);
        builder.Register<IBarService, BarService>(Lifetime.Singleton);
        builder.RegisterEntryPoint<EntryPoint>(Lifetime.Singleton);
    }
}

public class EntryPoint : IInitializable
{
    private IBarService _barService;

    public EntryPoint(IBarService barService)
    {
        _barService = barService;
    }

    public void Initialize()
    {
        Debug.Log(_barService.GetFoo());
    }
}