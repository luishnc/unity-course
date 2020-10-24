using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;

    [SerializeField]
    private GameObject[] powerups;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerupSpawnRoutine());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            float randomXPosition = Random.Range(-7f, 7f);
            Instantiate(enemyShipPrefab, new Vector3(randomXPosition, 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);

        }
    }

    IEnumerator PowerupSpawnRoutine()
    {
        while (true)
        {
            float randomXPosition = Random.Range(-7f, 7f);
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], new Vector3(randomXPosition, 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
    //create a coroutine to spawn an enemy every 5 seconds.


}
