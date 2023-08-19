//日本語対応
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadImageScript : MonoBehaviour
{
    private Image _image;
    private AsyncOperationHandle _saveHandle;
    void Start()
    {
         _saveHandle = Addressables.LoadAssetAsync<Sprite>("Assets/Game/Image/TestLoadImage.png");
         _saveHandle.Completed +=
         x =>
         {
             _image = GetComponent<Image>();
             _image.sprite = Instantiate(x.Result as Sprite);
         };
    }

    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Addressables.Release(_saveHandle);
    }
}
