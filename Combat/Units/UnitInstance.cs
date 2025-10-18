using Godot;
using System;

public partial class UnitInstance : Node
{
    [Export] public UnitID unitID;
    [Export] public bool isPlayer;
    [Export] public bool isAlly;
    [Export] public UnitResource resource;
    [Export] public int currentHealth;
    [Export] public int maxHealth;
    [Export] public int stun;
    [Export] public int breach;
    [Export] public int shock;
    [Export] public int silence;
    [Export] public int immunity;
    [Export] public int overheat;

    [Signal] public delegate void HealthChangedEventHandler(int current, int max);

    public UnitInstance(UnitID unitID, bool isPlayer = false, bool isAlly = false)
    {
        this.unitID = unitID;
        this.isPlayer = isPlayer;
        this.isAlly = isAlly;

        resource = Tables.Units.resources[unitID];

        if (isPlayer)
        {
            currentHealth = RunInstance.Instance.currentHealth;
            maxHealth = RunInstance.Instance.maxHealth;
        }
        else
        {
            currentHealth = resource.maxHealth;
            maxHealth = resource.maxHealth;
        }

        EmitSignal(SignalName.HealthChanged, currentHealth, maxHealth);
    }

    public void EnemyRoll()
    {
        int roll = GD.RandRange(1, 10);
        ActionID rollAction = ActionID.None;
        foreach (Vector2I rollRange in resource.rollActions.Keys)
        {
            if (roll >= rollRange.X && roll <= rollRange.Y)
            {
                rollAction = resource.rollActions[rollRange];
                break;
            }
        }
        GD.Print($"Enemy Roll Action: {rollAction}");
        new ActionBehavior(rollAction, this).Execute();
    }

    public void TryCombatAction()
    {

    }

    public void ApplyDamage(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth - value, 0, maxHealth);
        EmitSignal(SignalName.HealthChanged, currentHealth, maxHealth);
    }
}