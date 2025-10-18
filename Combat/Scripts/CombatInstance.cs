using Godot;
using Godot.Collections;
using System;

public partial class CombatInstance : Node
{
    [Export] public Array<UnitInstance> allyUnits = new Array<UnitInstance>();
    [Export] public Array<UnitInstance> enemyUnits = new Array<UnitInstance>();

    public CombatInstance()
    {
        
    }
}
