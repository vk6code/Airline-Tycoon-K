using Godot;
using System;
using System.Collections.Generic;

public partial class NavigationController : NavigationRegion2D {
	public static NavigationController instance;

	public override void _Ready() {
		instance = this;
	}

	/// <summary>
	/// Godot 4 removed Navigation2D.GetSimplePath. Until a real NavigationRegion2D
	/// polygon is authored, walk in a straight line.
	/// </summary>
	public List<Vector2> GetSimplePath(Vector2 from, Vector2 to, bool optimize) {
		return new List<Vector2> { from, to };
	}
}
