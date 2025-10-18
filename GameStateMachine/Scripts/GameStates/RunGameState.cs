using Godot;
using System;

public partial class RunGameState : GameState
{
    public static RunInstance Run;    

    public override void EnterState(object parameter = null)
    {
        Run = new RunInstance(UnitID.Test);
    }

    public override void ExitState()
    {
        //TODO
    }
}