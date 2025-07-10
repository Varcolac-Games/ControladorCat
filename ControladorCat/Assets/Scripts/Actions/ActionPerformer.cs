using System.Collections.Generic;
using UnityEngine;

public class ActionPerformer : MonoBehaviour, IActionPerformer
{
    [Header("Acciones por tipo")]
    public List<WorldActionSO> equippedActions;

    public void PerformAction(ActionType type, GameObject performer, GameObject target)
    {
        Debug.Log("ActionPerformer");
        var action = equippedActions.Find(a => a.actionType == type);
        if (action != null)
        {
            Debug.LogWarning(action.actionType.ToString());
            action.Execute(performer, target);
        }
    }

    public void isActivateOutliner(bool variable)
    {
        throw new System.NotImplementedException();
    }

}

