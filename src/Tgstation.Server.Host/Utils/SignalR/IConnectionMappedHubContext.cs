﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

using Tgstation.Server.Host.Models;
using Tgstation.Server.Host.Security;

namespace Tgstation.Server.Host.Utils.SignalR
{
	/// <summary>
	/// A <see cref="IHubContext{THub}"/> that maps <see cref="User"/>s to their connection IDs.
	/// </summary>
	/// <typeparam name="THub">The <see cref="Hub"/> the <see cref="IConnectionMappedHubContext{THub, THubMethods}"/> is for.</typeparam>
	/// <typeparam name="THubMethods">The interface <see langword="class"/> for implementing <see cref="Hub{T}"/> methods.</typeparam>
	interface IConnectionMappedHubContext<THub, THubMethods> : IHubContext<THub, THubMethods>
		where THub : Hub<THubMethods>
		where THubMethods : class
	{
		/// <summary>
		/// Called when a user connects. Should return an <see cref="IEnumerable{T}"/> of hub group names the given <see cref="IAuthenticationContext"/> belongs in.
		/// </summary>
		event Func<IAuthenticationContext, CancellationToken, ValueTask<IEnumerable<string>>> OnConnectionMapGroups;

		/// <summary>
		/// Gets a <see cref="List{T}"/> of current connection IDs for a given <paramref name="user"/>.
		/// </summary>
		/// <param name="user">The <see cref="User"/> to get connection IDs for.</param>
		/// <returns>A <see cref="List{T}"/> representing the active connection IDs of the <paramref name="user"/>.</returns>
		List<string> UserConnectionIds(User user);

		/// <summary>
		/// Aborts the connections associated with the given <paramref name="user"/>.
		/// </summary>
		/// <param name="user">The <see cref="User"/> to abort the connections of.</param>
		void AbortUnauthedConnections(User user);
	}
}
