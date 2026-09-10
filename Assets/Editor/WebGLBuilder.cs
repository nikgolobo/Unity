using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.IO;

public class WebGLBuilder
{
    [MenuItem("Build/WebGL Gzip Build")]
    public static void Build()
    {
        string buildPath = Path.Combine(Application.dataPath, "..", "WebGL_Gzip_Build");
        buildPath = Path.GetFullPath(buildPath);

        if (Directory.Exists(buildPath))
            Directory.Delete(buildPath, true);

        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Gzip;
        PlayerSettings.WebGL.nameFilesAsHashes = false;
        PlayerSettings.WebGL.dataCaching = true;

        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = new string[] {
            "Assets/Scenes/Menu.unity",
            "Assets/Scenes/Level.unity",
            "Assets/Scenes/Victory.unity",
            "Assets/Scenes/Gameover.unity"
        };
        options.locationPathName = buildPath;
        options.target = BuildTarget.WebGL;
        options.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(options);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
            Debug.Log("WebGL Gzip build succeeded: " + buildPath);
        else
            Debug.LogError("WebGL build failed: " + summary.result);
    }
}
