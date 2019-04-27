Public Class FormScanTilVisual
    '********************************
    'ScanTilVisual - Skal anvede en tekstfil med data til at vise data grafisk
    '
    'Af: Mads Daugaard - April 2019
    '*********************************

    Const xStart As Integer = 100 'forskydning x
    Const yStart As Integer = 100 'forskydning y

    Const aScanx As Integer = 32 'antallet af scans x
    Const aScany As Integer = 40 'antallet af scans y

    Const pixelSize As Integer = 10
    Dim pixels(aScanx - 1, aScany - 1) As PictureBox
    Dim farve(aScanx - 1, aScany - 1)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For y As Integer = 0 To aScany - 1
            For x As Integer = 0 To aScanx - 1
                pixels(x, y) = New PictureBox
                pixels(x, y).Size = New System.Drawing.Size(pixelSize, pixelSize)
                pixels(x, y).Location = New System.Drawing.Point(xStart + x * pixelSize, yStart + y * pixelSize)

                Me.Controls.Add(Me.pixels(x, y))



            Next
        Next
    End Sub


    Sub tegnFelter()
        For y As Integer = 0 To aScany - 1
            For x As Integer = 0 To aScanx - 1

                If farve(x, y) = 1 Then
                    pixels(x, y).BackColor = Color.Black

                Else
                    pixels(x, y).BackColor = Color.White

                End If

            Next
        Next

    End Sub

    Sub gemFarve()
        Dim scan As String
        Dim sti As String

        'åbner fil dialog, så der kan vælges en sti
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        dialog.SelectedPath = "C:\" 'drev
        dialog.Description = "Vælg filen som skal vises" 'forklaring
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Der er valgt en sti til mappen og den gemmes
            sti = dialog.SelectedPath
        End If

        scan = My.Computer.FileSystem.ReadAllText(sti & "\" & TextBoxInput.Text & ".txt")
        MsgBox(scan)
        scan = scan.Replace(" ", "")
        MsgBox(scan)
        scan = scan.Replace(vbLf, "").Replace(vbCr, "") 'fjerner mellemrum og linje skift
        MsgBox(scan)



        For y As Integer = 1 To aScany
            For x As Integer = 1 To aScanx
                farve(x - 1, y - 1) = Mid(scan, (x + (y - 1) * aScanx), 1)
            Next
        Next
    End Sub

    Private Sub ButtonTegn_Click(sender As Object, e As EventArgs) Handles ButtonTegn.Click
        Try
            gemFarve()

            Dim str As String = ""
            For y As Integer = 0 To aScany - 1
                For x As Integer = 0 To aScanx - 1
                    str = str + farve(x, y)
                Next
                str = str & vbNewLine
            Next
            MsgBox(str)

            tegnFelter()
        Catch ex As Exception
            MsgBox("Filen kunne ikke findes")
        End Try

    End Sub
End Class
