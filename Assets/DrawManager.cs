using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private Material _material;
    private LineRenderer _currentLine;
    private int _points;
    private int _currentPoint;
    private bool _drawing;

    // Start is called before the first frame update
    void Start()
    {
        _drawing = false;
        _currentLine = GetComponentInChildren<LineRenderer>();
        _currentLine.material = _material;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _drawing = true;
            _points = 0;
            _currentPoint = 0;
            _currentLine.positionCount = 0;
        }
        
        if (_drawing){
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var position = hit.point;
                if (_currentLine == null)
                {
                    _currentLine = this.AddComponent<LineRenderer>();
                }
                else
                {
                    
                }

                if (_currentPoint >= _points)
                {
                    _currentLine.positionCount += 1;
                }
                _currentLine.SetPosition(_currentPoint, position + new Vector3(0,0.1f,0));
                _currentPoint++;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _drawing = false;
        }
    }
}
