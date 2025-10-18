using Godot;
using Godot.Collections;
using System;

[GlobalClass]
[Tool]
public partial class UnitResource : Resource
{
    [Export] public string name;
    [Export(PropertyHint.MultilineText)] public string description;
    [Export] public Texture2D icon;
    [Export] public int vigor;
    [Export] public int grace;
    [Export] public int mind;
    [Export] public int tech;
    [Export] public WeaponID startingWeapon1 = WeaponID.None;
    [Export] public WeaponID startingWeapon2 = WeaponID.None;
    [Export] public Dictionary<ItemID, int> startingInventory = new Dictionary<ItemID, int>();
    [Export] public Array<ImplantID> startingImplants = new Array<ImplantID>();
    [Export] public Array<HackID> startingHacks = new Array<HackID>();
}
