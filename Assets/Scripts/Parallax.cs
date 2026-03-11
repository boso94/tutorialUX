using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    Rigidbody2D myRigidBody;
    public float parallaxAmount = 10f;
    float randonmNum;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        randonmNum = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = Vector2.up * parallaxAmount * Time.deltaTime * randonmNum;

        if (gameObject.name == "parallax1")
        {
            if (gameObject.transform.position.y > 7f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (gameObject.transform.position.y > 7f)
            {
                Destroy(gameObject);
            }
        }
    }
}
