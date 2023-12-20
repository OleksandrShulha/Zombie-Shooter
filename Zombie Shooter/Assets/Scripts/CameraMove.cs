using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] float boundsX = 3f;
    [SerializeField] float boundsY = 130f;


    Player player;
    Transform playerPosition;
    float moveSpeed;



    void Start()
    {
        player = FindAnyObjectByType<Player>();
        playerPosition = player.GetComponent<Transform>();
        moveSpeed = player.GetPlayrMoveSpeed();
    }


    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if ((transform.position.x < playerPosition.position.x) && (transform.position.x <= boundsX))
        {
            transform.position = transform.position + new Vector3(1f * moveSpeed / 4 * Time.deltaTime, 0, 0);
        }
        if ((transform.position.x > playerPosition.position.x) && (transform.position.x >= -boundsX))
        {
            transform.position = transform.position + new Vector3(-1f * moveSpeed / 4 * Time.deltaTime, 0, 0);
        }

        if ((transform.position.y < playerPosition.position.y) && (transform.position.y <= boundsY))
        {
            transform.position = transform.position + new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }
}
