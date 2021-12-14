using UnityEngine;

public class View : MonoBehaviour
{
    protected AnimatedElement _animation;
    public virtual void OnCreate()
    {
        _animation = new AnimatedElement(this.transform);
        _animation.Enable(false, 0f);
        gameObject.SetActive(true);
    } 

    public virtual void Open() => _animation.Enable(true, 1f);
    
    public virtual void Close() => _animation.Enable(false, 1f);
}
