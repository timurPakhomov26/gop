using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Bee : Enemy
{
    [SerializeField] private Transform _hero;
    private NavMeshAgent _agent;
    [SerializeField] private int _damage;
    protected override int Damage => _damage;
    public  bool CanMove{ get; private set; }
    
    protected override void Attack()
    {
        Destroy(this);
    }

    protected override void TouchLine(Transform transform)
    {
        _agent.isStopped = true;
        _rigidbody2D.AddForce(-(transform.position - transform.position) * 1000f,ForceMode2D.Force);
    }

    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (CanMove)
            Move();
    }

    private void Move()
    {
        _agent.SetDestination(new Vector3(_hero.transform.position.x,_hero.transform.position.y,1));
    }

    public void ChangeCanMove() => CanMove = true;

}
