using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainView : MonoBehaviour
{
    [SerializeField] float followSmoothnessX = 5f;
    [SerializeField] float followSmoothnessY = 1f;
    [SerializeField] private Transform followTarget;

    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        transform.position = new Vector3(followTarget.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Lerp(pos.x, followTarget.position.x, followSmoothnessX * Time.deltaTime);
        pos.y = Mathf.Lerp(pos.y, cameraTransform.position.y, followSmoothnessY * Time.deltaTime);

        transform.position = pos;
    }
}
