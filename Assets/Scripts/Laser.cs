﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserOnTime = .5f;
    [SerializeField] float maxDistance = 300f;
    [SerializeField] float fireDelay = 2f;
    LineRenderer lr;
    Light laserLight;
    bool canFire;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>();
    }

    void Start()
    {
        lr.enabled = false;
        laserLight.enabled = false;
        canFire = true;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.red);   
    }

    Vector3 CastRay()
    {
        RaycastHit hit;

        Vector3 fw = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fw, out hit))
        {
            Debug.Log("We hit: " + hit.transform.name);

            SpawnExplosion(hit.point, hit.transform);

            return hit.point;
        }
        Debug.Log("WE MISSED");
        return transform.position + (transform.forward * maxDistance);
    }

    void SpawnExplosion(Vector3 hitPosion, Transform target)
    {
        Explosion temp = target.GetComponent<Explosion>();
        if (temp != null)
            temp.AddForce(hitPosion, target);

    }

    public void FireLaser()
    {
        Vector3 pos = CastRay();
        FireLaser(pos);
    }

    public void FireLaser(Vector3 targetPosition, Transform target = null)
    {
        if (canFire)
        {
            if (target != null)
            {
                SpawnExplosion(targetPosition, target);
            }

            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, targetPosition);
            lr.enabled = true;
            laserLight.enabled = true;
            canFire = false;
            Invoke("TurnOffLaser", laserOnTime);
            Invoke("CanFire", fireDelay);
        }
    }

    void TurnOffLaser()
    {
        lr.enabled = false;
        laserLight.enabled = false;
    }

    public float Distance
    {
        get { return maxDistance; }
    }

    void CanFire()
    {
        canFire = true;
    }
}
