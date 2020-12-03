using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<PlatformerController> characters;
    int activeCharacterIndex = 0;

    public List<Door> exits;

    void Start()
    {
        ActivateSelectedCharacter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            activeCharacterIndex--;
            ActivateSelectedCharacter();
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            activeCharacterIndex++;
            ActivateSelectedCharacter();
        }

        if (IsLevelFinished()) 
        {
            Debug.Log("You won!");
        }
    }

    void ActivateSelectedCharacter() 
    {
        if (activeCharacterIndex >= characters.Count) 
        {
            activeCharacterIndex = 0;
        } else if (activeCharacterIndex < 0)
        {
            activeCharacterIndex = characters.Count - 1;
        }

        for(int i = 0; i < characters.Count; i++) 
        {
            if(i == activeCharacterIndex) 
            {
                characters[i].ActivateCharacter();
            } else 
            {
                characters[i].DeactivateCharacter();
            }
        }
    }

    bool IsLevelFinished() 
    {
        foreach(Door d in exits) 
        {
            if (!d.doorEntered) 
            {
                return false;
            }
        }

        return true;
    }

    public Transform GetActiveCharacter() 
    {
        return characters[activeCharacterIndex].transform;
    }
}
