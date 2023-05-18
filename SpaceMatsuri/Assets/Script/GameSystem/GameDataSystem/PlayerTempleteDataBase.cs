using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTempleteDataBase
{
    public List<BasicPlayerDataTemplate> M_PlayerTempleteDataBase = new List<BasicPlayerDataTemplate>();
    public PlayerTempleteDataBase() 
    {
        M_PlayerTempleteDataBase.Add(new BasicPlayerDataTemplate());
    }
    public BasicPlayerDataTemplate GetBasicPlayerDataByID(int id)
    {
        var result = new BasicPlayerDataTemplate();
        for (int i = 0; i < M_PlayerTempleteDataBase.Count; i++)
        {
            if (M_PlayerTempleteDataBase[i].PlayerTemplete_ID == id)
            {
                return M_PlayerTempleteDataBase[i];
            }
        }
        return result;
    }
}
