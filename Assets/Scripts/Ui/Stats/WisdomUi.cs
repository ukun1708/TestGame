using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class WisdomUi : StatsUi
{
    private void Start() => Subscribe(statsManager.Wisdom);

    protected override void Subscribe(IntReactiveProperty intReactive)
    {
        base.Subscribe(intReactive);
    }
}
