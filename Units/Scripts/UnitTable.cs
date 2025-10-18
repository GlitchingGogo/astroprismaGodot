using Godot;
using Godot.Collections;
using System;

[GlobalClass]
[Tool]
public partial class UnitTable : Resource
{
    [Export] public Dictionary<UnitID, UnitResource> resources;
    [Export(PropertyHint.Dir)] public string resourcePath;
    [ExportToolButton("Scan", Icon = "FileAccess")]
    Callable Scan => Callable.From(() =>
    {
        resources.Clear();

        for (int i = 0; i < (int)UnitID.Count; i++)
        {
            UnitID enumvalue = (UnitID)i;
            if (!Enum.IsDefined<UnitID>(enumvalue)) continue;
            string path = $"{resourcePath}/{enumvalue}.tres";
            if (!FileAccess.FileExists(path))
            {
                UnitResource newResource = new UnitResource()
                {
                    name = enumvalue.ToString(),
                };
                ResourceSaver.Save(newResource, path);
            }

            UnitResource resource = ResourceLoader.Load<UnitResource>(path);
            ResourceSaver.Save(resource, path);
            resources.Add(enumvalue, resource);
        }

        ResourceSaver.Save(this, ResourcePath);
        NotifyPropertyListChanged();
    });
}
