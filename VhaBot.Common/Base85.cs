/*
* VhaBot - Barbaric Edition
* Copyright (C) 2005-2008 Remco van Oosterhout
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

namespace VhaBot.Common
{
    public class Base85
    {
        public static Int32 Decode(string encoded)
        {
            Int32 total = 0;
            char[] chars = encoded.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                Int32 value = (Int32)chars[i] - 33;
                if (value >= 85 || value < 0)
                    return 0;
                total = (total * 85) + value;
            }
            return total;
        }
    }
}
