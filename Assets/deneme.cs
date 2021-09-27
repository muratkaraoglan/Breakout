using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
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

        Debug.Log(direction);
        magnitude = Random.Range(minImpulse, maxImpulse);

        Debug.Log(magnitude);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * magnitude, ForceMode2D.Impulse);
        position = transform.position;
        x = position.x;
        y = position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform collidedWith = collision.transform;

        Vector2 norm = collidedWith.position.normalized;

        Debug.Log(transform.up);
        float dot = Vector2.Dot(transform.up, norm);
        float angleInRadian = Mathf.Acos(dot);

        //Debug.Log(dot+" "+ angle*Mathf.Rad2Deg);
        float angleInDegree = angleInRadian * Mathf.Rad2Deg + 180f;

        direction = new Vector2(Mathf.Cos(angleInDegree), Mathf.Sin(angleInDegree));
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * magnitude, ForceMode2D.Impulse);

    }
}
