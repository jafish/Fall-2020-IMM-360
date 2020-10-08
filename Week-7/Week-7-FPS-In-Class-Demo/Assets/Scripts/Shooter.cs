using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float range = 50;
    public float fireRate = .3f;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject projectile;
    public float shotForce = 50;

    bool canShoot = true;
    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot) 
        {
            fireGun();
        }

        if (Input.GetMouseButton(1) && canShoot)
        {
            fireProjectile();
        }
    }

    void fireGun() 
    {
        audioSource.PlayOneShot(audioClip);

        Ray r = new Ray(transform.position + transform.forward, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(r, out hit, range)) 
        {
            Target targetHit = hit.collider.GetComponent<Target>();
            
            if (targetHit != null) 
            {
                targetHit.OnHit();
            }
        }
        StartCoroutine("shotCooldown");
    }

    void fireProjectile() 
    {
        audioSource.PlayOneShot(audioClip);

        GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, Quaternion.identity);

        Rigidbody projectileRB = newProjectile.GetComponent<Rigidbody>();

        MeshRenderer r = newProjectile.GetComponent<MeshRenderer>();
        r.material.color = new Color(Random.value, Random.value, Random.value);

        projectileRB.AddForce(transform.forward * shotForce, ForceMode.Impulse);

        StartCoroutine("shotCooldown");
    }

    IEnumerator shotCooldown() 
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    private void OnDrawGizmos()
    {
        Ray r = new Ray(transform.position + transform.forward, transform.forward);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(r);
    }

    
}
