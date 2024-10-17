using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl2 : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn; // Corrected spelling from bulletSpwan to bulletSpawn
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private ShootingStart shooting; // Exposed to the inspector
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
                var bullet = Instantiate(bulletObj, bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpawn.up * speed; // Corrected to 'up' for vertical movement

                cooldownTimer = 0;
            }

            cooldownTimer += Time.deltaTime;
            yield return null;
        }
    }
}
