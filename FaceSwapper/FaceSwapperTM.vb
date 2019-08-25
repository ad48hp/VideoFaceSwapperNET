Public MustInherit Class FaceSwapperTM
    Public MustOverride Sub Prepare()
    Public MustOverride Function Process(ByVal img1 As Bitmap, ByVal img2 As Bitmap) As Bitmap

    Public Errors As New List(Of Exception)

    Public Sub PushToErrors(ex As Exception)
        Errors.Add(ex)
    End Sub

    Public Sub ProgressČengd()
        curprogrezz += 1
        ProgressČenžedd(curprogrezz, totalprogrezz)
    End Sub

    Public ProgressČenžedd As Action(Of Integer, Integer)

    Public curprogrezz As Integer
    Public MustOverride ReadOnly Property totalprogrezz As Integer
End Class
