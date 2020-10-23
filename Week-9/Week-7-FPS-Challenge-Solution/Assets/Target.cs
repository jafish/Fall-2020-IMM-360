using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject projectile;
    public Transform targetTransform;
    public Vector3 fireOffset;
    public float shotForce;
    public float fireRate;

    bool canFire = true;
    void Update()
    {
        if (canFire) 
        {
            Fire();
        }
    }

    void Fire() 
    {
        GameObject newProjectile =  Instantiate(projectile, transform.position + transform.forward + fireOffset, Quaternion.identity);

        Vector3 shotDirection = (targetTransform.position - newProjectile.transform.position).normalized;

        newProjectile.GetComponent<Rigidbody>().AddForce(shotDirection * shotForce, ForceMode.Impulse);

        StartCoroutine("fireDelay");
    }

    IEnumerator fireDelay() 
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }


    public void OnHit() 
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + transform.forward + fireOffset, .15f);
    }
}
