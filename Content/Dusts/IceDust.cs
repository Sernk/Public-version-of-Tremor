using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TremorMod.Content.Dusts
{
	public class IceDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
		}
	}
}