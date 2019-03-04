using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageManager : MonoBehaviour
{
    #region Singleton

    public static HostageManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject Hostage;
}
