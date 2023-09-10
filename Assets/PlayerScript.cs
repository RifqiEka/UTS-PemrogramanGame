using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float RightEdge;
    public float LeftEdge;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.gameover)
        {
            return;
        }
        float Horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * Horizontal * Time.deltaTime * speed);
        if (transform.position.x < LeftEdge)
        {
            transform.position = new Vector2(LeftEdge, transform.position.y);
        }
        if (transform.position.x > RightEdge)
        {
            transform.position = new Vector2(RightEdge, transform.position.y);
        }
    }
}
