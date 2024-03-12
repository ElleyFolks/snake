using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class that controls the behavior of the food game object.
 * Contains methods to randomly change the position, and to handle collisions with food object.
 */
public class Food : MonoBehaviour
{
    // bounds where object can be positioned
    public BoxCollider2D gridArea;

    // Start is called first frame
    private void Start()
    {
        RandomizeFoodPosition();
    }


    // Changes position of food object to a random location within bounds.
    private void RandomizeFoodPosition()
    {
        Bounds bounds = this.gridArea.bounds;

        // gets a random position within bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // rounds to keep aligned with grid
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }


    // On collision event randomizes object to a new position 
    private void OnTriggerEnter2D(Collider2D other)
    {
        // checks that player is what collided with object
        if (other.tag == "Player") {
            RandomizeFoodPosition(); 
        }
    }
}
