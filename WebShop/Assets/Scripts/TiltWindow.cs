// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.Serialization;

public class TiltWindow : MonoBehaviour
{
    [FormerlySerializedAs("range")] public Vector2 Range = new Vector2(5f, 3f);

    private Transform _mTrans;
    private Quaternion _mStart;
    private Vector2 _mRot = Vector2.zero;

    private readonly float _halfWidth = Screen.width * 0.5f;
    private readonly float _halfHeight = Screen.height * 0.5f;

    private void Start()
    {
        _mTrans = transform;
        _mStart = _mTrans.localRotation;
    }

    private void Update()
    {
        var pos = Input.mousePosition;
        
        var x = Mathf.Clamp((pos.x - _halfWidth) / _halfWidth, -1f, 1f);
        var y = Mathf.Clamp((pos.y - _halfHeight) / _halfHeight, -1f, 1f);
        _mRot = Vector2.Lerp(_mRot, new Vector2(x, y), Time.deltaTime * 5f);

        _mTrans.localRotation = _mStart * Quaternion.Euler(-_mRot.y * Range.y, _mRot.x * Range.x, 0f);
    }
}