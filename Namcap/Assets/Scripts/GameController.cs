using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject life1, life2, life3;
    public static int lives;

    private float delay = 50f;

    [SerializeField]private string sceneName;

    // Start is called before the first frame update
    public void Start()
    {
        lives = 3;
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void Update()
    {
        switch (lives)
        {
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                break;
            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                break;
            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                break;
            case 0:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                Time.timeScale = 0;

                delay--;

                if (delay == 0)
                {
                    SceneManager.LoadScene(sceneName);
                }

                break;
        }
    }
}
