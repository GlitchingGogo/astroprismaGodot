using Godot;
using Godot.Collections;
using System;

[GlobalClass]
[Tool]
public partial class CombatResource : Resource
{
    [Export] public Array<UnitID> enemies = new Array<UnitID>();
}