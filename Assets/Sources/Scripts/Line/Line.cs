using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D),typeof(EdgeCollider2D))]
public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private EdgeCollider2D _edgeCollider;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [HideInInspector] public List<Vector2> points = new List<Vector2> ( );
    [HideInInspector] public int PointsCount = 0;
    
    private float _pointsMinDistance = 0.1f;
    
    private float _circleColliderRadius;
    
    
    public void AddPoint ( Vector2 newPoint ) 
    {
        if ( PointsCount >= 1 && Vector2.Distance ( newPoint, GetLastPoint ( ) ) < _pointsMinDistance )
            return;

        points.Add ( newPoint );
        PointsCount++;
        
        var circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.offset = newPoint;
        circleCollider.radius = _circleColliderRadius;
        
        _lineRenderer.positionCount = PointsCount;
        _lineRenderer.SetPosition (PointsCount - 1, newPoint);

        if ( PointsCount > 1 )
            _edgeCollider.points = points.ToArray();
    }

    public Vector2 GetLastPoint () 
    {
        return _lineRenderer.GetPosition (PointsCount - 1);
    }

    public void UsePhysics (bool usePhysics) => _rigidbody2D.isKinematic = !usePhysics;
    
    public void SetLineColor (Gradient colorGradient) => _lineRenderer.colorGradient = colorGradient;
    
    public void SetPointsMinDistance (float distance) 
    {
        _pointsMinDistance = distance;
    }

    public void SetLineWidth (float width) 
    {
        _lineRenderer.startWidth = width;
        _lineRenderer.endWidth = width;
        _circleColliderRadius = width / 2f;

        _edgeCollider.edgeRadius = _circleColliderRadius;
    }
}
