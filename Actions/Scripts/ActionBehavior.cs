using Godot;
using System;

public partial class ActionBehavior : Node
{
    ActionID actionID;
    UnitInstance sourceUnit;

    public ActionBehavior(ActionID actionID, UnitInstance sourceUnit)
    {
        this.actionID = actionID;
        this.sourceUnit = sourceUnit;
    }

    public void Execute()
    {
        switch (actionID)
        {
            case ActionID.TestDamageAction:
                int value = Dice.D4.Roll(4);
                GetTargetEnemy().ApplyDamage(value);
                if (sourceUnit.isPlayer) CombatLog.AddAsAlly($"{sourceUnit.resource.name} dealt {value} Damage!");
                else CombatLog.AddAsEnemy($"{sourceUnit.resource.name} dealt {value} Damage!");
                break;
            case ActionID.TestNewAction:
                break;
        }
    }

    UnitInstance GetTargetEnemy()
    {
        if (sourceUnit.isAlly) return CombatInstance.Instance.enemyUnits.PickRandom();
        else return CombatInstance.Instance.allyUnits.PickRandom();
    }
}