using System;

float health = 100;
float armor = 100;

const float kArmorValueProtection = 0.667f; // 0.667f == 2/3f

public void TakeDamage(float damage)
{
    if (damage <= 0)
    {
        return;
    }

    float reducedDamage = damage;

    if (armor > 0f)
    {
        // Calculate damage to armor
        int damageToArmor = Math.RoundToInt(reducedDamage * kArmorValueProtection);

        // Reduce damage
		reducedDamage -= damageToArmor;

		if (damageToArmor > armor)
		{
            // Apply excess armor damage
            //// e.g:
            //// if Player(100hp, 20armor) takes 60dmg,
            //// result will be Player(80hp, 0armor)
			reducedDamage += damageToArmor - (int)armor;
            damageToArmor = armor;
		}

        // Apply damage to armor
		armor -= damageToArmor;
    }

    // Apply damage to health
    health -= Math.Max(reducedDamage, 0);
}
