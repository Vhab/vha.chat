﻿/*
* Vha.Chat
* Copyright (C) 2009-2010 Remco van Oosterhout
*
* This program is free software; you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation; version 2 of the License only.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program; if not, write to the Free Software
* Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307
* USA
*/

using System;
using System.Text;

namespace Vha.Chat.Commands
{
    public class UnmuteCommand : Command
    {
        public override bool Process(Context context, string command, string[] args)
        {
            if (!context.Input.CheckArguments(command, 1, true)) return false;
            string channel = string.Join(" ", args, 1, args.Length - 1);
            if (!context.Input.CheckChannel(channel)) return false;
            context.Chat.SendChannelMute(channel, false);
            return true;
        }

        public UnmuteCommand()
            : base(
                "Unmute public channel", // Name
                new string[] { "unmute" }, // Triggers
                new string[] { "unmute [channel]" }, // Usage
                new string[] { "unmute Neutral OOC" }, // Examples
                // Description
                "The unmute command allows you to unmute a previously muted public channel."
            )
        { }
    }
}
