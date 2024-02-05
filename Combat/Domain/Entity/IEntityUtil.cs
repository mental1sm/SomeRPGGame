namespace Desert.Combat.Domain.Entity;

public interface IEntityUtil
{
    /// <summary>
    /// Установить значения здоровья и энергии на 100%
    /// </summary>
    void ResetHpAndEnergy();
}