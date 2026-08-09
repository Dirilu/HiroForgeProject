using BRDK.Core;
using System.IO;
using UnityEditor;

namespace BRDK.Modules.Scripts
{
    public static class BRDKScriptGenerator
    {
        private class ScriptInfo
        {
            public string Folder;
            public string Name;
            public bool IsMonoBehaviour;

            public ScriptInfo(string folder, string name, bool monoBehaviour = true)
            {
                Folder = folder;
                Name = name;
                IsMonoBehaviour = monoBehaviour;
            }
        }

        private static readonly ScriptInfo[] Scripts =
        {
            // Core
            new ScriptInfo("Core", "GameManager"),
            new ScriptInfo("Core", "AudioManager"),
            new ScriptInfo("Core", "SaveManager"),
            new ScriptInfo("Core", "SceneLoader"),
            new ScriptInfo("Core", "SettingsManager"),

            // Gameplay
            new ScriptInfo("Gameplay", "MatchManager"),
            new ScriptInfo("Gameplay", "TurnManager"),
            new ScriptInfo("Gameplay", "BalutRules"),
            new ScriptInfo("Gameplay", "JackpotManager"),

            // Dice
            new ScriptInfo("Dice", "DiceManager"),
            new ScriptInfo("Dice", "DiceController"),
            new ScriptInfo("Dice", "DiceRoller"),

            // Scorecard
            new ScriptInfo("Scorecard", "ScoreManager"),
            new ScriptInfo("Scorecard", "PlayerScorecard"),
            new ScriptInfo("Scorecard", "ScoreCategory", false),
            new ScriptInfo("Scorecard", "ScoreEntry", false),
            new ScriptInfo("Scorecard", "ScoreRow", false),
        };

        [MenuItem("Tools/Balut Royale/Create Scripts")]
        public static void CreateScripts()
        {
            int created = 0;

            foreach (var script in Scripts)
            {
                string folder = $"Assets/Scripts/{script.Folder}";
                string path = $"{folder}/{script.Name}.cs";

                if (!AssetDatabase.IsValidFolder(folder))
                    continue;

                if (File.Exists(path))
                    continue;

                File.WriteAllText(path, GenerateScript(script));

                created++;
            }

            AssetDatabase.Refresh();
            BRDKActivityLog.Add($"Created {created} scene(s).");
            EditorUtility.DisplayDialog(
                "BRDK",
                $"Created {created} script(s).",
                "Awesome");
        }

        private static string GenerateScript(ScriptInfo script)
        {
            string namespaceName = $"BalutRoyale.{script.Folder}";

            // Every class ending in "Manager" becomes a Singleton.
            if (script.Name.EndsWith("Manager"))
            {
                return
$@"using UnityEngine;

namespace {namespaceName}
{{
    public class {script.Name} : MonoBehaviour
    {{
        public static {script.Name} Instance {{ get; private set; }}

        private void Awake()
        {{
            if (Instance == null)
            {{
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }}
            else
            {{
                Destroy(gameObject);
            }}
        }}
    }}
}}";
            }

            // Standard MonoBehaviour
            if (script.IsMonoBehaviour)
            {
                return
$@"using UnityEngine;

namespace {namespaceName}
{{
    public class {script.Name} : MonoBehaviour
    {{

    }}
}}";
            }

            // Standard C# class
            return
$@"namespace {namespaceName}
{{
    public class {script.Name}
    {{

    }}
}}";
        }
    }
}