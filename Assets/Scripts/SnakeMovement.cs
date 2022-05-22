using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private Transform _segmentPrefab;
    [SerializeField] private Player _player;
    [SerializeField] private int _initialSize;

    private List<Transform> _segments = new List<Transform>();
    private Transform _transform;
    private Vector2 _direction = Vector2.right;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _direction = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S))
            _direction = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.D))
            _direction = Vector2.right;
        else if (Input.GetKeyDown(KeyCode.A))
            _direction = Vector2.left;
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
            _segments[i].position = _segments[i - 1].position;

        float x = Mathf.Round(_transform.position.x) + _direction.x;
        float y = Mathf.Round(_transform.position.y) + _direction.y;
        _transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Food>(out Food food))
            Grow();
        else if (collision.TryGetComponent<Obstacle>(out Obstacle obstacle))
            ResetState();
    }

    private void ResetState()
    {
        _player.ResetState();

        for (int i = 1; i < _segments.Count; i++)
            Destroy(_segments[i].gameObject);

        _segments.Clear();
        _segments.Add(_transform);

        for (int i = 1; i < _initialSize; i++)
            _segments.Add(Instantiate(_segmentPrefab));

        _transform.position = Vector2.zero;
    }

    private void Grow()
    {
        Transform segment = Instantiate(_segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
}
