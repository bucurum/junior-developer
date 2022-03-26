using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent<Collider2D> onTriggerEnter2D = new UnityEvent<Collider2D>();
    public UnityEvent<Collision2D> onCollisionEnter2D = new UnityEvent<Collision2D>();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        onTriggerEnter2D?.Invoke(collider);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onCollisionEnter2D?.Invoke(collision);
    }
}
