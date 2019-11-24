using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    private SpriteRenderer render;
    private Sprite entrance, exit;

    // Start is called before the first frame update
    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        entrance = Resources.Load<Sprite>("Entrance");
        exit = Resources.Load<Sprite>("Exit");
        render.sprite = entrance;
    }

    // Update is called once per frame
    private void Update()
    {
        if(GameObject.FindWithTag("Key") == null)
        {
            render.sprite = exit;
        }
    }
}
