using Godot;
using System;

public partial class MapGameState : GameState
{
    [Export] Button combatButton;
    [Export] Button shopButton;
    [Export] Button eventButton;

    public override void EnterState(object parameter = null)
    {
        combatButton.Pressed += () => RunStateMachine.GoToState(RunStateType.Combat);
        shopButton.Pressed += () => RunStateMachine.GoToState(RunStateType.Shop);
        eventButton.Pressed += () => RunStateMachine.GoToState(RunStateType.Event);
    }

    public override void ExitState()
    {
        QueueFree();
    }
}