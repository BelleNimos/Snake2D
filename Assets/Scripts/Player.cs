using UnityEngine;

public class Player : MonoBehaviour
{
    public int Apples { get; private set; }

    private void Start()
    {
        Apples = 0;
    }

    public void AddApple(int apple)
    {
        Apples += apple;
    }

    public void ResetState()
    {
        Apples = 0;
    }
}
