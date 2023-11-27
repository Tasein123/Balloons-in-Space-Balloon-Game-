using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    public float speed = 5f; 
    private Vector3 shootDirection; 


    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(shootDirection * speed * Time.deltaTime);
    }

    public void SetShootDirection(Vector3 direction)
    {
        shootDirection = direction.normalized; 
    }

}
