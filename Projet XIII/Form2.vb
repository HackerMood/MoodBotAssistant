Imports System.ComponentModel

Public Class Form2
    Dim s As String
    Dim i As Integer

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        speach("Mon nom est " + Label1.Text + "Vous utiliser en ce moment une version " + Label3.Text +
               "J'ai ete concu par l'Organisation Mood 13")
        i = 1

    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form1.Show()
    End Sub

    Dim fileReader, nouv, Anc As String

    Private Sub verif()
        nouv = RecCommand()
        If (i = 1) Then
            com(nouv)
            Anc = nouv
            i = 15
            nouv = ""
        ElseIf (Not (Anc = nouv)) Then
            com(nouv)
            Anc = nouv
            nouv = ""
        End If
    End Sub

    Private Sub com(val)
        If (val = "close") Then
            Me.Close()
        End If
        rm()
    End Sub

    Function rm() As String
        Dim FileToDelete As String

        FileToDelete = "command.txt"

        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
    End Function

    Function RecCommand() As String
        Try
            fileReader = My.Computer.FileSystem.ReadAllText("command.txt")

        Catch ex As Exception
            fileReader = ""
        End Try

        Return fileReader

    End Function

    Function speach(s) As String
        Dim SAPI
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Speak(s)
    End Function



End Class