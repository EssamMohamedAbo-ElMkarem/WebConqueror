Imports System.IO

Public Class history

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Visible = False
    End Sub

    Private Sub history_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For Each line As String In ListBox1.Items
            File.AppendAllText("C:\Users\Public\Documents\history.txt", line & vbNewLine)
            e.Cancel = True
            Me.Visible = False
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        File.Delete("C:\Users\Public\Documents\history.txt")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub history_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
