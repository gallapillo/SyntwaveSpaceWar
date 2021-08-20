using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] Thruster[] thruster;
    [SerializeField] Laser[] laser;
    Transform shipTransfrom;

    void Awake()
    {
        shipTransfrom = transform;    
    }

    void Update()
    {
        Turn();
        Thrust();
        Shoot();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        shipTransfrom.Rotate(-pitch, yaw, -roll);
    }
    void Thrust()
    {
        // star t call thurste

        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            foreach (Thruster t in thruster)
            {
                t.Intensity(Input.GetAxis("Vertical"), 1);
            }
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Laser l in laser)
            {
                Vector3 pos = transform.position + (transform.forward * l.Distance);
                l.FireLaser();
            }
        }
    }
}
