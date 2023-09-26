using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBacteria : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float growthAmmount;
    [SerializeField] float maxSize;
    Vector3 startPosition => transform.position;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "dontforgettoupdatethetag")
        {
            print("Ate Enemy");
            Destroy(other.gameObject);

            if(transform.localScale.x < maxSize){
                transform.localScale += new Vector3 (growthAmmount, growthAmmount,0);
            }
        }    
    }

    void FixedUpdate()
    {
        transform.position = startPosition + new Vector3(Random.Range(-movementSpeed,movementSpeed), Random.Range(-movementSpeed,movementSpeed), 0);
    }
}
