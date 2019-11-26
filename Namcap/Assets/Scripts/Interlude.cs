using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interlude : MonoBehaviour
{
    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
