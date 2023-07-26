using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameInstances : MonoBehaviour
{
    private static GameInstances _instance;

    public int Gold { get; set; }
    public void Win()
    {

    }
    public void Lose()
    {

    }

    public static GameInstances Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<GameInstances>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance && _instance == this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}


