using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CHASE : MonoBehaviour
{
    
    public float speed = 5f;

    
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
   // this code is from vlogize, I've changed it to make it go to the right