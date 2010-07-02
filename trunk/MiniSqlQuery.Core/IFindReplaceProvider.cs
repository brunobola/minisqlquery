﻿#region License

// Copyright 2005-2009 Paul Kohler (http://pksoftware.net/MiniSqlQuery/). All rights reserved.
// This source code is made available under the terms of the Microsoft Public License (Ms-PL)
// http://minisqlquery.codeplex.com/license
#endregion

using System;

namespace MiniSqlQuery.Core
{
	/// <summary>A control that allows its text to be "found" and optionally "replaced".
	/// The query editor is an obvious provider but other windows can also provide
	/// find/replace functionality by implementing this interface (tools, output windows etc).</summary>
	public interface IFindReplaceProvider : ISupportCursorOffset
	{
		/// <summary>True if the text can be replaced, otherwise false.</summary>
		/// <value>The can replace text.</value>
		bool CanReplaceText { get; }

		/// <summary>A text finding service.</summary>
		/// <seealso cref="SetTextFindService"/>
		/// <value>The text find service.</value>
		ITextFindService TextFindService { get; }

		/// <summary>Attemps to find <paramref name="value"/> in the controls text.</summary>
		/// <param name="value"></param>
		/// <param name="startIndex"></param>
		/// <param name="comparisonType"></param>
		/// <returns>The find string.</returns>
		int FindString(string value, int startIndex, StringComparison comparisonType);

		/// <summary>Replaces the text from <paramref name="startIndex"/> for <paramref name="length"/> characters 
		/// with <paramref name="value"/>.</summary>
		/// <param name="value">The new string.</param>
		/// <param name="startIndex">the starting position.</param>
		/// <param name="length">The length (0 implies an insert).</param>
		/// <returns>True if successful, otherwise false.</returns>
		/// <seealso cref="CanReplaceText"/>
		bool ReplaceString(string value, int startIndex, int length);

		/// <summary>Overrides the default text find service with <paramref name="textFindService"/> (e.g. a RegEx service).</summary>
		/// <param name="textFindService">The service to use.</param>
		void SetTextFindService(ITextFindService textFindService);
	}
}