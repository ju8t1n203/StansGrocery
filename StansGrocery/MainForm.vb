Public Class MainForm
    Private Sub SplashTimer_Tick(sender As Object, e As EventArgs) Handles SplashTimer.Tick
        Me.Show()
        SplashTimer.Enabled = False
        SplashForm.Close()

    End Sub
End Class
