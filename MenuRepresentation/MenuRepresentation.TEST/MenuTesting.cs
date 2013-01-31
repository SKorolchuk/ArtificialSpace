using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuRepresentation.TEST
{
	using MenuRepresentation.DOMAIN.MenuDOM.Model;

	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class MenuTesting
	{
		public MenuTesting()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void CreationalTest()
		{
			Menu menu = new Menu(XDocument.Load("Menu.xml"));
		}

		[TestMethod]
		public void BehavioralTest()
		{
			Menu menu = new Menu(XDocument.Load("Menu.xml"));
			Assert.IsTrue(menu.CurrentMenuLevel == menu);
			var pushingItem = menu.NestedItems[0];
			menu.Push(pushingItem);
			Assert.IsTrue(menu.CurrentMenuLevel == pushingItem);
			menu.Prev();
			Assert.IsTrue(menu.CurrentMenuLevel == menu);
		}
	}
}
