using Godot;
using Godot.Collections;
using System;

[GlobalClass]
[Tool]
public partial class GameStateTable : Resource
{
    [Export] public Dictionary<GameStateType, PackedScene> scenes = new Dictionary<GameStateType, PackedScene>();
    [Export(PropertyHint.Dir)] public string packedScenePath;
    [Export(PropertyHint.Dir)] public string scriptPath;
    [Export] public Script gameStateInstanceTemplate;

    [ExportToolButton("Scan", Icon = "FileAccess")]
    Callable Scan => Callable.From(() =>
    {
        scenes.Clear();

        for (int i = 0; i < (int)GameStateType.Count; i++)
        {
            GameStateType enumValue = (GameStateType)i;
            string enumValueName = ((GameStateType)i).ToString();
            string newScenePath = $"{packedScenePath}/{enumValueName}GameState.tscn";
            string scriptClassName = $"{enumValueName}GameState";
            Node scriptInstanceNode = ConstructClassByName<Node>(scriptClassName);

            if (scriptInstanceNode != null && !ResourceLoader.Exists(newScenePath))
            {
                PackedScene newScene = new PackedScene();
                Control sceneRoot = new Control();
                sceneRoot.Name = $"{enumValueName}";
                sceneRoot.SetScript(scriptInstanceNode.GetScript());
                newScene.Pack(sceneRoot);
                ResourceSaver.Save(newScene, newScenePath);
            }

            scenes.Add(enumValue, ResourceLoader.Load<PackedScene>(newScenePath));
        }

        Array<string> enumValuesWithoutScript = new Array<string>();

        for (int i = 0; i < (int)GameStateType.Count; i++)
        {
            GameStateType suitEnum = (GameStateType)i;
            string suitEnumName = suitEnum.ToString();

            if (!ResourceLoader.Exists($"{scriptPath}/{(GameStateType)i}GameState.cs"))
            {
                enumValuesWithoutScript.Add(suitEnumName);
            }
        }

        foreach (string enumValueName in enumValuesWithoutScript)
        {
            string newScriptPath = $"{scriptPath}/{enumValueName}GameState.cs";
            GD.Print($"Creating {newScriptPath}...");
            FileAccess file = FileAccess.Open(newScriptPath, FileAccess.ModeFlags.Write);
            if (file != null)
            {
                string fileContents = gameStateInstanceTemplate.SourceCode.Replace("GameStateTemplate", $"{enumValueName}GameState");
                file.StoreString(fileContents);
                file.Close();
                //NOTE: Because the C# project needs to get compiled before we can use the new .cs file as a Script, we won't add
                // the new file path to scriptPathsByName, and the Scene for this GameState can't be created below.
                // We must ask the user to compile the project and click Auto-fill button again
            }
            else { GD.PrintErr($"Failed to create script file at \"{newScriptPath}\""); }
        }

        ResourceSaver.Save(this, ResourcePath);
        NotifyPropertyListChanged();
    });

    public static T ConstructClassByName<T>(string className) where T : class
    {
        Type classType = Type.GetType(className);
        if (classType != null)
        {
            object classInstance = classType.GetConstructor(Type.EmptyTypes)?.Invoke(null);
            if (classInstance != null && classInstance is T classInstanceCast)
            {
                return classInstanceCast;
            }
        }
        return null;
    }
}
