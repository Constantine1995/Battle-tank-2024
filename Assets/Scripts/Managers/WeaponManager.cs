using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    IWeapon currentWeapon;
    GameObject curentrWeaponObject;
    GameController gameControleler;

    public GameObject[] weapons;

    float timeWeaponChange = 1f;
    float nextFireTime;

    int weaponType = 0;

    void Awake()
    {
        gameControleler = FindObjectOfType<GameController>();
        TakeNewWeapon(0);
    }

    void Start()
    {
        nextFireTime = Time.time;
    }

    void FixedUpdate()
    {
        if (gameControleler.isPlayerAlive)
        {
            currentWeapon.Attack();
            ChangeWeapon();
        }
    }

    void TakeNewWeapon(int index)
    {
        if (curentrWeaponObject != null)
        {
            Destroy(curentrWeaponObject);
        }

        if (weapons != null)
        {
            curentrWeaponObject = Instantiate(weapons[index], transform.position, transform.rotation, transform);
            currentWeapon = curentrWeaponObject.GetComponent<IWeapon>();
        }
    }

    void ChangeWeapon()
    {
        if (Input.GetButtonDown("W"))
        {
            if ((weaponType < 1) && (nextFireTime <= Time.time))
            {
                weaponType++;
                TakeNewWeapon(weaponType);
                nextFireTime = Time.time + timeWeaponChange;
            }
        }

        if (Input.GetButtonDown("Q"))
        {
            if ((weaponType > 0) && (nextFireTime <= Time.time))
            {
                weaponType--;
                TakeNewWeapon(weaponType);
                nextFireTime = Time.time + timeWeaponChange;
            }
        }
    }

}
