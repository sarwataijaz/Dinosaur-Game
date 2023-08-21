using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class moveScreen : MonoBehaviour
{

    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
       
         transform.position += Vector3.left * GameManager.instance.gameSpeed * Time.deltaTime;

        if (transform.position.x <= -1.5f)
        {
            // Reset the screen position to the starting position
            transform.position = startPosition;

        }
    }
}


