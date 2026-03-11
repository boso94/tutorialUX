using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject character;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    float charX;
    [SerializeField] float newVelocity = 2.0f;
    int score = 0;
    public GameObject scoreObject;
    TextMeshProUGUI scoreText;

    public GameObject gameOverObject;
    public GameObject restartObject;
    public bool gameActive = true;

    string[] player1 = new string[3] { "w", "a", "s" };
    string[] player2 = new string[3] { "d", "f", "g" };

    public string[] genKey = new string[2];

    public GameObject parallax1;
    public GameObject parallax2;

    public GameObject spawner1;
    public GameObject spawner2;

    float timer = 0f;
    public float spawnTime = 2;

    public List<GameObject> shapesList = new List<GameObject>();

    [SerializeField] AudioSource wind;
    [SerializeField] AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        genKey = GenerateKey();
        showShapes(shapesList, genKey);
        gameOverObject.SetActive(false);
        restartObject.SetActive(false);
        newVelocity = 2.0f;
        prefab1.GetComponent<Obstacle>().velocity = newVelocity;
        prefab2.GetComponent<Obstacle>().velocity = newVelocity;
        prefab3.GetComponent<Obstacle>().velocity = newVelocity;
        CreateObstacle();
        scoreText = scoreObject.GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.text = $"Score: {score}";
        parallaxSpawner(parallax1);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("obstacle"))
        {
            gameActive = !GameObject.FindGameObjectWithTag("obstacle").GetComponent<Obstacle>().GetGameOver();
        }

        if (!GameObject.FindGameObjectWithTag("obstacle"))
        {
            genKey = GenerateKey();
            showShapes(shapesList, genKey);
            score++;
            CreateObstacle();
            character.GetComponent<CharacterMovement>().movementAllowed = true;
        }

        scoreText.text = $"Score: {score}";

        if (gameActive == false)
        {
            GameOver();
        }

        if (timer > spawnTime)
        {
            float randomCloud = Random.Range(0f, 1f);
            if (randomCloud < 0.5f)
            {
                parallaxSpawner(parallax1);
            }
            else
            {
                parallaxSpawner(parallax2);
            }

            timer = 0;
        }
        else
        {
            timer = timer + Time.deltaTime;
        }

    }

    void CreateObstacle()
    {
        float randomObstacle = Random.Range(0.0f, 1.0f);
        charX = character.GetComponent<Transform>().position.x;
        if (randomObstacle <= 0.3f)
        {
            //nemico 1
            Instantiate(prefab1, new Vector2(charX, -6), Quaternion.identity);
            prefab1.GetComponent<Obstacle>().velocity = newVelocity;

        }
        else if (randomObstacle > 0.3f && randomObstacle <= 0.6f)
        {
            //nemico 2
            Instantiate(prefab2, new Vector2(charX, -6), Quaternion.identity);
            prefab2.GetComponent<Obstacle>().velocity = newVelocity;
        }
        else if (randomObstacle > 0.6f)
        {
            //nemico 3
            Instantiate(prefab3, new Vector2(charX, -6), Quaternion.identity);
            prefab3.GetComponent<Obstacle>().velocity = newVelocity;
        }
        if (score > 8)
        {
            newVelocity = newVelocity + 0.1f;
        }


    }

    public void GameOver()
    {
        gameOverObject.SetActive(true);
        wind.Stop();
        music.Stop();
        newVelocity = 2.0f;
        foreach (GameObject shape in shapesList)
        {
            shape.SetActive(false);
        }
    }

    public string[] GenerateKey()
    {
        string[] key = new string[2];

        if (score < 3) //Prendi sempre una lettera dalla propria board
        {
            key[0] = character.GetComponent<KeyRandomizer>().OneKey(player1)[0];
            key[1] = null;
        }

        else if (score >= 3 && score < 6) //Prendi sempre due lettere dalla propria board
        {
            key = character.GetComponent<KeyRandomizer>().TwoKey(player1);
        }

        else if (score >= 6 && score < 9) //Prendi sempre una lettera dalla board altrui
        {
            key[0] = character.GetComponent<KeyRandomizer>().OneKey(player2)[0];
            key[1] = null;
        }

        else if (score >= 9 && score < 12) //Prendi sempre una lettera dalla propria board e un'altra dalla board altrui
        {
            key = character.GetComponent<KeyRandomizer>().TwoKeyMixed(player1, player2);
        }

        else //Alterna a caso tra le modalità
        {
            float guess = Random.Range(0.0f, 1.0f);
            if (guess <= 0.20f)
            {
                key[0] = character.GetComponent<KeyRandomizer>().OneKey(player1)[0];
                key[1] = null;
            }

            else if (guess > 0.20f && guess <= 0.40f)
            {
                key = character.GetComponent<KeyRandomizer>().TwoKey(player1);
            }

            else if (guess > 0.40f && guess <= 0.60f)
            {
                key[0] = character.GetComponent<KeyRandomizer>().OneKey(player2)[0];
                key[1] = null;
            }

            else if (guess > 0.60f && guess <= 0.80f)
            {
                key = character.GetComponent<KeyRandomizer>().TwoKey(player2);
            }

            else 
            {
                key = character.GetComponent<KeyRandomizer>().TwoKeyMixed(player1, player2);
            }
            
        }
        return key;
    }

    public void parallaxSpawner(GameObject cloud)
    {
        Vector3 origin;
        if (cloud.name == "parallax1")
        {
            origin = spawner1.transform.position;
        }
        else
        {
            origin = spawner2.transform.position;
        }
              
        Instantiate(cloud, origin, Quaternion.identity);
    }

    void showShapes(List<GameObject> shapes, string[] keys)
    {
        foreach (GameObject shape in shapes)
        {
            shape.SetActive(false);
        }

        foreach (GameObject shape in shapes)
        {
            foreach (string key in keys)
            {
                if (shape.name == key)
                {
                    shape.SetActive(true);
                }
            }
        }
    }

    /*public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
