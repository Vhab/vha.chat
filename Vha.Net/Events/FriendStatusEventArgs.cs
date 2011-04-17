/*
* Vha.Net
* Copyright (C) 2005-2011 Remco van Oosterhout
* See Credits.txt for all aknowledgements.
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
using System.Collections.Generic;
using System.Text;
using Vha.Common;

namespace Vha.Net.Events
{
    /// <summary>
    /// Holds event args for friend status messages.
    /// </summary>
    public class FriendStatusEventArgs : EventArgs
    {
        private readonly UInt32 _characterID = 0;
        private readonly string _character;
        private readonly bool _online = false;
        private readonly string _tag = "";

        /// <summary>
        /// Event argument constructor
        /// </summary>
        /// <param name="characterID">The character id of the character</param>
        /// <param name="status">The status of the character</param>
        /// <param name="group">A string associated with this specific friendslist entry</param>
        public FriendStatusEventArgs(UInt32 characterID, string character, bool status, string tag)
        {
            this._characterID = characterID;
            this._character = character;
            this._online = status;
            this._tag = tag;
        }

        /// <summary>
        /// ID of the character
        /// </summary>
        public UInt32 CharacterID { get { return this._characterID; } }
        public string Character { get { return this._character; } }
        /// <summary>
        /// Whether the character is online or not
        /// </summary>
        public bool Online { get { return this._online; } }
        /// <summary>
        /// Whether the character is a temporary friend
        /// </summary>
        public bool Temporary { get { return this._tag == "\0"; } }
        /// <summary>
        /// A string associated with this specific friendslist entry
        /// </summary>
        public string Tag { get { return this._tag; } }
        /// <summary>
        /// Returns combined friend data
        /// </summary>
        /// <returns>A new instance of Friend</returns>
        public Friend GetFriend() { return new Friend(this.CharacterID, this.Character, this.Online, this.Tag, this.Temporary); }
    }
}
