using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;
    private Vector3 offset = new Vector3(0, 0, 1.5f);
    static int score = 0;
    public static int lives = 3;

    static public void hit()
    {
        lives--;
        if (lives > 0)
        {
            Debug.Log($"Lives = {lives}");
        }
        else
        {
            Debug.Log("Game Over!");
            Destroy(GameObject.FindWithTag("FarmerPlayer"));
        }
    }

    static public void addScore()
    {
        score++;
        Debug.Log($"Score = {score}");
    }

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Bounds the player horizontaly
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // Bounds the player vertically
        if (transform.position.z > 30)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 30);
        }
        if (transform.position.z < -8)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -8);
        }

        // Moves the player left or right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        // Moves the player up and down
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        //Launch a food projectile from player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + offset, projectilePrefab.transform.rotation);
        }
    }
}
