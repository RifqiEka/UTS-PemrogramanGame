using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform Paddle;
    public float speed;
    public Transform Break;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.gameover)
        {
            return;
        }
        if (!inPlay)
        {
            transform.position = Paddle.position;
        }
        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bawah"))
        {
            Debug.Log("Out Of Bounds");
            rb.velocity = Vector2.zero;
            inPlay = false;
            GM.UpdateLives(-1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {
            Transform newBreak = Instantiate(Break, other.transform.position, other.transform.rotation);
            Destroy(newBreak.gameObject, 2f);
            GM.UpdateScore(other.gameObject.GetComponent<BrickScript>().points);

            Destroy(other.gameObject);
        }
    }
}
