using Godot;
using Godot.Collections;
using System;

public partial class RunInstance : Node
{
    [Export] public string characterName;
    [Export] public UnitID unit = UnitID.None;
    [Export] public int currentHealth;
    [Export] public int maxHealth = 20;
    [Export] public int armor;
    [Export] public int experience;
    [Export] public int currentEnergy;
    [Export] public int maxEnergy = 20;
    [Export] public int vigor;
    [Export] public int grace;
    [Export] public int mind;
    [Export] public int tech;
    [Export] public WeaponInstance weapon1;
    [Export] public WeaponInstance weapon2;
    [Export] public Dictionary<ItemID, int> inventory = new Dictionary<ItemID, int>();
    [Export] public Array<ImplantID> implants = new Array<ImplantID>();
    [Export] public Array<HackID> hacks = new Array<HackID>();

    public RunInstance(UnitID unit)
    {
        this.unit = unit;
        UnitResource resource = Tables.Units.resources[unit];
        vigor = resource.vigor;
        grace = resource.grace;
        mind = resource.mind;
        tech = resource.tech;
        if (resource.startingWeapon1 != WeaponID.None) weapon1 = new WeaponInstance(resource.startingWeapon1);
        if (resource.startingWeapon2 != WeaponID.None) weapon2 = new WeaponInstance(resource.startingWeapon2);
        inventory = resource.startingInventory;
        implants = resource.startingImplants;
        hacks = resource.startingHacks;
    }
}
