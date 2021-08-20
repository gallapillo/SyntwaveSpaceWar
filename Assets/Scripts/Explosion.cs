using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject blowUp;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Sheild shield;
    [SerializeField] float laserHitModifer = 100f;
    
    public void IveBeenHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, 6f);
        if (shield == null)
            return;

        Debug.Log("TAKING DAMAGE");
        shield.TakeDamage();
    }



    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
            IveBeenHit(contact.point);
    }

    public void AddForce(Vector3 hitPosition, Transform hitSource)
    {
        IveBeenHit(hitPosition);

        if (rigidbody == null)
            return;

        Vector3 direction = hitSource.position - hitPosition;
        rigidbody.AddForceAtPosition(direction.normalized * laserHitModifer, hitPosition, ForceMode.Impulse);

    }

    public void BlowUp()
    {
        // summon particle effect\
        Instantiate(blowUp, transform.position, Quaternion.identity);
        // add points score if need

        // destroy
        Destroy(gameObject);

    }
}
