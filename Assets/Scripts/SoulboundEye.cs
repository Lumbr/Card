using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulboundEye : CardEffect
{
    internal override void Start() { base.Start(); special = false; }
    public override void Play() { }

    private void OnDestroy()
    {
        player.Draw(1);
    }
}
