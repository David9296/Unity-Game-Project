using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraBounds : MonoBehaviour {

    public float alignDuration = 2f;
    private Bounds currentBounds;
   

    IEnumerator AlignToNewBounds()
    {
       
        Vector3 trackingVect = transform.position;

        Vector3 startVect = transform.position;

        float targX = currentBounds.center.x;
        float targY = currentBounds.center.y;
        //Finds Desired Camera Position at the current boundary.
        Vector3 targetPosition = new Vector3(targX, targY, transform.position.z);

        float lerp = 0;
        while (lerp < alignDuration)
        {

            lerp += Time.deltaTime;
            trackingVect = Lerp(lerp, alignDuration, startVect, targetPosition);
            transform.position = trackingVect;
            yield return 0;
        }

        //Takes In camera position and moves it to target
        transform.position = targetPosition; 
    }

    public void SetNewBounds(Bounds newBounds)
    {

        currentBounds = newBounds;
        StartCoroutine(AlignToNewBounds());
    }


    public static Vector3 Lerp(float currentTime, float duration, Vector3 start, Vector3 goal)
    {
        float step = (currentTime / duration);
        Vector3 result = Vector3.Lerp(start, goal, step); // Sets Position for camera from start to Goal at time amount 
        return result;
    }


}




