using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float buletLifetime = 5f;
    [SerializeField] float fireRate = 0.2f;
    [SerializeField] bool useAi;

    public bool isFiring;

    Coroutine fireCoroutine;
    void Start()
    {
        if (useAi)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();

    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContiniusli());
           
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
            
        }
    }

    IEnumerator FireContiniusli()
    {
        while (true)
        {
            GameObject bullet =  Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * bulletSpeed;
            }
            Destroy(bullet, buletLifetime);
            if (useAi)
            {
                fireRate = Random.Range(2f, 4f);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
}
