using System.Collections;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject laserPrefab;

    public float spawnDelay = 5f;

    public Vector3 spawnVelocity = new Vector3(0,0,0);
    void Start()
    {
        StartCoroutine(SpawnLasersRoutine());   
    }

    IEnumerator SpawnLasersRoutine(){
        while(true){
            GameObject newLaser=Instantiate(laserPrefab,transform.position,Quaternion.identity);
            newLaser.GetComponent<Rigidbody>().linearVelocity = spawnVelocity;
            yield return new WaitForSeconds(spawnDelay);
            Destroy(newLaser, 20f);
        }


        yield return null;
    }
}
