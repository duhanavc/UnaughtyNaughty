using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical"); //var Vertical : float= bla bla �eklindede tan�mlayabilirdik

        Vector3 movementDir = new Vector3(horizontal, 0, Vertical);
        rb.velocity = movementDir * movementSpeed;
        //0 verildi�inde herhangi bi�ey yapmamas�n� sa�l�yor.
        if (movementDir == Vector3.zero)
        {
            return;
        }

        //movement direction y�n�n� rotation olarak al
        var rotationDirection = Quaternion.LookRotation(movementDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime); // slerp haraketimize zaman eklememize yar�yor 
        // ba��ndaki S ise haraketin smooth olmas�n� sa�l�yor 
        
    }

    

}
