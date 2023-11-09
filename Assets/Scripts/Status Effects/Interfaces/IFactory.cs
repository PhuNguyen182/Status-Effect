namespace StatusEffects.Interfaces
{
    public interface IFactory<in T, out TR>
    {
        public TR Create(T param);
    }
}
