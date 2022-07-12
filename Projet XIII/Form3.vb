Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer

    Const SWP_HIDEWINDOW = &H80
    Const SWP_SHOWWINDOW = &H40


    Dim TaskBarHwnd As Integer
    Dim t As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        Me.ControlBox = False
        TaskBarHwnd = FindWindow("Shell_traywnd", "")

        Me.StartPosition = FormStartPosition.Manual
        Me.Left = 0
        Me.Top = 0
        Me.Height = Screen.PrimaryScreen.Bounds.Height - 1
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        SetWindowPos(TaskBarHwnd, 0&, 0&, 0&, 0&, 0&, SWP_HIDEWINDOW)
        TextBox1.UseSystemPasswordChar = True
        Label2.Hide()
        t = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (TextBox1.Text = "hackermood13") Then
            Label1.BackColor = Color.Green
            Threading.Thread.Sleep(3000)
            Me.Close()
            Form1.Show()
        Else
            Label1.BackColor = Color.Red
            t = t + 1
        End If

        If (t = 3) Then
            Label2.Show()
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class