using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PowerUi : StatsUi
{
    private void Start() => Subscribe(statsManager.Power);

    protected override void Subscribe(IntReactiveProperty intReactive)
    {
        base.Subscribe(intReactive);
    }
}
