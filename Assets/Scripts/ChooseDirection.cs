using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDirection : MonoBehaviour
{
    public GameObject rightOrigin;
    public GameObject leftOrigin;

    float rightDist;
    float leftDist;

    public float minDist = 0.7f;

    Vector3 chosenDir = new Vector3(0, 0, 0);

    public Vector3 chooseDir()
    {
        RaycastHit2D rightHit = Physics2D.Raycast(rightOrigin.transform.position, Vector2.right);
        RaycastHit2D leftHit = Physics2D.Raycast(leftOrigin.transform.position, Vector2.left);

        if (rightHit.collider != null && leftHit.collider != null)
        {
            rightDist = rightHit.distance;
            leftDist = leftHit.distance;

            if (rightDist > minDist && leftDist > minDist)
            {
                //scegli la direzione verso cui c'è più spazio
                if (rightDist > leftDist)
                {
                    chosenDir = Vector3.right;
                }
                else
                {
                    chosenDir = Vector3.left;
                }
            }
            else
            {
                float guess = Random.Range(0f, 1f);
                if (guess >= 0.5f)
                {
                    chosenDir = Vector3.right;
                }
                else
                {
                    chosenDir = Vector3.left;
                }
            }
        }
        
        return chosenDir;
    }

}
