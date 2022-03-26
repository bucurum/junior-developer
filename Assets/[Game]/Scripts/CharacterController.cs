using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveDuration = 0.15f;
    [SerializeField] private float jumpDuration = 0.35f;
    [SerializeField] private float fallDuration = 0.4f;

    private Tween moveTween;

    private void Update()
    {
        HandlePlayerInputs();
    }

    private void HandlePlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandleMovement(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HandleMovement(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GoDown();
        }
    }

    private void HandleMovement(Vector3 deltaPos) {
        if (IsMoving())
        {
            return;
        }

        moveTween = transform.DOMove(transform.position + deltaPos, moveDuration).SetEase(Ease.InOutExpo);
    }

    private void Jump()
    {
        if (IsMoving())
        {
            return;
        }

        // TODO: Check if it is possible
        // Assume that there is a platform we can move.
        moveTween = transform.DOMoveY(transform.position.y + 3.5f, jumpDuration)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => {
                moveTween = transform.DOMoveY(transform.position.y - 0.5f, jumpDuration / 3f);
            });
    }

    private void GoDown()
    {
        if (IsMoving())
        {
            return;
        }

        // TODO: Check if it is possible
        moveTween = transform.DOMoveY(transform.position.y - 3f, fallDuration).SetEase(Ease.InSine);
    }

    private bool IsMoving()
    {
        return moveTween != null && moveTween.IsPlaying();
    }
}
