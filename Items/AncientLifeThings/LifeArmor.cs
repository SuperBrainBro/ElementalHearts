using System;
using ElementalHearts.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.AncientLifeThings
{
    public class LifeArmor
    {
        [AutoloadEquip(equipTypes: EquipType.Head)]
        public class LifeMask : ModItem
        {
            public override string Texture => "ElementalHearts/Items/AncientLifeThings/LifeMask";

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
                int plusHPregenPerKilledEnemyMadeForFoxPleaseSaveMe = 1;
                string setBonus = @"Increases life regen
Life regen is stronger when not moving"
/*You take more damage on hit"*/;
                if (player.name == "Lite")
                {
                    setBonus += "\nYou take more damage on hit";
                }
                if (Main.hardMode && player.name != "Fox")
                {
                    setBonus += "\nSlightly decreased life regen in hardmode but you takes less damage on hit.";
                }
                if (NPC.downedMoonlord && player.name == "Fox")
                {
                    setBonus += "\nYou get " + plusHPregenPerKilledEnemyMadeForFoxPleaseSaveMe + " additional hp per killed enemy.\nNOT WORKING HELP MEEEE";
                }
                player.setBonus = setBonus;
                player.GetModPlayer<ElementalHeartsPlayer>().lifeArmour = true;
                if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) < 1.0f && !player.rocketFrame)
                {
                    player.lifeRegen += 7;
                    player.lifeRegenCount += 7;
                    player.lifeRegenTime += 7;
                    if (Main.hardMode && player.name != "Fox")
                    {
                        player.lifeRegen -= 2;
                        player.lifeRegenCount -= 2;
                        player.lifeRegenTime -= 2;
                    }
                    if (Main.hardMode && player.name == "Fox")
                    {
                        player.lifeRegen += 3;
                        player.lifeRegenCount += 3;
                        player.lifeRegenTime += 3;
                    }
                }
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
            public override string Texture => "ElementalHearts/Items/AncientLifeThings/LifeChainmail";

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
            public override string Texture => "ElementalHearts/Items/AncientLifeThings/LifeGreaves";

            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Ancient Life Chainmail");
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