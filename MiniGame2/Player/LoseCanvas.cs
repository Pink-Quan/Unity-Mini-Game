using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCanvas : MonoBehaviour
{
    public void PlayAgain()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("MiniGame2");
    }
}
