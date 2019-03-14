using UnityEngine;

public class MultipleGun : MonoBehaviour, IWeapon
{
    int amountAmmo = 10;
    float rotateAngleBulllet = 40f;

    public GameObject prefabShell;

    GameObject ammunitionDepot;

    float spawnRange = 0.5f;
    float nextFireTime;
    float timeShoots = 0.5f;

    void Awake()
    {
        ammunitionDepot = GameObject.FindWithTag("Weapons");
    }

    void Start()
    {
        nextFireTime = Time.time;
    }

    public void Attack()
    {
        if (Input.GetButtonDown("X") && (nextFireTime <= Time.time))
        {
            nextFireTime = Time.time + timeShoots;

            for (int i = 0; i < amountAmmo; i++)
            {
                var shell = Instantiate(prefabShell);

                shell.transform.parent = ammunitionDepot.transform;
                shell.transform.position = transform.position + transform.up * spawnRange;
                shell.transform.rotation = transform.rotation;
                shell.transform.Rotate(Vector3.forward * rotateAngleBulllet * (i - 1));
               
            }
        }
    }
}


