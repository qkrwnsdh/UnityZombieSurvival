using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class RestartBtnTween : MonoBehaviour, IPointerEnterHandler
{
    Tween shakeAni = default;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("마우스 올려 둠");
        if (shakeAni == null || shakeAni == default)
        {
            shakeAni = transform.DOShakeScale(0.5f, 1, 10, 90, true, ShakeRandomnessMode.Harmonic).SetAutoKill();
            shakeAni.onKill += () => DisposeShake();
            return;
        }
        // Debug.Log("Shake Ani 가 비어 있지 않다");   
    }

    //! Tween이 kill 될 때 ShakeAni 변수를 비워주는 함수
    private void DisposeShake()
    {
        shakeAni = default;
        transform.localScale = Vector3.one;
    }
}
