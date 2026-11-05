using Godot;
using SDirectory = System.IO.Directory;

/// <summary>
/// Headless equivalent of the Build Manager "Extract Images" button.
/// Run: godot --path . --no-window --script res://tools/ExtractImages.cs
/// </summary>
public class ExtractImages : SceneTree {
	public override void _Initialize() {
		string atdPath = (string)ProjectSettings.GetSetting("application/config/atd_path");

		GD.Print("ATD path: " + atdPath);

		// Same validation as ATDGameLoader.IsOriginalGamePath
		GFXLibrary.pathToAirlineTycoonD = atdPath;
		try {
			SDirectory.GetDirectories(atdPath, "room", System.IO.SearchOption.AllDirectories);
			SDirectory.GetFiles(atdPath, "glbasis.gli", System.IO.SearchOption.AllDirectories);
		} catch (System.Exception e) {
			GD.PrintErr("INVALID ATD PATH: " + e.Message);
			Quit(1);
			return;
		}

		GD.Print("Extracting images...");
		ATDataLoader.LoadImageData();
		ATDataLoader.CreateImageResources();
		ATDataLoader.SaveAllLoadedResources();
		GD.Print("EXTRACTION DONE");
		Quit(0);
	}
}
