using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour {

    public string NextScene;

    public void SceneChanger()
    {
        SceneManager.LoadScene(NextScene);
    }
}
