using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{
    private static Manager _manager;

    private void Start()
    {
        _manager = FindObjectOfType<Manager>();
        DontDestroyOnLoad(this);
        Init();
    }
        
    private void Init()
    {  
        _manager.Open<MainPage>();
    }

    public static void OpenWindow<T, V>(Action activity = null) where T : View where V : View
    {
        _manager.Close<T>();
        activity?.Invoke();
        _manager.Open<V>();
    }
}