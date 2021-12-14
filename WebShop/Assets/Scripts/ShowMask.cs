using UnityEngine;
using UnityEngine.UI;

public class ShowMask : MonoBehaviour
{
    private Mask _thisMask;
    void Awake() => _thisMask = GetComponent<Mask>();
    

    void OnMouseOver() => _thisMask.showMaskGraphic = true;

    void OnMouseExit() => _thisMask.showMaskGraphic = false;
}
