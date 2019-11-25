using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private SpriteRenderer door;
    private Sprite exit;

    Scene currentScene;
    string currSceneName;

    // Start is called before the first frame update
    private void Start()
    {
        door = GetComponent<SpriteRenderer>();
        exit = Resources.Load<Sprite>("Exit");

        currentScene = SceneManager.GetActiveScene();
        currSceneName = currentScene.name;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GameObject.FindWithTag("Key") == null)
            {
                if (currSceneName == "1-Summer")
                {
                    SceneManager.LoadScene("2-Fall", LoadSceneMode.Single);
                }
                else if (currSceneName == "2-Fall")
                {
                    SceneManager.LoadScene("3-Winter", LoadSceneMode.Single);
                }
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(GameObject.FindWithTag("Key") == null)
        {
            door.sprite = exit;
        }
    }
}
