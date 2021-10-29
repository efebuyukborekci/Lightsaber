using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIController uIController;
    public CameraShake cameraShake;
    public LevelSettings levelSettings;
    public CharacterController[] characterControllers;

    private void Start()
    {
        Singleton();
        SetCharacters();
        AssignCharacterToSwing();
    }

    public void AssignCharacterToSwing()
    {
        uIController.swingButton.onClick.AddListener(() => 
        {
            for (int i = 0; i < characterControllers.Length; i++)
            {
                characterControllers[i].Swing();
            }
        });
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SetCharacters()
    {
        if (characterControllers.Length == levelSettings.characters.Count)
        {
            for (int i = 0; i < characterControllers.Length; i++)
            {
                characterControllers[i].InitializeCharacter(levelSettings.characters[i]);
            } 
        }
        else
        {
            Debug.LogError("Characters and Character Datas not match!!!");
        }
    }
}
