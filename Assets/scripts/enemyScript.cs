using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float speed;

    private SpriteRenderer sr;
    private Rigidbody2D rig;
    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine(enemyMovementLoop());
    }


    
    void Update()
    {
        
    }

    IEnumerator enemyMovementLoop()
    {
        yield return new WaitForSeconds(0.3f);
        transform.Translate(speed * Time.deltaTime, 0, 0);
        sr.flipX = true;
        yield return new WaitForSeconds(0.3f);
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        sr.flipX = false;
        StartCoroutine(enemyMovementLoop());


    }

   
}
