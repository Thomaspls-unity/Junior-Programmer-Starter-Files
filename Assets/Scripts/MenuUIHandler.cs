using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR //Lots of classes in this namespace, will only load when in the editor, not with the final product
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color) //Handles when a color is selected
    {
        MainManager.Instance.teamColor = color;
    }
    
    private void Start()
    {
        
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        //Setting the saved color in the json upon load of the main menu
        ColorPicker.SelectColor(MainManager.Instance.teamColor);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1); //Loads the main scene
    }

    public void Exit() //An if statement that is best used for use across different platforms, known as region, or conditional compilation
    {
        MainManager.Instance.SaveColor();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
    }
    
    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColor();
    }
}
