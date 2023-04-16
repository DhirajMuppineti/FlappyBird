using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public static float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (!col.isTrigger)
        {
            Bird.gameOver = true;
        }
    }
    void Update()
    {

        if (transform.position.x < screenBounds.x * -1)
        {
            Destroy(this.gameObject);
        }
    }
}
