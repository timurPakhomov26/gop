using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Hero : MonoBehaviour
{
  [SerializeField] private int _health;
  [SerializeField] private LevelUI _levelUI;
  private Rigidbody2D _rigidbody2D;


  private void Start()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
    UsePhysics(false);
    
  }

  public void UsePhysics (bool usePhysics) => _rigidbody2D.isKinematic = !usePhysics;

  public void TakeDamage(int value)
  {
      _health -= value;
      if (_health < 0)
      {
          _health = 0;
          Die();
      }
  }
  private void Die()
  { 
      _levelUI.Restart();
  }

  
}
