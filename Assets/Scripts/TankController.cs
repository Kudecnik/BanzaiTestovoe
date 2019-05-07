using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _rotationSpeed;
   
   private Rigidbody _rigidbody;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }
   
   private void FixedUpdate()
   {
      var verticalInput = Input.GetAxis("Vertical");
      var horizontalInput = Input.GetAxis("Horizontal");

      _rigidbody.position += _rigidbody.transform.forward * verticalInput * _moveSpeed * Time.deltaTime;
      
      _rigidbody.transform.Rotate(0,horizontalInput * _rotationSpeed,0);
   }
}
