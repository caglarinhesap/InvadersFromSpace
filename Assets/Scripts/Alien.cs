using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int scoreValue;
    public GameObject explosion;
    public GameObject coinPrefab;
    public GameObject lifePrefab;
    public GameObject healthPrefab;

    private const int LIFE_SPAWN_CHANCE = 1;
    private const int HEALTH_SPAWN_CHANCE = 10;
    private const int COIN_SPAWN_CHANCE = 50;


    public void Kill()
    {
        UIManager.UpdateScore(scoreValue);
        AlienMaster.allAliens.Remove(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);

        int randomInt = Random.Range(0, 1000);

        if (randomInt <= LIFE_SPAWN_CHANCE)
        {
            Instantiate(lifePrefab, transform.position, Quaternion.identity);
        }
        else if (randomInt <= HEALTH_SPAWN_CHANCE)
        {
            Instantiate(healthPrefab, transform.position, Quaternion.identity);
        }
        else if (randomInt <= COIN_SPAWN_CHANCE)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }




        if (AlienMaster.allAliens.Count == 0)
        {
            GameManager.SpawnNewWave();
        }

        gameObject.SetActive(false);
    }

}
