using StatusEffects.CombatEffects;
using StatusEffects.Effects;
using StatusEffects.Interfaces;
using StatusEffects.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExample : MonoBehaviour, IApplyStatusEffect
{
    private BaseStatusEffect statusEffect;
    private StatusEffectManager effectManager;

    public void ApplyStatusEffect(BaseStatusEffect statusEffect)
    {
        if (!statusEffect.CanBeStacked)
        {
            if (!effectManager.ContainEffect(statusEffect))
            {
                // Init actions for statusEffect here
            }
        }
        else
        {
            // Init actions for statusEffect here
        }

        effectManager.AddEffect(statusEffect, transform.position, Quaternion.identity, transform);
    }
}
