using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefabs;

    public GameObject powerUpPrefab ;
    private float spawnRange = 9;
    // Start is called before the first frame update
     public int waveNumber = 1;

     public int enemyCount ;
    void Start()
    {

        SpawnEnemyWave(waveNumber); 


    }
 
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        } 
    }

    void SpawnEnemyWave (int enemiesToSpawn){

    for (int i = 0; i < enemiesToSpawn; i++)
    {
      
    Instantiate(enemyPrefabs, GenerateSpawnPosition(), enemyPrefabs.transform.rotation);   
    }
 }

private Vector3 GenerateSpawnPosition(){
    //instead of using void, we use vector 3 because this function is to create and return 
    //a vector3 value, so then we also use the keyword return to return the value we want 
    //the function to call

    float spawnPosX = UnityEngine.Random.Range(-spawnRange,spawnRange);
         float spawnPosY = UnityEngine.Random.Range(-spawnRange, spawnRange);
          
          Vector3 randomPos = new Vector3(spawnPosX,0, spawnPosY);
           return randomPos;

}
}
