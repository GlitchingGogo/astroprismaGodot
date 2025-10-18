using Godot;
using System;

public partial class CombatGameState : GameState
{
    [Export] PackedScene unitDisplayPrefab;
    [Export] Control enemyDisplayContainer;
    [Export] Control allyDisplayContainer;

    [Export] Button rewardsButton;
    [Export] Button debugDamageButton;

    CombatInstance combatInstance;

    public override void EnterState(object parameter = null)
    {
        rewardsButton.Pressed += () => RunStateMachine.GoToState(RunStateType.Rewards);
        CreateCombatInstance();
        debugDamageButton.Pressed += () =>
        {
            new ActionBehavior(ActionID.TestDamageAction, combatInstance.player).Execute();
            combatInstance.EndPlayerTurn();
        };
    }

    void CreateCombatInstance()
    {
        combatInstance = new CombatInstance(this);
        AddChild(combatInstance);
    }

    public void CreateDisplay(UnitInstance unitInstance)
    {
        UnitDisplay unitDisplay = unitDisplayPrefab.Instantiate() as UnitDisplay;
        unitDisplay.Assign(unitInstance);
        if (unitInstance.isAlly) allyDisplayContainer.AddChild(unitDisplay);
        else enemyDisplayContainer.AddChild(unitDisplay);
    }

    public override void ExitState()
    {
        //TODO
    }
}