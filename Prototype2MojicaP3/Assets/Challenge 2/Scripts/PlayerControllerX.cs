using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float SpawnRate = 1f;
    private float spawnTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= spawnTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            spawnTime = Time.time + SpawnRate;
        }
    }
}
