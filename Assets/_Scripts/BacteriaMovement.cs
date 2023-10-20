using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaMovement : MonoBehaviour
{
    public Vector3 BaseScale {get; set;}
    [SerializeField] bool movement;
    [SerializeField] float movementSpeed, rotationSpeed;
    [SerializeField] float wobbleAmmount;

    void Start(){
        BaseScale = transform.localScale;
    }

    void FixedUpdate()
    {
        //Rotation
        Vector3 rotationVector = new Vector3(0, 0, rotationSpeed);
        transform.Rotate(rotationVector, Space.Self);

        //Movement
        if(movement){
            Vector3 movementVector = new Vector3(
                Random.Range(-movementSpeed, movementSpeed), 
                Random.Range(-movementSpeed, movementSpeed));

            transform.Translate(movementVector);
        }

        //Wobble
        Vector3 randomWobble = new Vector3(
            Random.Range(-wobbleAmmount, wobbleAmmount), 
            Random.Range(-wobbleAmmount, wobbleAmmount));

        transform.localScale = BaseScale + randomWobble;
    }
}
