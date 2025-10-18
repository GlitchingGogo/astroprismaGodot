using Godot;
using System;

public partial class RunGameState : GameState
{

    public override void EnterState(object parameter = null)
    {
        RunInstance run = new RunInstance(UnitID.Test);
        AddChild(run);
    }

    public override void ExitState()
    {
        //TODO
    }
}