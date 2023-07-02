using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerListを保持しているScriptのつもり
/// </summary>
public class TestVManager : MonoBehaviour
{
    public SampleModel GetSampleModel => _sampleModel;
    private SampleModel _sampleModel = new SampleModel();
}
