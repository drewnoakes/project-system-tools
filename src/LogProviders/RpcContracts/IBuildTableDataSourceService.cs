﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.VisualStudio.ProjectSystem.LogModel;

namespace Microsoft.VisualStudio.ProjectSystem.Tools.Providers.RpcContracts
{
    public interface IBuildTableDataSourceService
    {
        /// <summary>
        /// Returns whether or not the build logging window is currently tracking logs or not
        /// </summary>
        /// <returns>True if build logging window is tracking logs and false otherwise</returns>
        Task<bool> IsLogging();

        /// <summary>
        /// Tell build logging to start tracking logs
        /// </summary>
        /// <returns>True is operation succeeded and false if not</returns>
        Task<bool> Start();  // Should this be void return type?

        /// <summary>
        /// Tell build logging to stop tracking logs
        /// </summary>
        /// <returns>True if operation succeeded and false if not</returns>
        Task<bool> Stop();  // Should this be void return type?

        /// <summary>
        /// Tell build logging to clear out all the accumulated logs from the build logging window
        /// </summary>
        /// <returns>True if operation succeeded and false if not</returns>
        Task<bool> Clear();  // Would it be a good idea to have this? Technically the client could probably handle that logic and just clear the UI

        /// <summary>
        /// Send a notification through that a build has started
        /// </summary>
        /// <returns>A handle that the user can use to retrieve the given build</returns>
        Task<BuildHandle> NotifyBuildStart();

        /// <summary>
        /// Send a notification through that a build has finished
        /// </summary>
        /// <returns>True if operation succeeded and false if not</returns>
        Task<bool> NotifyBuildFinished();  // Should this be void return type?

        /// <summary>
        /// Gives the user a log of a requested build
        /// </summary>
        /// <param name="handle">an ID (type BuildHandle) used to retrieve a unique log for a build</param>
        /// <returns>The log tied to the requested BuildHandle</returns>
        Task<Log> RetrieveLogForBuild(BuildHandle handle);

        /// <summary>
        /// Gives the user a requested build
        /// </summary>
        /// <param name="handle">an ID (type BuildHandle) used to retrieve a unique build</param>
        /// <returns>The Build tied to the requested BuildHandle</returns>
        Task<Build> RetrieveBuild(BuildHandle handle);
    }
}
