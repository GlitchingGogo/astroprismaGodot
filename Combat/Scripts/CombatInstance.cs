using Godot;
using Godot.Collections;
using System;

public partial class CombatInstance : Node
{
    public static CombatInstance Instance;
    [Export] public bool isPlayerTurn;
    [Export] public UnitInstance player;
    [Export] public Array<UnitInstance> allyUnits = new Array<UnitInstance>();
    [Export] public Array<UnitInstance> enemyUnits = new Array<UnitInstance>();
    CombatGameState combatGameState;

    public CombatInstance(CombatGameState combatGameState)
    {
        Instance = this;
        player = new UnitInstance(RunInstance.Instance.unit, isPlayer: true, isAlly: true);
        allyUnits.Add(player);
        combatGameState.CreateDisplay(player);

        CombatResource resource = Tables.Combats.resources.PickRandom();
        foreach (UnitID unit in resource.enemies)
        {
            UnitInstance newEnemy = new UnitInstance(unit);
            enemyUnits.Add(newEnemy);
            combatGameState.CreateDisplay(newEnemy);
        }
    }

    public void EndPlayerTurn()
    {
        foreach (UnitInstance enemy in enemyUnits) enemy.EnemyRoll();
    }
}
