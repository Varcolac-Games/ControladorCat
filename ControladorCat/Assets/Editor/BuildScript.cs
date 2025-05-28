using UnityEditor;
using System.IO; // Necesario para Path.Combine y Directory.CreateDirectory



public class BuildScript
{
    // Define la escena a incluir en el build. Podrías hacer esto más dinámico si tuvieras múltiples escenas.
    private static string[] GetScenes()
    {
        return new string[] { "Assets/Scenes/Test_Integrate.unity" };
    }

    // --- Build para Windows ---
    public static void BuildWindows()
    {
        string buildPath = "Builds/Windows/";
        // Asegúrate de que la carpeta de destino exista
        Directory.CreateDirectory(buildPath);

        string outputPath = Path.Combine(buildPath, "ControladorCat.exe");
        BuildPipeline.BuildPlayer(GetScenes(), outputPath, BuildTarget.StandaloneWindows64, BuildOptions.None);
        UnityEngine.Debug.Log($"Build de Windows completado: {outputPath}");
    }

    // --- Build para Android ---
    public static void BuildAndroid()
    {
        string buildPath = "Builds/Android/";
        // Asegúrate de que la carpeta de destino exista
        Directory.CreateDirectory(buildPath);

        // Para Android, la extensión suele ser .apk o .aab (App Bundle)
        // Recomiendo usar .aab para publicaciones en Google Play Store
        string outputPath = Path.Combine(buildPath, "ControladorCat.apk"); // Puedes cambiar a .aab si prefieres
        // Aquí es crucial que el editor de Unity tenga el módulo de Android instalado y configurado
        // en File -> Build Settings -> Android
        BuildPipeline.BuildPlayer(GetScenes(), outputPath, BuildTarget.Android, BuildOptions.None);
        UnityEngine.Debug.Log($"Build de Android completado: {outputPath}");
    }

    // --- Método unificado para lanzar ambos builds (opcional) ---
    public static void BuildAllPlatforms()
    {
        BuildWindows();
        BuildAndroid();
    }
}