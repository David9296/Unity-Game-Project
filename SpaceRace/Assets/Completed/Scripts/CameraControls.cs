using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public GameObject player;
    private Vector3 playerPos;
    public float movSpeed;
    private float distanceAhead;

    public BoxCollider2D cameraBounds;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera cam;
    private float hHeight;
    private float hWidth;

  



    // Use this for initialization
    void Start()
    {


        minBounds = cameraBounds.bounds.min;
        maxBounds = cameraBounds.bounds.max;

        cam = GetComponent<Camera>();
        hHeight = cam.orthographicSize;
        hWidth = hHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Depending on what direction the player is looking look ahead with the camera in that direction
        



        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + hWidth, maxBounds.x - hWidth);

        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + hHeight, maxBounds.y - hHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }



}
