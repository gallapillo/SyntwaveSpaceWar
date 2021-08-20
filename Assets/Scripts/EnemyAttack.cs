using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Laser laser;

    Vector3 hitPosition;

    void Update()
    {
        if (!FindTarget())
            return; 
        InFront();
        HaveLineOfSightRayCast();
        if(InFront() && HaveLineOfSightRayCast())
        {
            Firelaser();
        }
    }

    bool InFront()
    {
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        // in range
        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            //Debug.DrawLine(transform.position, target.position, Color.green);
            return true;
        }
        //Debug.DrawLine(transform.position, target.position, Color.yellow);
        return false;

    }

    bool HaveLineOfSightRayCast()
    {
        RaycastHit hit;

        Vector3 direction = target.position - transform.position;
        //  Debug.DrawRay(laser.transform.position, direction, Color.yellow);
        if (Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance))
        {
            //Debug.Log(hit.transform.tag);
            if (hit.transform.CompareTag("Player"))
            {
                Debug.DrawLine(laser.transform.position, hit.point, Color.blue);
                hitPosition = hit.transform.position;
                return true;
            }
        }

        return false;
    }

    void Firelaser()
    {
        laser.FireLaser(hitPosition, target);
    }

    bool FindTarget()
    {
        if (target == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            if (temp != null)
            {
                target = temp.transform;
            }
        }

        if (target == null)
            return false;

        return true;
    }
}
