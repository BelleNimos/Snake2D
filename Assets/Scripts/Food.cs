using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(AudioSource))]
public class Food : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _gridArea;
    [SerializeField] private Player _player;

    private Transform _transform;
    private AudioSource _audioSource;

    private const int CountApple = 1;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.0f;
        RandomizePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            RandomizePosition();
            _audioSource.volume = 1.0f;
            _audioSource.Play();
            _player.AddApple(CountApple);
        }
    }

    private void RandomizePosition()
    {
        Bounds bounds = _gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        _transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }
}
