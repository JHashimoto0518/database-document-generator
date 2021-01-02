Imports System
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Excel

Public Class MacroExecutor
	Public Sub Execute(ByVal filePath As String, ByVal macroName As String)
		Dim application As Application = Nothing
		Dim workbooks As Workbooks = Nothing
		Dim workbook As Workbook = Nothing

		Try
			application = New ApplicationClass
			workbooks = application.Workbooks
			workbook = workbooks.Open(filePath)
			application.Run(macroName)
		Finally
			If workbook IsNot Nothing Then
				Try
					workbook.Close(True)
				Catch
				End Try
			End If

			If application IsNot Nothing Then
				Try
					application.Quit()
				Catch
				End Try
			End If

			ReleaseComObjects(workbook, workbooks, application)
		End Try

	End Sub

	Private Sub ReleaseComObjects(ByVal ParamArray objects As Object())
		Try
			For i As Integer = 0 To objects.Length
				If objects(i) Is Nothing Then
					Continue For
				End If

				If Marshal.IsComObject(objects(i)) = False Then
					Continue For
				End If

				Marshal.ReleaseComObject(objects(i))
			Next
		Catch
		End Try
	End Sub
End Class
