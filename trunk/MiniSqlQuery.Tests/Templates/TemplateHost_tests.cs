using System;
using MiniSqlQuery.Core;
using MiniSqlQuery.PlugIns.TemplateViewer;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace MiniSqlQuery.Tests.Templates
{
	[TestFixture]
	public class TemplateHost_tests
	{
		private TemplateHost _host;
		IApplicationServices _services;
		IDatabaseInspector _databaseInspector;

		[SetUp]
		public void TestSetUp()
		{
			_services = MockRepository.GenerateStub<IApplicationServices>();
			_databaseInspector = MockRepository.GenerateStub<IDatabaseInspector>();
			_host = new TemplateHost(_services, _databaseInspector);
		}

		[Test]
		public void UserName()
		{
			Assert.That(_host.UserName, Is.Not.Null);
		}

		[Test]
		public void ToPascalCase()
		{
			Assert.That(_host.ToPascalCase(null), Is.EqualTo(""));
			Assert.That(_host.ToPascalCase("name"), Is.EqualTo("Name"));
			Assert.That(_host.ToPascalCase("foo baa"), Is.EqualTo("FooBaa"));
		}

		[Test]
		public void ToCamelCase()
		{
			Assert.That(_host.ToCamelCase(null), Is.EqualTo(""));
			Assert.That(_host.ToCamelCase("name"), Is.EqualTo("name"));
			Assert.That(_host.ToCamelCase("Foo"), Is.EqualTo("foo"));
			Assert.That(_host.ToCamelCase("bat man"), Is.EqualTo("batMan"));
		}
	}
}