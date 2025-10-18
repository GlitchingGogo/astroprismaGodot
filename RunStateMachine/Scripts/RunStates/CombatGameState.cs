using Godot;
using System;

public partial class CombatGameState : GameState
{
    [Export] Button rewardsButton;

    public override void EnterState(object parameter = null)
    {
        rewardsButton.Pressed += () => RunStateMachine.GoToState(RunStateType.Rewards);
    }

    public override void ExitState()
    {
        //TODO
    }
}