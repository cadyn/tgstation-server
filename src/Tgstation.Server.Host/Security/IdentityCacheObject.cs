﻿using System;
using System.Threading;
using System.Threading.Tasks;

using Tgstation.Server.Host.Utils;

namespace Tgstation.Server.Host.Security
{
	/// <summary>
	/// For keeping a specific <see cref="ISystemIdentity"/> alive for a period of time.
	/// </summary>
	sealed class IdentityCacheObject : IAsyncDisposable
	{
		/// <summary>
		/// The <see cref="ISystemIdentity"/> the <see cref="IdentityCache"/> manages.
		/// </summary>
		public ISystemIdentity SystemIdentity { get; }

		/// <summary>
		/// The <see cref="cancellationTokenSource"/> for the <see cref="IdentityCache"/>.
		/// </summary>
		readonly CancellationTokenSource cancellationTokenSource;

		/// <summary>
		/// The <see cref="Task"/> to clean up <see cref="SystemIdentity"/>.
		/// </summary>
		readonly Task task;

		/// <summary>
		/// Initializes a new instance of the <see cref="IdentityCacheObject"/> class.
		/// </summary>
		/// <param name="systemIdentity">The value of <see cref="SystemIdentity"/>.</param>
		/// <param name="asyncDelayer">The <see cref="IAsyncDelayer"/> used to delay the expiry.</param>
		/// <param name="onExpiry">The <see cref="Action"/> to take on expiry.</param>
		/// <param name="expiry">The <see cref="DateTimeOffset"/>.</param>
		public IdentityCacheObject(ISystemIdentity systemIdentity, IAsyncDelayer asyncDelayer, Action onExpiry, DateTimeOffset expiry)
		{
			SystemIdentity = systemIdentity ?? throw new ArgumentNullException(nameof(systemIdentity));

			ArgumentNullException.ThrowIfNull(asyncDelayer);

			ArgumentNullException.ThrowIfNull(onExpiry);
			var now = DateTimeOffset.UtcNow;
			if (expiry < now)
				throw new ArgumentOutOfRangeException(nameof(expiry), expiry, "expiry must be greater than DateTimeOffset.UtcNow!");

			cancellationTokenSource = new CancellationTokenSource();

			async Task DisposeOnExipiry(CancellationToken cancellationToken)
			{
				using (SystemIdentity)
					try
					{
						await asyncDelayer.Delay(expiry - now, cancellationToken);
					}
					catch (OperationCanceledException)
					{
					}
					finally
					{
						onExpiry();
					}
			}

			task = DisposeOnExipiry(cancellationTokenSource.Token);
		}

		/// <inheritdoc />
		public async ValueTask DisposeAsync()
		{
			cancellationTokenSource.Cancel();
			cancellationTokenSource.Dispose();
			await task;
		}
	}
}
