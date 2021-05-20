﻿using System.Windows;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;

namespace Sdl.Community.SDLBatchAnonymize
{
	[ApplicationInitializer]
	public class AppInitializer : IApplicationInitializer
	{
		public void Execute()
		{
			Log.Setup();

			if (Application.Current == null)
			{
				new Application();
			}
		}
	}
}