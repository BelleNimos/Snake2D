using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _apples;
    [SerializeField] private Player _player;

    private void Update()
    {
        _apples.text = _player.Apples.ToString();
    }
}
