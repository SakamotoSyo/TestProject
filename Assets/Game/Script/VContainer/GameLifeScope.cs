using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifeScope : LifetimeScope
{
    [SerializeField] private SampleView _sampleView;
    private SampleModel _sampleModel;

    protected override void Configure(IContainerBuilder builder)
    {
        //インスタンスを注入するクラスを指定する
        builder.RegisterEntryPoint<SamplePresenter>(Lifetime.Singleton);

        //SampleModelのインスタンスを
        builder.Register<ISampleModel, SampleModel>(Lifetime.Singleton);

        builder.RegisterComponent(_sampleView);
    }
}
