using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;

namespace TremorMod.Content.Event
{
	public class InvasionWorld : ModSystem
	{
		public static int CyberWrathPoints = 0; // Is set once to Points1, never used. Delete ?? (?)
		public static int CyberWrathPoints1;
		public static bool CyberWrath;

		public override void OnWorldLoad()/* tModPorter Suggestion: Also override OnWorldUnload, and mirror your worldgen-sensitive data initialization in PreWorldGen */
		{
			CyberWrathPoints1 = 0;
			CyberWrath = false;
		}

		/*public override void SaveCustomData(BinaryWriter writer)
		{
			writer.Write(saveVersion);
			writer.Write(CyberWrath);
			writer.Write(CyberWrathPoints1);
		} */

		public override void SaveWorldData(TagCompound tag)/* tModPorter Suggestion: Edit tag parameter instead of returning new TagCompound */
        {
            tag["CyberWrath"] = CyberWrath;
            tag["CyberWrathPoints1"] = CyberWrathPoints1;
        }

		public override void LoadWorldData(TagCompound tag)
		{
			CyberWrath = tag.GetBool("CyberWrath");
			CyberWrathPoints1 = tag.GetAsInt("CyberWrathPoints1");
		}

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(CyberWrath);
			writer.Write(CyberWrathPoints1);
		}

		public override void NetReceive(BinaryReader reader)
		{
			CyberWrath = reader.ReadBoolean();
			CyberWrathPoints1 = reader.ReadInt32();
		}
	}
}
