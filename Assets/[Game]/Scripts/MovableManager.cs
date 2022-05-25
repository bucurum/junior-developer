using System.Collections.Generic;
using UnityEngine;

public class MovableManager : MonoBehaviour
{
    [SerializeField] private List<MovementType> movementList = new List<MovementType>();

    public Queue<MovementType> MovementQueue { get; private set; }
    
    public static MovableManager Instance { get; private set; }

    private void Awake()
    {
        // Singleton Pattern!
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // End of singleton codes.

        InstantiateMovementStack();
    }

    private void Start()
    {
        //GenerateText();
    }

    private void InstantiateMovementStack()
    {
        MovementQueue = new Queue<MovementType>(movementList);
    }

    private void GenerateText()
    {
        string result = "";

        movementList.ForEach(_movement => result += GetMovementText(_movement) + "\n");

        UIManager.Instance.SetInstructionsText(result);
    }

    private string GetMovementText(MovementType moveType)
    {
        switch (moveType)
        {
            case MovementType.MoveRight:    return "Sag();";
            case MovementType.MoveLeft:     return "Sol();";
            case MovementType.Jump:         return "Yukari();";
            case MovementType.GoDown:       return "Asagi();";
            default: return "";
        }
    }
}