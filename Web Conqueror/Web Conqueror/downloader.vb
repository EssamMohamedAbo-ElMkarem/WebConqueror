Imports System.Net
Public Class downloader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog1.Filter = ".jpg|*.jpg|.exe|*.exe|.zip|*.zip|.rar|*.rar|.png|*.png|.gif|*.gif|.mp4|*.mp4|.iso|*.iso|.mp3|*.mp3|.html|*.html"
        SaveFileDialog1.ShowDialog()
        TextBox2.Text = SaveFileDialog1.FileName
    End Sub
    Public WithEvents download As WebClient
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        download = New WebClient
        download.DownloadFileAsync(New Uri(TextBox1.Text), TextBox2.Text)

    End Sub

    Private Sub download_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles download.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("This programme has been programmed by Essam Mohamed the owner of ST Systems")
    End Sub

    Private Sub downloader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Form1.ToolStripTextBox1.Text
    End Sub
End Class

