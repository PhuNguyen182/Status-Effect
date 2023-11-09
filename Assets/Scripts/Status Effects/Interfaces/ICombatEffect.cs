using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffects.Interfaces
{
    public interface ICombatEffect
    {
        public void Play();
        public void Pause();
        public void Stop();
        public void Dispose();
    }
}