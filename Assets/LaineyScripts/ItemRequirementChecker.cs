// ItemRequirementChecker.cs
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemRequirementChecker : MonoBehaviour
{
    [Tooltip("List of item keys required to satisfy this check")]
    [SerializeField] private List<string> requiredItems;
    [SerializeField] private bool checkOnStart = true;

    public UnityEvent onRequirementsMet;
    public UnityEvent onRequirementsNotMet;

    private static ItemRequirementChecker instance;


    public bool AllRequirementsMet { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public static ItemRequirementChecker GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        if (checkOnStart)
        {
            CheckRequirements();
        }
    }


    public void CheckRequirements()
    {
        var inv = InventoryManager.Instance.items;
        AllRequirementsMet = requiredItems.All(key => inv.Contains(key));

        if (AllRequirementsMet)
        {
            Debug.Log("All requirements met!");
            onRequirementsMet.Invoke();
        }
        else
        {
            Debug.Log("Missing items: " + string.Join(", ", requiredItems.Where(key => !inv.Contains(key))));
            onRequirementsNotMet.Invoke();
        }
    }
}