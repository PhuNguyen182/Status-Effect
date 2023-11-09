using StatusEffects.Effects;
using StatusEffects.Enums;
using StatusEffects.CombatEffects;
using StatusEffects.Interfaces;

namespace StatusEffects.Factories
{
    public class StatusEffectFactory : IFactory<StatusEffectEnum, BaseStatusEffect>
    {
        private readonly CombatEffectDatabase _combatEffectDatabase;

        public StatusEffectFactory(CombatEffectDatabase combatEffectDatabase)
        {
            _combatEffectDatabase = combatEffectDatabase;
        }

        public BaseStatusEffect Create(StatusEffectEnum effectType)
        {
            BaseStatusEffect statusEffect;

            switch (effectType)
            {
                
                default:
                    statusEffect = null;
                    break;
            }

            statusEffect.CombatEffect = _combatEffectDatabase.CombatEffects[effectType];
            return statusEffect;
        }
    }
}
