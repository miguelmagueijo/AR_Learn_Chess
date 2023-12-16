using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    [SerializeField]
    public string sceneName;

    public void ChangeScene() {
        Debug.Log("Changing scene to " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
