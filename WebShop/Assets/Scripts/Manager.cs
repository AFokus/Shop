using System;
using System.Collections.Generic;
using UnityEngine;

public partial class Manager : MonoBehaviour
{
    public static Manager Instance;

    private readonly Dictionary<Type, View> _views = new Dictionary<Type, View>();

    private void Awake()
    {
        Instance = this;
        
        LoadAll();
    }

    private void LoadAll()
    {
        LoadViews(_viewsList);
    }

    private void LoadViews(IEnumerable<View> views)
    {
        foreach (var view in views)
        {
            view.OnCreate();
            _views.Add(view.GetType(), view);
        }
    }
    
    public void Open<T>() where T : View
    {
        var view = _views[typeof(T)];
        view.Open();
    }

    public void CLose<T>() where T : View
    {
        var view = _views[typeof(T)];
        view.Close();
    }
}
