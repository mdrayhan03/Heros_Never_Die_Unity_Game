using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private Transform bulletSpwan;
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private ShootingStart shooting;  // Exposed to the inspector
    private float speed = 8f;
    private float attackCooldown = 0f;
    private float cooldownTimer = Mathf.Infinity;

    private void Start()
    {
        // Ensure that shooting is correctly assigned
        if (shooting == null)
        {
            Debug.LogWarning($"{gameObject.name} has no ShootingStart assigned!");
        }
        else
        {
            StartCoroutine(BulletSpawn());
        }
    }

    IEnumerator BulletSpawn()
    {
        while (true)
        {
            attackCooldown = Random.Range(0.5f, 5f);

            if (shooting != null && shooting.isShooting && cooldownTimer > attackCooldown)
            {
                var bullet = Instantiate(bulletObj, bulletSpwan.position, bulletSpwan.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpwan.right * speed;

                cooldownTimer = 0;
            }

            cooldownTimer += Time.deltaTime;
            yield return null;
        }
    }
}
