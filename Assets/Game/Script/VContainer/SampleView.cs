using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleView : MonoBehaviour
{
    // View�N���X
    [SerializeField] private Text text;

    public void DrawText(string value)
    {
        text.text = value;
    }

}
