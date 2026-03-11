using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] AudioSource buttonBlip;
    public void startGame()
    {
        buttonBlip.Play();
        StartCoroutine(startGameCoroutine());
    }

    IEnumerator startGameCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("Game");
    }
}
