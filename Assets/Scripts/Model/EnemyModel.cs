using UnityEngine;

public class EnemyModel : MonoBehaviour {

    const int maxCountEnemies = 10;

    public GameObject prefabEnemy;

    float timeAfterLastSpawn = 0;
    float timeBetweenSpawnEnemies = 1f;

    int numberEnemies;
   
	void Update()
    {
        timeAfterLastSpawn += Time.deltaTime;

        if ( (numberEnemies < maxCountEnemies) && (timeAfterLastSpawn >= timeBetweenSpawnEnemies) )
        {
            Create();
        }
    }

    void Create()
    {
        timeAfterLastSpawn = 0;

        float randDirection = Random.Range(0, 360);
        float randDistance = Random.Range(10, 15);

        //float rotateAmount = Vector3.Cross(randDirection, transform.up).z;
        float newEnemyWithX = transform.position.x + (Mathf.Cos(randDirection * Mathf.Deg2Rad) * randDistance);
        float newEnemyWithY = transform.position.y + (Mathf.Sin(randDirection * Mathf.Deg2Rad) * randDistance);

        var enemy = Instantiate(prefabEnemy);

        enemy.transform.parent = transform;
        enemy.transform.position = new Vector2(newEnemyWithX, newEnemyWithY);
        enemy.transform.rotation = transform.rotation;

        numberEnemies++;
    }

    public void DestroyEnemyCount()
    {
        numberEnemies--;
    }
}
