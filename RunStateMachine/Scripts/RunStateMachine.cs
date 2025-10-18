using Godot;
using System;

public partial class RunStateMachine : Node
{
    public static RunStateMachine Instance;
    [Export] public RunStateType initialStateEnum = RunStateType.None;
    [ExportGroup("Runtime Stuff")]
    [Export] public RunStateType currentStateEnum = RunStateType.None;
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

    public static void GoToState(RunStateType gameStateEnum, object parameter = null, bool force = false)
    {
        if (Instance.currentStateEnum == gameStateEnum && !force) return;
        Instance.currentStateEnum = gameStateEnum;

        if (Instance.currentState != null && IsInstanceValid(Instance.currentState))
        {
            Instance.currentState.ExitState();
        }

        GameState instance = Tables.RunStates.scenes[gameStateEnum].Instantiate() as GameState;
        Instance.AddChild(instance);
        Instance.currentState = instance;
        instance.EnterState(parameter);

        GD.Print($"Going to state: {gameStateEnum}");
    }
}
