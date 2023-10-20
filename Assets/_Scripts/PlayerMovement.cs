using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float radiusLimit;
    void Update()
    {
        //Get player input.
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input.Normalize();

        //Move and rotate player.
        transform.Translate(input * movementSpeed * Time.deltaTime, Space.World);
        transform.right = Vector3.RotateTowards(transform.right, input, rotationSpeed * Time.deltaTime, 0);

        //Restrict player from going out of bounds.
        transform.position = Vector2.ClampMagnitude(transform.position, radiusLimit);
    }
}
