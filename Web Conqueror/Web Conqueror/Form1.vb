Imports System.Net
Imports System.IO
Public Class Form1
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        browser.GoBack()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        browser.GoForward()
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        browser.Refresh()
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        browser.GoHome()
    End Sub
    Private Sub ToolStripTextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox1.KeyUp
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        If e.KeyCode = Keys.Enter Then
            browser.Navigate(ToolStripTextBox1.Text)
        End If
    End Sub
    Private Sub ToolStripTextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox2.KeyUp
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        Select Case (ToolStripComboBox1.SelectedIndex)
            Case 0
                If e.KeyCode = Keys.Enter Then
                    browser.Navigate("https://www.google.com.eg/search?q=" + ToolStripTextBox2.Text)
                End If
            Case 1
                If e.KeyCode = Keys.Enter Then
                    browser.Navigate("https://www.youtube.com/results?search_query=" + ToolStripTextBox2.Text)
                End If
            Case 2
                If e.KeyCode = Keys.Enter Then
                    browser.Navigate("https://ar.wikipedia.org/wiki/" + ToolStripTextBox2.Text)
                End If
        End Select
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For Each line As String In history.ListBox1.Items
            File.AppendAllText("C:\Users\Public\Documents\history.txt", line & vbNewLine)
        Next
        For Each bookmarks As String In ListBox1.Items
            File.AppendAllText("C:\Users\Public\Documents\bookmarks.txt", bookmarks & vbNewLine)
        Next
        For Each url As String In ListBox1.Items
            File.AppendAllText("C:\Users\Public\Documents\url.txt", url & vbNewLine)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        WebBrowser1.Navigate("www.google.com")
        ToolStripComboBox1.Items.Add("Google")
        ToolStripComboBox1.Items.Add("Youtube")
        ToolStripComboBox1.Items.Add("Wikibedia")
        ToolStripComboBox1.SelectedIndex = 0
        Dim t As Date = Now
        ToolStripLabel1.Text = t
        Try
            history.Show()
            For Each lines As String In File.ReadLines("C:\Users\Public\Documents\history.txt")
                history.ListBox1.Items.Add(lines.ToString)
            Next
            history.Visible = False
        Catch ex As Exception
        End Try
        Try
            For Each url As String In ("C:\Users\Public\Documents\url.txt")
                ListBox3.Items.Add(url)
            Next
        Catch ex As Exception

        End Try

        Try
            ListBox3.SelectedIndex = 0
        Catch ex As Exception

        End Try


        Try
            For Each name As String In File.ReadAllLines("C:\Users\Public\Documents\bookmarks.txt")
                Dim newbook1s As New ToolStripButton

                newbook1s.Text = name

                newbook1s.Tag = ListBox3.SelectedIndex.ToString
                ToolStrip2.Items.Add(newbook1s)
                ListBox3.SelectedIndex = ListBox3.SelectedIndex + 1
            Next
        Catch ex As Exception

        End Try
        addtab(TabControl1)
        cb()
        history.Hide()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click

        ToolStripTextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click

        ToolStripTextBox1.ClearUndo()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        downloader.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("This programme has been programmed by Essam Mohamed , the owner of ST Systems ((important: if you want to enjoy all our advantages please when the browser loads close tabpage1))")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub FacebookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacebookToolStripMenuItem.Click
        addtab(TabControl1)
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        browser.Navigate("www.facebook.com")
    End Sub

    Private Sub TwitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TwitterToolStripMenuItem.Click
        addtab(TabControl1)
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        browser.Navigate("www.twitter.com")
    End Sub

    Private Sub GoogleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoogleToolStripMenuItem.Click
        addtab(TabControl1)
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        browser.Navigate("https://plus.google.com/")
    End Sub

    Private Sub YahooToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YahooToolStripMenuItem.Click
        addtab(TabControl1)
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        browser.Navigate("https://mail.yahoo.com/")
    End Sub

    Private Sub YoutubeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YoutubeToolStripMenuItem.Click
        addtab(TabControl1)
        Dim browser As Class1 = Me.TabControl1.SelectedTab.Tag
        browser.Navigate("www.youtube.com")
    End Sub

    Private Sub HistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryToolStripMenuItem.Click
        history.Visible = True
    End Sub

    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox1.TextChanged
        ToolStripTextBox1.AutoCompleteCustomSource.Clear()
        For z As Integer = 0 To history.ListBox1.Items.Count - 1
            ToolStripTextBox1.AutoCompleteCustomSource.Add(history.ListBox1.Items(z))
        Next
    End Sub

    Private Sub NewtapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewtapToolStripMenuItem.Click
        addtab(TabControl1)
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseTabToolStripMenuItem.Click
        remove()
    End Sub

    Public Sub addtab(ByRef tabcontrol1 As TabControl)
        Dim browser As New Class1
        Dim tab As New TabPage
        browser.Tag = tab
        tab.Tag = browser
        tabcontrol1.TabPages.Add(tab)
        tab.Controls.Add(browser)
        browser.Dock = DockStyle.Fill
        browser.Navigate("www.google.com")
        tabcontrol1.SelectedTab = tab
    End Sub
    Public Sub remove()
        If TabControl1.TabPages.Count <> 0 Then
            TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim browser As Class1 = TabControl1.SelectedTab.Tag
        Try
            ToolStripTextBox1.Text = browser.Url.ToString
            browser.Navigate(ToolStripTextBox1.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton6_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        addtab(TabControl1)
    End Sub

    Private Sub ToolStripButton7_Click_2(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        remove()
    End Sub

    Private Sub addbook()
        Dim browser As Class1 = TabControl1.SelectedTab.Tag
        Dim newbook As New ToolStripButton
        newbook.Text = TabControl1.SelectedTab.Text
        newbook.Tag = browser.Url
        ToolStrip2.Items.Add(newbook)
        ListBox1.Items.Add(TabControl1.SelectedTab.Text)

        ListBox2.Items.Add(browser.Url.ToString)
        AddHandler newbook.Click, AddressOf newbookd
    End Sub
    Private Sub cb()
        For Each item As ToolStripButton In ToolStrip2.Items
            AddHandler item.Click, AddressOf bookclick
        Next
    End Sub
    Private Sub booknavi()
        Dim browser As Class1 = TabControl1.SelectedTab.Tag
        browser.Navigate(ToolStripTextBox1.Text)
    End Sub
    Private Sub bookclick(ByVal sender As Object, ByVal e As EventArgs)
        ToolStripTextBox1.Text = CType(sender, ToolStripButton).Tag
        booknavi()
    End Sub

    Private Sub SavePageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SavePageToolStripMenuItem.Click
        Dim browser As Class1 = TabControl1.SelectedTab.Tag

        Dim filename As String = InputBox("Enter file name", "Save page as html", ".html")
        Dim path As String = "C:\Users\Public\Documents" & filename
        Try
            If File.Exists(path) Then
                Dim all As String
                all = browser.DocumentText
                File.WriteAllText(path, all)
            Else
                File.Create(path).Dispose()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SelectAllTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllTextToolStripMenuItem.Click
        ToolStripTextBox1.SelectAll()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        ToolStripTextBox1.Paste()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        ToolStripTextBox1.Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        ToolStripTextBox1.Cut()
    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        Dim neww As New Form1
        neww.Show()
    End Sub

    Private Sub newbookd(ByVal sender As Object, ByVal e As EventArgs)
        Dim browser As Class1 = TabControl1.SelectedTab.Tag

        If TypeOf sender Is ToolStripButton Then
            browser.Navigate(CType(sender, ToolStripButton).Tag)
        End If
    End Sub

    Private Sub newbookclick_Click(sender As Object, e As EventArgs) Handles newbookclick.Click
        addbook()
    End Sub

    Private Sub RemoveABookmarkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveABookmarkToolStripMenuItem.Click
        File.Delete("C:\Users\Public\Documents\bookmarks.txt")
        File.Delete("C:\Users\Public\Documents\url.txt")
    End Sub


    Private Sub ChooseYourViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChooseYourViewToolStripMenuItem.Click
        Form2.Show()
    End Sub
End Class