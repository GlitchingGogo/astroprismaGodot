using Godot;
using System;

public partial class RewardsGameState : GameState
{
    [Export] Button leaveButton;
    public override void EnterState(object parameter = null)
    {
        leaveButton.Pressed += () => RunStateMachine.GoToState(RunStateType.Map);
    }

    public override void ExitState()
    {
        //TODO
    }
}