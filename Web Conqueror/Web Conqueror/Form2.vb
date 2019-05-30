Public Class Form2

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form1.MenuStrip1.BackColor = Color.LightGray
        Form1.FileToolStripMenuItem.ForeColor = Color.Black
        Form1.EditToolStripMenuItem.ForeColor = Color.Black
        Form1.SocialMediaToolStripMenuItem.ForeColor = Color.Black
        Form1.HistoryToolStripMenuItem.ForeColor = Color.Black

        Form1.HelpToolStripMenuItem.ForeColor = Color.Black
        Form1.ToolStrip1.BackColor = Color.LightGray
        downloader.BackColor = Color.White
        downloader.Label1.ForeColor = Color.Black
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form1.MenuStrip1.BackColor = Color.Black
        Form1.FileToolStripMenuItem.ForeColor = Color.White
        Form1.EditToolStripMenuItem.ForeColor = Color.White
        Form1.SocialMediaToolStripMenuItem.ForeColor = Color.White
        Form1.HistoryToolStripMenuItem.ForeColor = Color.White
        Form1.HelpToolStripMenuItem.ForeColor = Color.White
        Form1.ToolStrip1.BackColor = Color.DarkRed
    End Sub
End Class