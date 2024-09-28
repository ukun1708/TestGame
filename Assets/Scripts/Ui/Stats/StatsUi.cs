using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using TMPro;
using DG.Tweening;

public abstract class StatsUi : MonoBehaviour
{
    [Inject] protected StatsManager statsManager;

    private TMP_Text text;
    private Tween tw;

    private void Awake() => text = GetComponent<TMP_Text>();

    protected virtual void Subscribe(IntReactiveProperty intReactive)
    {
        intReactive.Subscribe(value =>
        {
            text.text = value.ToString();

            if (tw == null)
            {
                tw = text.transform.DOPunchScale(Vector3.one * .15f, .25f).OnComplete(() => tw = null);
            }
        });
    }
}
