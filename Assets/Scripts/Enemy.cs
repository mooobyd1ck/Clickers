using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemyHp;
    [SerializeField] private float _enemySpeed;
    [SerializeField] Rigidbody _enemyRigidbody;
    [SerializeField] private AudioSource _hit;
    [SerializeField] private ParticleSystem _explosionParticle;
    private float _damage = 5f;
    bool _moveForwardBool = true;
    bool _moveBackBool = true;

    void Start()
    {
        _enemyHp = Spawner._fullHp;
        _enemySpeed = Spawner._enemySpeed;
        _enemyRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        MoveDirection();
        HealthBar();
    }
    void OnMouseDown()
    {
        _hit.Play();
        _enemyHp -= _damage;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            _moveForwardBool = false;
            _moveBackBool = false;
        }
        if (other.gameObject.CompareTag("Wall2"))
        {
            _moveForwardBool = true;
            _moveBackBool = true;
        }
    }
    private void MoveDirection()
    {
        if (_moveForwardBool == true)
        {
            _enemyRigidbody.AddForce(Vector3.forward * _enemySpeed * Time.deltaTime, ForceMode.Impulse);

        }
        if (_moveBackBool == false)
        {
            StartCoroutine(EnemyRotatetad());
        }
    }

    private void EnemyRotate()
    {
        _enemyRigidbody.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime);
    }

    private void HealthBar()
    {
        if (_enemyHp <= 0)
        {
            Spawner._updateScoreValue += 1;
            Destroy(gameObject);
            Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        }
    }
    IEnumerator EnemyRotatetad()
      {
          EnemyRotate();
          _enemyRigidbody.AddForce(Vector3.back * _enemySpeed * Time.deltaTime, ForceMode.Impulse);
          yield break;
      }
   
}


