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
        //Debug.Log("���콺 �÷� ��");
        if (shakeAni == null || shakeAni == default)
        {
            shakeAni = transform.DOShakeScale(0.5f, 1, 10, 90, true, ShakeRandomnessMode.Harmonic).SetAutoKill();
            shakeAni.onKill += () => DisposeShake();
            return;
        }
        // Debug.Log("Shake Ani �� ��� ���� �ʴ�");   
    }

    //! Tween�� kill �� �� ShakeAni ������ ����ִ� �Լ�
    private void DisposeShake()
    {
        shakeAni = default;
        transform.localScale = Vector3.one;
    }
}
