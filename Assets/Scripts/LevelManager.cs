using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string scene;
    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
