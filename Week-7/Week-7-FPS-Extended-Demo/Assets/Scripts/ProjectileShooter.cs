using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectile;
    public float shotForce;

    public float fireRate = .2f;
    bool canShoot = true;

    public AudioClip shot;
    public AudioSource source;
    void Update()
    {
        if (Input.GetMouseButton(1) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        source.PlayOneShot(shot);

        GameObject firedProjectile = Instantiate(projectile, transform.position + transform.forward, Quaternion.identity);
        Rigidbody projectileRB = firedProjectile.GetComponent<Rigidbody>();

        projectileRB.AddForce(transform.forward * shotForce, ForceMode.Impulse);
        projectileRB.AddTorque(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)));

        StartCoroutine("fireCooldown");
    }

    IEnumerator fireCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
