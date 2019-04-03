Public Class FormScanTilVisual
    '********************************
    'ScanTilVisual - Skal anvede en tekstfil oprettet af en arduino til
    '
    'Krav:
    '
    'Af: Mads Daugaard - April 2019
    '*********************************

    Const xStart As Integer = 100
    Const yStart As Integer = 100

    Const aScanx As Integer = 10 'antallet af scans
    Const aScany As Integer = 10

    Const pixelSize As Integer = 25
    Dim pixels(aScanx, aScany) As PictureBox

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Dim n As Integer = 0
    Sub tegnFelter()
        For y As Integer = 0 To aScanx
            For x As Integer = 0 To aScany
                pixels(x, y) = New PictureBox
                pixels(x, y).Size = New System.Drawing.Size(pixelSize, pixelSize)
                pixels(x, y).Location = New System.Drawing.Point(xStart + x * pixelSize, yStart + y * pixelSize)

                Me.Controls.Add(Me.pixels(x, y))

                If n = 0 Then
                    pixels(x, y).BackColor = Color.Black
                    n = n + 1
                Else
                    pixels(x, y).BackColor = Color.White
                    n = 0
                End If
                'If x Mod 2 = 0 Then

                '    
                'Else
                '   
                'End If
            Next
        Next

    End Sub

    Private Sub ButtonTegn_Click(sender As Object, e As EventArgs) Handles ButtonTegn.Click
        tegnFelter()
    End Sub
End Class
