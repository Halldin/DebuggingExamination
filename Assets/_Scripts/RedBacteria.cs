using UnityEngine;

public class RedBateria : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    Transform target;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        //Move towards player.
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //Kill player when they come into contact.
        if(other.gameObject.tag == "Player")
        {
            if(FindObjectOfType<WinstreakManager>() != null){
                FindObjectOfType<WinstreakManager>().Lose();
            }else{
                print("Singleton not detected! Play from Main Menu.");
            }
        }    
    }
}
