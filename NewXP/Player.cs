namespace PlayerXP
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;

    using static PlayerXP;

    /// <summary>
    /// Handles player events.
    /// </summary>
    internal sealed class Player
    {
        /// <inheritdoc cref="Events.Handlers.Player.OnDied(DiedEventArgs)"/>
        public void OnDied(DiedEventArgs ev)
        {
			if (ev.Target.Team == Team.CDP) //D级被杀
			{
				int gainedXP = 0;
				if (ev.Killer.Team == Team.RSC)
					gainedXP = (int)(Instance.Config.xp_dclass_scientist_kill * Instance.Config.xp_scale);
				if (ev.Killer.Team == Team.MTF)
					gainedXP = (int)(Instance.Config.xp_dclass_mtf_kill * Instance.Config.xp_scale);
				if (ev.Killer.Team == Team.SCP)
					gainedXP = (int)(Instance.Config.xp_dclass_scp_kill * Instance.Config.xp_scale);

				if (gainedXP > 0 && ev.Target.UserId != ev.Killer.UserId)
				{
					ev.Killer.SendConsoleMessage("你得到了" + gainedXP.ToString() + "经验! 原因:杀死了" + ev.Target.Nickname + "!", "yellow");
					AddXP(ev.Killer.UserId, gainedXP);
				}
			}

			if (ev.Target.Team == Team.RSC )//科学家被杀
			{
				int gainedXP = 0;
				if (ev.Killer.Team == Team.CDP)
					gainedXP = (int)(Instance.Config.xp_scientist_dclass_kill * Instance.Config.xp_scale);
				if (ev.Killer.Team == Team.CHI)
					gainedXP = (int)(Instance.Config.xp_scientist_chaos_kill * Instance.Config.xp_scale);
				if (ev.Killer.Team == Team.SCP)
					gainedXP = (int)(Instance.Config.xp_scientist_scp_kill * Instance.Config.xp_scale);

				if (gainedXP > 0 && ev.Target.UserId != ev.Killer.UserId)
				{
					ev.Killer.SendConsoleMessage("你得到了" + gainedXP.ToString() + "经验! 原因:杀死了" + ev.Target.Nickname + "!", "yellow");
					AddXP(ev.Killer.UserId, gainedXP);
				}
			}

			if (ev.Target.Team == Team.MTF) //九尾被杀
			{
				int gainedXP = 0;
				if (ev.Killer.Team == Team.CDP)
					gainedXP = (int)(Instance.Config.xp_mtf_dclass_kill * Instance.Config.xp_scale);
				if (ev.Killer.Team == Team.CHI)
					gainedXP = (int)(Instance.Config.xp_mtf_chaos_kill * Instance.Config.xp_scale);
				if (ev.Killer.Team == Team.SCP)
					gainedXP = (int)(Instance.Config.xp_mtf_scp_kill * Instance.Config.xp_scale);

				if (gainedXP > 0 && ev.Target.UserId != ev.Killer.UserId)
				{
					ev.Killer.SendConsoleMessage("你得到了" + gainedXP.ToString() + "经验! 原因:杀死了" + ev.Target.Nickname + "!", "yellow");
					AddXP(ev.Killer.UserId, gainedXP);
				}
			}

			if (ev.Target.Team == Team.CHI) //混沌被杀
			{
				int gainedXP = 0;
				if (ev.Killer.Team == Team.RSC)
					gainedXP = (int)(Instance.Config.xp_chaos_scientist_kill * Instance.Config.xp_scale);
				if (ev.Killer.Team == Team.MTF)
					gainedXP = (int)(Instance.Config.xp_chaos_mtf_kill * Instance.Config.xp_scale);
				if (ev.Killer.Team == Team.SCP)
					gainedXP = (int)(Instance.Config.xp_chaos_scp_kill * Instance.Config.xp_scale);

				if (gainedXP > 0 && ev.Target.UserId != ev.Killer.UserId)
				{
					ev.Killer.SendConsoleMessage("你得到了" + gainedXP.ToString() + "经验! 原因:杀死了" + ev.Target.Nickname + "!", "yellow");
					AddXP(ev.Killer.UserId, gainedXP);
				}
			}

			if (ev.Target.Team == Team.SCP)	//SCP被杀
			{
				int gainedXP = 0;
				if (ev.Target.UserId != ev.Killer.UserId && ev.Target.Role == RoleType.Scp049)
				{
					gainedXP = (int)(Instance.Config.xp_scp049_killed * Instance.Config.xp_scale);
					AddXP(ev.Killer.UserId, gainedXP);
				}
				if (ev.Target.UserId != ev.Killer.UserId && ev.Target.Role == RoleType.Scp0492)
				{
					gainedXP = (int)(Instance.Config.xp_scp0492_killed * Instance.Config.xp_scale);
					AddXP(ev.Killer.UserId, gainedXP);
				}
				if (ev.Target.UserId != ev.Killer.UserId && ev.Target.Role == RoleType.Scp079)
				{
					gainedXP = (int)(Instance.Config.xp_scp079_killed * Instance.Config.xp_scale);
					AddXP(ev.Killer.UserId, gainedXP);
				}
				if (ev.Target.UserId != ev.Killer.UserId && ev.Target.Role == RoleType.Scp096)
				{
					gainedXP = (int)(Instance.Config.xp_scp096_killed * Instance.Config.xp_scale);
					AddXP(ev.Killer.UserId, gainedXP);
				}
				if (ev.Target.UserId != ev.Killer.UserId && ev.Target.Role == RoleType.Scp106)
				{
					gainedXP = (int)(Instance.Config.xp_scp106_killed * Instance.Config.xp_scale);
					AddXP(ev.Killer.UserId, gainedXP);
				}
				if (ev.Target.UserId != ev.Killer.UserId && ev.Target.Role == RoleType.Scp173)
				{
					gainedXP = (int)(Instance.Config.xp_scp173_killed * Instance.Config.xp_scale);
					AddXP(ev.Killer.UserId, gainedXP);
				}
				if (ev.Target.UserId != ev.Killer.UserId && ev.Target.Role == RoleType.Scp93953)
				{
					gainedXP = (int)(Instance.Config.xp_scp93953_killed * Instance.Config.xp_scale);
					AddXP(ev.Killer.UserId, gainedXP);
				}
				if (ev.Target.UserId != ev.Killer.UserId && ev.Target.Role == RoleType.Scp93989)
				{
					gainedXP = (int)(Instance.Config.xp_scp93989_killed * Instance.Config.xp_scale);
					AddXP(ev.Killer.UserId, gainedXP);
				}
				if (gainedXP > 0) {
					ev.Killer.SendConsoleMessage("你得到了" + gainedXP.ToString() + "经验! 原因:杀死了" + ev.Target.Nickname + "!", "yellow");
				}
			}

			if (ev.Target.UserId != ev.Killer.UserId && ev.Killer != null && ev.Killer.UserId != string.Empty)
				ev.Target.SendConsoleMessage("你被杀了! 对方:" + ev.Killer.Nickname + ", 等级:" + GetLevel(ev.Killer.UserId).ToString() + ".", "yellow");
			if (ev.Target != null && ev.Target.UserId != string.Empty)
				ev.Target.SendConsoleMessage("你还差" + GetXP(ev.Target.UserId) + " / " + XpToLevelUp(ev.Target.UserId) + "经验才能到下一个等级:" + (GetLevel(ev.Target.UserId) + 1).ToString() + ".", "yellow");
		//Log.Info($"{ev.Target.Nickname} ({ev.Target.Role}) died from {ev.HitInformations.GetDamageName()}! {ev.Killer.Nickname} ({ev.Killer.Role}) killed him!");
        }

		/// <inheritdoc cref="Events.Handlers.Player.OnJoined(JoinedEventArgs)"/>
		public void OnVerified(VerifiedEventArgs ev)
		{
			InitData(ev.Player.UserId);
			ev.Player.RankName = "Lv." + GetLevel(ev.Player.UserId).ToString() + "(" + GetXP(ev.Player.UserId) + " / " + XpToLevelUp(ev.Player.UserId) + ")";
			//ev.Player.SetRank("Lv." + GetLevel(ev.Player.UserId).ToString() + "(" + GetXP(ev.Player.UserId) + " / " + XpToLevelUp(ev.Player.UserId) + ")",ev.Player.Group);
			//Broadcast(10u, "欢迎您来到Menyuserver RPG服务器,(加群很重要 N键看群号)本服务器RPG的核心控制台命令 .rpg ", false);

			//ev.Player.Broadcast(Instance.Config.JoinedBroadcast.Duration, Instance.Config.JoinedBroadcast.Content, Instance.Config.JoinedBroadcast.Type);
		}

		public void OnEscaping(EscapingEventArgs ev) {
			if (ev.Player.Role == RoleType.ClassD) {
				AddXP(ev.Player.UserId, (int)(Instance.Config.xp_dclass_escape * Instance.Config.xp_scale));
			}
			if (ev.Player.Role == RoleType.Scientist)
			{
				AddXP(ev.Player.UserId, (int)(Instance.Config.xp_scientist_escape * Instance.Config.xp_scale));
			}
		}
	}
}