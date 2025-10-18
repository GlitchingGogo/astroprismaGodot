using Godot;
using Godot.Collections;
using System;

public partial class GameStateMachine : Node
{
    public static GameStateMachine Instance;
    [Export] public GameStateType initialStateEnum = GameStateType.None;
    [ExportGroup("Runtime Stuff")]
    [Export] public GameStateType currentStateEnum = GameStateType.None;
    [Export] public GameState currentState = null;

    public override void _Ready()
    {
        Instance = this;
        CallDeferred(MethodName.EnterInitialState);
    }

    void EnterInitialState()
    {
        GoToState(initialStateEnum);
    }

    public static void GoToState(GameStateType gameStateEnum, object parameter = null, bool force = false)
    {
        if (Instance.currentStateEnum == gameStateEnum && !force) return;
        Instance.currentStateEnum = gameStateEnum;

        if (Instance.currentState != null && IsInstanceValid(Instance.currentState))
        {
            Instance.currentState.ExitState();
        }

        GameState instance = Tables.GameStates.scenes[gameStateEnum].Instantiate() as GameState;
        Instance.AddChild(instance);
        Instance.currentState = instance;
        instance.EnterState(parameter);
    }
}