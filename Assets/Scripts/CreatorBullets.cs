using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CreatorBullets : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedBullet;
    [SerializeField] float _timeWaitShoot;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isShoot = true;
        WaitForSeconds wait = new WaitForSeconds(_timeWaitShoot);

        while (isShoot)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.transform.up = direction;
            bullet.velocity = direction * _speedBullet;

            yield return wait;
        }
    }
}