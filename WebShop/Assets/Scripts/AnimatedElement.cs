using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedElement
{
    private readonly List<MaskableGraphic> _items = new List<MaskableGraphic>();

    private Transform _container;
    
    private AnimatedElement(Component container)
    {
        CollectItems(container);
    }
    
    private void CollectItems(Component container)
    {
        var images = container.GetComponentsInChildren<Image>();
        
        foreach (var image in images)
            _items.Add(image);
        
        var texts = container.GetComponentsInChildren<Text>();
        
        foreach (var text in texts)
            _items.Add(text);
    }

    public Sequence Enable(bool value, float duration, Ease ease)
    {
        var scale = value ? Vector3.one : Vector3.zero;
        var fade = value ? 1f : 0f;

        var sequence = DOTween.Sequence()
            .Append(_container.DOScale(scale, duration).SetEase(ease));

        foreach (var item in _items)
            sequence.Join(item.DOFade(fade, duration).SetEase(ease));

        return sequence;
    }
}
