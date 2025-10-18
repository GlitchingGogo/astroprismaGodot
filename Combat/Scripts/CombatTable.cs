using Godot;
using Godot.Collections;
using System;

[GlobalClass]
[Tool]
public partial class CombatTable : Resource
{
    [Export] public Array<CombatResource> resources;
    [Export(PropertyHint.Dir)] public string resourcePath;

    [ExportToolButton("Scan", Icon = "FileAccess")]
    Callable Scan => Callable.From(() =>
    {
        resources.Clear();

        DirAccess dir = DirAccess.Open(resourcePath);
        if (dir != null)
        {
            dir.ListDirBegin();
            string fileName = dir.GetNext();
            while (fileName != "")
            {
                if (dir.CurrentIsDir())
                {
                    GD.Print($"Found directory: {fileName}");
                }
                else
                {
                    GD.Print($"Found file: {fileName}");
                    CombatResource keywordResource = ResourceLoader.Load<CombatResource>($"{resourcePath}/{fileName}");
                    resources.Add(keywordResource);
                }
                fileName = dir.GetNext();
            }
        }

        ResourceSaver.Save(this, ResourcePath);
        NotifyPropertyListChanged();
    });
}
