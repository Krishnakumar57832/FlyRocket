using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour
{
    public void onClick()
    {
        int currentIndexNumber = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentIndexNumber+ 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex );
    }
    public void Loadfrom1()
    {
        int currentIndexNumber = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentIndexNumber + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 1;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
