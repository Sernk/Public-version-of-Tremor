using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class AxeofExecutionerPro : ModProjectile
	{
        public override void SetDefaults()
        {
            //  опируем параметры поведени€ снар€да с ID 182
            Projectile.CloneDefaults(182);

            // «адаем размеры снар€да
            Projectile.width = 29;
            Projectile.height = 29;

            // ”казываем AIType (снар€д, на который ориентируетс€ логика поведени€)
            AIType = 182; // ”бедитесь, что 182 Ч это существующий ID снар€да, с которым вы хотите сравн€тьс€
        }


        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AxeofExecutioner");
		}*/
    }
}
