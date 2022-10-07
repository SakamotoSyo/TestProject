
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEngine.SceneManagement;

public class SceneDropdown : EditorWindow
{
    [MenuItem("Window/SceneDropdown")]
    static void Init()
    {
        SceneDropdown window = (SceneDropdown)EditorWindow.GetWindow(typeof(SceneDropdown));
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Select a Scene", EditorStyles.boldLabel);

        if (EditorBuildSettings.scenes.Length == 0)
        {
            EditorGUILayout.HelpBox("No scenes are in the Build Settings.", MessageType.Info);
            return;
        }

        int selectedSceneIndex = EditorBuildSettings.scenes.ToList().FindIndex(s => s.path == EditorApplication.currentScene);

        selectedSceneIndex = EditorGUILayout.Popup("Scenes in Build Settings", selectedSceneIndex, EditorBuildSettings.scenes.Select(s => s.path).ToArray());

        if (GUILayout.Button("Open Scene"))
        {
            if (EditorBuildSettings.scenes[selectedSceneIndex].enabled)
            {
                EditorApplication.OpenScene(EditorBuildSettings.scenes[selectedSceneIndex].path);
                Debug.Log(EditorBuildSettings.scenes[selectedSceneIndex].path);
                //SceneManager.LoadScene(EditorBuildSettings.scenes[selectedSceneIndex].path);
            }
            else
            {
                EditorUtility.DisplayDialog("Can't Open Scene", "The selected scene is not enabled in the Build Settings.", "OK");
            }
        }
    }
}