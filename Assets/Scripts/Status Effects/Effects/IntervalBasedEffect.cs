using StatusEffects.CombatEffects;
using StatusEffects.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffects.Effects
{
    public class IntervalBasedEffect : BaseStatusEffect
    {
        protected bool _isPause = false;
        protected bool _isExpired = false;
        protected float _elapsedTime = 0;
        protected float _dropInterval = 1;

        public override bool IsPaused => _isPause;

        public override bool IsExpired => _isExpired;

        public override bool CanBeStacked { get; }

        public override float Duration { get; set; }

        public override float AffectingPercentage { get; }

        public override float TickRate { get; }

        public override Action OnStart { get; set; }
        public override Action OnStop { get; set; }
        public override Action<bool> OnPause { get; set; }
        public override Action<float> OnTick { get; set; }
        public override Action Remove { get; set; }

        public override StatusEffectEnum StatusEffectType { get; }

        public override CombatEffect CombatEffect { get; set; }

        public override void Pause(bool isPause)
        {
            _isPause = isPause;
            OnPause?.Invoke(isPause);

            if (combatEffect != null)
            {
                if (_isPause)
                    combatEffect.Pause();
                else
                    combatEffect.Play();
            }
        }

        public override void Reset()
        {
            _elapsedTime = 0;
            _dropInterval = 1;

            _isPause = false;
            _isExpired = false;
        }

        public override void Stop()
        {
            Remove?.Invoke();
            OnStop?.Invoke();
            Dispose();
        }

        public override void Update()
        {
            if (_elapsedTime < Duration)
            {
                _elapsedTime += TickRate;
                _dropInterval += TickRate;

                if (_dropInterval > 1)
                {
                    _dropInterval = 0;
                    OnTick?.Invoke(AffectingPercentage);
                }

                //OnTick?.Invoke(_elapsedTime / Duration);
            }

            else
                _isExpired = true;
        }
    }
}
