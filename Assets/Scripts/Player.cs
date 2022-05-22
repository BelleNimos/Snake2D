using UnityEngine;

public class Player : MonoBehaviour
{
    public int Apples { get; private set; }

    private void Start()
    {
        Apples = 0;
    }

    public void AddApples(int apples)
    {
        if (apples > 0)
            Apples += apples;
    }

    public void ResetState()
    {
        Apples = 0;
    }
}
