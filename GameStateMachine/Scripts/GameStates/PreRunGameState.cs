using Godot;
using System;

public partial class PreRunGameState : GameState
{
    [Export] Button startRunButton;

    public override void EnterState(object parameter = null)
    {
        startRunButton.Pressed += () => GameStateMachine.GoToState(GameStateType.Run);
    }

    public override void ExitState()
    {
        QueueFree();
    }
}