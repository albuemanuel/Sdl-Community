﻿using System.Windows;
using System.Windows.Forms;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Application = System.Windows.Application;

namespace Sdl.Community.Reports.Viewer
{
	[ApplicationInitializer]
	internal class ApplicationInstance : IApplicationInitializer
	{	
		public void Execute()
		{
			SetApplicationShutdownMode();
		}

		public static Form GetActiveForm()
		{
			var allForms = System.Windows.Forms.Application.OpenForms;
			var activeForm = allForms[allForms.Count - 1];
			foreach (Form form in allForms)
			{
				if (form.GetType().Name == "StudioWindowForm")
				{
					activeForm = form;
					break;
				}
			}

			return activeForm;
		}

		private static void SetApplicationShutdownMode()
		{
			if (Application.Current == null)
			{
				// initialize the environments application instance
				new Application();
			}

			if (Application.Current != null)
			{
				Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
			}
		}
	}
}
