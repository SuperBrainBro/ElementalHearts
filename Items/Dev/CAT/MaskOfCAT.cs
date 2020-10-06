using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.CAT
{
    [AutoloadEquip(EquipType.Head)]
    public class MaskOfCAT : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Maskof");
            Tooltip.SetDefault("'Great for impersonating devs!'\nThe Starbreaker... what under his mask?");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<RobeOfCAT>()/* && legs.type == ItemType<ExampleLeggings>()*/;
        }

        public override void UpdateEquip(Player player)
        {
            if (player.name == "CAT")
            {
                player.buffImmune[39] = true;
                player.statManaMax2 += 20;
                player.maxMinions++;
                player.allDamage += .5f;
            }
            if (player.name == "AstralCat")
            {
                player.buffImmune[39] = true;
                player.statManaMax2 += 20;
                player.maxMinions++;
                player.allDamage += .5f;
            }
        }
    }

    [AutoloadEquip(EquipType.Head)]
    public class MaskOfCAT2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Mask of Fox");
            Tooltip.SetDefault("'Great for impersonating devs!'\nWho knew he was a fox?");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = ItemRarityID.Cyan;
            item.vanity = false;
            item.defense = 1;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<RobeOfCAT>() && legs.type == ItemID.None;
        }

        public override void UpdateEquip(Player player)
        {
            ElementalHeartsPlayer player1 = new ElementalHeartsPlayer();
            player1.setBonusFox = true;
            player1.shadowFox = true;
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.FindBuffIndex(mod.BuffType("FoxShadowB")) == 0)
                {
                    player.AddBuff(mod.BuffType("FoxShadowB"), 3600, true);
                }
                if (player.ownedProjectileCounts[mod.ProjectileType("FoxShadow")] < 1)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, mod.ProjectileType("FoxShadow"), 0, 0f, Main.myPlayer, 0f, 0f);
                }
            }
            if (player.name == "CAT" || player.name == "AstralCat" || player.name == "Fox" || player.name == "FOX" || player.name == "Cat")
            {
                for (int k = 0; k < player.buffImmune.Length; k++)
                {
                    player.buffImmune[k] = true;
                }
                player.statManaMax2 += 20 * 2;
                player.maxMinions += 2;
                player.allDamage += .5f * 2;
            }
            else
            {
                player.buffImmune[39 / 2] = true;
                player.statManaMax2 += 20 / 2;
                player.allDamage += .5f / 2;
            }
            player.buffImmune[mod.BuffType("FoxShadowB")] = false;
        }
    }
}