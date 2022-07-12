Imports System.IO
Public Class Form1
    Dim time As DateTime
    Dim i As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = My.Resources._7
        Me.Show()

        salutation()
        Try
            Process.Start("mood.exe")
        Catch ex As Exception

        End Try
        i = 0
    End Sub


    Dim fileReader As String

    Dim voice As String
    Public Sub speach(voice)
        Dim SAPI
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Speak(voice)
    End Sub

    '''les diffrentes taches 

    Private Sub stream()
        If (Not (RecCommand() = "")) Then
            speach("Process d'ouverture des sessions stream ")
            Dim twitch As String = "https://www.twitch.tv/"
            Dim dropdaz As String = "https://dropdaz.com/store/"
            Process.Start(twitch)
            Process.Start(dropdaz)
        End If

    End Sub




    Public Sub rech()
        Dim o As Integer
        o = 3
        rm()
        While (o < 4)
            If (Not (RecCommand() = "")) Then
                o = 5
            End If
            Threading.Thread.Sleep(3000)
        End While
        If (Not (RecCommand() = "")) Then
            speach("Recherche de " + RecCommand())
            Dim requete As String = "https://www.google.fr/search?q=" + RecCommand()
            Process.Start(requete)
        End If

    End Sub

    'A prpos de l'assistant
    Public Sub info()
        Form2.show()
    End Sub


    'Ouverture application
    Function overturapk() As String
        boucle()
        If (RecCommand() = "jeu" Or RecCommand() = "steam" Or RecCommand() = "c" Or RecCommand() = "code") Then
            speach("Ouverture de " + RecCommand())
            If (RecCommand() = "jeu" Or RecCommand() = "steam") Then
                Process.Start("C:\Program Files (x86)\Steam\steam.exe")
            ElseIf (RecCommand() = "c") Then
                Process.Start("C:\Program Files\CodeBlocks\codeblocks.exe")
            ElseIf (RecCommand() = "code") Then
                Process.Start("C:\Users\DELL\AppData\Local\Programs\Microsoft VS Code\Code.exe")

            ElseIf (RecCommand() = "chrome") Then
                Process.Start("C:\Program Files\Google\Chrome\Application\chrome.exe")
            End If
        End If
    End Function


    'fermeture application
    Function fermapk()
        Threading.Thread.Sleep(10000)
        If (Not (RecCommand() = "")) Then
            For Each p As Process In Process.GetProcessesByName(RecCommand())
                p.CloseMainWindow()
            Next
        End If
    End Function

    'Gestion des dossiers

    Function boucle() As String
        Dim o As Integer
        o = 3
        While (o < 4)

            If (Not (RecCommand() = "")) Then
                o = 5
            End If
            Threading.Thread.Sleep(3000)
        End While
        Return RecCommand()
    End Function


    Function Fold()
        Dim pth, ajou, filecopy, filepast As String
        Dim p, ry, aq As String
        Dim i As Integer
        i = 1
        speach("Ouverture du gestionnaire de fichier")
        Threading.Thread.Sleep(2000)
        speach("Quel dossier Ouvrir")
        rm()
        Dim o As Integer
        o = 3
        While (o < 4)

            If (Not (RecCommand() = "")) Then
                o = 5
            End If
            Threading.Thread.Sleep(3000)
        End While
        If (Not (RecCommand() = "")) Then
            If (RecCommand() = "bureau") Then
                Process.Start("C:\Users\DELL\Desktop\")
                speach("overture du dossier bureau")
                pth = "C:\Users\DELL\Desktop\"
                i = 2
            ElseIf (RecCommand() = "disque local") Then
                Process.Start("C:\")
                speach("overture du dossier disque local")
                pth = "C:\"
                i = 2
            ElseIf (RecCommand() = "document") Then
                Process.Start("C:\Users\DELL\Documents")
                speach("overture du dossier document")
                pth = "C:\Users\DELL\Documents"
                i = 2
            End If
            rm()
        End If
        Threading.Thread.Sleep(8000)
        If (i = 2) Then

            o = 3
            While (o < 4)
                If (Not (RecCommand() = "")) Then
                    o = 5
                End If
                Threading.Thread.Sleep(3000)
            End While
            If (Not (RecCommand() = "")) Then
                If (RecCommand() = "liste") Then
                    For Each file As String In IO.Directory.GetFiles(pth)
                        Dim pa As String
                        pa = file.Substring(file.LastIndexOf("\"))
                        speach(pa)
                        Threading.Thread.Sleep(3000)
                    Next
                    rm()
                ElseIf (RecCommand() = "copie") Then
                    speach("Quelle fichier dois je copier ?")
                    rm()

                    o = 3
                    While (o < 4)
                        If (Not (RecCommand() = "")) Then
                            o = 5
                        End If
                        Threading.Thread.Sleep(3000)
                    End While
                    Dim dt As Integer
                    dt = 2
                    If (Not (RecCommand() = "")) Then
                        For Each file As String In IO.Directory.GetFiles(pth)
                            Dim dr As New IO.FileInfo(file)
                            If (dt = 2) Then

                                p = dr.Name
                                aq = p
                                Try
                                    p = p.Trim().Remove(p.Length - 4)
                                Catch ex As Exception

                                End Try
                            End If


                            If (p = RecCommand()) Then
                                i = 0
                                filecopy = pth + "\" + aq
                                dt = 0
                            End If

                        Next
                        If (Not (i = 0)) Then

                            speach("Fichier non trouver")
                            rm()
                        Else
                            speach("Le fichier a été sélectioné")
                        End If
                        rm()
                    End If

                    If (i = 0) Then
                        Threading.Thread.Sleep(2000)
                        speach("Ou voulez vous coller ce fichier ")
                        o = 3
                        While (o < 4)
                            If (Not (RecCommand() = "")) Then
                                o = 5
                            End If
                            Threading.Thread.Sleep(3000)
                        End While
                        filepast = ""
                        If (Not (RecCommand() = "")) Then
                            If (RecCommand() = "bureau") Then
                                filepast = "C:\Users\DELL\Desktop"
                            ElseIf (RecCommand() = "disque local") Then
                                filepast = "C:"
                            ElseIf (RecCommand() = "document") Then
                                filepast = "C:\Users\DELL\Documents"
                            End If
                            rm()
                        End If

                        If (Not (filepast = "")) Then
                            Dim cp As String = filepast + "\" + aq
                            Try
                                File.Copy(filecopy, cp, True)
                                speach("Fichier Copier avec succes")
                            Catch ex As Exception
                                speach("Echec de l'operation de copie")
                            End Try
                        Else
                            filepast = ""
                            speach("Erreur lors de la copie du fichier")
                        End If


                    End If
                    rm()
                End If
            End If
        End If
        rm()
    End Function






    '''Fin des taches

    Dim val As String
    Private Sub com(val)
        If (val = "stream") Then
            stream()
            rm()
        ElseIf (val = "recherche") Then
            speach("Que voulez vous recherché")
            rech()
        ElseIf (val = "information" Or val = "informations") Then
            info()
        ElseIf (val = "ouverture application") Then
            speach("Quelle Application souhaitez vous ouvrir")
            overturapk()
        ElseIf (val = "fermeture application") Then
            speach("Quelle Application souhaitez vous fermer")
            fermapk()
        ElseIf (val = "masquer le processus") Then
            speach("Chargement de la mise en arrière plan ")
            Me.Hide()
        ElseIf (val = "fermeture") Then
            speach("fermeture de l'application")
            Me.Close()
        ElseIf (val = "fichier") Then
            Fold()
        ElseIf (val = "verrouillage") Then
            Me.Hide()
            Form3.Show()
        ElseIf (val = "Bonjour") Then
            speach("Bonjour Yamine")

        End If
        rm()
    End Sub


    'Suppression fichier txt
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

    Public Sub salutation()


        If (time.Hour <= 12) Then
            speach("Bonjour, Je vous souhaite la bienvenue parmi nous. Il me faudra sans doute quelques minutes pour vous adapter les ressources , Mais grace a mon automatisation integre je peut prendre en charge vos demandes tout en configurant les ressources .
                    je suis a l'ecoute  ? ")
        ElseIf (time.Hour >= 12 <= 16) Then
            speach("Bon apres midi , Je vous souhaite la bienvenue parmi nous. Il me faudra sans doute quelques minutes pour vous adapter les ressources , Mais grace a mon automatisation integre je peut prendre en charge vos demandes tout en configurant les ressources .
                    je suis a l'ecoute  ?")
        Else
            speach("Bonsoir , Je vous souhaite la bienvenue parmi nous. Il me faudra sans doute quelques minutes pour vous adapter les ressources , Mais grace a mon automatisation integre je peut prendre en charge vos demandes tout en configurant les ressources .
                    je suis a l'ecoute ?")
        End If
    End Sub

    Dim Anc, nouv As String

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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        verif()
    End Sub
End Class
