using Godot;
using System;

public partial class UnitDisplay : Control
{
    [Export] Label nameLabel;
    [Export] ProgressBar healthProgressBar;
    [Export] Label healthLabel;

    UnitInstance unitInstance;

    public void Assign(UnitInstance unitInstance)
    {
        this.unitInstance = unitInstance;
        nameLabel.Text = unitInstance.resource.name;
        unitInstance.HealthChanged += OnHealthChanged;
        OnHealthChanged(unitInstance.currentHealth, unitInstance.currentHealth);
    }

    void OnHealthChanged(int current, int max)
    {
        healthProgressBar.Value = current;
        healthProgressBar.MaxValue = max;
        healthLabel.Text = $"{current}/{max}";
    }
}
