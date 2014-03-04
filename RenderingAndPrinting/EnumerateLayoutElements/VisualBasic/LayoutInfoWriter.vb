' Copyright (c) 2001-2014 Aspose Pty Ltd. All Rights Reserved.

Imports Microsoft.VisualBasic
Imports System

Imports Aspose.Words.Layout

Namespace EnumerateLayoutElements
	Friend Class LayoutInfoWriter
		Public Shared Sub Run(ByVal it As LayoutEnumerator)
			DisplayLayoutElements(it, String.Empty)
		End Sub

		''' <summary>
		''' Enumerates forward through each layout element in the document and prints out details of each element. 
		''' </summary>
		Private Shared Sub DisplayLayoutElements(ByVal it As LayoutEnumerator, ByVal padding As String)
			Do
				DisplayEntityInfo(it, padding)

				If it.MoveFirstChild() Then
					' Recurse into this child element.
					DisplayLayoutElements(it, AddPadding(padding))
					it.MoveParent()
				End If
			Loop While it.MoveNext()
		End Sub

		''' <summary>
		''' Displays information about the current layout entity to the console.
		''' </summary>
		Private Shared Sub DisplayEntityInfo(ByVal it As LayoutEnumerator, ByVal padding As String)
			Console.Write(padding & it.Type & " - " & it.Kind)

			If it.Type = LayoutEntityType.Span Then
				Console.Write(" - " & it.Text)
			End If

			Console.WriteLine()
		End Sub

		''' <summary>
		''' Returns a string of spaces for padding purposes.
		''' </summary>
		Private Shared Function AddPadding(ByVal padding As String) As String
			Return padding & New String(" "c, 4)
		End Function
	End Class
End Namespace
