using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBacteria : MonoBehaviour
{
    [SerializeField] float growthAmmount, shrinkAmmount;
    [SerializeField] float maxSize, minSize;
    [SerializeField] BacteriaMovement bacteriaMovemet;

    void OnCollisionEnter2D(Collision2D other) 
    {
        //Trigger EatOrganism if object collides with relevant organism.
        string tag = other.gameObject.tag;

        if (tag == "Enemy") EatOrganism(other.gameObject, growthAmmount);
        else if (tag == "Antidote") EatOrganism(other.gameObject, -shrinkAmmount);
    }

    //When the bacteria eats a relevant organism it should shrink or grow accordingly.
    void EatOrganism(GameObject organism, float scaleChange){
        Destroy(organism);

        float targetScale = transform.localScale.x + scaleChange;
        targetScale = Mathf.Clamp(targetScale, minSize, maxSize);
        bacteriaMovemet.BaseScale = new Vector3 (targetScale, targetScale,0);  
    }
}
