using UnityEngine;
using DG.Tweening;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveDuration = 0.15f;
    [SerializeField] private float jumpDelay = 0.35f;
    [SerializeField] private float jumpDuration = 0.35f;
    [SerializeField] private float fallDuration = 0.4f;
    [Space]
    [SerializeField] private Transform spriteRendererParent;

    private bool isDead = false;
    private Animator animator;
    private Tween moveTween;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameActive)
        {
            HandlePlayerInputs();
        }
    }

    private void HandlePlayerInputs()
    {
        if (IsMoving())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (IsMovementValid(MovementType.MoveRight))
            {
                Run(Vector3.right);
            }
            else
            {
                Dead();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (IsMovementValid(MovementType.MoveLeft))
            {
                Run(Vector3.left);
            }
            else
            {
                Dead();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (IsMovementValid(MovementType.Jump))
            {
                Jump();
            }
            else
            {
                Dead();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (IsMovementValid(MovementType.GoDown))
            {
                GoDown();
            }
            else
            {
                Dead();
            }
        }
    }

    private void Dead()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        animator.SetTrigger("Dead");
        GameManager.Instance.EndGame(false);
    }

    private void Run(Vector3 direction)
    {
        if (IsMoving())
        {
            return;
        }

        Vector3 mirroredScale = spriteRendererParent.transform.localScale;
        mirroredScale.x = (direction == Vector3.right) ? Mathf.Abs(mirroredScale.x) : -Mathf.Abs(mirroredScale.x);
        spriteRendererParent.transform.localScale = mirroredScale;

        animator.SetTrigger("Run");

        moveTween = transform.DOMove(transform.position + direction, moveDuration).SetEase(Ease.InSine);

        GameManager.Instance.hidePopupEvent?.Invoke();
    }

    private void Jump()
    {
        if (IsMoving())
        {
            return;
        }

        animator.SetTrigger("Jump");

        // Assume that there is a platform we can move.
        moveTween = transform.DOMoveY(transform.position.y + 3.5f, jumpDuration)
            .SetEase(Ease.OutCubic)
            .SetDelay(jumpDelay)
            .OnComplete(() => {
                moveTween = transform.DOMoveY(transform.position.y - 0.5f, jumpDuration / 3f);
            });

        GameManager.Instance.hidePopupEvent?.Invoke();
    }

    private void GoDown()
    {
        if (IsMoving())
        {
            return;
        }

        moveTween = transform.DOMoveY(transform.position.y - 3f, fallDuration).SetEase(Ease.InSine);

        GameManager.Instance.hidePopupEvent?.Invoke();
    }

    private bool IsMovementValid(MovementType moveType)
    {
        bool isValid = false;

        if (MovableManager.Instance.MovementQueue.Count != 0)
        {
            isValid = moveType == MovableManager.Instance.MovementQueue.Dequeue();

            if (MovableManager.Instance.MovementQueue.Count <= 0 && isValid)
            {
                GameManager.Instance.EndGame(true);
            }
        }

        return isValid;
    }

    //private bool CheckMovableTile(Vector3 direction)
    //{
    //    Vector3 rayPos = transform.position + direction + Vector3.up * 0.5f;
    //
    //    RaycastHit2D hit = Physics2D.Raycast(rayPos, rayPos, 2f);
    //
    //    if (hit.transform != null && hit.collider.CompareTag("Movable"))
    //    {
    //        Movable _movable = hit.collider.GetComponentInParent<Movable>();
    //
    //        //return _movable.Order == moveCount;
    //    }
    //
    //    return false;
    //}

    private bool IsMoving()
    {
        return moveTween != null && moveTween.IsPlaying();
    }
}
