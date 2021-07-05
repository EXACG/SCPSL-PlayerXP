using System;
using System.IO;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events;
using Exiled.Events.Handlers;

namespace PlayerXP
{
	// Token: 0x02000004 RID: 4
	public class PlayerXP : Plugin<Config>
	{
		private Player player;
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000234B File Offset: 0x0000054B
		public override string Author
		{
			get
			{
				return "MenYu";
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002352 File Offset: 0x00000552
		public override Version Version
		{
			get
			{
				return new Version(1, 0, 0);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000235C File Offset: 0x0000055C
		public override Version RequiredExiledVersion
		{
			get
			{
				return new Version(2, 8, 0);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002366 File Offset: 0x00000566
		public static PlayerXP Instance
		{
			get
			{
				return PlayerXP.lazyInstance.Value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002372 File Offset: 0x00000572
		public override PluginPriority Priority { get; } = 0;

		// Token: 0x06000010 RID: 16 RVA: 0x0000237A File Offset: 0x0000057A
		private PlayerXP()
		{
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000238B File Offset: 0x0000058B
		public override void OnEnabled()
		{
			if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\") == false)
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\");
			}
			base.OnEnabled();
			this.RegisterEvents();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000239B File Offset: 0x0000059B
		public override void OnDisabled()
		{
			base.OnDisabled();
			this.UnregisterEvents();
		}
		
		// Token: 0x06000013 RID: 19 RVA: 0x000023A5 File Offset: 0x000005A5
		public void RegisterEvents()
		{
			player = new Player();
			//this.handlers = new EventHandlers();
			Exiled.Events.Handlers.Player.Verified += player.OnVerified;
			Exiled.Events.Handlers.Player.Died += player.OnDied;
			Exiled.Events.Handlers.Player.Escaping += player.OnEscaping;
			//Exiled.Events.Handlers.Player.Joined += player.OnJoined;
			//Exiled.Events.Handlers.Server.RoundStarted += new Events.CustomEventHandler(this.handlers.OnRoundStarted);
			//Exiled.Events.Handlers.Server.RestartingRound += new Events.CustomEventHandler(Preferences.SavePreferencesToFile);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000023DC File Offset: 0x000005DC
		public void UnregisterEvents()
		{
            //Exiled.Events.Handlers.Server.RoundStarted -= new Events.CustomEventHandler(this.handlers.OnRoundStarted);
            //Exiled.Events.Handlers.Server.RestartingRound -= new Events.CustomEventHandler(Preferences.SavePreferencesToFile);
			//this.handlers = null;
			player = null;
		}

		public static void InitData(string steamid) 
		{
			if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\" + steamid + ".txt"))
			{
				File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\" + steamid + ".txt", "1:0");
			}
		}

		public static int XpToLevelUp(string steamid)
		{
			string[] data = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\" + steamid + ".txt").Split(':');
			int lvl = int.Parse(data[0]);
			int currXP = int.Parse(data[1]);

			return lvl * 250 + 750;
		}

		public static int GetLevel(string steamid)
		{
			return int.Parse(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\" + steamid + ".txt").Split(':')[0]);
		}
		public static int GetXP(string steamid)
		{
			return int.Parse(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\" + steamid + ".txt").Split(':')[1]);
		}

		public static void AddXP(string steamid, int xp)
		{
			string[] data = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\" + steamid + ".txt").Split(':');
			int level = int.Parse(data[0]);
			int currXP = int.Parse(data[1]);

			currXP += xp;
			if (currXP >= level * 250 + 750)
			{
				currXP -= level * 250 + 750;
				level++;
			}
			File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\" + steamid + ".txt", level + ":" + currXP);
		}
		public static void RemoveXP(string steamid, int xp)
		{
			string[] data = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\" + steamid + ".txt").Split(':');
			int level = int.Parse(data[0]);
			int currXP = int.Parse(data[1]);

			currXP -= xp;
			if (currXP <= 0)
			{
				if (level > 1)
				{
					level--;
					currXP = (level * 250 + 750) - Math.Abs(currXP);
				}
				else
				{
					currXP = 0;
				}
			}
			File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EXILED\\Configs\\PlayerXP\\" + steamid + ".txt", level + ":" + currXP);
		}

		// Token: 0x04000006 RID: 6
		private static readonly Lazy<PlayerXP> lazyInstance = new Lazy<PlayerXP>(() => new PlayerXP());

		// Token: 0x04000008 RID: 8
		//private EventHandlers handlers;
    }
}
