using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 position;
    float x, y;
    public float minImpulse = 4f;
    public float maxImpulse = 6f;
    float angle;
    Vector2 direction;

    float magnitude;
    void Start()
    {

        angle = Random.Range(0, 180);

        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Debug.Log("before: " + direction);
        if ( Mathf.Floor(direction.x) == 1.0 || Mathf.Floor(direction.x) == -1.0 )
        {
            direction.x += 0.5f;
        }
        if ( Mathf.Floor(direction.y) == 1.0 || Mathf.Floor(direction.y) == -1.0 )
        {
            direction.y += 0.5f;
        }

        //Debug.Log(direction);
        magnitude = Random.Range(minImpulse, maxImpulse);

        //Debug.Log(magnitude); 

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * magnitude, ForceMode2D.Impulse);
        position = transform.position;
        x = position.x;
        y = position.y;

        StartCoroutine(CheckY());
    }

    IEnumerator CheckY()
    {
        while ( true )
        {
            yield return new WaitForSeconds(1f);
            if ( y == transform.position.y )
            {
                rb.AddForce(Vector2.up * 0.5f * magnitude, ForceMode2D.Impulse);
            }
            y = transform.position.y;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.gameObject.name == "Ground" )
        {
            Debug.Log("ground");
        }
    }
}
