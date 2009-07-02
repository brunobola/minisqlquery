using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniSqlQuery.Core
{
	/// <summary>
	/// Represents a "command", typically a user action such as saving a file or executing a query.
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// Executes the command based on the current settings.
		/// </summary>
		/// <remarks>
		/// If a commands <see cref="Enabled"/> value is false, a call to <see cref="Execute"/> should have no effect
		/// (and not throw an exception).
		/// </remarks>
		void Execute();

		/// <summary>
		/// The name of the command, used in menus and buttons.
		/// </summary>
		/// <value>The name of the command.</value>
		string Name
		{
			get;
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="ICommand"/> is enabled.
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		bool Enabled { get; }

		/// <summary>
		/// Gets the "small image" associated with this control (for use on buttons or menu items).
		/// Use null (or Nothing in Visual Basic) if there is no image.
		/// </summary>
		/// <value>The small image representing this command (or null for none).</value>
		Image SmallImage { get; }

		/// <summary>
		/// Gets the menu shortcut keys for this command (e.g. Keys.F5).
		/// </summary>
		/// <value>The shortcut keys for this command.</value>
		Keys ShortcutKeys { get; }

		/// <summary>
		/// A reference to the application services to allow access to the other components.
		/// </summary>
		/// <value>A reference to the <see cref="IApplicationServices"/> instance.</value>
		IApplicationServices Services { get; set; }
	}
}