using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterMovement : MonoBehaviour
{
    public float velocity = 0.6f;

    bool move = false;
    public bool movementAllowed = true;

    public GameObject spawnerObject;
    ObstacleSpawn spawnerScript;

    public TextMeshProUGUI keyCombination;

    string[] key = new string[2];

    ObstacleSpawn gameOverScript;
    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = spawnerObject.GetComponent<ObstacleSpawn>();

        gameOverScript = GameObject.FindGameObjectWithTag("manager").GetComponent<ObstacleSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        key = spawnerScript.genKey;
        keyCombination.text = "Player 1, premi: " + key[0] + key[1];

        if (movementAllowed)
        {
            if (key[1] == null)
            {
                if (Input.GetKey(key[0]))
                {
                    move = true;                  
                }
            }
            else
            {
                if (Input.GetKey(key[0]) && Input.GetKey(key[1]) || Input.GetKey(key[1]) && Input.GetKey(key[0]))
                {
                    move = true;
                }
            }
        }

    }

    private void FixedUpdate()
    {
        if (move)
        {
            MoveCharacter();
        }
    }

    void MoveCharacter()
    {
        Vector3 direction = GetComponent<ChooseDirection>().chooseDir();
        transform.position += direction * velocity;
        move = false;
        movementAllowed = false;
    }
}
