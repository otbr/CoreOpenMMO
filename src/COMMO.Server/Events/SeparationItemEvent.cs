// <copyright file="SeparationItemEvent.cs" company="2Dudes">
// Copyright (c) 2018 2Dudes. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using COMMO.Data.Contracts;

namespace COMMO.Server.Events
{
    internal class SeparationItemEvent : BaseItemEvent
    {
        public ushort ThingIdOfSeparation { get; }

        public SeparationItemEvent(IList<string> conditionSet, IList<string> actionSet)
            : base(conditionSet, actionSet)
        {
            var isTypeCondition = Conditions.FirstOrDefault(func => IsTypeFunctionName.Equals(func.FunctionName));

            if (isTypeCondition == null)
            {
                throw new ArgumentNullException($"Unable to find {IsTypeFunctionName} function.");
            }

            ThingIdOfSeparation = Convert.ToUInt16(isTypeCondition.Parameters[1]);
        }

        public override ItemEventType Type => ItemEventType.Separation;
    }
}