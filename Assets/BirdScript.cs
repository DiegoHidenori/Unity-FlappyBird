using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public float flapStrength;
    public LogicScript logicScript;
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            rigidBody.linearVelocity = Vector2.up * flapStrength;
        }

        OutOfBounds();
    }

    private void OutOfBounds()
    {
        if (transform.position.y < -15 || transform.position.y > 20)
        {
            logicScript.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.gameOver();
        birdIsAlive = false;
    }
}
