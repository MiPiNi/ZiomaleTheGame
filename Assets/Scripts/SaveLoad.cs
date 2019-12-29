using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.DeleteAll();
        Load(); //loading all variables on awake
    }
    public void Save() //saving variables to memory
    {
        PlayerPrefs.SetFloat("best", VariableTag.BEST);
    }
    public void Load() //loading variables from memory and setting them to specified variable
    {
        if (PlayerPrefs.HasKey("best")) //if any variable is already saved, load all
        {
            VariableTag.BEST = PlayerPrefs.GetFloat("best");
        }
        else //else save all
            Save();
    }
}
