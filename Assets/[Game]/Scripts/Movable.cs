using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField] private int order;

    public int Order
    {
        get
        {
            return order;
        }
    }

    private Trigger trigger;

    private void Awake()
    {
        trigger = GetComponentInChildren<Trigger>();
        trigger.onTriggerEnter2D.AddListener(OnChildTriggerEnter2D);
    }

    private void OnChildTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyTile();
        }
    }

    public void DestroyTile()
    {
        gameObject.SetActive(false);
    }
}
