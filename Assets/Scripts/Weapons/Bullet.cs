using UnityEngine;

public class Bullet : MonoBehaviour, IWeapon  {

    public GameObject prefabShell;

    GameObject ammunitionDepot;

    float spawnRange = 0.5f;
    float nextFireTime;
    float timeBetweenShoots = 0.1f;

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
            nextFireTime = Time.time + timeBetweenShoots;

            var shell = Instantiate(prefabShell);
            shell.transform.parent = ammunitionDepot.transform;
            shell.transform.position = transform.position + transform.up * spawnRange;
            shell.transform.rotation = transform.rotation;
          
        }
    }
}
