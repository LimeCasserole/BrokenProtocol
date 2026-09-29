using Godot;
using System;

public partial class Player : CharacterBody3D {
	[ExportGroup("Movement")]
	[Export] public float maxRotYDeg = 60, minRotYDeg = -30;
	[Export] public float Speed { get; set; } = 14;

	[ExportGroup("References")]
	[Export] public Node3D Neck;
	[Export] public Camera3D Camera;

	[ExportGroup("Inside view")]
	[Export] private Vector3 _targetVelocity = Vector3.Zero;

	public override void _Ready() {
		GD.Print("Player is ready.");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	public override void _PhysicsProcess(double delta) {
		MovePlayer();
		RotateCamera();
	}

	private void MovePlayer() {
		// We create a local variable to store the input direction.
		var direction2D = Input.GetVector("move_left", "move_right", "move_forward", "move_back");
		var direction = new Vector3(direction2D.X, 0, direction2D.Y);


		_targetVelocity = direction * Speed;
		// if (IsOnFloor()) {
		// 	_targetVelocity = direction * Speed;
		// }

		// GD.Print($"d-{direction} v-{Velocity}");

		Velocity = _targetVelocity;
		MoveAndSlide();
	}

	private void RotateCamera() {
		Vector2 mouseDelta = InputHandler.MouseDelta;

		Neck.RotateY((float)(mouseDelta.X * 0.01));
		RotateX((float)(mouseDelta.Y * 0.01));

		Vector3 current = Neck.Rotation;
		current.X = Math.Clamp(current.X, Mathf.RadToDeg(minRotYDeg), Mathf.RadToDeg(maxRotYDeg));
		Neck.Rotation = current;
	}
}
