Public Class CustomMsgBox
    Public curx As Integer
    Public defsize As Integer = 69
    Public defoffzet As Integer = 12
    Dim defyofffzettt As Integer = 4
    Public Property setto As String

    Public Sub AddToButtonz(ByVal buttonznejm69 As String(), ByVal dzsisezz As Integer(), ByVal dzoffsetzz As Integer())
        For i911 = 1 To buttonznejm69.Length
            Dim mybuutnnn6969 As New Button
            mybuutnnn6969.Location = New Point(curx, defyofffzettt)
            mybuutnnn6969.Size = New Size(dzsisezz(i911 - 1), Panel1.Size.Height - (defyofffzettt * 2))
            mybuutnnn6969.Text = buttonznejm69(i911 - 1)
            mybuutnnn6969.BackColor = Color.White
            mybuutnnn6969.FlatStyle = FlatStyle.Flat
            AddHandler mybuutnnn6969.Click, AddressOf ClickedOn
            Panel1.Controls.Add(mybuutnnn6969)
            curx += dzsisezz(i911 - 1) + dzoffsetzz(i911 - 1)
        Next
    End Sub

    Public Sub AddToButtonz(ByVal buttonznejm69 As String())
        Dim dazzsizz As New List(Of Integer)
        Dim dazzzoffzz As New List(Of Integer)
        For i911 = 1 To buttonznejm69.Length
            dazzsizz.Add(defsize)
            dazzzoffzz.Add(defoffzet)
        Next
        AddToButtonz(buttonznejm69, dazzsizz.ToArray(), dazzzoffzz.ToArray())
    End Sub

    Private Sub ClickedOn(sender As Object, e As EventArgs)
        setto = DirectCast(sender, Button).Text
        Me.Hide()
    End Sub

    Private Sub CustomMsgBox_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        curx = 0
    End Sub
End Class