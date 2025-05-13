using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public int waveNumber = 1;
    public int enemycount; 
    private float spawnPos = 9.0f;
    public GameObject enemySpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(SpawnPrefab, RandomPos(), SpawnPrefab.transform.rotation);
        spawnEnemyWave(waveNumber);
    }
    private void Update()
    {
        enemycount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemycount == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            Instantiate(SpawnPrefab, RandomPos(), SpawnPrefab.transform.rotation);
        }
    }
    void spawnEnemyWave(int enemiesspown)
    {
       
        for (int i = 0; i < enemiesspown; i++)
        {
            Instantiate(enemySpawner, RandomPos(), enemySpawner.transform.rotation);
        }
    }


   Vector3 RandomPos()
    {
        float spawnPosX = Random.Range(-spawnPos, spawnPos);
        float spawnPosZ = Random.Range(-spawnPos, spawnPos);
        Vector3 Position=  new Vector3(spawnPosX, 0, spawnPosZ);
        return Position;

    }

 
}
