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
    public partial class InfoForm : Form
    {
        private static int _defaultWidth = -1;
        private static int _defaultHeight = -1;
        private static int _defaultLeft = -1;
        private static int _defaultTop = -1;

        protected string _html = "";
        protected ChatHtml _htmlUtil;

        public InfoForm(ChatHtml links, string html)
        {
            InitializeComponent();
            this._html = html;
            this._htmlUtil = links;
            // Check for default position
            if (_defaultLeft != -1 && _defaultTop != -1)
            {
                this.Location = new Point(_defaultLeft, _defaultTop);
                this.StartPosition = FormStartPosition.Manual;
            }
            // Check for default size
            if (_defaultWidth != -1 && _defaultHeight != -1)
            {
                this.Size = new Size(_defaultWidth, _defaultHeight);
            }
        }
        
        private void _info_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Scheme != "file")
                e.Cancel = true;
        }

        private void _info_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this._info.Document.Write(this._htmlUtil.Template);
            // Set background color
            this._info.Document.BackColor = this.BackColor;
            if (this._info.Document.Body != null)
            {
                string color = this.ForeColor.R.ToString("X") + this.ForeColor.G.ToString("X") + this.ForeColor.B.ToString("X");
                this._info.Document.Body.Style =
                    "color: #" + color + ";" +
                    "padding: 6px;";
            }
            // Put in some content
            this._htmlUtil.AppendHtml(this._info.Document, TextStyle.Default, this._html);
        }

        private void InfoForm_Move(object sender, EventArgs e)
        {
            _defaultLeft = this.Location.X + 15;
            _defaultTop = this.Location.Y + 15;
        }

        private void InfoForm_Resize(object sender, EventArgs e)
        {
            _defaultWidth = this.Size.Width;
            _defaultHeight = this.Size.Height;
        }

        private void InfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _defaultWidth = this.Size.Width;
            _defaultHeight = this.Size.Height;
            _defaultLeft = this.Location.X;
            _defaultTop = this.Location.Y;
        }
    }
}