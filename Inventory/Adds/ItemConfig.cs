using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName ="ItemStatconfigData",menuName ="ItemStatconfig",order =1)]
public class ItemConfig : ScriptableObject
{
    //public List<HPConfig> hPConfigs;
    public HPConfig hPConfig;
}
[Serializable]
public class HPConfig
{
    public float HPRestore(int Tier)
    {
        float restore=0;
        if(Tier<0)
            Tier=0;
        if(Tier>4)
            Tier=4;
        switch (Tier)
        {
            case 0: restore= 10f; break;
            case 1: restore= 20f; break;
            case 2: restore= 30f; break;
            case 3: restore= 40f; break;
            case 4: restore= 50f; break;
        }
        return restore;
    }
}
