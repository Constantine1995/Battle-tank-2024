using UnityEngine;

public class EnemyController : MonoBehaviour, IDamage
{

    const int typesEnumy = 3;

    GameObject player;
    EnemyModel enemyModel;

    public Sprite[] imageEnemy = new Sprite[typesEnumy];

    int enemyType;

    float damageEnemy;
    float defenseEnemy;
    float healthEnemy;
    float speedEnemy;

    void Awake()
    {
        enemyType = Random.Range(0, typesEnumy);
        SetEnemy(enemyType);

        player = GameObject.FindWithTag("Player");
        enemyModel = FindObjectOfType<EnemyModel>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void SetEnemy(int type)
    {
        switch (type)
        {
            case 0:
                damageEnemy = 10f;
                healthEnemy = 20f;
                defenseEnemy = 1f;
                speedEnemy = 3f;
                GetComponent<SpriteRenderer>().sprite = imageEnemy[0];
                break;
            case 1:
                damageEnemy = 20f;
                healthEnemy = 40f;
                defenseEnemy = 0.8f;
                speedEnemy = 4f;
                GetComponent<SpriteRenderer>().sprite = imageEnemy[1];
                break;
            case 2:
                damageEnemy = 50f;
                healthEnemy = 50f;
                defenseEnemy = 0.5f;
                speedEnemy = 1.5f;
                GetComponent<SpriteRenderer>().sprite = imageEnemy[2];
                break;
        }
    }

    public void DestroyEnemy()
    {
        enemyModel.DestroyEnemyCount();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            Damage(other.GetComponent<IDamage>().GetDamage());
            Destroy(other.gameObject);
        }
    }

    public float GetDamage()
    {
        return damageEnemy;
    }


    void Damage(float dmg)
    {
        healthEnemy -= dmg * defenseEnemy;
        if (healthEnemy <= 0)
        {
            DestroyEnemy();
        }
    }

    void Move()
    {
        Vector3 delta = player.transform.position - transform.position;
        delta.Normalize();
        transform.position = transform.position + delta * speedEnemy * Time.deltaTime;
    }
}
