namespace PlayerXP
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using System.Collections.Generic;
    using System.Linq;
    using static PlayerXP;

    /// <summary>
    /// Handles player events.
    /// </summary>
    internal sealed class Server
    {
        /// <inheritdoc cref="Events.Handlers.Server.OnEndingRound(EndingRoundEventArgs)"/>
        public void OnEndingRound(EndingRoundEventArgs ev)
        {
            if (ev.LeadingTeam != LeadingTeam.Draw) {
                //不是平局
                List<Exiled.API.Features.Player> players = Exiled.API.Features.Player.List.ToList();
                foreach (Exiled.API.Features.Player player in players)
                {
                    if (player.Team == Team.MTF && ev.LeadingTeam == LeadingTeam.FacilityForces)    //获胜阵营加经验
                    {
                        AddXP(player.UserId, (int)(Instance.Config.xp_all_round_win * Instance.Config.xp_scale));
                    }
                    if (player.Team == Team.SCP && ev.LeadingTeam == LeadingTeam.Anomalies)    //获胜阵营加经验
                    {
                        AddXP(player.UserId, (int)(Instance.Config.xp_all_round_win * Instance.Config.xp_scale));
                    }
                    if (player.Team == Team.CHI && ev.LeadingTeam == LeadingTeam.ChaosInsurgency)    //获胜阵营加经验
                    {
                        AddXP(player.UserId, (int)(Instance.Config.xp_all_round_win * Instance.Config.xp_scale));
                    }
                }
            }
        }
    }
}