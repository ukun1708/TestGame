using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class StaminaUi : StatsUi
{
    private void Start() => Subscribe(statsManager.Stamina);

    protected override void Subscribe(IntReactiveProperty intReactive)
    {
        base.Subscribe(intReactive);
    }
}
