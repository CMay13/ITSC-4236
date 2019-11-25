using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private SpriteRenderer door;
    private Sprite exit;

    // Start is called before the first frame update
    private void Start()
    {
        door = GetComponent<SpriteRenderer>();
        exit = Resources.Load<Sprite>("Exit");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GameObject.FindWithTag("Key") == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
