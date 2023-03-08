using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject[] animalRightHorizontalPrefabs;
    public GameObject[] animalLeftHorizontalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 30;
    private float startDelay = 2;
    private float spawnInterval = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalRightHorizontal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalLeftHorizontal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalRightHorizontal()
    {
        int animalIndex = Random.Range(0, animalRightHorizontalPrefabs.Length);
        Vector3 spawnPosRightHorizontal = new Vector3(25, 0, Random.Range(-5, 30));

        Instantiate(animalRightHorizontalPrefabs[animalIndex], spawnPosRightHorizontal, animalRightHorizontalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalLeftHorizontal()
    {
        int animalIndex = Random.Range(0, animalLeftHorizontalPrefabs.Length);
        Vector3 spawnPosLeftHorizontal = new Vector3(-25, 0, Random.Range(-5, 30));

        Instantiate(animalLeftHorizontalPrefabs[animalIndex], spawnPosLeftHorizontal, animalLeftHorizontalPrefabs[animalIndex].transform.rotation);
    }
}
