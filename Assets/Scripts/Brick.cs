using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.CompareTag("ball") )
        {
            collision.gameObject.transform.localScale = Vector2.one * brickValue/2;

            GameManager.Instance.BreakBrick(brickValue);
            Destroy(gameObject);
        }
    }



}
