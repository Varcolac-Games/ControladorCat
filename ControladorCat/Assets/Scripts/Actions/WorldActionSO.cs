using UnityEngine;

public enum ActionType
{
    PushOrScratch,
    PositiveInteraction,
    NegativeInteraction,
    Hide
}

public abstract class WorldActionSO : ScriptableObject, IWorldAction
{
    public ActionType actionType;
    public string displayName;
    public Sprite icon;

    public abstract void Execute(GameObject performer, GameObject target);

    public void isActivateOutliner(bool variable)
    {
        throw new System.NotImplementedException();
    }
}
