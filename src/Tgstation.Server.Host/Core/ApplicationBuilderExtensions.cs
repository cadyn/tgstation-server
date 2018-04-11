﻿using Microsoft.AspNetCore.Builder;

namespace Tgstation.Server.Host.Core
{
	/// <summary>
	/// Extension methods for <see cref="IApplicationBuilder"/>
	/// </summary>
	static class ApplicationBuilderExtensions
	{
		/// <summary>
		/// Apply the <see cref="AuthenticationContext"/> middleware
		/// </summary>
		/// <param name="applicationBuilder">The <paramref name="applicationBuilder"/> to add the middleware for</param>
		/// <returns><paramref name="applicationBuilder"/></returns>
        public static IApplicationBuilder UseAuthentication(this IApplicationBuilder applicationBuilder)
        {
            AuthenticationContext.AddToPipeline(applicationBuilder);
            return applicationBuilder;
        }
	}
}
