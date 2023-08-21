using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Build;
using UnityEditor.PackageManager.UI;
using UnityEngine;


public class Spawner : MonoBehaviour
{

    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }


    public SpawnableObject[] objects;
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;
    Vector3 startPosition;

    private void OnEnable()
    {

        startPosition = transform.position;
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

     private void OnDisable()
    {
        CancelInvoke();
    }  

    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                // obstacle -> reference to the tag we gave to our prefabs

                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += startPosition;

                break;
            }

          // incase its greater than the object spawn chance, we have to minimize else no object will be spawned
               spawnChance -= obj.spawnChance;
            
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

}




    

