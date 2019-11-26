using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Vector3 respawnPoint;

    public GameObject playerPrefab;

    public void Start()
    {
        respawnPoint = new Vector3(-7, 5, 0);
        playerPrefab = Resources.Load("Player") as GameObject;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Key")
        {
            Debug.Log("Collected key!");
            Destroy(other.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameController.lives -= 1;
            Debug.Log("Lives remaining: " + GameController.lives);

            if (GameController.lives > 0)
            {
                Respawn();
            }
            else if (GameController.lives == 0)
            {
                Debug.Log("Game Over");
                Destroy(this.gameObject);
            }
        }
    }

    public void Respawn()
    {
        Debug.Log("Respawned");
        Instantiate(playerPrefab, respawnPoint, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
