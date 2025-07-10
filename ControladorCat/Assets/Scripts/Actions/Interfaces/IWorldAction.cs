using UnityEngine;

public interface IWorldAction
{
    void Execute(GameObject performer, GameObject target);
    public void isActivateOutliner(bool variable);
}
