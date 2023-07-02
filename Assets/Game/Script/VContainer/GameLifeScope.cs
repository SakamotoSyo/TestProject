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
        //�C���X�^���X�𒍓�����N���X���w�肷��
        builder.RegisterEntryPoint<SamplePresenter>(Lifetime.Singleton);

        //SampleModel�̃C���X�^���X��
        builder.Register<ISampleModel, SampleModel>(Lifetime.Singleton);

        builder.RegisterComponent(_sampleView);
    }
}
