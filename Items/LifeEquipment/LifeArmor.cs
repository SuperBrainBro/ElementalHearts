using System;
using ElementalHearts.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.LifeEquipment
{
    public class LifeArmor
    {
        [AutoloadEquip(equipTypes: EquipType.Head)]
        public class LifeMask : ModItem
        {
            public override string Texture => "ElementalHearts/Items/LifeEquipment/LifeMask";

            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Ancient Life Mask");
                //Main.armorHeadTexture[item.type] = GetTexture(Texture + "_Head");
                base.SetStaticDefaults();
            }

            public override bool IsArmorSet(Item head, Item body, Item legs)
            {
                return body.type == ItemType<LifeChainmail>() && legs.type == ItemType<LifeGreaves>();
            }

            public override void UpdateEquip(Player player)
            {
                player.lifeRegen += 1;
                player.lifeRegenCount += 1;
                player.lifeRegenTime += 1;
                base.UpdateEquip(player);
            }

            public override void UpdateArmorSet(Player player)
            {
                player.setBonus = "Increases life regen";
                player.lifeRegen += 3;
                base.UpdateArmorSet(player);
            }

            public override void SetDefaults()
            {
                item.width = 26;
                item.height = 24;
                item.defense = 5;
                item.rare = ItemRarityID.Blue;
                item.value = 4000 * 15;
                base.SetDefaults();
            }

            public override void AddRecipes()
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemType<LifeBar>(), 20);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this, 1);
                recipe.AddRecipe();
                base.AddRecipes();
            }
        }

        [AutoloadEquip(equipTypes: EquipType.Body)]
        public class LifeChainmail : ModItem
        {
            public override string Texture => "ElementalHearts/Items/LifeEquipment/LifeChainmail";

            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Ancient Life Chainmail");
                //Main.armorArmTexture[item.type] = GetTexture(Texture + "_Arms");
                //Main.armorBodyTexture[item.type] = GetTexture(Texture + "_Body");
                //Main.femaleBodyTexture[item.type] = GetTexture(Texture + "_Female_Body");
                base.SetStaticDefaults();
            }

            public override void SetDefaults()
            {
                item.width = 26;
                item.height = 24;
                item.defense = 6;
                item.rare = ItemRarityID.Blue;
                item.value = 4000 * 25;
                base.SetDefaults();
            }

            public override void UpdateEquip(Player player)
            {
                player.lifeRegen += 1;
                player.lifeRegenCount += 1;
                player.lifeRegenTime += 1;
                base.UpdateEquip(player);
            }

            public override void AddRecipes()
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemType<LifeBar>(), 30);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this, 1);
                recipe.AddRecipe();
                base.AddRecipes();
            }
        }

        [AutoloadEquip(equipTypes: EquipType.Legs)]
        public class LifeGreaves : ModItem
        {
            public override string Texture => "ElementalHearts/Items/LifeEquipment/LifeGreaves";

            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Ancient Life Greaves");
                //Main.armorLegTexture[item.type] = GetTexture(Texture + "_Legs");
                base.SetStaticDefaults();
            }

            public override void UpdateEquip(Player player)
            {
                player.lifeRegen += 1;
                player.lifeRegenCount += 1;
                player.lifeRegenTime += 1;
                base.UpdateEquip(player);
            }

            public override void SetDefaults()
            {
                item.width = 26;
                item.height = 24;
                item.defense = 5;
                item.rare = ItemRarityID.Blue;
                item.value = 4000 * 20;
                base.SetDefaults();
            }

            public override void AddRecipes()
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemType<LifeBar>(), 25);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this, 1);
                recipe.AddRecipe();
                base.AddRecipes();
            }
        }
    }
}