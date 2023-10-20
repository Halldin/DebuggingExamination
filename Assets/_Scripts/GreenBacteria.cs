using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBacteria : MonoBehaviour
{
    [SerializeField] float growthAmmount, shrinkAmmount;
    [SerializeField] float maxSize, minSize;

    BacteriaMovement bacteriaMovemet;

    void Start(){
        bacteriaMovemet = GetComponent<BacteriaMovement>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Enemy") EatOrganism(other.gameObject, growthAmmount);
        if (other.gameObject.tag == "Antidote") EatOrganism(other.gameObject, -shrinkAmmount);
    }

    void EatOrganism(GameObject organism, float scaleChange){
        Destroy(organism);

        float targetScale = transform.localScale.x + scaleChange;
        targetScale = Mathf.Clamp(targetScale, minSize, maxSize);
        bacteriaMovemet.BaseScale = new Vector3 (targetScale, targetScale,0);  
    }
}
