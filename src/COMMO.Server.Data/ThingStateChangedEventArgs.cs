// <copyright file="ThingStateChangedEventArgs.cs" company="2Dudes">
// Copyright (c) 2018 2Dudes. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace COMMO.Server.Data
{
	public class ThingStateChangedEventArgs : EventArgs
    {
        public string PropertyChanged { get; set; }
    }
}