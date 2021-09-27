using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{

    void Update()
    {
        if ( Input.GetKey(KeyCode.A) )
        {
            transform.position += new Vector3(-0.1f, 0, 0);
        }
        if ( Input.GetKey(KeyCode.D) )
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if ( collision.collider.CompareTag("LeftWall") )
        {
            transform.position += new Vector3(0.5f, 0, 0);
            //Debug.Log("Left");
        }
        else if ( collision.collider.CompareTag("RightWall") ) 
        {
            transform.position += new Vector3(-0.5f, 0, 0);
           // Debug.Log("Right");
        }
    }

}
