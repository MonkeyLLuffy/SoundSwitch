﻿/********************************************************************
* Copyright (C) 2015-2017 Antoine Aflalo
*
* This program is free software; you can redistribute it and/or
* modify it under the terms of the GNU General Public License
* as published by the Free Software Foundation; either version 2
* of the License, or (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
********************************************************************/

using System;
using System.Windows.Forms;

namespace SoundSwitch.Common.WinApi.Keyboard
{
    public class HotKey : IEquatable<HotKey>
    {
        /// <summary>
        ///     The enumeration of possible modifiers.
        /// </summary>
        [Flags]
        public enum ModifierKeys : uint
        {
            Alt = 1,
            Control = 2,
            Shift = 4,
            Win = 8
        }

        public HotKey(Keys keys, ModifierKeys modifier)
        {
            Keys = keys;
            Modifier = modifier;
            Enabled = true;
        }

        public HotKey()
        {
            Enabled = true;
        }

        public Keys Keys { get; set; }
        public ModifierKeys Modifier { get; set; }
        public bool Enabled { get; set; }

        public bool Equals(HotKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Keys == other.Keys && Modifier == other.Modifier;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((HotKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Keys * 397) ^ (int) Modifier;
            }
        }

        public static bool operator ==(HotKey left, HotKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HotKey left, HotKey right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return Display();
        }

        public string Display()
        {
            var key = (Keys == Keys.None ? "" : $"+{Keys}");
            return $"{Modifier.ToString().Replace(", ", "+")}{key}";
        }
    }
}