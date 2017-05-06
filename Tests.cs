using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		// App is already instantiated before each Test in the above [SetUp] method

		// Screenshots can be used to break tests up into "steps". Can view them
		// after the test run to make sure the screen looks correct at each point.

		// All tests are currently subject to lack of proper internet connection to the server but all work currently

		[Test]
		public void AppLaunchesTest()
		{
			//test to check app launches correctly and logs in with dummy user Louis' credentials
			/* Act */
			app.EnterText(c => c.Marked("User name"), "Louis");
			app.EnterText(c => c.Marked("Password"), "dfhgwbfngg");
			app.Screenshot("Inputting login credentials");
			app.Tap("Log in");
			;
		}

		[Test]
		public void BrowseMenuPagesTest()
		{
			// test to check all menu pages are traversible
			/* Act */
			app.EnterText(c => c.Marked("User name"), "Louis");
			app.EnterText(c => c.Marked("Password"), "dfhgwbfngg");
			app.Tap("Log in");
			app.Tap("Account");
			app.Screenshot("Viewing account page");
			app.Back();
			app.Tap("Questions");
			app.Screenshot("Viewing empty questions page");
			app.Back();
			app.Tap("Groups");
			app.Screenshot("Viewing empty groups page");
			app.Back();
			;
		}

		[Test]
		public void CreateAGroupTest()
		{
			// test to check create a group works 
			/* Act */
			app.EnterText(c => c.Marked("User name"), "Louis");
			app.EnterText(c => c.Marked("Password"), "dfhgwbfngg");
			app.Tap("Log in");
			app.Tap("Groups");
			app.Tap("Create a group");
			app.EnterText(c => c.Marked("Group Name"), "Test");
			app.EnterText(c => c.Marked("Member Count"), "3");
			app.Screenshot("Filled out Create a group form");
			app.Tap("Submit");
			app.Tap("Ok");
			;
		}

		[Test]
		public void CreateAQuestionTest()
		{
			// test to check create a question works
			/* Act */
			app.EnterText(c => c.Marked("User name"), "Louis");
			app.EnterText(c => c.Marked("Password"), "dfhgwbfngg");
			app.Tap("Log in");
			app.Tap("Questions");
			app.Tap("Create a question");
			app.EnterText(c => c.Marked("Example Question"), "Favourite colour?");
			app.EnterText(c => c.Marked("Example Answer 1"), "red");
			app.EnterText(c => c.Marked("Example Answer 2"), "blue");
			app.Screenshot("Filled out Create a question form");
			app.Tap("Submit");
			app.Tap("Ok");
			;
		}

		[Test]
		public void GroupsRefreshTest()
		{
			// test to check the groups page refreshes upon downwards drag
			/* Act */
			app.EnterText(c => c.Marked("User name"), "Louis");
			app.EnterText(c => c.Marked("Password"), "dfhgwbfngg");
			app.Tap("Log in");
			app.Tap("Groups");
			app.DragCoordinates(384, 316, 384, 1000);
			;
		}

		[Test]
		public void QuestionsRefreshTest()
		{
			// test to check the questions page refreshes upon downwards drag
			/* Act */
			app.EnterText(c => c.Marked("User name"), "Louis");
			app.EnterText(c => c.Marked("Password"), "dfhgwbfngg");
			app.Tap("Log in");
			app.Tap("Questions");
			app.DragCoordinates(384, 316, 384, 1000);
			;
		}
	}
}
