using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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