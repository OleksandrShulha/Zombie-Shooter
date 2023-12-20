using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float paddingOnScreen;


    void Start()
    {
        
    }

    void Update()
    {
        PlayerMove();
    }

    public float GetPlayrMoveSpeed()
    {
        return moveSpeed;
    }

    private void PlayerMove()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if(Input.GetKey(KeyCode.RightArrow) && (transform.position.x <= maxBounds.x - paddingOnScreen))
            {
                transform.position = transform.position + new Vector3(1f * moveSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && (transform.position.x >= minBounds.x + paddingOnScreen))
            {
                transform.position = transform.position + new Vector3(-1f * moveSpeed * Time.deltaTime, 0, 0);
            }
        }



        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow) && (transform.position.y <= maxBounds.y - paddingOnScreen))
            {
                transform.position = transform.position + new Vector3(0, 1f * moveSpeed * Time.deltaTime,  0);
            }
            if (Input.GetKey(KeyCode.DownArrow) && (transform.position.y >= minBounds.y + paddingOnScreen))
            {
                transform.position = transform.position + new Vector3(0, -1f * moveSpeed * Time.deltaTime,  0);
            }
        }

    }
}

