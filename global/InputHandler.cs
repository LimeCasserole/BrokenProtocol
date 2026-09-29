using Godot;
using System;

public partial class InputHandler : Node3D {
    public static Vector2 MouseDelta { get; private set; }
    private static InputHandler handler = null;
    private static bool frameProcessed = false;

    public override void _Ready() {
        base._Ready();

        if (handler != null) {
            GD.PrintErr("Tried to spawn second instance of 'InputHandler'.");
            QueueFree();
            return;
        }
    }

    public override void _Process(double delta) {
        base._Process(delta);

        GD.Print($"Current delta {MouseDelta}");
    }

    public override void _Input(InputEvent @event) {
        if (@event is InputEventMouseMotion mouseMotion) {
            MouseDelta = mouseMotion.Relative;
            GD.Print($"Mouse motiot {mouseMotion.Relative}");
        }

        frameProcessed = true;
    }
}