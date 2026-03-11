using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyRandomizer : MonoBehaviour
{
    public string[] OneKey(string[] player)
    {
        float guess = Random.Range(0f, 1f);
        string[] selectedKey = new string[1];

        if (guess <= 0.33f) //Prima lettera
        {
            selectedKey[0] = player[0];
        }

        else if (guess >= 0.66f) //Seconda lettera
        {
            selectedKey[0] = player[2];
        }

        else //Terza lettera
        {
            selectedKey[0] = player[1];
        }

        return selectedKey;
    }

    public string[] TwoKey(string[] player)
    {
        float guess = Random.Range(0f, 1f);
        string[] selectedKey = new string[2];

        if (guess <= 0.33f) //Prima e seconda lettera
        {
            selectedKey[0] = player[0];
            selectedKey[1] = player[1];
        }

        else if (guess >= 0.66f) //Prima e terza lettera
        {
            selectedKey[1] = player[0];
            selectedKey[0] = player[2];
        }

        else //Seconda e terza lettera
        {
            selectedKey[0] = player[1];
            selectedKey[1] = player[2];
        }

        return selectedKey;
    }

    public string[] TwoKeyMixed(string[] playerA, string[] playerB)
    {
        float guess = Random.Range(0f, 1f);
        string[] selectedKey = new string[2];

        if (guess <= 0.11f) //Prima lettera di A e prima lettera di B
        {
            selectedKey[0] = playerA[0];
            selectedKey[1] = playerB[0];
        }

        else if (guess > 0.11f && guess <= 0.22f) //Prima lettera di A e seconda lettera di B
        {
            selectedKey[0] = playerA[0];
            selectedKey[1] = playerB[1];
        }

        else if (guess > 0.22f && guess <= 0.33f) //Prima lettera di A e terza lettera di B
        {
            selectedKey[0] = playerA[0];
            selectedKey[1] = playerB[2];
        }

        else if (guess > 0.33f && guess <= 0.44f) //Seconda lettera di A e prima lettera di B
        {
            selectedKey[0] = playerA[1];
            selectedKey[1] = playerB[0];
        }

        else if (guess > 0.44f && guess <= 0.55f) //Seconda lettera di A e seconda lettera di B
        {
            selectedKey[0] = playerA[1];
            selectedKey[1] = playerB[1];
        }

        else if (guess > 0.55f && guess <= 0.66f) //Seconda lettera di A e terza lettera di B
        {
            selectedKey[0] = playerA[1];
            selectedKey[1] = playerB[2];
        }

        else if (guess > 0.66f && guess <= 0.77f) //Terza lettera di A e prima lettera di B
        {
            selectedKey[0] = playerA[2];
            selectedKey[1] = playerB[0];
        }

        else if (guess > 0.77f && guess <= 0.88f) //Terza lettera di A e seconda lettera di B
        {
            selectedKey[0] = playerA[2];
            selectedKey[1] = playerB[1];
        }

        else //Terza lettera di A e terza lettera di B
        {
            selectedKey[0] = playerA[2];
            selectedKey[1] = playerB[2];
        }

        return selectedKey;
    }
}
