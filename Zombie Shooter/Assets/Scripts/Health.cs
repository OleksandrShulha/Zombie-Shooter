using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healt = 10;
    [SerializeField] ParticleSystem hitEfect;

    CameraShake cameraShake;
    [SerializeField] bool apleyCameraShake;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    public int GetHealt()
    {
        return healt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            HitEfect();
            damageDealer.Hit();
            ShakeCamera();
            TakeDamage(damageDealer.GetDamage());
        }
    }

    private void ShakeCamera()
    {
        if (cameraShake != null && apleyCameraShake)
        {
            cameraShake.Play();
        }
    }

    private void TakeDamage(int damage)
    {
        healt -= damage;

        if (healt <= 0)
        {
            Destroy(gameObject);
        }
    }

    void HitEfect()
    {
        if(hitEfect != null)
        {
            ParticleSystem instantiante = Instantiate(hitEfect, transform.position, Quaternion.identity);
            Destroy(instantiante, instantiante.main.duration + instantiante.main.startLifetime.constantMax);
        }
    }
}
