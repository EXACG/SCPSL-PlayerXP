using System;
using System.ComponentModel;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace PlayerXP
{
	public sealed class Config : IConfig
	{
		public bool IsEnabled { get; set; } = true;

		public float xp_scale { get; set; } = 1.0f;
		
		public int xp_all_round_win { get; set; } = 200;

		public int xp_dclass_scientist_kill { get; set; } = 50;
		public int xp_dclass_mtf_kill { get; set; } = 100;
		public int xp_dclass_scp_kill { get; set; } = 200;
		public int xp_dclass_escape { get; set; } = 100;

		public int xp_scientist_dclass_kill { get; set; } = 50;
		public int xp_scientist_chaos_kill { get; set; } = 100;
		public int xp_scientist_scp_kill { get; set; } = 200;
		public int xp_scientist_escape { get; set; } = 100;

		public int xp_mtf_dclass_kill { get; set; } = 25;
		public int xp_mtf_chaos_kill { get; set; } = 50;
		public int xp_mtf_scp_kill { get; set; } = 100;

		public int xp_chaos_scientist_kill { get; set; } = 25;
		public int xp_chaos_mtf_kill { get; set; } = 50;
		public int xp_chaos_scp_kill { get; set; } = 100;

		public int xp_scp049_killed { get; set; } = 100;
		public int xp_scp0492_killed { get; set; } = 100;
		public int xp_scp079_killed { get; set; } = 100;
		public int xp_scp096_killed { get; set; } = 100;
		public int xp_scp106_killed { get; set; } = 100;
		public int xp_scp173_killed { get; set; } = 100;
		public int xp_scp93953_killed { get; set; } = 100;
		public int xp_scp93989_killed { get; set; } = 100;
	}
}
