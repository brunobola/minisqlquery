﻿using System;
using System.IO;
using System.Windows.Forms;
using MiniSqlQuery.Core;
using MiniSqlQuery.PlugIns.TemplateViewer.Commands;
using WeifenLuo.WinFormsUI.Docking;

namespace MiniSqlQuery.PlugIns.TemplateViewer
{
	public partial class TemplateViewForm : DockContent
	{
		private readonly IApplicationServices _services;
		private readonly TemplateModel _model;

		public TemplateViewForm(IApplicationServices services, TemplateModel model)
		{
			InitializeComponent();
			_services = services;
			_model = model;
		}

		private void TemplateViewForm_Load(object sender, EventArgs e)
		{
			tvTemplates.Nodes[0].Nodes.AddRange(_model.CreateNodes());
			tvTemplates.Nodes[0].Expand();
		}

		private void tvTemplates_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e != null && e.Node != null)
			{
				FileInfo fi = e.Node.Tag as FileInfo;
				if (fi != null)
				{
					new NewQueryByTemplateCommand().Execute();
					IQueryEditor editor = (IQueryEditor) ApplicationServices.Instance.HostWindow.ActiveChildForm;
					string template = _model.ProcessTemplateFile(fi.FullName);
					editor.AllText = template;
				}
			}
		}
	}
}