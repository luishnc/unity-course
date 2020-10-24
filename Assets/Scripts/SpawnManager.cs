using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;

    [SerializeField]
    private GameObject[] powerups;

    private GameManager _gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerupSpawnRoutine());
    }

    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerupSpawnRoutine());
    }

    IEnumerator EnemySpawn()
    {
        while (_gameManager.gameOver == false)
        {
            float randomXPosition = Random.Range(-7f, 7f);
            Instantiate(enemyShipPrefab, new Vector3(randomXPosition, 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);

        }
    }

    IEnumerator PowerupSpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            float randomXPosition = Random.Range(-7f, 7f);
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], new Vector3(randomXPosition, 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
    //create a coroutine to spawn an enemy every 5 seconds.


}
