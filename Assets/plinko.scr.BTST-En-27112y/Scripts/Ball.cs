using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Action<GameObject> OnCollided { get; set; } = delegate { };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollided?.Invoke(collision.gameObject);
    }
}
