using StatusEffects.Effects;

namespace StatusEffects.Interfaces
{
    public interface IApplyStatusEffect
    {
        public void ApplyStatusEffect(BaseStatusEffect statusEffect);
    }
}
