#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;



[InitializeOnLoad]
public class audioToolsInstall : MonoBehaviour {

  static string packageFolder;
  
    static audioToolsInstall()
  {
    // wait for the first editor update to ensure the scene is fully loaded...
    EditorApplication.update += RunOnce;
  }

  static void RunOnce()
  {
    // remove the update listener
      EditorApplication.update -= RunOnce;
  
    // Detect installation requirements by checking if the MelodriveInstruments are in the wrong place...
    packageFolder = Path.Combine(Application.dataPath, "Audio-Tools-for-Unity-Playground-master");
    string packageFolderScripts = Path.Combine(Application.dataPath, "Audio-Tools-for-Unity-Playground-master/Scripts/actionScripts");

    if (Directory.Exists(packageFolderScripts))
    {
      Install();
      
    }
    
  }

  public static void Install()
  {
  
    Debug.Log("Installing Audio Tools...");
       
  
      
    if (!Directory.Exists(Path.Combine(Application.dataPath,"Audio")))
      
    {
      string audioPath = Path.Combine(Application.dataPath,"Audio");
      string audioAssetsPath = Path.Combine(packageFolder,"Audio Tools Assets");

      Directory.CreateDirectory(audioPath);


      Directory.Move(audioAssetsPath, Path.Combine(audioPath,"Audio Tools Assets"));


    }

    // movong action scripts into Action folder in unity playground 
    if (Directory.Exists(Path.Combine(Application.dataPath,"Scripts/Conditions/Actions/")))
    {

      
      string [] actionFiles = Directory.GetFiles(Path.Combine(packageFolder,"Scripts/actionScripts/"));
      string actionScripts = Path.Combine(Application.dataPath,"Scripts/Conditions/Actions/");

      foreach (string file in actionFiles)
      {
            Directory.Move(file, Path.Combine(actionScripts, Path.GetFileName(file)));
      }
      Directory.Delete(Path.Combine(packageFolder,"Scripts/actionScripts"));
    }


    // movong other scripts into other gameplay fodler in unity playground 
    if (Directory.Exists(Path.Combine(Application.dataPath,"Scripts/Gameplay/")))
    {
      
      string [] gameplayFiles = Directory.GetFiles(Path.Combine(packageFolder,"Scripts/gameplay/"));
      string gameplayScripts = Path.Combine(Application.dataPath,"Scripts/Gameplay/");
      
      foreach (string file in gameplayFiles)
      {
            Directory.Move(file, Path.Combine(gameplayScripts, Path.GetFileName(file)));
      }
      Directory.Delete(Path.Combine(packageFolder,"Scripts/gameplay"));

    }
    Debug.Log("Audio Tools installed, have fun!");
    AssetDatabase.Refresh();
  }

}

#endif
