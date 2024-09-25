using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float goal;
    private int randomStart;
    private Vector2 direction;
    public float delay = 2f;
    private bool playing = false;
    public AudioClip boing;
    public Transform camPos;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        delay -= Time.deltaTime;

        if (delay <= 0 && !playing)
        {
            startBall();
            playing = true;
        }


        if (transform.position.x >= goal || transform.position.x <= -goal)
        {
            SceneManager.LoadScene(0);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boing, camPos.position);

    }

    private void startBall()
    {
        rb = GetComponent<Rigidbody2D>();

        randomStart = Random.Range(0, 4);

        if (randomStart == 0)
        {
            direction.x = speed;
            direction.y = speed;
        }
        else if (randomStart == 1)
        {
            direction.x = -speed;
            direction.y = speed;
        }
        else if (randomStart == 2)
        {
            direction.x = -speed;
            direction.y = -speed;
        }
        else
        {
            direction.x = speed;
            direction.y = -speed;
        }

        //Adicionando força na bola
        rb.velocity = direction;
    }
}
