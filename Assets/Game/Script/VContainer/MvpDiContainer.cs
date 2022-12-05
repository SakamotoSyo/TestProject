using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

// Viewクラス
public class SampleView : MonoBehaviour
{
    [SerializeField] private Text text;

    public void DrawText(string value)
    {
        text.text = value;
    }
}

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

// Modelクラス
public interface ISampleModel
{
    string GetRandomText();
}

public class SampleModel : ISampleModel
{
    public string GetRandomText()
        => "Test";
}

public class SampleModelMock : ISampleModel
{
    public string GetRandomText()
        => "Test";
}
