using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar
{
    public class NovaPilarSummon : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32; // Ширина спрайта
            Item.height = 32; // Высота спрайта
            Item.useStyle = ItemUseStyleID.HoldUp; // Анимация использования
            Item.useTime = 20; // Время использования
            Item.useAnimation = 20; // Анимация использования
            Item.rare = ItemRarityID.Red; // Редкость предмета
            Item.value = Item.sellPrice(0, 5, 0, 0); // Цена предмета
            Item.consumable = true; // Используется ли предмет (сохраняется/исчезает после использования)
            Item.maxStack = 20; // Максимальное количество в стаке
        }

        public override bool CanUseItem(Player player)
        {
            // Проверяем, можно ли использовать предмет
            if (NPC.AnyNPCs(ModContent.NPCType<NovaPillar>()))
            {
                Main.NewText("A Nova Pillar already exists in this world!", Color.Red);
                return false; // Если NovaPillar уже существует, использование предмета запрещено
            }
            return true;
        }

        public override bool? UseItem(Player player)
        {
            // Определяем координаты для спавна NovaPillar
            Vector2 spawnPos = player.Center + new Vector2(Main.rand.Next(-1600, 1600), -100); // Пример позиции над игроком

            int spawnNPC = NPC.NewNPC(new Terraria.DataStructures.EntitySource_ItemUse(player, Item),
                (int)spawnPos.X, (int)spawnPos.Y, ModContent.NPCType<NovaPillar>());

            if (spawnNPC < 200)
            {
                Main.NewText("The Nova Pillar has been summoned!", Color.Orange);
                return true; // Предмет успешно использован
            }
            else
            {
                Main.NewText("Failed to summon the Nova Pillar.", Color.Red);
                return false; // Ошибка при использовании
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(3456, 10);
            recipe.AddIngredient(3457, 10);
            recipe.AddIngredient(3458, 10);
            //recipe.AddIngredient(3459, 1);
            //recipe.SetResult(this);
            recipe.AddTile(412);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(3456, 10);
            recipe1.AddIngredient(3457, 10);
            recipe1.AddIngredient(3459, 10);
            recipe1.AddTile(412);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(3456, 10);
            recipe2.AddIngredient(3459, 10);
            recipe2.AddIngredient(3458, 10);
            recipe2.AddTile(412);
            recipe2.Register();

            Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(3459, 10);
            recipe3.AddIngredient(3457, 10);
            recipe3.AddIngredient(3458, 10);
            recipe3.AddTile(412);
            recipe3.Register();
        }
    }
}