using Rocket.API;
using Rocket.Core.Commands;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Reponseİncele
{
    public class Class1 : RocketPlugin<Config>
    {
        protected override void Load()
        {
            base.Load();
            Console.WriteLine("ReponseCode Review = AKTİF");
            Console.WriteLine("ReponseCode Review = AKTİF");
            Console.WriteLine("ReponseCode Review = AKTİF");
            Console.WriteLine("ReponseCode Review = AKTİF");
            Console.WriteLine("ReponseCode Review = AKTİF");
            Console.WriteLine("ReponseCode Review = AKTİF");
            Console.WriteLine("ReponseCode Review = AKTİF");
            Console.WriteLine("ReponseCode Review = AKTİF");
            Console.WriteLine("ReponseCode Review = AKTİF");
            Console.WriteLine("ReponseCode Review = AKTİF");

        }

        [RocketCommand("review", "review", "/review", AllowedCaller.Both)]
        [RocketCommandPermission("reponce.review")]
        public void İncele(IRocketPlayer caller, string[] args)
        {
            UnturnedPlayer pl = caller as UnturnedPlayer;

            if (Physics.Raycast(pl.Player.look.aim.position, pl.Player.look.aim.forward, out var hits, 10f, RayMasks.BARRICADE_INTERACT))
            {
                var Barricade = BarricadeManager.FindBarricadeByRootTransform(hits.transform);
                var datas = Barricade.GetServersideData();

                UnturnedPlayer owner = UnturnedPlayer.FromCSteamID((CSteamID)datas.owner);


                if (owner != null)
                {
                    ChatManager.serverSendMessage($"<color=orange>The Owner of The Structure |</color> Owner Name: {owner.CharacterName} - Owner Id: {owner.CSteamID}", Color.white, null, pl.SteamPlayer(), EChatMode.SAY, Configuration.Instance.ServerLogo, true);

                }
                else
                {
                    ChatManager.serverSendMessage($"<color=orange>The Owner of The Structure |</color> Owner Name: Offline - Owner Id: {owner.CSteamID}", Color.white, null, pl.SteamPlayer(), EChatMode.SAY, Configuration.Instance.ServerLogo, true);
                }


            }
            else if (Physics.Raycast(pl.Player.look.aim.position, pl.Player.look.aim.forward, out var hit, 10f, RayMasks.STRUCTURE_INTERACT))
            {
                var structure = StructureManager.FindStructureByRootTransform(hit.transform);
                var data = structure.GetServersideData();

                UnturnedPlayer owner = UnturnedPlayer.FromCSteamID((CSteamID)data.owner);

                if (owner != null)
                {
                    ChatManager.serverSendMessage($"<color=orange>The Owner of The Structure |</color> Owner Name: {owner.CharacterName} - Owner Id: {owner.CSteamID}", Color.white, null, pl.SteamPlayer(), EChatMode.SAY, Configuration.Instance.ServerLogo, true);

                }
                else
                {
                    ChatManager.serverSendMessage($"<color=orange>The Owner of The Structure |</color> Owner Name: Offline - Owner Id: {owner.CSteamID}", Color.white, null, pl.SteamPlayer(), EChatMode.SAY, Configuration.Instance.ServerLogo, true);
                }
            }




        }
    }
}
