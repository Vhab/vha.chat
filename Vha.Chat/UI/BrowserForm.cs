/*
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vha.Chat;

namespace Vha.Chat.UI
{
    public enum BrowserFormType
    {
        Url,
        Item
    }

    public partial class BrowserForm : BaseForm
    {
        public BrowserForm(Context context, string argument, BrowserFormType type)
            : base(context, "Browser")
        {
            InitializeComponent();
            base.Initialize();
            // Handle argument
            switch (type)
            {
                case BrowserFormType.Item:
                    string[] parts = argument.Split(new char[] { '/' });
                    if (parts.Length < 3)
                    {
                        this._browser.DocumentText = "Invalid item: " + argument;
                        return;
                    }
                    else
                    {
                        string url = "http://www.xyphos.com/ao/aodb.php?id={0}&id2={1}&ql={2}&minimode=1";
                        this._browser.Navigate(string.Format(url, parts[0], parts[1], parts[2]));
                    }
                    break;
                case BrowserFormType.Url:
                    this._browser.Navigate(argument);
                    break;
            }
        }
    }
}