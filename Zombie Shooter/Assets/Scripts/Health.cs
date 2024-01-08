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

    ScoreKeeper scoreKeeper;
    [SerializeField] bool isPlayr;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
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
            if (!isPlayr)
            {
                scoreKeeper.SetScore(50);
            }
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
