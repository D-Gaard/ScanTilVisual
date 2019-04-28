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
    Dim pixels(aScanx - 1, aScany - 1) As PictureBox 'array til visning af scan
    Dim farve(aScanx - 1, aScany - 1)  'array til at holde farve strengen

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'opretter alle picturboxes ved load
        For y As Integer = 0 To aScany - 1
            'lopper genne arayets y
            For x As Integer = 0 To aScanx - 1
                'looper gennem arrayets x

                'Opretter en ny picturebox og giver den dens atributter 
                pixels(x, y) = New PictureBox
                pixels(x, y).Size = New System.Drawing.Size(pixelSize, pixelSize)
                pixels(x, y).Location = New System.Drawing.Point(xStart + x * pixelSize, yStart + y * pixelSize)
                Me.Controls.Add(Me.pixels(x, y))

            Next
        Next
    End Sub


    Sub tegnFelter()
        'farver pictureboxesne
        For y As Integer = 0 To aScany - 1
            'looper y
            For x As Integer = 0 To aScanx - 1
                'looper x

                'undersøger om farve arrayet indeholder 1 eller 0
                If farve(x, y) = 1 Then
                    '1 -> stort
                    pixels(x, y).BackColor = Color.Black

                Else
                    '0-> hvid
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

        scan = My.Computer.FileSystem.ReadAllText(sti & "\" & TextBoxInput.Text & ".txt") 'læser filen ud fra sti og tekstboks input
        scan = scan.Replace(" ", "") 'fjerner mellemrum
        scan = scan.Replace(vbLf, "").Replace(vbCr, "") 'fjerner mellemrum og linje skift

        'indlæser farve
        For y As Integer = 1 To aScany
            'looper y
            For x As Integer = 1 To aScanx
                'looper x
                farve(x - 1, y - 1) = Mid(scan, (x + (y - 1) * aScanx), 1) 'udregner positionen fra teksten og inputter den i farve arrayet
            Next
        Next
    End Sub

    Private Sub ButtonTegn_Click(sender As Object, e As EventArgs) Handles ButtonTegn.Click
        'når der klikkes på knappen

        Try
            'forsøger at indlæse fil og vise den

            gemFarve() 'læser fil og farve

            'viser hvordan strengen ser ud
            Dim str As String = ""
            For y As Integer = 0 To aScany - 1
                For x As Integer = 0 To aScanx - 1
                    str = str + farve(x, y)
                Next
                str = str & vbNewLine
            Next
            MsgBox(str)

            tegnFelter() 'optegner de korrekte farve
        Catch ex As Exception
            'der blev valgt en ulæselig fil og det fortælles til brugeren
            MsgBox("Filen kunne ikke findes")
        End Try

    End Sub
End Class
