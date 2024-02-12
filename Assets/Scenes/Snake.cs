using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // snake movement in x / y axes so Vector2 is required
    private Vector2 _direction = Vector2.right;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // must assign a direction of snake based on user input
        if(Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }else if (Input.GetKeyDown(KeyCode.S)) { 
            _direction = Vector2.down;
        }else if (Input.GetKeyDown(KeyCode.A)) { 
            _direction = Vector2.left; 
        }else if(Input.GetKeyDown(KeyCode.D)) { 
            _direction = Vector2.right;
        }
    }

    // FixedUpdate is called at a fixed time interval, useful for consistent game physics
    private void FixedUpdate() 
    {
        // changing direction of snake, rounding to keep snake aligned on a grid
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
            );

    }
}
