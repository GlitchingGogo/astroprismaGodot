using Godot;
using System;

public partial class CombatLog : RichTextLabel
{
    public static CombatLog Instance;

    public override void _Ready()
    {
        Instance = this;
    }

    public static void AddAsAlly(string s)
    {
        Instance.Text += $"[color=8ff8e2]{s}[/color]\n";
    }
    
    public static void AddAsEnemy(string s)
    {
        Instance.Text += $"[color=e83b3b]{s}[/color]\n";
    }
}