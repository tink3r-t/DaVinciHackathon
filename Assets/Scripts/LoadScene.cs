using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
