// <copyright file="IStatementInfo.cs" company="2Dudes">
// Copyright (c) 2018 2Dudes. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;

namespace COMMO.Communications.Packets
{
    internal interface IStatementInfo
    {
        uint Unknown { get; set; }

        uint StatementId { get; set; }

        ushort Count { get; set; }

        IList<Tuple<uint, uint, string, string>> Data { get; set; }
    }
}