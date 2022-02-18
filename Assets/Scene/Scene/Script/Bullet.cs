using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _collisionCooldown = 0.5f;

    public Vector3 Direction { get; private set; }
    public int Power { get; private set; }
    float LaunchTime { get; set; }

    public UnityEvent OnDestroy;

    public AudioClip bulletDestroy;
    public ParticleSystem ps;
    

    internal Bullet Init(Vector3 vector3, int power)
    {
        Direction = vector3;
        Power = power;
        LaunchTime = Time.fixedTime;
        return this;
    }

    public void PlayParticlesAndSound()
    {
        //GameObject audioSpawned = Instantiate(gameObject, transform.position, Quaternion.identity,null);
        //audioSpawned.AddComponent<AudioSource>().PlayOneShot(bulletDestroy);
        //GameObject spawnedPs = Instantiate(ps.gameObject, transform.position,Quaternion.identity,null);
        //Destroy(spawnedPs, 4);
    }

    void FixedUpdate()
    {
        _rb.MovePosition((transform.position + (Direction.normalized * _speed)));
    }

    void LateUpdate()
    {
        transform.rotation = EntityRotation.AimPositionToZRotation(transform.position, transform.position + Direction);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;


        if (collision.TryGetComponent<IHealth>(out var c))
        {
            c.TakeDamage(Power);
            this.gameObject.SetActive(false); 
        };

        if (collision.TryGetComponent<ITouchable>(out var d))
        {
            d.Touch(Power);
            this.gameObject.SetActive(false);
        }


        if (collision.tag == "Wall")
            gameObject.SetActive(false);

        OnDestroy?.Invoke();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;



        if (collision.collider.TryGetComponent<IHealth>(out var c))
        {
            c.TakeDamage(Power);
            this.gameObject.SetActive(false); 
        };

        if (collision.collider.TryGetComponent<ITouchable>(out var d))
        {
            d.Touch(Power);
            this.gameObject.SetActive(false); 
        }
      ;

        if (collision.collider.tag == "Wall")
            gameObject.SetActive(false);

        OnDestroy?.Invoke();
    }

    private void Health_OnDamage(int arg0)
    {
        throw new NotImplementedException();
    }
}
