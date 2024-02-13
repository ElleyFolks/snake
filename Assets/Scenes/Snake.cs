using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // snake movement in x / y axes so Vector2 is required
    private Vector2 _direction = Vector2.right;

    // list to track snake segments, Note: initialized to prevent crashing
    private List<Transform> _segments = new List<Transform>();

    // references prefab snake segment
    public Transform segmentPrefab;

    // initial size of snake
    public int initialSize = 3;

    
    // Start is called before the first frame update
    void Start()
    {
        ResetState();
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

    // "game over", resets state to beginning
    private void ResetState()
    {
        // resetting "score" starting at head
        for (int i = 1; i < _segments.Count; i++) 
        {
            Destroy(_segments[i].gameObject);
        }

        // must clear list because there are still references to destroyed game objects
        _segments.Clear();

        //adding snake head object to start again
        _segments.Add(this.transform);
        
        for(int i = 1; i < this.initialSize; ++i)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        // resetting position of snake randomly
        this.transform.position = Vector3.zero;
    }

    // trigger to add segment when food object is collided with
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks that player is what collided with object
        if (other.tag == "Food")
        {
            Grow();
        }

        // Game over if snake collides with wall or other segments
        if(other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
