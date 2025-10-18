using Godot;
using Godot.Collections;
using System;

public partial class WeaponInstance : Node
{
    [Export] public WeaponID weaponID = WeaponID.None;
    [Export] public Array<WeaponAttachmentID> attachments = new Array<WeaponAttachmentID>();

    public WeaponInstance(WeaponID weaponID)
    {
        this.weaponID = weaponID;
    }
}
