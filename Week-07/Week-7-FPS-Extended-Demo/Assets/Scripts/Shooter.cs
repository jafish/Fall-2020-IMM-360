using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float range;
    public float fireRate = .2f;
    public AudioClip shot;
    public AudioSource source;

    public ParticleSystem shootParticles;

    bool canShoot = true;
    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot) 
        {
            Shoot();
        }
    }

    void Shoot() 
    {
        source.PlayOneShot(shot);
        shootParticles.Play();
        Ray ray = new Ray(transform.position + transform.forward, transform.forward);
        RaycastHit hit = new RaycastHit();

        if(Physics.Raycast(ray, out hit, range)) 
        {
            Zombie targetHit = hit.collider.GetComponent<Zombie>();
            if (targetHit) 
            {
                targetHit.OnHit();
            }
        }

        StartCoroutine("fireCooldown");
    }

    IEnumerator fireCooldown() 
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
