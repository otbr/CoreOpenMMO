// <copyright file="Program.cs" company="2Dudes">
// Copyright (c) 2018 2Dudes. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

using COMMO.Communications;
using COMMO.Communications.Interfaces;
using COMMO.Server.Events;
using COMMO.Server.Handlers;
using COMMO.Server.Handlers.Management;
using COMMO.Server.Items;
using COMMO.Server.Monsters;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace COMMO.Server.Standalone
{
    public class Program
    {
        private static IOpenTibiaListener _loginListener;
        private static IOpenTibiaListener _gameListener;

        // private static IOpenTibiaListener managementListener;
        static void Main()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            // Set the loaders to use.
            Game.Instance.Initialize(new MoveUseItemEventLoader(), new ObjectsFileItemLoader(), new MonFilesMonsterLoader());

            // TODO: load and validate external aux files.

            // Set the persistence storage source (database)

            // Initilize client listening pipeline (but reject game connections)
            _loginListener = new LoginListener(new ManagementHandlerFactory(), 7171);
            _gameListener = new GameListener(new GameHandlerFactory(), 7172);
            // managementListener = new ManagementListener(new ManagementHandlerFactory());
            var listeningTask = RunAsync(cancellationTokenSource.Token);

            // Initilize game
            Game.Instance.Begin(cancellationTokenSource.Token);

            // TODO: open up game connections
            listeningTask.Wait(cancellationTokenSource.Token);
        }

        private static async Task RunAsync(CancellationToken cancellationToken)
        {
            _loginListener.BeginListening();
            // managementListener.BeginListening();
            _gameListener.BeginListening();

            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
    }
}
