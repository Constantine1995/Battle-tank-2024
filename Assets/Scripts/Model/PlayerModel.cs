using UnityEngine;

public class PlayerModel: MonoBehaviour {
    //public float BaseHp { get { return Hp / MaxHp; } }
    //public bool isValueHpChanged { get; private set; }

    //private float Hp { get; set; }
    //private float MaxHp { get; set; }

    //public PlayerModel(float maxHp)
    //{
    //    MaxHp = maxHp;
    //    Hp = MaxHp;
    //}

    //public void LateUpdate()
    //{
    //    isValueHpChanged = false;
    //}
    //public void GetDamage(float damage)
    //{
    //    Hp = Hp - damage;
    //    isValueHpChanged = true;
    //}

    PlayerView hpDisplay;
    GameController gameController;

    float hp = 100.0f;
    [SerializeField]
    float defense = 0.5f;

    void Awake()
    {
        hpDisplay = FindObjectOfType<PlayerView>();
        gameController = FindObjectOfType<GameController>();
    }

    void Damage(float dmg)
    {
        hp -= dmg * defense;

        if (hp <= 0)
        {
            hp = 0;
            gameController.GameOver();
        }
        hpDisplay.UpdateHp(hp);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DestroyEnemy();
            Damage(other.GetComponent<IDamage>().GetDamage());
       }
    }
}
