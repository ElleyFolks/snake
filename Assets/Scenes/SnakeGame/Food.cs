using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Bounds where object can be positioned
    public BoxCollider2D gridArea;

    // Start is called first frame
    private void Start()
    {
        RandomizedPosition();
    }

    private void RandomizedPosition()
    {
        // gets bounds
        Bounds bounds = this.gridArea.bounds;

        // gets a random position within bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // actually changes position (rounds to keep aligned with grid)
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    // Called when player collides with object, randomizing object in new position.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks that player is what collided with object
        if (other.tag == "Player") {
            RandomizedPosition(); 
        }
    }
}
