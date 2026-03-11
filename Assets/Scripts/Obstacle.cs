using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float velocity = 1.0f;
    Rigidbody2D rigidBody;

    public bool gameOverBool = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "character")
        {
            gameOverBool = true;
            velocity = 1.0f;
        }

        if (collision.gameObject.name == "TopBorder")
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = transform.up * velocity;
    }

    public bool GetGameOver()
    {
        return gameOverBool;
    }
}
