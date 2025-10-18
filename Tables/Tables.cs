using Godot;
using System;

public partial class Tables : Node
{
    public static GameStateTable GameStates = ResourceLoader.Load<GameStateTable>("res://Tables/GameStateTable.tres");
    public static RunStateTable RunStates = ResourceLoader.Load<RunStateTable>("res://Tables/RunStateTable.tres");
    public static UnitTable Units = ResourceLoader.Load<UnitTable>("res://Tables/UnitTable.tres");
    public static CombatTable Combats = ResourceLoader.Load<CombatTable>("res://Tables/CombatTable.tres");
}