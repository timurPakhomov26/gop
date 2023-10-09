using UnityEngine;

public class Saw : Enemy
{
    [SerializeField] private int _damage;
    protected override int Damage => _damage;
    protected override void Attack()
    {
       
    }

    protected override void TouchLine(Transform transform)
    {
        
    }
}
