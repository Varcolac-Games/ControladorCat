using UnityEngine;

public interface IActionPerformer
{
    void PerformAction(ActionType type, GameObject performer, GameObject target);
    public void isActivateOutliner(bool variable);
}
