// <copyright file="IMapLoader.cs" company="2Dudes">
// Copyright (c) 2018 2Dudes. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

using COMMO.Server.Data.Interfaces;

namespace COMMO.Server.Map
{
    public interface IMapLoader
    {
        byte PercentageComplete { get; }

        // ITile[,,] LoadFullMap();
        ITile[,,] Load(int fromSectorX, int toSectorX, int fromSectorY, int toSectorY, byte fromSectorZ, byte toSectorZ);

        bool HasLoaded(int x, int y, byte z);
    }
}