using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Start is called before the first frame update
    private float posY;
    public float speed;
    public float limit = 3.5f;

    private Transform ball;

    public string playerTag;

    void Start()
    {
        ball = FindObjectOfType<BallController>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float speedTime = speed * Time.deltaTime;

        if (playerTag == "Player")
        {
            //Modificar a posição da raquete
            if (Input.GetKey(KeyCode.W))
            {
                posY = posY + speedTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                posY = posY - speedTime;
            }
        }
        else if (playerTag == "Player2")
        {

            if (Input.GetKeyDown(KeyCode.Return)){
                playerTag = "";
            }
            //Modificar a posição da raquete
            if (Input.GetKey(KeyCode.UpArrow))
            {
                posY = posY + speedTime;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                posY = posY - speedTime;
            }
            
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                playerTag = "Player2";
            }

            posY = Mathf.Lerp(transform.position.y, ball.position.y, speedTime);
        }

        if (posY > limit)
        {
            posY = limit;
        }
        else if (posY < -limit)
        {
            posY = -limit;
        }

        transform.position = new Vector3(transform.position.x, posY, transform.position.z);

    }
}
