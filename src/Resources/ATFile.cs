using System.IO;
using System.Linq;

public partial class ATFile {
	protected string filePath;

	public ATFile(string _filePath, bool searchForFile = true) {
		// Security check for casing issues in non windows systems and backup search
		if (!_filePath.StartsWith("res") && !File.Exists(_filePath)) {
			if (!searchForFile)
				throw new FileNotFoundException("AT file not found and the searchForFile flag was 'false'!", _filePath);

			_filePath = FindFile(System.IO.Path.GetFileName(_filePath));
		}

		filePath = _filePath;
	}


	public static string FindFile(string file) {
		string subFolder = "";
		if (file.StartsWith(GFXLibrary.pathToAirlineTycoonD)) {
			string temp = file.Remove(0, GFXLibrary.pathToAirlineTycoonD.Length);
			subFolder = System.IO.Path.GetDirectoryName(temp);
		}

		string fileName = System.IO.Path.GetFileName(file);

		string searchPath = GFXLibrary.pathToAirlineTycoonD;
		return System.IO.Directory.GetFiles(searchPath, fileName, System.IO.SearchOption.AllDirectories).First();
	}

	public static string FindFolder(string folderName) {
		string basePath = GFXLibrary.pathToAirlineTycoonD;
		return System.IO.Directory.GetDirectories(basePath, folderName, System.IO.SearchOption.AllDirectories).First();
	}
}