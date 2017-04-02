using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public string NextScene;

    public void SceneChanger()
    {
        SceneManager.LoadScene(NextScene);
    }
}
