using System.Collections.Generic;
using UnityEngine;

public delegate void FinisDraw(bool state);

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private  GameObject _linePrefab;
    [SerializeField] private Hero _hero;
    [SerializeField] private LayerMask _cantDrawOverLayer;
    [SerializeField] private LevelUI _levelUI;
    private  Queue<Line> _lines = new Queue<Line>();
    private int _cantDrawOverLayerIndex;
    
    [Space ( 50f )]
    [SerializeField] private Gradient _lineColor;
    [SerializeField] private float _linePointsMinDistance;
    [SerializeField] private float _lineWidth;

    [SerializeField] private List<Bee> _bees = new List<Bee>();

    private Line _currentLine;

    private Camera _camera;

    private void Start() 
    {
        _camera = Camera.main;
        _cantDrawOverLayerIndex = 3;
    }

    private void Update() 
    {
        if ( Input.GetMouseButtonDown(0))
            BeginDraw();

        if ( _currentLine != null )
            Draw();

        if (Input.GetMouseButtonUp(0))
            EndDraw();
        
    }
    
    private  void BeginDraw() 
    {
        if(_lines.Count > 1)
             return;
        
        _currentLine = Instantiate ( _linePrefab, this.transform ).GetComponent <Line> ();
        
        _currentLine.UsePhysics (false);
        _currentLine.SetLineColor ( _lineColor );
        _currentLine.SetPointsMinDistance (_linePointsMinDistance);
        _currentLine.SetLineWidth ( _lineWidth );

    }

    private void Draw ( ) 
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint ( Input.mousePosition );
        
        RaycastHit2D hit = Physics2D.CircleCast ( mousePosition, _lineWidth / 3f, Vector2.zero, 1f, _cantDrawOverLayer );

        if ( hit )
            EndDraw ( );
        else
            _currentLine.AddPoint ( mousePosition );
    }
    
    
    private  void EndDraw ( ) 
    {
        if (_currentLine == null) 
             return;

        if (_currentLine.PointsCount < 2) 
            {
                Destroy (_currentLine.gameObject);
            } 
            
        else 
            {
                _currentLine.gameObject.layer = _cantDrawOverLayerIndex;
                
                _currentLine.UsePhysics (true);
                
                _lines.Enqueue(_currentLine);
                _hero.UsePhysics(true);
                
                _currentLine = null;
                
                _levelUI.ChangeCanRecreaseTime();
                
                if (_bees != null)
                {
                    foreach (var bee in _bees)
                    {
                        bee.ChangeCanMove();
                    }
                }
            }
    }
}
