using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public abstract class Enemy : MonoBehaviour
{
   protected abstract int Damage { get; }

   protected abstract void Attack();
   protected void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.GetComponent<Hero>())
      {
         other.gameObject.GetComponent<Hero>().TakeDamage(Damage);
         Attack();
      }

      if (other.gameObject.GetComponent<Line>())
         TouchLine(other.transform);
      
   }

   protected abstract void TouchLine(Transform transform);
}


