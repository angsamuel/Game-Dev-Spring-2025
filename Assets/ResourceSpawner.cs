using UnityEngine;
using System.Collections.Generic;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject throwingStarBoxPrefab;
    public int maxThowingBoxes = 3;

    public List<Transform> spawnPucks;
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnResources();
    }

    void SpawnResources(){
        // for(int i = 0; i< maxThowingBoxes; i++){
        //     Instantiate(throwingStarBoxPrefab, new Vector3(Random.Range(-10f,10f),0.4f,Random.Range(-10f,10f)), Quaternion.identity);
        // }
        for(int i = 0; i< maxThowingBoxes; i++){
            int randomIndex = Random.Range(0,spawnPucks.Count);
            Instantiate(throwingStarBoxPrefab,spawnPucks[randomIndex].position + new Vector3(0,.4f,0), Quaternion.identity);
            spawnPucks.RemoveAt(randomIndex);
            //spawnPucks.Add()
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
