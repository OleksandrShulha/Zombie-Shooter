using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    float minBoundsX = -3f;
    float maxBoundsX = 3f;
    float maxBoundsY = 130f;
    Transform playerPosition;
    void Start()
    {
        playerPosition = FindAnyObjectByType<Player>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.RightArrow) && (transform.position.x <= maxBoundsX))
            {
                transform.position = transform.position + new Vector3(1f * moveSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && (transform.position.x >= minBoundsX))
            {
                transform.position = transform.position + new Vector3(-1f * moveSpeed * Time.deltaTime, 0, 0);
            }
        }



        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow) &&(transform.position.y <= maxBoundsY))
            {
                if(transform.position.y < playerPosition.position.y)
                {
                    transform.position = transform.position + new Vector3(0, 1f * 10f * Time.deltaTime, 0);
                }
                else
                {
                    transform.position = transform.position + new Vector3(0, 1f * 7f * Time.deltaTime, 0);
                }

            }
            //if (Input.GetKey(KeyCode.DownArrow) && (transform.position.y >= 0))
            //{
            //    transform.position = transform.position + new Vector3(0, -1f * 10f * Time.deltaTime, 0);
            //}
        }

    }
}
