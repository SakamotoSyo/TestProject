using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

// Presenterクラス
public class SamplePresenter : IStartable
{
    private readonly SampleView _view;
    private readonly ISampleModel _model;

    [Inject]
    public SamplePresenter(SampleView view, ISampleModel model)
    {
        _view = view;
        _model = model;
    }

    public void Start()
    {
        // MonoBehaviorのStartメソッドが呼ばれるタイミングで実行でされる(IStartableのおかげ)
        var text = _model.GetRandomText();
        _view.DrawText(text);
    }
}
