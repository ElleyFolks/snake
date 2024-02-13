using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // snake movement in x / y axes so Vector2 is required
    private Vector2 _direction = Vector2.right;

    // list to track snake segments
    private List<Transform> _segments;

    // references prefab snake segment
    public Transform segmentPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform); // adds 'head' or first segment
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
        //updating position of each segment starting from tail
        for(int i = (_segments.Count-1); i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;

        }

        // changing direction of head segment, rounding to keep snake aligned on a grid
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
            );
    }

    // adds a segment to snake
    private void Grow()
    {
        // instatiantes a new segment and adds it to segment list
        Transform segment = Instantiate(this.segmentPrefab);

        // sets position of segment to be the end of the snake
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    // trigger to add segment when food object is collided with
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks that player is what collided with object
        if (other.tag == "Food")
        {
            Grow();
        }
    }
}
