﻿using System.Collections.Generic;
using System.ComponentModel;
using Sdl.Community.ExportAnalysisReports.Model;
using Sdl.ProjectAutomation.Core;

namespace Sdl.Community.ExportAnalysisReports.Interfaces
{
	public interface IStudioService
	{
		string GetStudioProjectsPath();
		ProjectInfo GetProjectInfo(string projectPath);
		void SetLanguagesForProject(ProjectDetails project, Dictionary<string, LanguageDirection> languages);

		BindingList<ProjectDetails> BindProjects(List<ProjectDetails> projects, BindingList<ProjectDetails> projectsBindingList);
	}
}
