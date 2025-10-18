using Godot;
using System;

public partial class MainMenuGameState : GameState
{
    [Export] Button startButton;
    [Export] Button exitButton;

    public override void EnterState(object parameter = null)
    {
        startButton.Pressed += () => GameStateMachine.GoToState(GameStateType.PreRun);
        exitButton.Pressed += () => GetTree().Quit();
    }

    public override void ExitState()
    {
        QueueFree();
    }
}