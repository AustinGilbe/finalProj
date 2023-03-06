using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfer : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public logic Logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive) {
        
            myRigidBody.velocity = Vector2.up * flapStrength;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Logic.gameOver();
        birdIsAlive = false;
    }
}
