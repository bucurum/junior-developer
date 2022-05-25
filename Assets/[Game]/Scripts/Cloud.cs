using UnityEngine;
using DG.Tweening;

public class Cloud : MonoBehaviour
{
    private void Awake()
    {
        float xScale = Random.Range(0.75f, 1.05f);
        float yScale = xScale * Random.Range(0.8f, 0.95f);
        float animationDuration = Random.Range(0.75f, 1.2f);

        Vector3 posDelta = Random.insideUnitSphere * Random.Range(0f, 1.2f);
        posDelta.z = 0f;
        posDelta.y *= 1.2f;
        transform.position += posDelta;

        transform.localScale = new Vector3(xScale, yScale, 0f);
        transform.DOScale(new Vector3(xScale * 1.05f, yScale * 0.96f, 0f), animationDuration).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
