using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * Class that controls behavior of player.
 * Contains methods to restart the game state, iniate game over, grow the snake in size, and basic controls for the direction of the player.
 */
public class Snake : MonoBehaviour
{
    // snake movement in x / y axes so Vector2 is required
    private Vector2 _direction = Vector2.right;

    // list to track snake segments, Note: initialized to prevent crashing
    private List<Transform> _segments = new List<Transform>();

    // references prefab snake segment
    public Transform segmentPrefab;

    public int initialSize = 3;

    public int finalScore = 0;

    // true if snake is moving, false otherwise
    private bool isMoving = true;

    public GameOverScreen gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        ResetState();
    }


    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // must assign a direction of snake based on user input
            if (Input.GetKeyDown(KeyCode.W))
            {
                _direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _direction = Vector2.down;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _direction = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _direction = Vector2.right;
            }
        }

    }


    // FixedUpdate is called at a fixed time interval, useful for consistent game physics
    private void FixedUpdate() 
    {
        // only updates position if snake should be moving
        if (isMoving)
        {
            //updating position of each segment starting from tail
            for (int i = (_segments.Count - 1); i > 0; i--)
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
    }


    // Adds a segment to the snake
    private void Grow()
    {
        // instatiantes a new segment and adds it to segment list
        Transform segment = Instantiate(this.segmentPrefab);

        // sets position of segment to be the end of the snake
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }


    // Destroys all segments in the snake
    private void DestroySnakeSegments()
    {
        // resetting number of segments starting at head
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        // must clear list because there are still references to destroyed game objects
        _segments.Clear();
    }


    /*
     * Restarts the game. 
     * Snake segments are set back to default value, additional segments are destroyed. 
     * Position is randomly reset.
     */
    public void ResetState()
    {
        isMoving = true;
        DestroySnakeSegments();

        //adding snake head object to start again
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; ++i)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        // resetting position of snake randomly
        this.transform.position = Vector3.zero;
    }


    /*
     * Initiates game over. 
     * The game over screen is displayed, the final score is displayed. 
     * Snake no longer moves.
     */
    public Boolean GameOver()
    {
        finalScore = _segments.Count;
        gameOverScreen.Setup(finalScore);

        isMoving = false;

        return true;
    }


    // On collision event, triggered to add segment when food object is collided with, or game over if snake segment / wall is collided with
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checks that player is what collided with object
        if (collision.tag == "Food")
        {
            Grow();
        }

        // game over if player collides with wall or other segments
        if (collision.tag == "Obstacle")
        {
            GameOver();
        }
    }
}
