using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    void PlayGame()
    {
        SceneManager.LoadScene("Play");
    }
}
