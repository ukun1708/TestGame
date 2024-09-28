using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HealthUi : StatsUi
{
    private void Start() => Subscribe(statsManager.Health);

    protected override void Subscribe(IntReactiveProperty intReactive)
    {
        base.Subscribe(intReactive);
    }
}
