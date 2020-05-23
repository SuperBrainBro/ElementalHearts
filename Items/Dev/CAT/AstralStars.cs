using ElementalHearts.Items.Dev.CAT;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.CAT
{
	public class AstralStars : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Astral Stars");
			Tooltip.SetDefault("Summons Stars from sky!"
							+ "\n'Great for impersonating devs!'");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Starfury);
			item.shootSpeed *= 0.75f;
			item.summon = true;
			item.damage = 45;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (Main.rand.NextBool(2)) {
				type = ProjectileType<DreamerStarSmall>();
			} else if (Main.rand.NextBool(4)) {
				type = ProjectileType<DreamerStarMedium>();
			} else {
				type = ProjectileType<DreamerStarLarge>();
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}