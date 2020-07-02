#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoadAttribute]

public static class LaunchfromStart
{
    public static string currentScene;

 
    static LaunchfromStart()
    {
        EditorApplication.playModeStateChanged += LogPlayModeState;
    }

    private static void LogPlayModeState(PlayModeStateChange state)
    {
        if (EditorApplication.isPlaying == false)
        {
            //EditorSceneManager.OpenScene("Assets/Scenes/outside.unity");
            return;
        }
    }


    [MenuItem("DevHelpers/Start-Stop")]
    static void DoSomething()
    {

        //EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.SaveOpenScenes();
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        EditorApplication.isPlaying = true;

    }
}
#endif