Public Class Class1
    Inherits WebBrowser
    Private Sub webbrowsred() Handles Me.DocumentCompleted

        Dim tab As TabPage = Me.Tag

        Form1.ToolStripTextBox1.Text = Me.Url.ToString

        If Me.DocumentTitle.Length > 25 Then
            tab.Text = Me.DocumentTitle.Substring(0, 25)
        Else
            tab.Text = Me.DocumentTitle
        End If
        If Not history.ListBox1.Items.Contains(Form1.ToolStripTextBox1.Text) Then
            history.ListBox1.Items.Add(Form1.ToolStripTextBox1.Text)
        End If
    End Sub

    Public Sub New()
        Me.ScriptErrorsSuppressed = True
    End Sub
End Class
