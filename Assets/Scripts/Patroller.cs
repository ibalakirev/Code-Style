using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _point;

    private Transform[] _pointsTrajectory;
    private int _currentIndexPoint;

    private void Start()
    {
        _pointsTrajectory = new Transform[_point.childCount];

        for (int i = 0; i < _pointsTrajectory.Length; i++)
        {
            _pointsTrajectory[i] = _point.GetChild(i);
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Transform currentPoint = _pointsTrajectory[_currentIndexPoint];

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, _speed * Time.deltaTime);

        if (transform.position == currentPoint.position)
        {
            LoopRoute();
        }
    }

    private void LoopRoute()
    {
        _currentIndexPoint++;

        _currentIndexPoint = _currentIndexPoint % _pointsTrajectory.Length;

        Vector3 nextPointDirection = _pointsTrajectory[_currentIndexPoint].transform.position;

        transform.forward = nextPointDirection - transform.position;
    }
}
